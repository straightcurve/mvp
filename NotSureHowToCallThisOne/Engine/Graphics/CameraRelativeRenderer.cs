using System.Drawing;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class CameraRelativeRenderer : IComponent
    {
        public CameraRelativeRenderer(GameObject parent, Form form, Camera camera)
        {
            this.gameObject = parent;
            this.form = form;
            this.camera = camera;
            Box = new PictureBox { Size = new Size(100, 100), };
            form.Controls.Add(Box);
        }

        ~CameraRelativeRenderer()
        {
            form.Controls.Remove(Box);
            Box.Dispose();
        }

        public GameObject gameObject { get; }

        private Form form;
        private Camera camera;

        public PictureBox Box { get; private set; }
        public Color color { get => Box.BackColor; set { Box.BackColor = value; } }

        public void Update()
        {
            var distance = (camera.gameObject.transform.position - gameObject.transform.position);
            Box.Location = new Point((int)(camera.location.X - distance.X), (int)(camera.location.Y - distance.Y));
        }

        public void FixedUpdate()
        {
        }
    }
}
