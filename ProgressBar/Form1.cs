using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        private bool run => btn_Interact.Text == "Stop";
        private readonly ManualResetEvent mre;

        public Form1()
        {
            InitializeComponent();

            mre = new ManualResetEvent(false);
            Task.Run(async () =>
            {
                while (true)
                {
                    mre.WaitOne();
                    Invoke((MethodInvoker)(() => pb_Progress.Increment(5)));
                    await Task.Delay(1000);
                }
            });
        }

        private void btn_Interact_Click(object sender, EventArgs e)
        {
            if (run)
            {
                mre.Reset();
                btn_Interact.Text = "Start";
            } else
            {
                mre.Set();
                btn_Interact.Text = "Stop";
            }
        }
    }
}
