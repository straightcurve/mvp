namespace JiraCloneTest.Forms
{
    partial class AddColumn
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Create = new System.Windows.Forms.Button();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_ScreenName = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Create
            // 
            this.btn_Create.BackColor = System.Drawing.Color.White;
            this.btn_Create.FlatAppearance.BorderSize = 0;
            this.btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Create.Location = new System.Drawing.Point(93, 274);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(179, 40);
            this.btn_Create.TabIndex = 28;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // lbl_Name
            // 
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Name.ForeColor = System.Drawing.Color.White;
            this.lbl_Name.Location = new System.Drawing.Point(10, 167);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(338, 26);
            this.lbl_Name.TabIndex = 23;
            this.lbl_Name.Text = "Name";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Name
            // 
            this.txt_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Name.Font = new System.Drawing.Font("SAO UI", 15.75F);
            this.txt_Name.Location = new System.Drawing.Point(60, 205);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(5, 12, 5, 12);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(238, 33);
            this.txt_Name.TabIndex = 22;
            // 
            // lbl_ScreenName
            // 
            this.lbl_ScreenName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ScreenName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_ScreenName.Font = new System.Drawing.Font("SAO UI", 20F);
            this.lbl_ScreenName.ForeColor = System.Drawing.Color.White;
            this.lbl_ScreenName.Location = new System.Drawing.Point(4, 90);
            this.lbl_ScreenName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ScreenName.Name = "lbl_ScreenName";
            this.lbl_ScreenName.Size = new System.Drawing.Size(344, 33);
            this.lbl_ScreenName.TabIndex = 21;
            this.lbl_ScreenName.Text = "CREATE COLUMN";
            this.lbl_ScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Title.Font = new System.Drawing.Font("SAO UI", 15.75F);
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(10, 52);
            this.lbl_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(338, 26);
            this.lbl_Title.TabIndex = 20;
            this.lbl_Title.Text = "Issue Tracker";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.BackgroundImage = global::JiraCloneTest.Properties.Resources.background_977x550;
            this.ClientSize = new System.Drawing.Size(352, 511);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_ScreenName);
            this.Controls.Add(this.lbl_Title);
            this.Font = new System.Drawing.Font("SAO UI", 15.75F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "AddColumn";
            this.Text = "AddColumn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_ScreenName;
        private System.Windows.Forms.Label lbl_Title;
    }
}