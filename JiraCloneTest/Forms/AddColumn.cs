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
    public partial class AddColumn : Form
    {
        private Project project;

        public Column Column { get; private set; } = new Column();

        public AddColumn(Project project)
        {
            InitializeComponent();
            this.project = project;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            Column.Name = txt_Name.Text;

            project.Columns.Add(Column);
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
