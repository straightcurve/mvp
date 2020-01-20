namespace JiraCloneTest
{
    partial class Register
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
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.btn_Register = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_ScreenName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Username
            // 
            this.txt_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Username.Location = new System.Drawing.Point(97, 202);
            this.txt_Username.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(179, 33);
            this.txt_Username.TabIndex = 0;
            // 
            // txt_Password
            // 
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.Location = new System.Drawing.Point(97, 241);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(179, 33);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // btn_Register
            // 
            this.btn_Register.BackColor = System.Drawing.Color.White;
            this.btn_Register.FlatAppearance.BorderSize = 0;
            this.btn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Register.Location = new System.Drawing.Point(97, 316);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(179, 40);
            this.btn_Register.TabIndex = 6;
            this.btn_Register.Text = "Sign up";
            this.btn_Register.UseVisualStyleBackColor = false;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Title.Location = new System.Drawing.Point(18, 79);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(338, 26);
            this.lbl_Title.TabIndex = 7;
            this.lbl_Title.Text = "Issue Tracker";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ScreenName
            // 
            this.lbl_ScreenName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ScreenName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_ScreenName.Font = new System.Drawing.Font("SAO UI", 20F);
            this.lbl_ScreenName.Location = new System.Drawing.Point(12, 117);
            this.lbl_ScreenName.Name = "lbl_ScreenName";
            this.lbl_ScreenName.Size = new System.Drawing.Size(344, 33);
            this.lbl_ScreenName.TabIndex = 8;
            this.lbl_ScreenName.Text = "USER REGISTRATION";
            this.lbl_ScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.BackgroundImage = global::JiraCloneTest.Properties.Resources.background_977x550;
            this.ClientSize = new System.Drawing.Size(368, 550);
            this.Controls.Add(this.lbl_ScreenName);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.btn_Register);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Username);
            this.Font = new System.Drawing.Font("SAO UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(97, 316);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_ScreenName;
    }
}

