using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            trackbars.Add(tb_Red);
            trackbars.Add(tb_Green);
            trackbars.Add(tb_Blue);
            textboxes.Add(txt_Red);
            textboxes.Add(txt_Green);
            textboxes.Add(txt_Blue);

            trackbars.ForEach(trackbar => {
                trackbar.Minimum = 0;
                trackbar.Maximum = 255;
                trackbar.ValueChanged += SetColor;
                trackbar.ValueChanged += SetColorTextValue;
            });

            textboxes.ForEach(textbox => {
                textbox.TextChanged += SetColorFromTextbox;
                textbox.Text = "0";
            });
        }

        private void SetColorTextValue(object sender, EventArgs e)
        {
            if (textboxes.Count != trackbars.Count)
            {
                lbl_Error.Text = "Trackbars amount doesn't match texboxes amount.";
                return;
            }

            for (int i = 0; i < textboxes.Count; i++)
            {
                textboxes[i].Text = trackbars[i].Value.ToString();
            }
        }

        readonly List<TrackBar> trackbars = new List<TrackBar>();
        readonly List<TextBox> textboxes = new List<TextBox>();
        private void SetColorFromTextbox(object sender, EventArgs e)
        {
            if (textboxes.Count != trackbars.Count)
            {
                lbl_Error.Text = "Trackbars amount doesn't match texboxes amount.";
                return;
            }

            var valid = false;
            for(int i = 0; i < trackbars.Count; i++)
            {
                valid = int.TryParse(textboxes[i].Text, out var value);
                trackbars[i].Value = valid ? System.Math.Min(value, 255) : trackbars[i].Value;
            }
        }

        private void SetColor(object sender, EventArgs e)
        {
            pic_Color.BackColor = Color.FromArgb(
                tb_Red.Value,
                tb_Green.Value,
                tb_Blue.Value
            );
        }
    }
}
