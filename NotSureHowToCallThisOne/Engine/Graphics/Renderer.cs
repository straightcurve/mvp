using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Renderer : IComponent
    {
        public Renderer(GameObject parent, Control canvas)
        {
            this.gameObject = parent;
            this.canvas = canvas;
        }

        public void SetSprite(string id)
        {
            sprite = ResourceLoader.GetImage(id);
        }

        private Size _size;
        public bool enabled { get; set; } = true;
        public Image sprite { get; set; }
        public Size size { get => _size; set { _size = value; halfSize = new Size(_size.Width / 2, _size.Height / 2); } }
        public Size halfSize { get; private set; }
        public GameObject gameObject { get; }

        private Control canvas;

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}
