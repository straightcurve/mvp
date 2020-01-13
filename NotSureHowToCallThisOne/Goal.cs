using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Goal : IComponent
    {
        public GameObject gameObject { get; }

        public int player { get; }

        public event Action<int> Scored;
        public Goal(GameObject parent, int player)
        {
            this.gameObject = parent;
            this.player = player;
            gameObject.OnTriggerStay += OnTriggerStay;
        }
        private void OnTriggerStay(ICollider other)
        {
            var ball = other.gameObject.GetComponent<Ball>();
            if (ball == null)
                return;

            Scored?.Invoke(player);
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
        }
    }
}
