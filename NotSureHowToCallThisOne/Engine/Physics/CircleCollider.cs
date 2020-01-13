using System.Drawing;
using System.Numerics;

namespace NotSureHowToCallThisOne
{
    public class CircleCollider : IComponent, ICollider
    {
        public CircleCollider(GameObject parent)
        {
            this.gameObject = parent;
            this.transform = gameObject.transform;
        }

        private Transform transform;
        private Size _size;
        public Vector2 center { get; set; }
        public GameObject gameObject { get; }
        public Size halfSize { get; private set; }
        public bool isStatic { get; set; }
        public bool isTrigger { get; set; }
        public Size size { get => _size; set { _size = value; halfSize = new Size(_size.Width / 2, _size.Height / 2); } }
        public ColliderType type => ColliderType.Circle;


        public void Update()
        {
            this.center = transform.position;
        }
        public override string ToString()
        {
            return $"Diameter: {size}\nRadius: {halfSize}\nCenter: {center}";
        }
        public void FixedUpdate()
        {
        }
    }
}
