namespace VirtualTrain
{
    partial class AnswerDialog
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
            this.components = new System.ComponentModel.Container();
            this.countDown = new System.Windows.Forms.Timer(this.components);
            this.lblPaperName = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // countDown
            // 
            this.countDown.Interval = 1000;
            this.countDown.Tick += new System.EventHandler(this.countDown_Tick);
            // 
            // lblPaperName
            // 
            this.lblPaperName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaperName.AutoSize = true;
            this.lblPaperName.Location = new System.Drawing.Point(230, 9);
            this.lblPaperName.Name = "lblPaperName";
            this.lblPaperName.Size = new System.Drawing.Size(53, 12);
            this.lblPaperName.TabIndex = 0;
            this.lblPaperName.Text = "试卷名称";
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(459, 9);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(41, 12);
            this.lblTimer.TabIndex = 1;
            this.lblTimer.Text = "label1";
            // 
            // AnswerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 381);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblPaperName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnswerDialog";
            this.ShowInTaskbar = false;
            this.Text = "AnswerDialog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AnswerDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer countDown;
        private System.Windows.Forms.Label lblPaperName;
        private System.Windows.Forms.Label lblTimer;
    }
}