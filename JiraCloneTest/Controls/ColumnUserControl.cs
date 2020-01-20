using System;
using System.Windows.Forms;

namespace JiraCloneTest
{
    public partial class ColumnUserControl : UserControl
    {
        private Column column;

        public ColumnUserControl(Column column)
        {
            InitializeComponent();

            this.column = column;
        }

        private void ColumnUserControl_Load(object sender, EventArgs e)
        {
            lbl_Name.Text = column.Name;

            RefreshIssues();
        }

        private void pnl_Issues_DragDrop(object sender, DragEventArgs e)
        {
            var iuc = e.Data.GetData(typeof(IssueUserControl)) as IssueUserControl;
            if (iuc == null)
                return;

            AddIssue(iuc);
        }

        public void AddIssue(IssueUserControl iuc)
        {
            if (column.Issues.Contains(iuc.Issue))
                return;

            column.Issues.Add(iuc.Issue);
            iuc.TransferTo(pnl_Issues);
            iuc.Moved += OnMoved_Issue;

            UpdateDisplay();
        }

        private void OnMoved_Issue(IssueUserControl iuc)
        {
            column.Issues.Remove(column.Issues.Find(i => i == iuc.Issue));
            pnl_Issues.Controls.Remove(iuc);
            iuc.Moved -= OnMoved_Issue;

            UpdateDisplay();
        }

        private void RefreshIssues()
        {
            pnl_Issues.Controls.Clear();
            column.Issues.ForEach(issue =>
            {
                var iuc = new IssueUserControl(issue);
                iuc.Moved += OnMoved_Issue;
                pnl_Issues.Controls.Add(iuc);
            });
        }

        private void UpdateDisplay()
        {
            lbl_Count.Text = column.Issues.Count.ToString();
        }

        private void pnl_Issues_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(IssueUserControl)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
