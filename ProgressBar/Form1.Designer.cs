namespace ProgressBar
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
            this.pb_Progress = new System.Windows.Forms.ProgressBar();
            this.btn_Interact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pb_Progress
            // 
            this.pb_Progress.Location = new System.Drawing.Point(193, 128);
            this.pb_Progress.Name = "pb_Progress";
            this.pb_Progress.Size = new System.Drawing.Size(396, 49);
            this.pb_Progress.TabIndex = 0;
            // 
            // btn_Interact
            // 
            this.btn_Interact.Location = new System.Drawing.Point(351, 252);
            this.btn_Interact.Name = "btn_Interact";
            this.btn_Interact.Size = new System.Drawing.Size(75, 23);
            this.btn_Interact.TabIndex = 1;
            this.btn_Interact.Text = "Start";
            this.btn_Interact.UseVisualStyleBackColor = true;
            this.btn_Interact.Click += new System.EventHandler(this.btn_Interact_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Interact);
            this.Controls.Add(this.pb_Progress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_Progress;
        private System.Windows.Forms.Button btn_Interact;
    }
}

