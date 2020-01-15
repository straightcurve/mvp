using System;
using System.Drawing;
using System.Numerics;

namespace NotSureHowToCallThisOne
{

    public class BoxCollider : IComponent, ICollider
    {

        public class Bounds
        {
            private Transform transform;

            public Bounds(Transform transform)
            {
                this.transform = transform;
            }

            private Size _size;
            public Size halfSize { get; private set; }
            public Size size { get { return _size; } set { _size = value; halfSize = new Size(value.Width / 2, value.Height / 2); } }

            public float left => transform.position.X - halfSize.Width;
            public float top => transform.position.Y - halfSize.Height;
            public float right => transform.position.X + halfSize.Width;
            public float bot => transform.position.Y + halfSize.Height;
        }

        private Size _size;
        private Transform transform;

        public Bounds bounds { get; }

        public BoxCollider(GameObject parent)
        {
            this.gameObject = parent;
            this.transform = gameObject.transform;
            this.bounds = new Bounds(transform);
        }
        public Size size { get => _size; set { _size = value; bounds.size = value; halfSize = new Size(_size.Width / 2, _size.Height / 2); } }
        public Size halfSize { get; private set; }
        public Vector2 center { get; set; }
        public GameObject gameObject { get; }
        public bool isStatic { get; set; }
        public bool isTrigger { get; set; }
        public ColliderType type => ColliderType.Box;

        public void Update()
        {
            this.center = transform.position;
        }
        public override string ToString()
        {
            return $"Size: {size}\nCenter: {center}";
        }

        public void FixedUpdate()
        {
        }
    }
}
