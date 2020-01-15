using System;
using System.Drawing;
using System.Numerics;

namespace NotSureHowToCallThisOne
{
    public class Rigidbody : IComponent
    {
        public enum ForceMode
        {
            //  uses mass
            Continuous,
            //  doesnt use mass
            Acceleration,
            //  literally changes the velocity
            VelocityChange,
        }

        public Rigidbody(GameObject parent, ICollider collider)
        {
            this.gameObject = parent;
            this.collider = collider;
            this.transform = gameObject.transform;
            this.mass = 1f;
        }

        private float _mass;
        private bool _isStatic;
        
        public ICollider collider { get; }
        public float friction { get; set; } = .1f;
        public GameObject gameObject { get; }
        public float inverseMass { get; private set; }
        public bool isKinematic { get; set; }
        public bool isStatic { get => _isStatic; set { _isStatic = value; if (_isStatic) mass = 999999; else mass = 1; } }
        public float mass { get => _mass; set { _mass = value; inverseMass = 1 / _mass; } }
        public Transform transform { get; }
        public bool useGravity { get; set; }
        public Vector2 velocity { get; set; }
        public float drag { get; set; } = 10f;

        public void ApplyForce(Vector2 force, ForceMode mode = ForceMode.Continuous) {
            switch (mode)
            {
                case ForceMode.Continuous:
                    this.velocity += (force * mass) * Time.deltaTime;
                    break;
                case ForceMode.Acceleration:
                    this.velocity += (force) * Time.deltaTime;
                    break;
                case ForceMode.VelocityChange:
                    this.velocity = force;
                    break;
                default:
                    break;
            }
        }

        public void ApplyForce(Vector2 direction, float magnitude, ForceMode mode = ForceMode.Continuous)
        {
            var force = direction * magnitude;
            switch (mode)
            {
                case ForceMode.Continuous:
                    this.velocity += (force * mass) * Time.deltaTime;
                    break;
                case ForceMode.Acceleration:
                    this.velocity += (force) * Time.deltaTime;
                    break;
                case ForceMode.VelocityChange:
                    this.velocity = force;
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {

        }

        public override string ToString()
        {
            return $"{velocity}";
        }

        public void FixedUpdate()
        {
        }
    }
}
