namespace VirtualTrain
{
    partial class TeacherWelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherWelcomeForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.cboMajors = new System.Windows.Forms.ComboBox();
            this.upDownSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lblName = new System.Windows.Forms.Label();
            this.btnOnlineTeaching = new System.Windows.Forms.Button();
            this.btnExamine = new System.Windows.Forms.Button();
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewDisableButtonColumn1 = new VirtualTrain.DataGridViewDisableButtonColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.upDownSplitContainer.Panel1.SuspendLayout();
            this.upDownSplitContainer.Panel2.SuspendLayout();
            this.upDownSplitContainer.SuspendLayout();
            this.BasicFrame.Panel1.SuspendLayout();
            this.BasicFrame.Panel2.SuspendLayout();
            this.BasicFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(318, 300);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 22);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboMajors
            // 
            this.cboMajors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMajors.FormattingEnabled = true;
            this.cboMajors.Location = new System.Drawing.Point(624, 4);
            this.cboMajors.Name = "cboMajors";
            this.cboMajors.Size = new System.Drawing.Size(121, 20);
            this.cboMajors.TabIndex = 1;
            this.cboMajors.SelectedIndexChanged += new System.EventHandler(this.cboMajors_SelectedIndexChanged);
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
            this.upDownSplitContainer.Panel1.BackgroundImage = global::VirtualTrain.Properties.Resources.车教;
            this.upDownSplitContainer.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upDownSplitContainer.Panel1.Controls.Add(this.lblName);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnOnlineTeaching);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnExamine);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnExit);
            // 
            // upDownSplitContainer.Panel2
            // 
            this.upDownSplitContainer.Panel2.BackgroundImage = global::VirtualTrain.Properties.Resources.底边;
            this.upDownSplitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upDownSplitContainer.Panel2.Controls.Add(this.cboMajors);
            this.upDownSplitContainer.Size = new System.Drawing.Size(750, 404);
            this.upDownSplitContainer.SplitterDistance = 375;
            this.upDownSplitContainer.SplitterWidth = 1;
            this.upDownSplitContainer.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblName.Location = new System.Drawing.Point(668, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "label1";
            // 
            // btnOnlineTeaching
            // 
            this.btnOnlineTeaching.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOnlineTeaching.BackgroundImage")));
            this.btnOnlineTeaching.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOnlineTeaching.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOnlineTeaching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnlineTeaching.Location = new System.Drawing.Point(318, 176);
            this.btnOnlineTeaching.Name = "btnOnlineTeaching";
            this.btnOnlineTeaching.Size = new System.Drawing.Size(113, 23);
            this.btnOnlineTeaching.TabIndex = 1;
            this.btnOnlineTeaching.UseVisualStyleBackColor = true;
            this.btnOnlineTeaching.Click += new System.EventHandler(this.btnOnlineTeaching_Click);
            // 
            // btnExamine
            // 
            this.btnExamine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExamine.BackgroundImage")));
            this.btnExamine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExamine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExamine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamine.Location = new System.Drawing.Point(318, 238);
            this.btnExamine.Name = "btnExamine";
            this.btnExamine.Size = new System.Drawing.Size(113, 23);
            this.btnExamine.TabIndex = 1;
            this.btnExamine.UseVisualStyleBackColor = true;
            this.btnExamine.Click += new System.EventHandler(this.btnExamine_Click);
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
            this.BasicFrame.Panel2.Controls.Add(this.upDownSplitContainer);
            this.BasicFrame.Size = new System.Drawing.Size(750, 450);
            this.BasicFrame.SplitterDistance = 45;
            this.BasicFrame.SplitterWidth = 1;
            this.BasicFrame.TabIndex = 4;
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
            // dataGridViewDisableButtonColumn1
            // 
            this.dataGridViewDisableButtonColumn1.HeaderText = "";
            this.dataGridViewDisableButtonColumn1.Name = "dataGridViewDisableButtonColumn1";
            this.dataGridViewDisableButtonColumn1.ReadOnly = true;
            this.dataGridViewDisableButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisableButtonColumn1.Width = 69;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 69;
            // 
            // TeacherWelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TeacherWelcomeForm";
            this.ShowInTaskbar = false;
            this.Text = "TeacherWelcomeForm";
            this.Load += new System.EventHandler(this.TeacherWelcomeForm_Load);
            this.upDownSplitContainer.Panel1.ResumeLayout(false);
            this.upDownSplitContainer.Panel1.PerformLayout();
            this.upDownSplitContainer.Panel2.ResumeLayout(false);
            this.upDownSplitContainer.ResumeLayout(false);
            this.BasicFrame.Panel1.ResumeLayout(false);
            this.BasicFrame.Panel2.ResumeLayout(false);
            this.BasicFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cboMajors;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private DataGridViewDisableButtonColumn dataGridViewDisableButtonColumn1;
        private System.Windows.Forms.SplitContainer upDownSplitContainer;
        private System.Windows.Forms.SplitContainer BasicFrame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExamine;
        private System.Windows.Forms.Button btnOnlineTeaching;
        private System.Windows.Forms.Label lblName;
    }
}