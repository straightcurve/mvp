using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class PlayerHit : IComponent
    {
        private Renderer renderer;
        private int player;
        private Control canvas;
        private Audio audio;

        public GameObject gameObject { get; }

        public PlayerHit(GameObject parent, Renderer renderer, Control canvas, int player, Audio audio)
        {
            this.gameObject = parent;
            gameObject.OnCollisionStay += OnCollision;
            this.renderer = renderer;
            this.player = player;
            this.canvas = canvas;
            this.audio = audio;
        }

        private void OnCollision(ICollider other)
        {
            var wall = other.gameObject.name.Contains("Wall");
            if(wall)
            {
                //  hit
                OnHit();
            }
            else
            {
                var ball = other.gameObject.name.Contains("Ball");
                if(!ball)
                {
                    var player = other.gameObject.GetComponent<Movement>();
                    if (player == null)
                        return;
                    else
                    {
                        //  hit
                        OnHit();
                    }
                } else
                {
                    //  play hit ball sound
                    audio.Play("hit");
                }
            }
        }

        private void OnHit() {
            Task.Run(async () =>
            {
                canvas.Invoke(new MethodInvoker(() => {
                    renderer.SetSprite($"p{player}hit");
                }));
                await Task.Delay(1000);
                canvas.Invoke(new MethodInvoker(() => {
                    renderer.SetSprite($"p{player}");
                }));
            });
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}
