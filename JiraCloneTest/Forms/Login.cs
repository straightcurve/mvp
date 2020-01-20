using JiraCloneTest.Forms;
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
    public partial class Login : AlphaBlendForm
    {
        public enum AuthError {
            None,
            WrongCredentials,
            NonExistent,
        }

        public Login()
        {
            InitializeComponent();

            lbl_Title.BackColor = Color.FromArgb(0, 255, 255, 255);
            //txt_Username.BackColor = Color.FromArgb(0, 255, 255, 255);
            //txt_Password.BackColor = Color.FromArgb(0, 255, 255, 255);
        }

        private (User user, AuthError error) Authenticate(string username, string password)
        {
            User user = DbContext.GetUser(username);
            if (user == null)
                return (null, AuthError.NonExistent);

            var candidate = Encoding.ASCII.GetBytes(password);
            var actual = Encoding.ASCII.GetBytes(user.Password);
            if (candidate.Length != actual.Length)
                return (null, AuthError.WrongCredentials);

            for (int i = 0; i < candidate.Length; i++)
                if (candidate[i] != actual[i])
                    return (null, AuthError.WrongCredentials);

            DbContext.GetUserData(user);

            return (user, AuthError.None);
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            //  send request
            var result = Authenticate(txt_Username.Text, txt_Password.Text);
            switch (result.error)
            {
                case AuthError.None:
                    using (var projectsBoard = new ProjectBoard(result.user))
                    {
                        txt_Username.Text = "";
                        txt_Password.Text = "";
                        if (projectsBoard.ShowDialog() == DialogResult.OK) ;
                    }
                    break;
                case AuthError.WrongCredentials:
                    using (var errorForm = new LoginFailed("Wrong credentials."))
                        if (errorForm.ShowDialog() == DialogResult.OK) ;
                    break;
                case AuthError.NonExistent:
                    using (var errorForm = new LoginFailed("That user does not exist."))
                        if (errorForm.ShowDialog() == DialogResult.OK) ;
                    break;
                default:
                    break;
            }         
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var register = new Register())
            {
                if (register.ShowDialog() == DialogResult.OK)
                {
                    register.Close();
                }
            }
        }
    }
}
