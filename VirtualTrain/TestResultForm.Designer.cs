namespace VirtualTrain
{
    partial class TestResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestResultForm));
            this.picFace = new System.Windows.Forms.PictureBox();
            this.lblStudentScore = new System.Windows.Forms.Label();
            this.lblFullScore = new System.Windows.Forms.Label();
            this.lblFullScoreStrip = new System.Windows.Forms.Label();
            this.lblStudentScoreStrip = new System.Windows.Forms.Label();
            this.lbl100 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.faces = new System.Windows.Forms.ImageList(this.components);
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CommonPanel = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).BeginInit();
            this.BasicFrame.Panel1.SuspendLayout();
            this.BasicFrame.Panel2.SuspendLayout();
            this.BasicFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CommonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFace
            // 
            this.picFace.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.picFace.Location = new System.Drawing.Point(301, 62);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(100, 100);
            this.picFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFace.TabIndex = 0;
            this.picFace.TabStop = false;
            // 
            // lblStudentScore
            // 
            this.lblStudentScore.AutoSize = true;
            this.lblStudentScore.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblStudentScore.Location = new System.Drawing.Point(228, 238);
            this.lblStudentScore.Name = "lblStudentScore";
            this.lblStudentScore.Size = new System.Drawing.Size(65, 12);
            this.lblStudentScore.TabIndex = 1;
            this.lblStudentScore.Text = "你的得分：";
            // 
            // lblFullScore
            // 
            this.lblFullScore.AutoSize = true;
            this.lblFullScore.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblFullScore.Location = new System.Drawing.Point(252, 299);
            this.lblFullScore.Name = "lblFullScore";
            this.lblFullScore.Size = new System.Drawing.Size(41, 12);
            this.lblFullScore.TabIndex = 1;
            this.lblFullScore.Text = "满分：";
            // 
            // lblFullScoreStrip
            // 
            this.lblFullScoreStrip.BackColor = System.Drawing.Color.Green;
            this.lblFullScoreStrip.Location = new System.Drawing.Point(299, 288);
            this.lblFullScoreStrip.Name = "lblFullScoreStrip";
            this.lblFullScoreStrip.Size = new System.Drawing.Size(182, 23);
            this.lblFullScoreStrip.TabIndex = 1;
            // 
            // lblStudentScoreStrip
            // 
            this.lblStudentScoreStrip.BackColor = System.Drawing.Color.Red;
            this.lblStudentScoreStrip.Location = new System.Drawing.Point(299, 227);
            this.lblStudentScoreStrip.Name = "lblStudentScoreStrip";
            this.lblStudentScoreStrip.Size = new System.Drawing.Size(41, 23);
            this.lblStudentScoreStrip.TabIndex = 1;
            // 
            // lbl100
            // 
            this.lbl100.AutoSize = true;
            this.lbl100.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbl100.Location = new System.Drawing.Point(487, 299);
            this.lbl100.Name = "lbl100";
            this.lbl100.Size = new System.Drawing.Size(35, 12);
            this.lbl100.TabIndex = 1;
            this.lbl100.Text = "100分";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblScore.Location = new System.Drawing.Point(487, 238);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 12);
            this.lblScore.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblComment.Location = new System.Drawing.Point(407, 150);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(0, 12);
            this.lblComment.TabIndex = 1;
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // faces
            // 
            this.faces.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("faces.ImageStream")));
            this.faces.TransparentColor = System.Drawing.Color.Transparent;
            this.faces.Images.SetKeyName(0, "png-0484.png");
            this.faces.Images.SetKeyName(1, "png-0490.png");
            this.faces.Images.SetKeyName(2, "png-0494.png");
            this.faces.Images.SetKeyName(3, "png-0486.png");
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
            this.BasicFrame.TabIndex = 18;
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
            this.CommonPanel.Controls.Add(this.btnConfirm);
            this.CommonPanel.Controls.Add(this.picFace);
            this.CommonPanel.Controls.Add(this.lblStudentScore);
            this.CommonPanel.Controls.Add(this.lblScore);
            this.CommonPanel.Controls.Add(this.lblFullScoreStrip);
            this.CommonPanel.Controls.Add(this.lblComment);
            this.CommonPanel.Controls.Add(this.lblStudentScoreStrip);
            this.CommonPanel.Controls.Add(this.lbl100);
            this.CommonPanel.Controls.Add(this.lblFullScore);
            this.CommonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommonPanel.Location = new System.Drawing.Point(0, 0);
            this.CommonPanel.Name = "CommonPanel";
            this.CommonPanel.Size = new System.Drawing.Size(750, 404);
            this.CommonPanel.TabIndex = 12;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.BackgroundImage")));
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Location = new System.Drawing.Point(328, 354);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(73, 21);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // TestResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestResultForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "TestResultForm";
            this.Load += new System.EventHandler(this.TestResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).EndInit();
            this.BasicFrame.Panel1.ResumeLayout(false);
            this.BasicFrame.Panel2.ResumeLayout(false);
            this.BasicFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CommonPanel.ResumeLayout(false);
            this.CommonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picFace;
        private System.Windows.Forms.Label lblStudentScore;
        private System.Windows.Forms.Label lblFullScore;
        private System.Windows.Forms.Label lblFullScoreStrip;
        private System.Windows.Forms.Label lblStudentScoreStrip;
        private System.Windows.Forms.Label lbl100;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.ImageList faces;
        private System.Windows.Forms.SplitContainer BasicFrame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel CommonPanel;
        private System.Windows.Forms.Button btnConfirm;
    }
}