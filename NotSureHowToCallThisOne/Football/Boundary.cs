using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Boundary : IComponent
    {
        private ICollider collider;

        public GameObject gameObject { get; }

        private Control canvas;

        public Boundary(GameObject parent, Control canvas)
        {
            this.gameObject = parent;
            this.canvas = canvas;
            this.collider = gameObject.GetComponent<ICollider>();
        }

        public void Update()
        {
            return;
            if (gameObject.transform.position.X > canvas.Width - collider.halfSize.Width) ;
                //gameObject.transform.position.X = canvas.Width - collider.halfSize.Width;
            if (gameObject.transform.position.X < 0) ;
                //gameObject.transform.position.X = 0;
        }

        public void FixedUpdate()
        {
        }
    }
}
