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
    public partial class ProjectBoard : Form
    {

        private User user;

        public ProjectBoard(User user)
        {
            InitializeComponent();
            this.user = user;

            lbl_Username.Text = user.Username;
        }

        private void ProjectsBoard_Load(object sender, EventArgs e)
        {
            user.Projects.ForEach(project =>
            {
                var lvi = new ListViewItem();
                lvi.SubItems.Add(project.Name);
                lvi.SubItems.Add(project.Key);
                lvi.SubItems.Add(project.Lead);
                lv_Projects.Items.Add(lvi);
            });
        }

        private void lv_Projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_Projects.SelectedIndices.Count == 0)
                return;
            
            var index = lv_Projects.SelectedIndices[0];
            if (index >= user.Projects.Count)
                return;

            //  load issue board form
            using(var issueBoard = new IssueBoard(user.Projects[index]))
            {
                if (issueBoard.ShowDialog() == DialogResult.OK) ;
            }
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbl_Username_Click(object sender, EventArgs e)
        {

        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            using (var createProject = new Forms.AddProject(user))
            {
                if(createProject.ShowDialog() == DialogResult.OK)
                {
                    lv_Projects.Items.Clear();
                    user.Projects.ForEach(project =>
                    {
                        var lvi = new ListViewItem();
                        lvi.SubItems.Add(project.Name);
                        lvi.SubItems.Add(project.Key);
                        lvi.SubItems.Add(project.Lead);
                        lv_Projects.Items.Add(lvi);
                    });

                    DbContext.Save(createProject.Project, user.ID);

                }
            }
        }
    }
}
