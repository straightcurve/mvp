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
    public partial class IssueBoard : Form
    {

        private Project project;

        public IssueBoard(Project project)
        {
            InitializeComponent();

            this.project = project;
        }

        private void IssueBoard_Load(object sender, EventArgs e)
        {
            project.Columns.ForEach(column => {
                var cuc = new ColumnUserControl(column);
                flowLayoutPanel1.Controls.Add(cuc);
            });
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            using (var createColumn = new Forms.AddColumn(project))
            {
                if (createColumn.ShowDialog() == DialogResult.OK)
                {
                    flowLayoutPanel1.Controls.Clear();
                    project.Columns.ForEach(column => {
                        var cuc = new ColumnUserControl(column);
                        flowLayoutPanel1.Controls.Add(cuc);
                    });

                    DbContext.Save(createColumn.Column, project.ID);
                }
            }
        }
    }
}
