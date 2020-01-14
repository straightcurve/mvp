using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Responsive : IComponent
    {
        public GameObject gameObject { get; }

        private int currentWidth;
        private int currentHeight;

        public Responsive(GameObject parent, Form form, List<GameObject> entities)
        {
            this.currentWidth = form.Width;
            this.currentHeight = form.Height;

            form.Resize += (sender, e) => {

                for (int i = 0; i < entities.Count; i++)
                {
                    if (entities[i].name.Contains("Wall"))
                    {
                        var renderer = entities[i].GetComponent<Renderer>();
                        renderer.size = new Size(form.Width / 16, form.Height / 9);
                        var collider = entities[i].GetComponent<ICollider>();
                        collider.size = renderer.size;
                    }

                    if (entities[i].name.ToLower().Contains("goal"))
                    {
                        var renderer = entities[i].GetComponent<Renderer>();
                        renderer.size = new Size(form.Width / 81, form.Height / 4);
                        var collider = entities[i].GetComponent<ICollider>();
                        collider.size = renderer.size;
                    }

                    if (entities[i].name.ToLower().Contains("player"))
                    {
                        var renderer = entities[i].GetComponent<Renderer>();
                        renderer.size = new Size(form.Width / 16, form.Height / 9);
                        var collider = entities[i].GetComponent<ICollider>();
                        collider.size = renderer.size;
                    }

                    if (entities[i].name.ToLower().Contains("ball"))
                    {
                        var renderer = entities[i].GetComponent<Renderer>();
                        renderer.size = new Size(form.Width / 32, form.Height / 16);
                        var collider = entities[i].GetComponent<ICollider>();
                        collider.size = renderer.size;
                    }

                    entities[i].transform.position = new Vector2(entities[i].transform.position.X * form.Width / this.currentWidth, entities[i].transform.position.Y * form.Height / this.currentHeight);
                }

                this.currentWidth = form.Width;
                this.currentHeight = form.Height;
            };
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}
