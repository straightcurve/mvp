using System;
using System.Drawing;
using System.Numerics;

namespace NotSureHowToCallThisOne
{

    public class BoxCollider : IComponent, ICollider
    {

        private Size _size;
        private Transform transform;
        public BoxCollider(GameObject parent)
        {
            this.gameObject = parent;
            this.transform = gameObject.transform;
        }
        public Size size { get => _size; set { _size = value; halfSize = new Size(_size.Width / 2, _size.Height / 2); } }
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
