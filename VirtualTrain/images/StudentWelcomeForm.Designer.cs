﻿namespace VirtualTrain
{
    partial class StudentWelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentWelcomeForm));
            this.upDownSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lblName = new System.Windows.Forms.Label();
            this.cboMajors = new System.Windows.Forms.ComboBox();
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBasics = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnVR = new System.Windows.Forms.Button();
            this.btnElectronicSandTable = new System.Windows.Forms.Button();
            this.btnExamine = new System.Windows.Forms.Button();
            this.dataGridViewDisableButtonColumn1 = new VirtualTrain.DataGridViewDisableButtonColumn();
            this.upDownSplitContainer.Panel1.SuspendLayout();
            this.upDownSplitContainer.Panel2.SuspendLayout();
            this.upDownSplitContainer.SuspendLayout();
            this.BasicFrame.Panel1.SuspendLayout();
            this.BasicFrame.Panel2.SuspendLayout();
            this.BasicFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnBasics);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnExit);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnVR);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnElectronicSandTable);
            this.upDownSplitContainer.Panel1.Controls.Add(this.btnExamine);
            this.upDownSplitContainer.Panel1.Controls.Add(this.lblName);
            // 
            // upDownSplitContainer.Panel2
            // 
            this.upDownSplitContainer.Panel2.BackgroundImage = global::VirtualTrain.Properties.Resources.底边;
            this.upDownSplitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upDownSplitContainer.Panel2.Controls.Add(this.cboMajors);
            this.upDownSplitContainer.Size = new System.Drawing.Size(750, 404);
            this.upDownSplitContainer.SplitterDistance = 375;
            this.upDownSplitContainer.SplitterWidth = 1;
            this.upDownSplitContainer.TabIndex = 14;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblName.Location = new System.Drawing.Point(668, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "label1";
            // 
            // cboMajors
            // 
            this.cboMajors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMajors.FormattingEnabled = true;
            this.cboMajors.Location = new System.Drawing.Point(624, 4);
            this.cboMajors.Name = "cboMajors";
            this.cboMajors.Size = new System.Drawing.Size(121, 20);
            this.cboMajors.TabIndex = 16;
            this.cboMajors.SelectedIndexChanged += new System.EventHandler(this.cboMajors_SelectedIndexChanged);
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
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnBasics
            // 
            this.btnBasics.BackColor = System.Drawing.Color.Transparent;
            this.btnBasics.BackgroundImage = global::VirtualTrain.Properties.Resources.在线学习1;
            this.btnBasics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBasics.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBasics.FlatAppearance.BorderSize = 0;
            this.btnBasics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasics.Location = new System.Drawing.Point(306, 231);
            this.btnBasics.Name = "btnBasics";
            this.btnBasics.Size = new System.Drawing.Size(140, 25);
            this.btnBasics.TabIndex = 11;
            this.btnBasics.UseVisualStyleBackColor = false;
            this.btnBasics.Click += new System.EventHandler(this.btnVR_Click);
            this.btnBasics.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnBasics.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::VirtualTrain.Properties.Resources.退出11;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(306, 265);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 25);
            this.btnExit.TabIndex = 9;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnVR
            // 
            this.btnVR.BackColor = System.Drawing.Color.Transparent;
            this.btnVR.BackgroundImage = global::VirtualTrain.Properties.Resources.虚拟演练1;
            this.btnVR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVR.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVR.FlatAppearance.BorderSize = 0;
            this.btnVR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVR.Location = new System.Drawing.Point(306, 161);
            this.btnVR.Name = "btnVR";
            this.btnVR.Size = new System.Drawing.Size(140, 25);
            this.btnVR.TabIndex = 8;
            this.btnVR.UseVisualStyleBackColor = false;
            this.btnVR.Click += new System.EventHandler(this.btnBasics_Click);
            this.btnVR.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnVR.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnElectronicSandTable
            // 
            this.btnElectronicSandTable.BackColor = System.Drawing.Color.Transparent;
            this.btnElectronicSandTable.BackgroundImage = global::VirtualTrain.Properties.Resources.电子沙盘1;
            this.btnElectronicSandTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnElectronicSandTable.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnElectronicSandTable.FlatAppearance.BorderSize = 0;
            this.btnElectronicSandTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElectronicSandTable.Location = new System.Drawing.Point(306, 126);
            this.btnElectronicSandTable.Name = "btnElectronicSandTable";
            this.btnElectronicSandTable.Size = new System.Drawing.Size(140, 25);
            this.btnElectronicSandTable.TabIndex = 11;
            this.btnElectronicSandTable.UseVisualStyleBackColor = false;
            this.btnElectronicSandTable.Click += new System.EventHandler(this.btnElectronicSandTable_Click);
            this.btnElectronicSandTable.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnElectronicSandTable.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnExamine
            // 
            this.btnExamine.BackColor = System.Drawing.Color.Transparent;
            this.btnExamine.BackgroundImage = global::VirtualTrain.Properties.Resources.在线考试1;
            this.btnExamine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExamine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExamine.FlatAppearance.BorderSize = 0;
            this.btnExamine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamine.Location = new System.Drawing.Point(306, 196);
            this.btnExamine.Name = "btnExamine";
            this.btnExamine.Size = new System.Drawing.Size(140, 25);
            this.btnExamine.TabIndex = 11;
            this.btnExamine.UseVisualStyleBackColor = false;
            this.btnExamine.Click += new System.EventHandler(this.btnExamine_Click);
            this.btnExamine.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnExamine.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // dataGridViewDisableButtonColumn1
            // 
            this.dataGridViewDisableButtonColumn1.HeaderText = "a";
            this.dataGridViewDisableButtonColumn1.Name = "dataGridViewDisableButtonColumn1";
            this.dataGridViewDisableButtonColumn1.ReadOnly = true;
            this.dataGridViewDisableButtonColumn1.Width = 62;
            // 
            // StudentWelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentWelcomeForm";
            this.Text = "StudentWelcomeForm";
            this.Load += new System.EventHandler(this.StudentWelcomeForm_Load);
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

        private System.Windows.Forms.SplitContainer upDownSplitContainer;
        private DataGridViewDisableButtonColumn dataGridViewDisableButtonColumn1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer BasicFrame;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnBasics;
        private System.Windows.Forms.Button btnElectronicSandTable;
        private System.Windows.Forms.Button btnExamine;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnVR;
        private System.Windows.Forms.ComboBox cboMajors;
    }
}