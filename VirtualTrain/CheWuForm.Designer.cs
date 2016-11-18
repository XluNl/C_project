namespace VirtualTrain
{
    partial class CheWuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheWuForm));
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.upDownSplitContainer = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.BasicFrame.Panel1.SuspendLayout();
            this.BasicFrame.Panel2.SuspendLayout();
            this.BasicFrame.SuspendLayout();
            this.upDownSplitContainer.Panel1.SuspendLayout();
            this.upDownSplitContainer.Panel2.SuspendLayout();
            this.upDownSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
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
            this.BasicFrame.TabIndex = 19;
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
            this.upDownSplitContainer.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upDownSplitContainer.Panel1.Controls.Add(this.listBox1);
            this.upDownSplitContainer.Panel1.Controls.Add(this.axWindowsMediaPlayer1);
            // 
            // upDownSplitContainer.Panel2
            // 
            this.upDownSplitContainer.Panel2.BackgroundImage = global::VirtualTrain.Properties.Resources.底边;
            this.upDownSplitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upDownSplitContainer.Panel2.Controls.Add(this.button1);
            this.upDownSplitContainer.Size = new System.Drawing.Size(750, 404);
            this.upDownSplitContainer.SplitterDistance = 375;
            this.upDownSplitContainer.SplitterWidth = 1;
            this.upDownSplitContainer.TabIndex = 14;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.Font = new System.Drawing.Font("宋体", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 8;
            this.listBox1.Location = new System.Drawing.Point(564, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(184, 373);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
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
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(658, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 21);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(566, 373);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // CheWuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheWuForm";
            this.Opacity = 0D;
            this.Text = "CheWuForm";
            this.Load += new System.EventHandler(this.CheWuForm_Load);
            this.BasicFrame.Panel1.ResumeLayout(false);
            this.BasicFrame.Panel2.ResumeLayout(false);
            this.BasicFrame.ResumeLayout(false);
            this.upDownSplitContainer.Panel1.ResumeLayout(false);
            this.upDownSplitContainer.Panel2.ResumeLayout(false);
            this.upDownSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer BasicFrame;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.SplitContainer upDownSplitContainer;
        private System.Windows.Forms.Button button1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ListBox listBox1;

    }
}