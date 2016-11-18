namespace VirtualTrain
{
    partial class BasicForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicForm));
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.upDownSplitContainer = new System.Windows.Forms.SplitContainer();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnGW = new System.Windows.Forms.Button();
            this.btnDD = new System.Windows.Forms.Button();
            this.btnCW = new System.Windows.Forms.Button();
            this.btnDW = new System.Windows.Forms.Button();
            this.btnGD = new System.Windows.Forms.Button();
            this.BasicFrame.Panel1.SuspendLayout();
            this.BasicFrame.Panel2.SuspendLayout();
            this.BasicFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.upDownSplitContainer.Panel1.SuspendLayout();
            this.upDownSplitContainer.SuspendLayout();
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
            this.BasicFrame.Panel1.Controls.Add(this.pictureBox11);
            // 
            // BasicFrame.Panel2
            // 
            this.BasicFrame.Panel2.Controls.Add(this.upDownSplitContainer);
            this.BasicFrame.Size = new System.Drawing.Size(750, 450);
            this.BasicFrame.SplitterDistance = 45;
            this.BasicFrame.SplitterWidth = 1;
            this.BasicFrame.TabIndex = 17;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox11.Image = global::VirtualTrain.Properties.Resources.抬头栏;
            this.pictureBox11.Location = new System.Drawing.Point(0, 0);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(750, 45);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 15;
            this.pictureBox11.TabStop = false;
            // 
            // upDownSplitContainer
            // 
            this.upDownSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upDownSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upDownSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.upDownSplitContainer.Name = "upDownSplitContainer";
            this.upDownSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // upDownSplitContainer.Panel1
            // 
            this.upDownSplitContainer.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("upDownSplitContainer.Panel1.BackgroundImage")));
            this.upDownSplitContainer.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnBack);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnVideo);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnGW);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnDD);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnCW);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnDW);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnGD);
            // 
            // upDownSplitContainer.Panel2
            // 
            this.upDownSplitContainer.Panel2.BackgroundImage = global::VirtualTrain.Properties.Resources.底边;
            this.upDownSplitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upDownSplitContainer.Panel2Collapsed = true;
            this.upDownSplitContainer.Size = new System.Drawing.Size(750, 404);
            this.upDownSplitContainer.SplitterDistance = 375;
            this.upDownSplitContainer.SplitterWidth = 1;
            this.upDownSplitContainer.TabIndex = 14;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::VirtualTrain.Properties.Resources.返回1;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(307, 344);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(135, 20);
            this.btnBack.TabIndex = 1;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            this.btnBack.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnBack.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnVideo
            // 
            this.btnVideo.BackgroundImage = global::VirtualTrain.Properties.Resources.视频资料1;
            this.btnVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVideo.FlatAppearance.BorderSize = 0;
            this.btnVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideo.Location = new System.Drawing.Point(307, 309);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(135, 20);
            this.btnVideo.TabIndex = 5;
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.picCheWuVideo_Click);
            this.btnVideo.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnVideo.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnGW
            // 
            this.btnGW.BackgroundImage = global::VirtualTrain.Properties.Resources.工务电子书1;
            this.btnGW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGW.FlatAppearance.BorderSize = 0;
            this.btnGW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGW.Location = new System.Drawing.Point(307, 275);
            this.btnGW.Name = "btnGW";
            this.btnGW.Size = new System.Drawing.Size(135, 20);
            this.btnGW.TabIndex = 4;
            this.btnGW.Tag = "3";
            this.btnGW.UseVisualStyleBackColor = true;
            this.btnGW.Click += new System.EventHandler(this.pictureBox_Click);
            this.btnGW.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnGW.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnDD
            // 
            this.btnDD.BackgroundImage = global::VirtualTrain.Properties.Resources.调度电子书1;
            this.btnDD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDD.FlatAppearance.BorderSize = 0;
            this.btnDD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDD.Location = new System.Drawing.Point(307, 240);
            this.btnDD.Name = "btnDD";
            this.btnDD.Size = new System.Drawing.Size(135, 20);
            this.btnDD.TabIndex = 4;
            this.btnDD.Tag = "4";
            this.btnDD.UseVisualStyleBackColor = true;
            this.btnDD.Click += new System.EventHandler(this.pictureBox_Click);
            this.btnDD.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnDD.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnCW
            // 
            this.btnCW.BackgroundImage = global::VirtualTrain.Properties.Resources.车务电子书1;
            this.btnCW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCW.FlatAppearance.BorderSize = 0;
            this.btnCW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCW.Location = new System.Drawing.Point(307, 135);
            this.btnCW.Name = "btnCW";
            this.btnCW.Size = new System.Drawing.Size(135, 20);
            this.btnCW.TabIndex = 4;
            this.btnCW.Tag = "1";
            this.btnCW.UseVisualStyleBackColor = true;
            this.btnCW.Click += new System.EventHandler(this.pictureBox_Click);
            this.btnCW.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCW.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnDW
            // 
            this.btnDW.BackgroundImage = global::VirtualTrain.Properties.Resources.电务电子书1;
            this.btnDW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDW.FlatAppearance.BorderSize = 0;
            this.btnDW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDW.Location = new System.Drawing.Point(307, 168);
            this.btnDW.Name = "btnDW";
            this.btnDW.Size = new System.Drawing.Size(135, 20);
            this.btnDW.TabIndex = 4;
            this.btnDW.Tag = "2";
            this.btnDW.UseVisualStyleBackColor = true;
            this.btnDW.Click += new System.EventHandler(this.pictureBox_Click);
            this.btnDW.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnDW.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnGD
            // 
            this.btnGD.BackgroundImage = global::VirtualTrain.Properties.Resources.供电电子书1;
            this.btnGD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGD.FlatAppearance.BorderSize = 0;
            this.btnGD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGD.Location = new System.Drawing.Point(307, 204);
            this.btnGD.Name = "btnGD";
            this.btnGD.Size = new System.Drawing.Size(135, 20);
            this.btnGD.TabIndex = 4;
            this.btnGD.Tag = "5";
            this.btnGD.UseVisualStyleBackColor = true;
            this.btnGD.Click += new System.EventHandler(this.pictureBox_Click);
            this.btnGD.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnGD.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // BasicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BasicForm";
            this.Opacity = 0D;
            this.Text = "VRForm";
            this.Load += new System.EventHandler(this.BasicForm_Load);
            this.BasicFrame.Panel1.ResumeLayout(false);
            this.BasicFrame.Panel2.ResumeLayout(false);
            this.BasicFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.upDownSplitContainer.Panel1.ResumeLayout(false);
            this.upDownSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.SplitContainer BasicFrame;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.SplitContainer upDownSplitContainer;
        private System.Windows.Forms.Button btnGD;
        private System.Windows.Forms.Button btnGW;
        private System.Windows.Forms.Button btnDD;
        private System.Windows.Forms.Button btnCW;
        private System.Windows.Forms.Button btnDW;
        private System.Windows.Forms.Button btnVideo;
    }
}