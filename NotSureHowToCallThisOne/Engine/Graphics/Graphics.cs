using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NotSureHowToCallThisOne
{
    public class Graphics {
        private readonly List<Renderer> renderers = new List<Renderer>();
        private Control canvas;

        public Graphics(Control form)
        {
            this.canvas = form;

            form.Paint += Paint;
        }

        public void Add(Renderer renderer)
        {
            if (renderer == null)
                return;

            if (renderers.Contains(renderer))
                return;

            renderers.Add(renderer);
        }

        private void Paint(object sender, PaintEventArgs e) {
            for (int i = 0; i < renderers.Count; i++)
            {
                if (!renderers[i].enabled)
                    continue;

                var position = renderers[i].gameObject.transform.position;
                var halfSize = renderers[i].halfSize;
                var top = new Point((int)position.X - halfSize.Width, (int)position.Y - halfSize.Height);
                var size = renderers[i].size;
                var rect = new Rectangle(top, size);

                try
                {
                    if (renderers[i].sprite == null)
                        e.Graphics.DrawRectangle(new Pen(Color.Black), rect);
                    else
                        e.Graphics.DrawImage(renderers[i].sprite, rect);
                } catch
                {

                }
            }
        }
    }
}

