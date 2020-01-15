using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace NotSureHowToCallThisOne
{
    public class PhysicsV2 : IPhysicsEngine
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

        private readonly List<Collision> collisions = new List<Collision>();
        private object syncCollisions = new object();
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
                            otherRigidbody.velocity = otherNewVelocity;
                            tokens.Add(token1);
                            tokens.Add(token2);
                        }

                        rigidbody.velocity = newVelocity;
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
            delta /= 1000;
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                float x, y;
                x = -rigidbodies[i].velocity.X * rigidbodies[i].friction;
                y = -rigidbodies[i].velocity.Y * rigidbodies[i].friction;

                rigidbodies[i].velocity += new Vector2(x, y);
                rigidbodies[i].transform.position += rigidbodies[i].velocity * delta;
            }

            for (int i = 0; i < rigidbodies.Count; i++)
            {
                for (int j = 1; j < rigidbodies.Count; j++)
                {
                    if (rigidbodies[i] == rigidbodies[j])
                        continue;
                    if (rigidbodies[i].isStatic && rigidbodies[j].isStatic)
                        continue;

                    var collided = false;
                    BoxCollider boxa, boxb;
                    CircleCollider circlea, circleb;

                    if (rigidbodies[i].collider.type == ColliderType.Box && rigidbodies[j].collider.type == ColliderType.Box)
                    {
                        boxa = rigidbodies[i].collider as BoxCollider;
                        boxb = rigidbodies[j].collider as BoxCollider;

                        collided = IsCollisionBetween(boxa, boxb);
                        if (collided)
                        {
                            if (rigidbodies[i].collider.isTrigger)
                            {
                                if (rigidbodies[j].collider.isTrigger)
                                    continue;

                                rigidbodies[i].gameObject.InvokeOnTriggerStay(rigidbodies[j].collider);
                            }
                            else if (rigidbodies[j].collider.isTrigger)
                            {
                                rigidbodies[j].gameObject.InvokeOnTriggerStay(rigidbodies[i].collider);
                            }
                            else
                            {
                                ResolveCollisionBasedOnDistanceAndDirection(rigidbodies[i], rigidbodies[j]);
                                rigidbodies[i].gameObject.InvokeOnCollisionStay(rigidbodies[j].collider);
                                rigidbodies[j].gameObject.InvokeOnCollisionStay(rigidbodies[i].collider);
                            }
                        }
                    }
                    else if (rigidbodies[i].collider.type == ColliderType.Circle && rigidbodies[j].collider.type == ColliderType.Circle)
                    {
                        circlea = rigidbodies[i].collider as CircleCollider;
                        circleb = rigidbodies[j].collider as CircleCollider;
                        collided = IsCollisionBetween(circlea, circleb);
                        if (collided)
                        {
                            if (rigidbodies[i].collider.isTrigger)
                            {
                                if (rigidbodies[j].collider.isTrigger)
                                    continue;

                                rigidbodies[i].gameObject.InvokeOnTriggerStay(rigidbodies[j].collider);
                            }
                            else if (rigidbodies[j].collider.isTrigger)
                            {
                                rigidbodies[j].gameObject.InvokeOnTriggerStay(rigidbodies[i].collider);
                            }
                            else
                                ResolveCircleCircleCollision(rigidbodies[i], rigidbodies[j]);
                        }
                    }
                }
            }
        }

        private void ResolveCircleCircleCollision(Rigidbody a, Rigidbody b)
        {

        }

        private void ResolveCollisionBasedOnDistanceAndDirection(Rigidbody a, Rigidbody b)
        {
            ResolveBoxBoxCollision(a, b);
            
            var inverseMassSum = a.inverseMass + b.inverseMass;
            if(!a.isStatic)
            {
                var dxa = a.collider.center.X - b.collider.center.X;
                var dya = a.collider.center.Y - b.collider.center.Y;
                var dira = new Vector2(dxa, dya);
                var lena = dira.Length();
                dira.X /= lena;
                dira.Y /= lena;

                //var velocityFactor = (b.velocity * .01f).Length();
                //velocityFactor = velocityFactor < .1f ? 1 : velocityFactor;
                //a.velocity += dira * b.inverseMass / inverseMassSum;

            }

            if(!b.isStatic)
            {
                var dirb = new Vector2(b.collider.center.X - a.collider.center.X, b.collider.center.Y - a.collider.center.Y);
                var lenb = dirb.Length();
                dirb.X /= lenb;
                dirb.Y /= lenb;

                //var velocityFactor = (a.velocity * .01f).Length();
                //velocityFactor = velocityFactor < .1f ? 1 : velocityFactor;
                //b.velocity += dirb * a.inverseMass / inverseMassSum;
            }
        }

        private void ResolveBoxBoxCollision(Rigidbody a, Rigidbody b)
        {
            //   find out the minimum displacement between x and y
            var dx = Math.Abs(a.collider.center.X - b.collider.center.X);
            var dy = Math.Abs(a.collider.center.Y - b.collider.center.Y);
            a.velocity = new Vector2();
            b.velocity = new Vector2();

            if (dx > dy)
            {
                //  find out if we're to the left or to the right on X
                if (a.collider.center.X < b.collider.center.X)
                {
                    //  left
                    if (!a.isStatic)
                    {
                        var x = (a.collider.center.X - b.collider.center.X + b.collider.halfSize.Width);
                        //a.transform.position.X -= x;
                    }
                    if (!b.isStatic)
                    {
                        var x = (b.collider.center.X - a.collider.center.X + b.collider.halfSize.Width);
                        //b.transform.position.X += x;
                    }
                }
                else
                {
                    //  right
                    if (!a.isStatic)
                    {
                        var x = (a.collider.center.X - b.collider.center.X);
                        //a.transform.position.X -= x;
                    }
                    if (!b.isStatic)
                    {
                        var x = (b.collider.center.X - a.collider.center.X);
                        //b.transform.position.X += x;
                    }
                }
            }
            else
            {
                if (a.collider.center.Y < b.collider.center.Y)
                {
                    //  left
                    if (!a.isStatic)
                    {
                        var y = (a.collider.center.Y - b.collider.center.Y);
                        //a.transform.position.Y = a.transform.position.Y - y;
                    }
                    if (!b.isStatic)
                    {
                        var y = (b.collider.center.Y - a.collider.center.Y);
                        //b.transform.position.Y = b.transform.position.Y + y;
                    }
                }
                else
                {
                    //  right
                    if (!a.isStatic)
                    {
                        var y = (a.collider.center.Y - b.collider.center.Y);
                        //a.transform.position.Y = a.transform.position.Y - y;
                    }
                    if (!b.isStatic)
                    {
                        var y = (b.collider.center.Y - a.collider.center.Y);
                        //b.transform.position.Y = b.transform.position.Y + y;
                    }
                }
            }
        }

        //private void ResolveBoxBoxCollisionOld(ICollider a, ICollider b)
        //{
        //    //   find out the minimum displacement between x and y
        //    var dx = Math.Abs(a.center.X - b.center.X);
        //    var dy = Math.Abs(a.center.Y - b.center.Y);
        //    (Vector2 a, Vector2 b) velocity;
        //    if (dx > dy)
        //    {
        //        //  find out if we're to the left or to the right on X
        //        if (a.center.X < b.center.X)
        //        {
        //            //  left
        //            if (!a.isStatic)
        //            {
        //                var x = (a.center.X + a.halfSize.Width - b.center.X + b.halfSize.Width);
        //                a.gameObject.transform.position.X -= x;
        //            }
        //            if (!b.isStatic)
        //            {
        //                var x = (b.center.X + b.halfSize.Width - a.center.X + a.halfSize.Width);
        //                b.gameObject.transform.position.X += x;
        //            }
        //        }
        //        else
        //        {
        //            //  right
        //            if (!a.isStatic)
        //                a.velocity = new Vector2(a.velocity.X - (a.collider.center.X - a.collider.halfSize.Width - b.collider.center.X - b.collider.halfSize.Width), a.velocity.Y);
        //            if (!b.isStatic)
        //                b.velocity = new Vector2(b.velocity.X + (b.collider.center.X - b.collider.halfSize.Width - a.collider.center.X - a.collider.halfSize.Width), b.velocity.Y);
        //        }
        //    }
        //    else
        //    {
        //        if (a.collider.center.Y < b.collider.center.Y)
        //        {
        //            //  left
        //            if (!a.isStatic)
        //                a.velocity = new Vector2(a.velocity.X, a.velocity.Y - (a.collider.center.Y + a.collider.halfSize.Height - b.collider.center.Y + b.collider.halfSize.Height));
        //            if (!b.isStatic)
        //                b.velocity = new Vector2(b.velocity.X, b.velocity.Y + (b.collider.center.Y + b.collider.halfSize.Height - a.collider.center.Y + a.collider.halfSize.Height));
        //        }
        //        else
        //        {
        //            //  right
        //            if (!a.isStatic)
        //                a.velocity = new Vector2(a.velocity.X, a.velocity.Y - (a.collider.center.Y - a.collider.halfSize.Height - b.collider.center.Y - b.collider.halfSize.Height));
        //            if (!b.isStatic)
        //                b.velocity = new Vector2(b.velocity.X, b.velocity.Y + (b.collider.center.Y - b.collider.halfSize.Height - a.collider.center.Y - a.collider.halfSize.Height));
        //        }
        //    }
        //}

        private void ResolveBoxBoxCollisionOld(Rigidbody a, Rigidbody b)
        {
            //   find out the minimum displacement between x and y
            var dx = Math.Abs(a.collider.center.X - b.collider.center.X);
            var dy = Math.Abs(a.collider.center.Y - b.collider.center.Y);

            if (dx > dy)
            {
                //  find out if we're to the left or to the right on X
                if (a.collider.center.X < b.collider.center.X)
                {
                    //  left
                    if (!a.isStatic)
                    {
                        var wtf = (a.collider.center.X + a.collider.halfSize.Width - b.collider.center.X + b.collider.halfSize.Width);
                        a.velocity = new Vector2(a.velocity.X - wtf, a.velocity.Y);

                    }
                    if (!b.isStatic)
                    {
                        var oof = (b.collider.center.X + b.collider.halfSize.Width - a.collider.center.X + a.collider.halfSize.Width);
                        b.velocity = new Vector2(b.velocity.X + oof, b.velocity.Y);
                    }
                }
                else
                {
                    //  right
                    if (!a.isStatic)
                        a.velocity = new Vector2(a.velocity.X - (a.collider.center.X - a.collider.halfSize.Width - b.collider.center.X - b.collider.halfSize.Width), a.velocity.Y);
                    if(!b.isStatic)
                        b.velocity = new Vector2(b.velocity.X + (b.collider.center.X - b.collider.halfSize.Width - a.collider.center.X - a.collider.halfSize.Width), b.velocity.Y);
                }
            }
            else
            {
                if (a.collider.center.Y < b.collider.center.Y)
                {
                    //  left
                    if (!a.isStatic)
                        a.velocity = new Vector2(a.velocity.X, a.velocity.Y - (a.collider.center.Y + a.collider.halfSize.Height - b.collider.center.Y + b.collider.halfSize.Height));
                    if(!b.isStatic)
                        b.velocity = new Vector2(b.velocity.X, b.velocity.Y + (b.collider.center.Y + b.collider.halfSize.Height - a.collider.center.Y + a.collider.halfSize.Height));
                }
                else
                {
                    //  right
                    if (!a.isStatic)
                        a.velocity = new Vector2(a.velocity.X, a.velocity.Y - (a.collider.center.Y - a.collider.halfSize.Height - b.collider.center.Y - b.collider.halfSize.Height));
                    if(!b.isStatic)
                        b.velocity = new Vector2(b.velocity.X, b.velocity.Y + (b.collider.center.Y - b.collider.halfSize.Height - a.collider.center.Y - a.collider.halfSize.Height));
                }
            }
        }
    }
}