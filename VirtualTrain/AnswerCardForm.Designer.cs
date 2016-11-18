namespace VirtualTrain
{
    partial class AnswerCardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnswerCardForm));
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.countDown = new System.Windows.Forms.Timer(this.components);
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CommonPanel = new System.Windows.Forms.Panel();
            this.BasicFrame.Panel1.SuspendLayout();
            this.BasicFrame.Panel2.SuspendLayout();
            this.BasicFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CommonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer.Location = new System.Drawing.Point(638, 2);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(100, 23);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Location = new System.Drawing.Point(665, 371);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(73, 21);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // countDown
            // 
            this.countDown.Interval = 1000;
            this.countDown.Tick += new System.EventHandler(this.countDown_Tick);
            // 
            // BasicFrame
            // 
            this.BasicFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicFrame.Location = new System.Drawing.Point(0, 0);
            this.BasicFrame.Name = "BasicFrame";
            this.BasicFrame.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BasicFrame.Panel1
            // 
            this.BasicFrame.Panel1.Controls.Add(this.pictureBox1);
            // 
            // BasicFrame.Panel2
            // 
            this.BasicFrame.Panel2.Controls.Add(this.CommonPanel);
            this.BasicFrame.Size = new System.Drawing.Size(750, 450);
            this.BasicFrame.SplitterDistance = 45;
            this.BasicFrame.SplitterWidth = 1;
            this.BasicFrame.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::VirtualTrain.Properties.Resources.抬头栏;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(750, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CommonPanel
            // 
            this.CommonPanel.BackgroundImage = global::VirtualTrain.Properties.Resources.背景;
            this.CommonPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CommonPanel.Controls.Add(this.btnSubmit);
            this.CommonPanel.Controls.Add(this.lblTimer);
            this.CommonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommonPanel.Location = new System.Drawing.Point(0, 0);
            this.CommonPanel.Name = "CommonPanel";
            this.CommonPanel.Size = new System.Drawing.Size(750, 404);
            this.CommonPanel.TabIndex = 12;
            // 
            // AnswerCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnswerCardForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "AnswerCardForm";
            this.Load += new System.EventHandler(this.AnswerCardForm_Load);
            this.BasicFrame.Panel1.ResumeLayout(false);
            this.BasicFrame.Panel2.ResumeLayout(false);
            this.BasicFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CommonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Timer countDown;
        private System.Windows.Forms.SplitContainer BasicFrame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel CommonPanel;
    }
}