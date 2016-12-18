namespace VirtualTrain
{
    partial class VRForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VRForm));
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.upDownSplitContainer = new System.Windows.Forms.SplitContainer();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDian = new System.Windows.Forms.Button();
            this.btnTMIS = new System.Windows.Forms.Button();
            this.btnZhuan = new System.Windows.Forms.Button();
            this.btnADX = new System.Windows.Forms.Button();
            this.btnCangku = new System.Windows.Forms.Button();
            this.btnU3D = new System.Windows.Forms.Button();
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
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnDian);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnTMIS);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnZhuan);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnADX);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnCangku);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnU3D);
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
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::VirtualTrain.Properties.Resources.返回1;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(307, 338);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(135, 20);
            this.btnBack.TabIndex = 1;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            this.btnBack.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnBack.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnDian
            // 
            this.btnDian.BackColor = System.Drawing.Color.Transparent;
            this.btnDian.BackgroundImage = global::VirtualTrain.Properties.Resources.轨道电路演练1;
            this.btnDian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDian.FlatAppearance.BorderSize = 0;
            this.btnDian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDian.Location = new System.Drawing.Point(307, 306);
            this.btnDian.Name = "btnDian";
            this.btnDian.Size = new System.Drawing.Size(135, 20);
            this.btnDian.TabIndex = 3;
            this.btnDian.Tag = "2";
            this.btnDian.UseVisualStyleBackColor = false;
            this.btnDian.Click += new System.EventHandler(this.picMajor_Click);
            this.btnDian.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnDian.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnTMIS
            // 
            this.btnTMIS.BackColor = System.Drawing.Color.Transparent;
            this.btnTMIS.BackgroundImage = global::VirtualTrain.Properties.Resources.TMIS1;
            this.btnTMIS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTMIS.FlatAppearance.BorderSize = 0;
            this.btnTMIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTMIS.Location = new System.Drawing.Point(307, 273);
            this.btnTMIS.Name = "btnTMIS";
            this.btnTMIS.Size = new System.Drawing.Size(135, 20);
            this.btnTMIS.TabIndex = 3;
            this.btnTMIS.UseVisualStyleBackColor = false;
            this.btnTMIS.Click += new System.EventHandler(this.picTMIS_Click);
            this.btnTMIS.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnTMIS.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnZhuan
            // 
            this.btnZhuan.BackColor = System.Drawing.Color.Transparent;
            this.btnZhuan.BackgroundImage = global::VirtualTrain.Properties.Resources.转辙机拆装1;
            this.btnZhuan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZhuan.FlatAppearance.BorderSize = 0;
            this.btnZhuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZhuan.Location = new System.Drawing.Point(307, 176);
            this.btnZhuan.Name = "btnZhuan";
            this.btnZhuan.Size = new System.Drawing.Size(135, 20);
            this.btnZhuan.TabIndex = 3;
            this.btnZhuan.Tag = "3";
            this.btnZhuan.UseVisualStyleBackColor = false;
            this.btnZhuan.Click += new System.EventHandler(this.picMajor_Click);
            this.btnZhuan.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnZhuan.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnADX
            // 
            this.btnADX.BackColor = System.Drawing.Color.Transparent;
            this.btnADX.BackgroundImage = global::VirtualTrain.Properties.Resources.ADX教学1;
            this.btnADX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnADX.FlatAppearance.BorderSize = 0;
            this.btnADX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnADX.Location = new System.Drawing.Point(307, 241);
            this.btnADX.Name = "btnADX";
            this.btnADX.Size = new System.Drawing.Size(135, 20);
            this.btnADX.TabIndex = 3;
            this.btnADX.Tag = "1";
            this.btnADX.UseVisualStyleBackColor = false;
            this.btnADX.Click += new System.EventHandler(this.picMajor_Click);
            this.btnADX.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnADX.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnCangku
            // 
            this.btnCangku.BackColor = System.Drawing.Color.Transparent;
            this.btnCangku.BackgroundImage = global::VirtualTrain.Properties.Resources.仓库1;
            this.btnCangku.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCangku.FlatAppearance.BorderSize = 0;
            this.btnCangku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCangku.Location = new System.Drawing.Point(307, 208);
            this.btnCangku.Name = "btnCangku";
            this.btnCangku.Size = new System.Drawing.Size(135, 20);
            this.btnCangku.TabIndex = 3;
            this.btnCangku.UseVisualStyleBackColor = false;
            this.btnCangku.Click += new System.EventHandler(this.picMajor_Click);
            this.btnCangku.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCangku.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnU3D
            // 
            this.btnU3D.BackColor = System.Drawing.Color.Transparent;
            this.btnU3D.BackgroundImage = global::VirtualTrain.Properties.Resources.VR虚拟演练1;
            this.btnU3D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnU3D.FlatAppearance.BorderSize = 0;
            this.btnU3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnU3D.Location = new System.Drawing.Point(307, 143);
            this.btnU3D.Name = "btnU3D";
            this.btnU3D.Size = new System.Drawing.Size(135, 20);
            this.btnU3D.TabIndex = 3;
            this.btnU3D.UseVisualStyleBackColor = false;
            this.btnU3D.Click += new System.EventHandler(this.btnU3D_Click);
            this.btnU3D.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnU3D.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // VRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VRForm";
            this.Opacity = 0D;
            this.Text = "VRForm";
            this.Load += new System.EventHandler(this.VRForm_Load);
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
        private System.Windows.Forms.Button btnU3D;
        private System.Windows.Forms.Button btnCangku;
        private System.Windows.Forms.Button btnDian;
        private System.Windows.Forms.Button btnTMIS;
        private System.Windows.Forms.Button btnZhuan;
        private System.Windows.Forms.Button btnADX;
    }
}