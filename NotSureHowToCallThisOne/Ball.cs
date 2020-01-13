using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Ball : IComponent
    {
        public GameObject gameObject { get; }

        public Ball(GameObject parent)
        {
            this.gameObject = parent;
        }
        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
        }
    }
}
