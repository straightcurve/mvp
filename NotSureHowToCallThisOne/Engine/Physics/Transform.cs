using System.Drawing;
using System.Numerics;

namespace NotSureHowToCallThisOne
{
    public class Transform : IComponent
    {
        private Vector2 _position;
        //public Vector2 position { get { lock (gameObject.SyncRoot) return _position; } set { lock (gameObject.SyncRoot) _position = value; } }
        public Vector2 position;
        public GameObject gameObject { get; }

        public Transform(GameObject parent)
        {
            this.gameObject = parent;
        }

        public void FixedUpdate()
        {
        }

        public void Update() {
        }
    }
}
