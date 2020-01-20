using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraCloneTest
{
    public partial class IssueUserControl : UserControl
    {
        private Issue issue;

        public event Action<IssueUserControl> Moved;

        public IssueUserControl(Issue issue)
        {
            InitializeComponent();

            this.issue = issue;
        }

        public Issue Issue => issue;

        private void IssueUserControl_Load(object sender, EventArgs e)
        {
            lbl_Summary.Text = issue.Summary;
        }

        private void IssueUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.Move);
        }

        public void TransferTo(FlowLayoutPanel panel)
        {
            panel.Controls.Add(this);
            Moved?.Invoke(this);
        }
    }
}
