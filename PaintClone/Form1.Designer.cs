namespace PaintClone
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
            this.pic_DrawArea = new System.Windows.Forms.PictureBox();
            this.btn_PenTool = new System.Windows.Forms.Button();
            this.btn_EraserTool = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.pic_FirstColor = new System.Windows.Forms.PictureBox();
            this.pic_SecondColor = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.grp_Thickness = new System.Windows.Forms.GroupBox();
            this.rad_Thickness3 = new System.Windows.Forms.RadioButton();
            this.rad_Thickness2 = new System.Windows.Forms.RadioButton();
            this.rad_Thickness1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DrawArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_FirstColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_SecondColor)).BeginInit();
            this.grp_Thickness.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_DrawArea
            // 
            this.pic_DrawArea.Location = new System.Drawing.Point(118, 12);
            this.pic_DrawArea.Name = "pic_DrawArea";
            this.pic_DrawArea.Size = new System.Drawing.Size(670, 426);
            this.pic_DrawArea.TabIndex = 0;
            this.pic_DrawArea.TabStop = false;
            this.pic_DrawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_DrawArea_MouseDown);
            this.pic_DrawArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_DrawArea_MouseMove);
            // 
            // btn_PenTool
            // 
            this.btn_PenTool.Location = new System.Drawing.Point(16, 21);
            this.btn_PenTool.Name = "btn_PenTool";
            this.btn_PenTool.Size = new System.Drawing.Size(81, 27);
            this.btn_PenTool.TabIndex = 1;
            this.btn_PenTool.Text = "Pen";
            this.btn_PenTool.UseVisualStyleBackColor = true;
            this.btn_PenTool.Click += new System.EventHandler(this.btn_PenTool_Click);
            // 
            // btn_EraserTool
            // 
            this.btn_EraserTool.Location = new System.Drawing.Point(16, 54);
            this.btn_EraserTool.Name = "btn_EraserTool";
            this.btn_EraserTool.Size = new System.Drawing.Size(81, 27);
            this.btn_EraserTool.TabIndex = 2;
            this.btn_EraserTool.Text = "Eraser";
            this.btn_EraserTool.UseVisualStyleBackColor = true;
            this.btn_EraserTool.Click += new System.EventHandler(this.btn_EraserTool_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(16, 411);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(81, 27);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // pic_FirstColor
            // 
            this.pic_FirstColor.BackColor = System.Drawing.Color.Black;
            this.pic_FirstColor.Location = new System.Drawing.Point(16, 87);
            this.pic_FirstColor.Name = "pic_FirstColor";
            this.pic_FirstColor.Size = new System.Drawing.Size(37, 28);
            this.pic_FirstColor.TabIndex = 4;
            this.pic_FirstColor.TabStop = false;
            this.pic_FirstColor.Click += new System.EventHandler(this.pic_FirstColor_Click);
            // 
            // pic_SecondColor
            // 
            this.pic_SecondColor.BackColor = System.Drawing.SystemColors.Control;
            this.pic_SecondColor.Location = new System.Drawing.Point(60, 87);
            this.pic_SecondColor.Name = "pic_SecondColor";
            this.pic_SecondColor.Size = new System.Drawing.Size(37, 28);
            this.pic_SecondColor.TabIndex = 5;
            this.pic_SecondColor.TabStop = false;
            this.pic_SecondColor.Click += new System.EventHandler(this.pic_SecondColor_Click);
            // 
            // grp_Thickness
            // 
            this.grp_Thickness.Controls.Add(this.rad_Thickness3);
            this.grp_Thickness.Controls.Add(this.rad_Thickness2);
            this.grp_Thickness.Controls.Add(this.rad_Thickness1);
            this.grp_Thickness.Location = new System.Drawing.Point(16, 135);
            this.grp_Thickness.Name = "grp_Thickness";
            this.grp_Thickness.Size = new System.Drawing.Size(81, 125);
            this.grp_Thickness.TabIndex = 6;
            this.grp_Thickness.TabStop = false;
            this.grp_Thickness.Text = "Thickness";
            // 
            // rad_Thickness3
            // 
            this.rad_Thickness3.AutoSize = true;
            this.rad_Thickness3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_Thickness3.Location = new System.Drawing.Point(6, 78);
            this.rad_Thickness3.Name = "rad_Thickness3";
            this.rad_Thickness3.Size = new System.Drawing.Size(59, 35);
            this.rad_Thickness3.TabIndex = 2;
            this.rad_Thickness3.Text = "---";
            this.rad_Thickness3.UseVisualStyleBackColor = true;
            this.rad_Thickness3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rad_Thickness2
            // 
            this.rad_Thickness2.AutoSize = true;
            this.rad_Thickness2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_Thickness2.Location = new System.Drawing.Point(6, 44);
            this.rad_Thickness2.Name = "rad_Thickness2";
            this.rad_Thickness2.Size = new System.Drawing.Size(46, 28);
            this.rad_Thickness2.TabIndex = 1;
            this.rad_Thickness2.Text = "---";
            this.rad_Thickness2.UseVisualStyleBackColor = true;
            this.rad_Thickness2.CheckedChanged += new System.EventHandler(this.rad_Thickness2_CheckedChanged);
            // 
            // rad_Thickness1
            // 
            this.rad_Thickness1.AutoSize = true;
            this.rad_Thickness1.Location = new System.Drawing.Point(6, 21);
            this.rad_Thickness1.Name = "rad_Thickness1";
            this.rad_Thickness1.Size = new System.Drawing.Size(34, 17);
            this.rad_Thickness1.TabIndex = 0;
            this.rad_Thickness1.Text = "---";
            this.rad_Thickness1.UseVisualStyleBackColor = true;
            this.rad_Thickness1.CheckedChanged += new System.EventHandler(this.rad_Thickness1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grp_Thickness);
            this.Controls.Add(this.pic_SecondColor);
            this.Controls.Add(this.pic_FirstColor);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_EraserTool);
            this.Controls.Add(this.btn_PenTool);
            this.Controls.Add(this.pic_DrawArea);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic_DrawArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_FirstColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_SecondColor)).EndInit();
            this.grp_Thickness.ResumeLayout(false);
            this.grp_Thickness.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_DrawArea;
        private System.Windows.Forms.Button btn_PenTool;
        private System.Windows.Forms.Button btn_EraserTool;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.PictureBox pic_FirstColor;
        private System.Windows.Forms.PictureBox pic_SecondColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox grp_Thickness;
        private System.Windows.Forms.RadioButton rad_Thickness3;
        private System.Windows.Forms.RadioButton rad_Thickness2;
        private System.Windows.Forms.RadioButton rad_Thickness1;
    }
}

