namespace JiraCloneTest
{
    partial class ColumnUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Name = new System.Windows.Forms.Label();
            this.btn_Options = new System.Windows.Forms.Button();
            this.pnl_Issues = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_Count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("SAO UI", 14F);
            this.lbl_Name.Location = new System.Drawing.Point(19, 10);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(42, 23);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name";
            // 
            // btn_Options
            // 
            this.btn_Options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btn_Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Options.Font = new System.Drawing.Font("SAO UI", 14F);
            this.btn_Options.Location = new System.Drawing.Point(241, 6);
            this.btn_Options.Name = "btn_Options";
            this.btn_Options.Size = new System.Drawing.Size(93, 31);
            this.btn_Options.TabIndex = 1;
            this.btn_Options.Text = "Options";
            this.btn_Options.UseVisualStyleBackColor = false;
            // 
            // pnl_Issues
            // 
            this.pnl_Issues.AllowDrop = true;
            this.pnl_Issues.AutoScroll = true;
            this.pnl_Issues.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_Issues.Location = new System.Drawing.Point(3, 43);
            this.pnl_Issues.Name = "pnl_Issues";
            this.pnl_Issues.Size = new System.Drawing.Size(331, 374);
            this.pnl_Issues.TabIndex = 2;
            this.pnl_Issues.WrapContents = false;
            this.pnl_Issues.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnl_Issues_DragDrop);
            this.pnl_Issues.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnl_Issues_DragEnter);
            // 
            // lbl_Count
            // 
            this.lbl_Count.AutoSize = true;
            this.lbl_Count.Font = new System.Drawing.Font("SAO UI", 14F);
            this.lbl_Count.Location = new System.Drawing.Point(179, 10);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(46, 23);
            this.lbl_Count.TabIndex = 3;
            this.lbl_Count.Text = "Count";
            // 
            // ColumnUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.Controls.Add(this.lbl_Count);
            this.Controls.Add(this.pnl_Issues);
            this.Controls.Add(this.btn_Options);
            this.Controls.Add(this.lbl_Name);
            this.Font = new System.Drawing.Font("SAO UI", 16F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "ColumnUserControl";
            this.Size = new System.Drawing.Size(337, 420);
            this.Load += new System.EventHandler(this.ColumnUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Button btn_Options;
        private System.Windows.Forms.FlowLayoutPanel pnl_Issues;
        private System.Windows.Forms.Label lbl_Count;
    }
}
