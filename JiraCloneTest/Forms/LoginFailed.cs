using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraCloneTest
{
    public partial class LoginFailed : Form
    {
        public LoginFailed(string error)
        {
            InitializeComponent();

            lbl_Error.Text = error;
        }

        private void lbl_Error_Click(object sender, EventArgs e)
        {

        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
