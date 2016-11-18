namespace VirtualTrain
{
    partial class PaperDialog
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
            this.lblPaperName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPaperName
            // 
            this.lblPaperName.AutoSize = true;
            this.lblPaperName.Location = new System.Drawing.Point(229, 9);
            this.lblPaperName.Name = "lblPaperName";
            this.lblPaperName.Size = new System.Drawing.Size(53, 12);
            this.lblPaperName.TabIndex = 2;
            this.lblPaperName.Text = "试卷名称";
            // 
            // PaperDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(497, 362);
            this.Controls.Add(this.lblPaperName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaperDialog";
            this.ShowInTaskbar = false;
            this.Text = "PaperDialog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PaperDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPaperName;
    }
}