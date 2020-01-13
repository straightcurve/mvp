namespace NotSureHowToCallThisOne
{
    partial class Form1
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
            this.doubleBufferedPanel1 = new NotSureHowToCallThisOne.DoubleBufferedPanel();
            this.lbl_Input = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.lbl_Score = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_NewVelocity = new System.Windows.Forms.Label();
            this.lbl_OtherNewVelocity = new System.Windows.Forms.Label();
            this.doubleBufferedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.Controls.Add(this.lbl_OtherNewVelocity);
            this.doubleBufferedPanel1.Controls.Add(this.lbl_NewVelocity);
            this.doubleBufferedPanel1.Controls.Add(this.lbl_Input);
            this.doubleBufferedPanel1.Controls.Add(this.btn_Back);
            this.doubleBufferedPanel1.Controls.Add(this.lbl_Score);
            this.doubleBufferedPanel1.Controls.Add(this.pictureBox1);
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(8, 12);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(1244, 614);
            this.doubleBufferedPanel1.TabIndex = 12;
            // 
            // lbl_Input
            // 
            this.lbl_Input.AutoSize = true;
            this.lbl_Input.Location = new System.Drawing.Point(1058, 24);
            this.lbl_Input.Name = "lbl_Input";
            this.lbl_Input.Size = new System.Drawing.Size(30, 13);
            this.lbl_Input.TabIndex = 3;
            this.lbl_Input.Text = "Keys";
            // 
            // btn_Back
            // 
            this.btn_Back.Enabled = false;
            this.btn_Back.Location = new System.Drawing.Point(157, 14);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 10;
            this.btn_Back.TabStop = false;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            // 
            // lbl_Score
            // 
            this.lbl_Score.AutoSize = true;
            this.lbl_Score.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_Score.ForeColor = System.Drawing.Color.Black;
            this.lbl_Score.Location = new System.Drawing.Point(22, 15);
            this.lbl_Score.Name = "lbl_Score";
            this.lbl_Score.Size = new System.Drawing.Size(69, 26);
            this.lbl_Score.TabIndex = 11;
            this.lbl_Score.Text = "Score";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NotSureHowToCallThisOne.Properties.Resources.player2_hit;
            this.pictureBox1.Location = new System.Drawing.Point(248, 215);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbl_NewVelocity
            // 
            this.lbl_NewVelocity.AutoSize = true;
            this.lbl_NewVelocity.Location = new System.Drawing.Point(154, 78);
            this.lbl_NewVelocity.Name = "lbl_NewVelocity";
            this.lbl_NewVelocity.Size = new System.Drawing.Size(35, 13);
            this.lbl_NewVelocity.TabIndex = 12;
            this.lbl_NewVelocity.Text = "label1";
            // 
            // lbl_OtherNewVelocity
            // 
            this.lbl_OtherNewVelocity.AutoSize = true;
            this.lbl_OtherNewVelocity.Location = new System.Drawing.Point(593, 78);
            this.lbl_OtherNewVelocity.Name = "lbl_OtherNewVelocity";
            this.lbl_OtherNewVelocity.Size = new System.Drawing.Size(35, 13);
            this.lbl_OtherNewVelocity.TabIndex = 13;
            this.lbl_OtherNewVelocity.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.doubleBufferedPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.doubleBufferedPanel1.ResumeLayout(false);
            this.doubleBufferedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_Input;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label lbl_Score;
        private DoubleBufferedPanel doubleBufferedPanel1;
        private System.Windows.Forms.Label lbl_OtherNewVelocity;
        private System.Windows.Forms.Label lbl_NewVelocity;
    }
}

