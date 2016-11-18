namespace VirtualTrain
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UserInfoManage = new System.Windows.Forms.ToolStripButton();
            this.QuestionInfoManage = new System.Windows.Forms.ToolStripButton();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserInfoManage,
            this.QuestionInfoManage,
            this.Exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(465, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UserInfoManage
            // 
            this.UserInfoManage.Image = ((System.Drawing.Image)(resources.GetObject("UserInfoManage.Image")));
            this.UserInfoManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UserInfoManage.Name = "UserInfoManage";
            this.UserInfoManage.Size = new System.Drawing.Size(97, 22);
            this.UserInfoManage.Text = "人员信息管理";
            this.UserInfoManage.Click += new System.EventHandler(this.UserInfoManage_Click);
            // 
            // QuestionInfoManage
            // 
            this.QuestionInfoManage.Image = ((System.Drawing.Image)(resources.GetObject("QuestionInfoManage.Image")));
            this.QuestionInfoManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuestionInfoManage.Name = "QuestionInfoManage";
            this.QuestionInfoManage.Size = new System.Drawing.Size(73, 22);
            this.QuestionInfoManage.Text = "题库管理";
            this.QuestionInfoManage.Click += new System.EventHandler(this.QuestionInfoManage_Click);
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(49, 22);
            this.Exit.Text = "退出";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 317);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "AdminForm";
            this.ShowInTaskbar = false;
            this.Text = "AdminForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton UserInfoManage;
        private System.Windows.Forms.ToolStripButton QuestionInfoManage;
        private System.Windows.Forms.ToolStripButton Exit;
    }
}