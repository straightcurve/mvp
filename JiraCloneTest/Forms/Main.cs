using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraCloneTest.Forms
{
    public partial class Main : AlphaBlendForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            using(var login = new Login())
            {
                if (login.ShowDialog() == DialogResult.OK) ;
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            using (var register = new Register())
            {
                if (register.ShowDialog() == DialogResult.OK)
                {
                    register.Close();
                    using(var login = new Login())
                    {
                        if (login.ShowDialog() == DialogResult.OK) ;
                    }
                }
            }
        }
    }
}
