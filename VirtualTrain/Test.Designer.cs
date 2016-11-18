namespace VirtualTrain
{
    partial class Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CommonPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.picDescription = new System.Windows.Forms.PictureBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGiveUp = new System.Windows.Forms.Button();
            this.BasicFrame.Panel1.SuspendLayout();
            this.BasicFrame.Panel2.SuspendLayout();
            this.BasicFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CommonPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDescription)).BeginInit();
            this.SuspendLayout();
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
            this.BasicFrame.TabIndex = 16;
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
            this.CommonPanel.Controls.Add(this.groupBox1);
            this.CommonPanel.Controls.Add(this.picDescription);
            this.CommonPanel.Controls.Add(this.btnBegin);
            this.CommonPanel.Controls.Add(this.label2);
            this.CommonPanel.Controls.Add(this.btnGiveUp);
            this.CommonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommonPanel.Location = new System.Drawing.Point(0, 0);
            this.CommonPanel.Name = "CommonPanel";
            this.CommonPanel.Size = new System.Drawing.Size(750, 404);
            this.CommonPanel.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Location = new System.Drawing.Point(222, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDescription.Location = new System.Drawing.Point(23, 17);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(202, 80);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "1.所有题目均为单项选择题\r\n2.题量为20题\r\n3.答题时间为20分钟\r\n祝你好运！";
            // 
            // picDescription
            // 
            this.picDescription.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.picDescription.Image = ((System.Drawing.Image)(resources.GetObject("picDescription.Image")));
            this.picDescription.Location = new System.Drawing.Point(284, 87);
            this.picDescription.Name = "picDescription";
            this.picDescription.Size = new System.Drawing.Size(28, 28);
            this.picDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDescription.TabIndex = 4;
            this.picDescription.TabStop = false;
            // 
            // btnBegin
            // 
            this.btnBegin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBegin.BackgroundImage")));
            this.btnBegin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBegin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBegin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBegin.Location = new System.Drawing.Point(372, 298);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(73, 21);
            this.btnBegin.TabIndex = 1;
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Location = new System.Drawing.Point(313, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "考考自己，看学的怎么样！";
            // 
            // btnGiveUp
            // 
            this.btnGiveUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGiveUp.BackgroundImage")));
            this.btnGiveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGiveUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGiveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiveUp.Location = new System.Drawing.Point(453, 298);
            this.btnGiveUp.Name = "btnGiveUp";
            this.btnGiveUp.Size = new System.Drawing.Size(73, 21);
            this.btnGiveUp.TabIndex = 1;
            this.btnGiveUp.UseVisualStyleBackColor = true;
            this.btnGiveUp.Click += new System.EventHandler(this.btnGiveUp_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Test";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "SelectSubjectForm";
            this.Load += new System.EventHandler(this.Test_Load);
            this.BasicFrame.Panel1.ResumeLayout(false);
            this.BasicFrame.Panel2.ResumeLayout(false);
            this.BasicFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CommonPanel.ResumeLayout(false);
            this.CommonPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDescription)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer BasicFrame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel CommonPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox picDescription;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGiveUp;
    }
}