namespace JiraCloneTest
{
    partial class IssueUserControl
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
            this.lbl_Summary = new System.Windows.Forms.Label();
            this.btn_Options = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Summary
            // 
            this.lbl_Summary.AutoSize = true;
            this.lbl_Summary.Font = new System.Drawing.Font("SAO UI", 12F);
            this.lbl_Summary.Location = new System.Drawing.Point(19, 11);
            this.lbl_Summary.Name = "lbl_Summary";
            this.lbl_Summary.Size = new System.Drawing.Size(56, 19);
            this.lbl_Summary.TabIndex = 0;
            this.lbl_Summary.Text = "Summary";
            // 
            // btn_Options
            // 
            this.btn_Options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.btn_Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Options.Font = new System.Drawing.Font("SAO UI", 12F);
            this.btn_Options.Location = new System.Drawing.Point(212, 3);
            this.btn_Options.Name = "btn_Options";
            this.btn_Options.Size = new System.Drawing.Size(93, 34);
            this.btn_Options.TabIndex = 2;
            this.btn_Options.Text = "Options";
            this.btn_Options.UseVisualStyleBackColor = false;
            // 
            // IssueUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.Controls.Add(this.btn_Options);
            this.Controls.Add(this.lbl_Summary);
            this.Font = new System.Drawing.Font("SAO UI", 16F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "IssueUserControl";
            this.Size = new System.Drawing.Size(306, 131);
            this.Load += new System.EventHandler(this.IssueUserControl_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IssueUserControl_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Summary;
        private System.Windows.Forms.Button btn_Options;
    }
}
