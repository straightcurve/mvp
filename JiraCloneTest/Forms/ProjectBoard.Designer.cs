namespace JiraCloneTest
{
    partial class ProjectBoard
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
            this.lv_Projects = new System.Windows.Forms.ListView();
            this.col_Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Lead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.btn_Create = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_Projects
            // 
            this.lv_Projects.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_Projects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_Projects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_Index,
            this.col_Name,
            this.col_Key,
            this.col_Lead});
            this.lv_Projects.FullRowSelect = true;
            this.lv_Projects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_Projects.HideSelection = false;
            this.lv_Projects.LabelWrap = false;
            this.lv_Projects.Location = new System.Drawing.Point(244, 73);
            this.lv_Projects.MultiSelect = false;
            this.lv_Projects.Name = "lv_Projects";
            this.lv_Projects.Scrollable = false;
            this.lv_Projects.Size = new System.Drawing.Size(721, 465);
            this.lv_Projects.TabIndex = 0;
            this.lv_Projects.UseCompatibleStateImageBehavior = false;
            this.lv_Projects.View = System.Windows.Forms.View.Details;
            this.lv_Projects.SelectedIndexChanged += new System.EventHandler(this.lv_Projects_SelectedIndexChanged);
            // 
            // col_Index
            // 
            this.col_Index.Text = "";
            this.col_Index.Width = 0;
            // 
            // col_Name
            // 
            this.col_Name.Text = "Name";
            this.col_Name.Width = 233;
            // 
            // col_Key
            // 
            this.col_Key.Text = "Key";
            this.col_Key.Width = 233;
            // 
            // col_Lead
            // 
            this.col_Lead.Text = "Lead";
            this.col_Lead.Width = 233;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.btn_Logout);
            this.panel1.Controls.Add(this.lbl_Username);
            this.panel1.Controls.Add(this.lbl_Title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 550);
            this.panel1.TabIndex = 1;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Location = new System.Drawing.Point(70, 21);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(99, 26);
            this.lbl_Title.TabIndex = 2;
            this.lbl_Title.Text = "Issue Tracker";
            // 
            // lbl_Username
            // 
            this.lbl_Username.Location = new System.Drawing.Point(3, 60);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(232, 26);
            this.lbl_Username.TabIndex = 3;
            this.lbl_Username.Text = "Username";
            this.lbl_Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Username.Click += new System.EventHandler(this.lbl_Username_Click);
            // 
            // btn_Logout
            // 
            this.btn_Logout.BackColor = System.Drawing.Color.White;
            this.btn_Logout.FlatAppearance.BorderSize = 0;
            this.btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Logout.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_Logout.Location = new System.Drawing.Point(31, 498);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(179, 40);
            this.btn_Logout.TabIndex = 5;
            this.btn_Logout.Text = "Log out";
            this.btn_Logout.UseVisualStyleBackColor = false;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // btn_Create
            // 
            this.btn_Create.BackColor = System.Drawing.Color.White;
            this.btn_Create.FlatAppearance.BorderSize = 0;
            this.btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Create.Location = new System.Drawing.Point(786, 14);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(179, 40);
            this.btn_Create.TabIndex = 20;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // ProjectBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(977, 550);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lv_Projects);
            this.Font = new System.Drawing.Font("SAO UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "ProjectBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ProjectsBoard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_Projects;
        private System.Windows.Forms.ColumnHeader col_Name;
        private System.Windows.Forms.ColumnHeader col_Key;
        private System.Windows.Forms.ColumnHeader col_Lead;
        private System.Windows.Forms.ColumnHeader col_Index;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.Button btn_Create;
    }
}