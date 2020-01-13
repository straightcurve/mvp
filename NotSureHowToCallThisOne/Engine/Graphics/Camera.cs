using System.Drawing;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Camera : IComponent
    {
        public Camera(GameObject parent, Control canvas)
        {
            this.gameObject = parent;
            this.canvas = canvas;

            this.location = new Point(canvas.Width / 2, canvas.Height / 2);
        }

        public GameObject gameObject { get; }

        private Control canvas;

        public Point location { get; }

        public void Update() {
        }

        public void FixedUpdate()
        {
        }
    }
}
