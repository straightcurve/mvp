using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraCloneTest.Forms
{
    public partial class AddProject : Form
    {
        private User user;

        public Project Project { get; private set; } = new Project();

        public AddProject(User user)
        {
            InitializeComponent();
            this.user = user;

            txt_Lead.Text = user.Username;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            Project.Name = txt_Name.Text;
            Project.Key = txt_Key.Text;
            Project.Lead = user.Username;

            user.Projects.Add(Project);
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
