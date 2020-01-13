using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class AreaOfInterest : IComponent
    {
        public GameObject gameObject { get; }

        private Physics physics;
        private BoxCollider cameraCollider;
        private BoxCollider collider;
        private Renderer renderable;

        public AreaOfInterest(GameObject parent, Physics physics, BoxCollider collider, BoxCollider cameraCollider, Renderer renderable)
        {
            this.gameObject = parent;
            this.physics = physics;
            this.cameraCollider = cameraCollider;
            this.collider = collider;
            this.renderable = renderable;
        }

        public void Update()
        {
            //renderable.Box.Visible = physics.IsCollisionBetween(collider, cameraCollider);
        }

        public void FixedUpdate()
        {
        }
    }
}
