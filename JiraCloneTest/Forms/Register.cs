using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraCloneTest
{
    public partial class Register : Form
    {
        public enum RegisterError
        {
            None,
            UsernameTaken
        }

        public Register()
        {
            InitializeComponent();
        }

        private RegisterError Register_Request(string username, string password)
        {
            var user = DbContext.GetUser(username);
            if (user != null)
                return RegisterError.UsernameTaken;

            DbContext.Save(new User { Username = username, Password = password });
            return RegisterError.None;
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            var error = Register_Request(txt_Username.Text, txt_Password.Text);
            switch (error)
            {
                case RegisterError.None:
                    using (var login = new Login())
                        if (login.ShowDialog() == DialogResult.OK) ;
                    break;
                case RegisterError.UsernameTaken:
                    using (var errorForm = new LoginFailed("Username taken."))
                        if (errorForm.ShowDialog() == DialogResult.OK) ;
                    break;
                default:
                    break;
            }         
        }
    }
}
