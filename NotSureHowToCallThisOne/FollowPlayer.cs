using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class FollowPlayer : IComponent
    {
        public GameObject gameObject { get; }

        private GameObject target;

        public FollowPlayer(GameObject parent, GameObject target)
        {
            this.gameObject = parent;
            this.target = target;
        }

        public void Update()
        {
            gameObject.transform.position = target.transform.position;
        }

        public void FixedUpdate()
        {
        }
    }
}
