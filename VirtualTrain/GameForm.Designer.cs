namespace VirtualTrain
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.OptionA = new System.Windows.Forms.CheckBox();
            this.OptionB = new System.Windows.Forms.CheckBox();
            this.OptionC = new System.Windows.Forms.CheckBox();
            this.OptionD = new System.Windows.Forms.CheckBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlquestion = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.pnlquestion.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).BeginInit();
            this.SuspendLayout();
            // 
            // OptionA
            // 
            this.OptionA.AutoSize = true;
            this.OptionA.Location = new System.Drawing.Point(34, 66);
            this.OptionA.Name = "OptionA";
            this.OptionA.Size = new System.Drawing.Size(78, 16);
            this.OptionA.TabIndex = 0;
            this.OptionA.Text = "checkBox1";
            this.OptionA.UseVisualStyleBackColor = true;
            // 
            // OptionB
            // 
            this.OptionB.AutoSize = true;
            this.OptionB.Location = new System.Drawing.Point(134, 66);
            this.OptionB.Name = "OptionB";
            this.OptionB.Size = new System.Drawing.Size(78, 16);
            this.OptionB.TabIndex = 0;
            this.OptionB.Text = "checkBox1";
            this.OptionB.UseVisualStyleBackColor = true;
            // 
            // OptionC
            // 
            this.OptionC.AutoSize = true;
            this.OptionC.Location = new System.Drawing.Point(229, 66);
            this.OptionC.Name = "OptionC";
            this.OptionC.Size = new System.Drawing.Size(78, 16);
            this.OptionC.TabIndex = 0;
            this.OptionC.Text = "checkBox1";
            this.OptionC.UseVisualStyleBackColor = true;
            // 
            // OptionD
            // 
            this.OptionD.AutoSize = true;
            this.OptionD.Location = new System.Drawing.Point(339, 66);
            this.OptionD.Name = "OptionD";
            this.OptionD.Size = new System.Drawing.Size(78, 16);
            this.OptionD.TabIndex = 0;
            this.OptionD.Text = "checkBox1";
            this.OptionD.UseVisualStyleBackColor = true;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(32, 38);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(41, 12);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "label1";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(34, 88);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // pnlquestion
            // 
            this.pnlquestion.Controls.Add(this.btnSubmit);
            this.pnlquestion.Controls.Add(this.OptionC);
            this.pnlquestion.Controls.Add(this.lblQuestion);
            this.pnlquestion.Controls.Add(this.OptionA);
            this.pnlquestion.Controls.Add(this.OptionD);
            this.pnlquestion.Controls.Add(this.OptionB);
            this.pnlquestion.Location = new System.Drawing.Point(31, 12);
            this.pnlquestion.Name = "pnlquestion";
            this.pnlquestion.Size = new System.Drawing.Size(454, 194);
            this.pnlquestion.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wmp);
            this.panel1.Location = new System.Drawing.Point(31, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 227);
            this.panel1.TabIndex = 4;
            // 
            // wmp
            // 
            this.wmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmp.Enabled = true;
            this.wmp.Location = new System.Drawing.Point(0, 0);
            this.wmp.Name = "wmp";
            this.wmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmp.OcxState")));
            this.wmp.Size = new System.Drawing.Size(307, 227);
            this.wmp.TabIndex = 0;
            this.wmp.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.wmp_PlayStateChange);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlquestion);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.pnlquestion.ResumeLayout(false);
            this.pnlquestion.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox OptionA;
        private System.Windows.Forms.CheckBox OptionB;
        private System.Windows.Forms.CheckBox OptionC;
        private System.Windows.Forms.CheckBox OptionD;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel pnlquestion;
        private System.Windows.Forms.Panel panel1;
        private AxWMPLib.AxWindowsMediaPlayer wmp;
    }
}