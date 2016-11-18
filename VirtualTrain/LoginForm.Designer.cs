namespace VirtualTrain
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkPwd = new System.Windows.Forms.CheckBox();
            this.txtLoginPwd = new System.Windows.Forms.TextBox();
            this.viewTime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtLoginId
            // 
            this.txtLoginId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLoginId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(188)))), ((int)(((byte)(71)))));
            this.txtLoginId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginId.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtLoginId.Location = new System.Drawing.Point(474, 285);
            this.txtLoginId.MaxLength = 20;
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(101, 14);
            this.txtLoginId.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = global::VirtualTrain.Properties.Resources.登录1;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(406, 368);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(90, 31);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(495, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 31);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // chkPwd
            // 
            this.chkPwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkPwd.AutoSize = true;
            this.chkPwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPwd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkPwd.Location = new System.Drawing.Point(517, 340);
            this.chkPwd.MaximumSize = new System.Drawing.Size(15, 15);
            this.chkPwd.Name = "chkPwd";
            this.chkPwd.Size = new System.Drawing.Size(15, 14);
            this.chkPwd.TabIndex = 3;
            this.chkPwd.UseVisualStyleBackColor = false;
            // 
            // txtLoginPwd
            // 
            this.txtLoginPwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLoginPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(86)))), ((int)(((byte)(192)))));
            this.txtLoginPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginPwd.Location = new System.Drawing.Point(474, 316);
            this.txtLoginPwd.MaxLength = 20;
            this.txtLoginPwd.Name = "txtLoginPwd";
            this.txtLoginPwd.PasswordChar = '*';
            this.txtLoginPwd.Size = new System.Drawing.Size(101, 14);
            this.txtLoginPwd.TabIndex = 2;
            this.txtLoginPwd.Enter += new System.EventHandler(this.txtLoginPwd_Enter);
            // 
            // viewTime
            // 
            this.viewTime.Interval = 1000;
            this.viewTime.Tick += new System.EventHandler(this.viewTime_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(991, 581);
            this.Controls.Add(this.chkPwd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtLoginPwd);
            this.Controls.Add(this.txtLoginId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(15, 34);
            this.Name = "LoginForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkPwd;
        private System.Windows.Forms.TextBox txtLoginPwd;
        private System.Windows.Forms.Timer viewTime;
    }
}

