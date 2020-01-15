using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using static NotSureHowToCallThisOne.BoxCollider;
using static NotSureHowToCallThisOne.PhysicsV2;

namespace NotSureHowToCallThisOne
{
    public class PhysicsV3 : IPhysicsEngine
    {
        private readonly List<ICollider> colliders = new List<ICollider>();
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

        public class Contact
        {
            public Contact(Rigidbody a, Rigidbody b)
            {
                var abox = ((BoxCollider)a.collider);
                var bbox = ((BoxCollider)b.collider);

                Action act = null;
                float left, top, right, bot, min = float.MinValue;
                left = bbox.bounds.left - abox.bounds.right;
                top = bbox.bounds.top - abox.bounds.bot;
                right = abox.bounds.left - bbox.bounds.right;
                bot = abox.bounds.top - bbox.bounds.bot;

                if (left > min)
                {
                    min = left;
                    act = () =>
                    {
                        //  a is to the left of b
                        m_normal = new Vector2(-1, 0);
                        m_dist = left;
                    };
                }

                if (top > min)
                {
                    min = top;
                    act = () =>
                    {
                        //  a is above b
                        m_normal = new Vector2(0, -1);
                        m_dist = top;
                    };
                }

                if (right > min)
                {
                    min = right;
                    act = () =>
                    {
                        //  a is to the right of b
                        m_normal = new Vector2(1, 0);
                        m_dist = right;
                    };
                }

                if (bot > min)
                {
                    min = bot;
                    act = () =>
                    {
                        //  a is under b
                        m_normal = new Vector2(0, 1);
                        m_dist = bot;
                    };
                }

                this.a = a;
                this.b = b;
                this.aCollider = a.collider;
                this.bCollider = b.collider;
                m_dist = Math.Abs(m_dist);

                act?.Invoke();
            }

            public Contact(Rigidbody a, ICollider b)
            {
                var abox = ((BoxCollider)a.collider);
                var bbox = ((BoxCollider)b);

                Action act = null;
                float left, top, right, bot, min = float.MinValue;
                left = bbox.bounds.left - abox.bounds.right;
                top = bbox.bounds.top - abox.bounds.bot;
                right = abox.bounds.left - bbox.bounds.right;
                bot = abox.bounds.top - bbox.bounds.bot;

                if (left > min)
                {
                    min = left;
                    act = () =>
                    {
                        //  a is to the left of b
                        m_normal = new Vector2(-1, 0);
                        m_dist = left;
                    };
                }

                if (top > min)
                {
                    min = top;
                    act = () =>
                    {
                        //  a is above b
                        m_normal = new Vector2(0, -1);
                        m_dist = top;
                    };
                }

                if (right > min)
                {
                    min = right;
                    act = () =>
                    {
                        //  a is to the right of b
                        m_normal = new Vector2(1, 0);
                        m_dist = right;
                    };
                }

                if (bot > min)
                {
                    min = bot;
                    act = () =>
                    {
                        //  a is under b
                        m_normal = new Vector2(0, 1);
                        m_dist = bot;
                    };
                }

                this.a = a;
                this.b = null;
                this.aCollider = a.collider;
                this.bCollider = b;
                //m_dist = Math.Abs(m_dist);

                act?.Invoke();
            }

            public Vector2 m_normal;
            public float m_dist;
            public double m_impulse;
            public bool isTrigger;
            public ICollider bCollider;
            public ICollider aCollider;

            public Rigidbody a { get; }
            public Rigidbody b { get; }
        }

        private List<Contact> contacts = new List<Contact>();
        private Dictionary<string, Contact> zz = new Dictionary<string, Contact>();
        public void Simulate(float delta)
        {
            bool Collide(BoxCollider a, BoxCollider b)
            {
                // 1. Is the left edge of this BoundingBox less than the right edge of the other BoundingBox
                // 2. Is the right edge of this BoundingBox greater than the left edge of the other BoundingBox
                // 3. Is the top edge of this BoundingBox less than the bottom edge of the other BoundingBox
                // 4. Is the bottom edge of this BoundingBox greater than the top edge of the other BoundingBox
                return
                    a.bounds.left < b.bounds.right &&
                    a.bounds.right > b.bounds.left &&
                    a.bounds.top < b.bounds.bot &&
                    a.bounds.bot > b.bounds.top;
            }

            for (int r = 0; r < rigidbodies.Count; r++)
            {
                for (int c = 0; c < colliders.Count; c++)
                {
                    if (rigidbodies[r].collider == colliders[c])
                        continue;

                    var rname = rigidbodies[r].gameObject.name;
                    var cname = colliders[c].gameObject.name;
                    if (zz.ContainsKey($"{rname}_{cname}") || zz.ContainsKey($"{cname}_{rname}"))
                        continue;

                    var collided = Collide((BoxCollider)rigidbodies[r].collider, (BoxCollider)colliders[c]);
                    if(collided)
                    {
                        var otherRb = rigidbodyColliders.ContainsKey(colliders[c]) ? rigidbodyColliders[colliders[c]] : null;
                        Contact contact;
                        if(otherRb == null)
                            contact = new Contact(rigidbodies[r], colliders[c]);
                        else
                            contact = new Contact(rigidbodies[r], otherRb);
                        
                        //  check if trigger
                        if (colliders[c].isTrigger)
                            contact.isTrigger = true;

                        contacts.Add(contact);
                        zz.Add($"{rname}_{cname}", contact);
                        zz.Add($"{cname}_{rname}", contact);
                    }
                }
            }

            for (int c = 0; c < contacts.Count; c++)
            {
                Contact con = contacts[c];
                if (con.isTrigger)
                    continue;

                Vector2 n = con.m_normal;

                // get all of relative normal velocity
                Vector2 conAVel, conBVel;
                float conAInvMass, conBInvMass;
                float conAMass, conBMass;

                if (con.a == null)
                {
                    conAVel = new Vector2();
                    conAInvMass = 0;
                    conAMass = 0;
                } else
                {
                    conAVel = con.a.velocity;
                    conAInvMass = con.a.inverseMass;
                    conAMass = con.a.mass;
                }

                if (con.b == null)
                {
                    conBVel = new Vector2();
                    conBInvMass = 0;
                    conBMass = 0;
                }
                else
                {
                    conBVel = con.b.velocity;
                    conBInvMass = con.b.inverseMass;
                    conBMass = con.b.mass;
                }

                double relNv = Vector2.Dot((conBVel - conAVel), n);

                // we want to remove only the amount which leaves them touching next frame
                double remove = relNv + con.m_dist / (Time.fixedDeltaTime);
                if(remove >= 0)
                    continue;

                // compute impulse
                double imp = remove / (conAInvMass + conBInvMass);

                // accumulate
                double newImpulse = Math.Min(imp + con.m_impulse, 0);

                // compute change
                double change = newImpulse - con.m_impulse;

                // store accumulated impulse
                con.m_impulse = newImpulse;

                // apply impulse
                var xda = (float)change * n * conAInvMass;
                var xdb = (float)change * n * conBInvMass;

                if (con.a != null)
                    con.a.velocity -= xda;

                if(con.b != null)
                    con.b.velocity += xdb;
            }

            for (int r = 0; r < rigidbodies.Count; r++)
            {
                rigidbodies[r].velocity *= (1 - Time.fixedDeltaTime * rigidbodies[r].drag);
                rigidbodies[r].transform.position += rigidbodies[r].velocity * delta;
            }

            //  trigger events
            for (int c = 0; c < contacts.Count; c++)
            {
                if (contacts[c].isTrigger)
                {
                    contacts[c].aCollider.gameObject.InvokeOnTriggerStay(contacts[c].bCollider);
                    contacts[c].bCollider.gameObject.InvokeOnTriggerStay(contacts[c].aCollider);
                }
                else
                {
                    contacts[c].aCollider.gameObject.InvokeOnCollisionStay(contacts[c].bCollider);
                    contacts[c].bCollider.gameObject.InvokeOnCollisionStay(contacts[c].aCollider);
                }
            }

            contacts.Clear();
            zz.Clear();
        }
    }
}