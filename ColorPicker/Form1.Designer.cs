namespace ColorPicker
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
            this.tb_Red = new System.Windows.Forms.TrackBar();
            this.txt_Red = new System.Windows.Forms.TextBox();
            this.txt_Green = new System.Windows.Forms.TextBox();
            this.tb_Green = new System.Windows.Forms.TrackBar();
            this.txt_Blue = new System.Windows.Forms.TextBox();
            this.tb_Blue = new System.Windows.Forms.TrackBar();
            this.pic_Color = new System.Windows.Forms.PictureBox();
            this.lbl_Error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Color)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Red
            // 
            this.tb_Red.AutoSize = false;
            this.tb_Red.BackColor = System.Drawing.Color.Red;
            this.tb_Red.Location = new System.Drawing.Point(41, 47);
            this.tb_Red.Name = "tb_Red";
            this.tb_Red.Size = new System.Drawing.Size(257, 35);
            this.tb_Red.TabIndex = 0;
            // 
            // txt_Red
            // 
            this.txt_Red.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Red.Location = new System.Drawing.Point(304, 47);
            this.txt_Red.Name = "txt_Red";
            this.txt_Red.Size = new System.Drawing.Size(45, 37);
            this.txt_Red.TabIndex = 1;
            // 
            // txt_Green
            // 
            this.txt_Green.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Green.Location = new System.Drawing.Point(304, 88);
            this.txt_Green.Name = "txt_Green";
            this.txt_Green.Size = new System.Drawing.Size(45, 37);
            this.txt_Green.TabIndex = 3;
            // 
            // tb_Green
            // 
            this.tb_Green.AutoSize = false;
            this.tb_Green.BackColor = System.Drawing.Color.Green;
            this.tb_Green.Location = new System.Drawing.Point(41, 88);
            this.tb_Green.Name = "tb_Green";
            this.tb_Green.Size = new System.Drawing.Size(257, 35);
            this.tb_Green.TabIndex = 2;
            // 
            // txt_Blue
            // 
            this.txt_Blue.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Blue.Location = new System.Drawing.Point(304, 129);
            this.txt_Blue.Name = "txt_Blue";
            this.txt_Blue.Size = new System.Drawing.Size(45, 37);
            this.txt_Blue.TabIndex = 5;
            // 
            // tb_Blue
            // 
            this.tb_Blue.AutoSize = false;
            this.tb_Blue.BackColor = System.Drawing.Color.Blue;
            this.tb_Blue.Location = new System.Drawing.Point(41, 129);
            this.tb_Blue.Name = "tb_Blue";
            this.tb_Blue.Size = new System.Drawing.Size(257, 35);
            this.tb_Blue.TabIndex = 4;
            // 
            // pic_Color
            // 
            this.pic_Color.Location = new System.Drawing.Point(377, 44);
            this.pic_Color.Name = "pic_Color";
            this.pic_Color.Size = new System.Drawing.Size(120, 120);
            this.pic_Color.TabIndex = 6;
            this.pic_Color.TabStop = false;
            // 
            // lbl_Error
            // 
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error.Location = new System.Drawing.Point(263, 9);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(0, 26);
            this.lbl_Error.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 201);
            this.Controls.Add(this.lbl_Error);
            this.Controls.Add(this.pic_Color);
            this.Controls.Add(this.txt_Blue);
            this.Controls.Add(this.tb_Blue);
            this.Controls.Add(this.txt_Green);
            this.Controls.Add(this.tb_Green);
            this.Controls.Add(this.txt_Red);
            this.Controls.Add(this.tb_Red);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tb_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Color)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tb_Red;
        private System.Windows.Forms.TextBox txt_Red;
        private System.Windows.Forms.TextBox txt_Green;
        private System.Windows.Forms.TrackBar tb_Green;
        private System.Windows.Forms.TextBox txt_Blue;
        private System.Windows.Forms.TrackBar tb_Blue;
        private System.Windows.Forms.PictureBox pic_Color;
        private System.Windows.Forms.Label lbl_Error;
    }
}

