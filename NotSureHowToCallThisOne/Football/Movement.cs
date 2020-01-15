using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Movement : IComponent
    {
        public GameObject gameObject { get; }

        public Keys up { get; set; } = Keys.Up;
        public Keys down { get; set; } = Keys.Down;
        public Keys left { get; set; } = Keys.Left;
        public Keys right { get; set; } = Keys.Right;

        private Input input;
        private Rigidbody rigidbody;

        public Movement(GameObject parent, Input input, Rigidbody rigidbody)
        {
            this.gameObject = parent;
            this.input = input;
            this.rigidbody = rigidbody;
        }

        public float speed = 100f;
        private Vector2 inputData;

        public void Update()
        {
            var x = input.IsPressed(left) ? -1 : input.IsPressed(right) ? 1 : 0;
            var y = input.IsPressed(down) ? 1 : input.IsPressed(up) ? -1 : 0;

            this.inputData = new Vector2(x, y);
        }

        public void FixedUpdate()
        {
            rigidbody.ApplyForce(inputData, speed, Rigidbody.ForceMode.Continuous);
        }
    }
}
