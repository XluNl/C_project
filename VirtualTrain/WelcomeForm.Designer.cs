namespace VirtualTrain
{
    partial class WelcomeForm
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
            this.btnVR = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnScore = new System.Windows.Forms.Button();
            this.btnRegulation = new System.Windows.Forms.Button();
            this.btnExam = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSubject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVR
            // 
            this.btnVR.Location = new System.Drawing.Point(146, 116);
            this.btnVR.Name = "btnVR";
            this.btnVR.Size = new System.Drawing.Size(109, 23);
            this.btnVR.TabIndex = 8;
            this.btnVR.Text = "VR模拟训练";
            this.btnVR.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(146, 232);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出系统";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnScore
            // 
            this.btnScore.Location = new System.Drawing.Point(146, 203);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(109, 23);
            this.btnScore.TabIndex = 10;
            this.btnScore.Text = "成绩查询";
            this.btnScore.UseVisualStyleBackColor = true;
            // 
            // btnRegulation
            // 
            this.btnRegulation.Location = new System.Drawing.Point(146, 87);
            this.btnRegulation.Name = "btnRegulation";
            this.btnRegulation.Size = new System.Drawing.Size(109, 23);
            this.btnRegulation.TabIndex = 5;
            this.btnRegulation.Text = "规章制度学习";
            this.btnRegulation.UseVisualStyleBackColor = true;
            this.btnRegulation.Click += new System.EventHandler(this.btnSubject_Click);
            // 
            // btnExam
            // 
            this.btnExam.Location = new System.Drawing.Point(146, 174);
            this.btnExam.Name = "btnExam";
            this.btnExam.Size = new System.Drawing.Size(109, 23);
            this.btnExam.TabIndex = 6;
            this.btnExam.Text = "在线考试";
            this.btnExam.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(146, 145);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(109, 23);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "自我测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSubject
            // 
            this.btnSubject.Location = new System.Drawing.Point(146, 58);
            this.btnSubject.Name = "btnSubject";
            this.btnSubject.Size = new System.Drawing.Size(109, 23);
            this.btnSubject.TabIndex = 5;
            this.btnSubject.Text = "科目学习";
            this.btnSubject.UseVisualStyleBackColor = true;
            this.btnSubject.Click += new System.EventHandler(this.btnSubject_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 312);
            this.Controls.Add(this.btnVR);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnScore);
            this.Controls.Add(this.btnSubject);
            this.Controls.Add(this.btnRegulation);
            this.Controls.Add(this.btnExam);
            this.Controls.Add(this.btnTest);
            this.Name = "WelcomeForm";
            this.Text = "WelcomeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVR;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnScore;
        private System.Windows.Forms.Button btnRegulation;
        private System.Windows.Forms.Button btnExam;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSubject;
    }
}