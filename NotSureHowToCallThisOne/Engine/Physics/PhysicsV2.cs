using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace NotSureHowToCallThisOne
{
    public class PhysicsV3 : ISystem
    {
        private object syncColliders = new object();
        private readonly List<ICollider> colliders = new List<ICollider>();

        private object syncRigidbodies = new object();
        private readonly List<Rigidbody> rigidbodies = new List<Rigidbody>();

        private readonly Dictionary<ICollider, Rigidbody> rigidbodyColliders = new Dictionary<ICollider, Rigidbody>();

        public void Add(ICollider collider)
        {
            if (collider == null)
                return;
            if (colliders.Contains(collider))
                return;

            colliders.Add(collider);
        }

        public bool Add(GameObject gameObject)
        {
            var collider = gameObject.GetComponent<ICollider>();
            if (collider == null)
                return false;

            Add(collider);

            return true;
        }

        public void AddRigidbody(Rigidbody rigidbody)
        {
            Add(rigidbody.collider);
            rigidbodyColliders.Add(rigidbody.collider, rigidbody);
            rigidbodies.Add(rigidbody);
        }

        public bool IsCollisionBetween(ICollider a, ICollider b)
        {
            var x = Math.Abs(a.center.X - b.center.X) <= a.halfSize.Width + b.halfSize.Width;
            var y = Math.Abs(a.center.Y - b.center.Y) <= a.halfSize.Height + b.halfSize.Height;

            return x && y;
        }

        public class Collision
        {
            public Collision(ICollider a, ICollider b)
            {
                this.a = a;
                this.b = b;

                Enter();
            }

            public ICollider a { get; }
            public ICollider b { get; }

            public void Enter()
            {
                if (a.isTrigger)
                    a.gameObject.InvokeOnTriggerEnter(b);
                else
                    a.gameObject.InvokeOnCollisionEnter(b);
            }

            public void Exit()
            {

            }

            const float collisionThreshold = 50f;

            public Vector2 Solve()
            {
                //  a should move
                //  where is a in relation to b?
                var dx = a.center.X - b.center.X;
                if(dx > 0)
                {
                    //  a is to the right of b on x
                    //  are we under or above or away from b?
                    var xCalc = Math.Abs(b.center.X + b.halfSize.Width + a.halfSize.Width - a.center.X);
                    var away = xCalc < collisionThreshold;
                    var under = !away && b.center.Y < a.center.Y;
                    var above = !away && !under;
                    if(away)
                    {
                        //  place on right side
                        return new Vector2(1, 0);
                    } else if(under)
                    {
                        //  place on bottom side
                        return new Vector2(0, 1);
                    } else if(above)
                    {
                        //  place on top side
                        return new Vector2(0, -1);
                    }
                    else
                    {
                        //  WTF?!
                        return new Vector2(0, 0);
                    }
                } else
                {
                    //  a is to the left of b on x
                    //  are we under or above or away from b?
                    var xCalc = Math.Abs(b.center.X - b.halfSize.Width - a.halfSize.Width - a.center.X);
                    var away = xCalc < collisionThreshold;
                    var under = !away && (b.center.Y + b.halfSize.Height < a.center.Y);
                    var above = !away && !under;
                    if (away)
                    {
                        //  place on left side
                        return new Vector2(-1, 0);
                    }
                    else if (under)
                    {
                        //  place on bottom side
                        return new Vector2(0, 1);
                    }
                    else if (above)
                    {
                        //  place on top side
                        return new Vector2(0, -1);
                    }
                    else
                    {
                        //  WTF?!
                        return new Vector2(0, 0);
                    }
                }
            }
        }

        private readonly List<string> tokens = new List<string>();

        public void Simulate(float delta)
        {
            delta /= 1000;
            tokens.Clear();
            //  compute collision data
            lock(syncColliders)
            {
                for (int i = 0; i < colliders.Count; i++)
                {
                    for (int j = 0; j < colliders.Count; j++)
                    {
                        if (colliders[i] == colliders[j])
                            continue;

                        if (colliders[i].isStatic)
                            continue;

                        if (colliders[i].isTrigger && colliders[j].isTrigger)
                            continue;

                        if (!IsCollisionBetween(colliders[i], colliders[j]))
                            continue;

                        var collision = new Collision(colliders[i], colliders[j]);
                        var direction = collision.Solve();

                        if (!rigidbodyColliders.ContainsKey(colliders[i]))
                            return;

                        var rigidbody = rigidbodyColliders[colliders[i]];
                        Vector2 newVelocity = new Vector2();

                        if (rigidbody.isKinematic || !rigidbodyColliders.ContainsKey(colliders[j]))
                        {
                            if (direction.X == 0)
                            {
                                newVelocity.X = rigidbody.velocity.X;
                                newVelocity.Y = -rigidbody.velocity.Y;
                            }
                            else if (direction.Y == 0)
                            {
                                newVelocity.Y = rigidbody.velocity.Y;
                                newVelocity.X = -rigidbody.velocity.X;
                            }
                        }
                        else
                        {
                            var otherRigidbody = rigidbodyColliders[colliders[j]];
                            var token1 = $"{rigidbody.gameObject.name}_{otherRigidbody.gameObject.name}";
                            var token2 = $"{otherRigidbody.gameObject.name}_{rigidbody.gameObject.name}";
                            if (tokens.Contains(token1) || tokens.Contains("token2"))
                                continue;

                            //var inverseSum = rigidbody.inverseMass + otherRigidbody.inverseMass;
                            //var otherVelocityDirection = (otherRigidbody.transform.position - rigidbody.transform.position);
                            //var otherVelocityMagnitude = otherVelocityDirection.Length();
                            //otherVelocityDirection.X /= otherVelocityMagnitude;
                            //otherVelocityDirection.Y /= otherVelocityMagnitude;
                            //otherVelocityMagnitude = 100 * otherRigidbody.inverseMass / inverseSum;
                            //otherRigidbody.velocity = otherVelocityDirection * otherVelocityMagnitude;

                            //var velocityDirection = rigidbody.transform.position - otherRigidbody.transform.position;
                            //var velocityMagnitude = velocityDirection.Length();
                            //velocityDirection.X /= velocityMagnitude;
                            //velocityDirection.Y /= velocityMagnitude;
                            //velocityMagnitude = 100;// * otherRigidbody.inverseMass / inverseSum;
                            //newVelocity = velocityDirection * velocityMagnitude;
                            var cachedVelocity = rigidbody.velocity;
                            var cachedOtherVelocity = otherRigidbody.velocity;
                            newVelocity = ((rigidbody.mass - otherRigidbody.mass) / (rigidbody.mass + otherRigidbody.mass)) * cachedVelocity + ((2 * otherRigidbody.mass) / (rigidbody.mass + otherRigidbody.mass)) * cachedOtherVelocity;
                            var otherNewVelocity = ((2 * rigidbody.mass) / (rigidbody.mass + otherRigidbody.mass)) * cachedVelocity + ((otherRigidbody.mass - rigidbody.mass) / (rigidbody.mass + otherRigidbody.mass)) * cachedOtherVelocity;
                            if(rigidbody.gameObject.name.ToLower().Contains("player"))
                                Form1.NewVelocity = $"Name: {rigidbody.gameObject.name}\nVelocity: {newVelocity}";
                            if(rigidbody.gameObject.name.ToLower().Contains("ball"))
                                Form1.OtherNewVelocity = $"Name: {rigidbody.gameObject.name}\nVelocity: {otherNewVelocity}";
                            otherRigidbody.velocity = otherNewVelocity;
                            tokens.Add(token1);
                            tokens.Add(token2);
                        }

                        rigidbody.velocity = newVelocity;

                        


                        //otherRigidbody.velocity = otherNewVelocity;
                        //lock(syncCollisions)
                        //{
                        //    collisions.Add(collision);
                        //}
                    }
                }
            }

            //  apply forces
            lock(syncRigidbodies)
            {
                for (int i = 0; i < rigidbodies.Count; i++)
                {
                    var friction = -rigidbodies[i].velocity * rigidbodies[i].friction;
                    if(rigidbodies[i].useGravity)
                        friction.Y -= 10f * delta;
                    rigidbodies[i].velocity += friction;
                    rigidbodies[i].transform.position += rigidbodies[i].velocity * delta;
                }
            }
        }

        public void Update(float delta)
        {
        }
    }
}