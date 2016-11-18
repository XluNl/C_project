namespace VirtualTrain
{
    partial class AnswerQuestionForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnswerQuestionForm));
            this.countDown = new System.Windows.Forms.Timer(this.components);
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CommonPanel = new System.Windows.Forms.Panel();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnAnswerCard = new System.Windows.Forms.Button();
            this.rdoOptionD = new System.Windows.Forms.RadioButton();
            this.rdoOptionC = new System.Windows.Forms.RadioButton();
            this.rdoOptionB = new System.Windows.Forms.RadioButton();
            this.rdoOptionA = new System.Windows.Forms.RadioButton();
            this.lblQuestionDetails = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.BasicFrame.Panel1.SuspendLayout();
            this.BasicFrame.Panel2.SuspendLayout();
            this.BasicFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CommonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // countDown
            // 
            this.countDown.Interval = 1000;
            this.countDown.Tick += new System.EventHandler(this.countDown_Tick);
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
            this.BasicFrame.TabIndex = 17;
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
            this.CommonPanel.Controls.Add(this.lblAnswer);
            this.CommonPanel.Controls.Add(this.lblQuestion);
            this.CommonPanel.Controls.Add(this.btnAnswerCard);
            this.CommonPanel.Controls.Add(this.rdoOptionD);
            this.CommonPanel.Controls.Add(this.rdoOptionC);
            this.CommonPanel.Controls.Add(this.rdoOptionB);
            this.CommonPanel.Controls.Add(this.rdoOptionA);
            this.CommonPanel.Controls.Add(this.lblQuestionDetails);
            this.CommonPanel.Controls.Add(this.lblTimer);
            this.CommonPanel.Controls.Add(this.btnNext);
            this.CommonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommonPanel.Location = new System.Drawing.Point(0, 0);
            this.CommonPanel.Name = "CommonPanel";
            this.CommonPanel.Size = new System.Drawing.Size(750, 404);
            this.CommonPanel.TabIndex = 12;
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblAnswer.Location = new System.Drawing.Point(53, 245);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(41, 12);
            this.lblAnswer.TabIndex = 16;
            this.lblAnswer.Text = "答案：";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblQuestion.Location = new System.Drawing.Point(53, 7);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(35, 12);
            this.lblQuestion.TabIndex = 15;
            this.lblQuestion.Text = "问题1";
            // 
            // btnAnswerCard
            // 
            this.btnAnswerCard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnswerCard.BackgroundImage")));
            this.btnAnswerCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnswerCard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAnswerCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswerCard.Location = new System.Drawing.Point(532, 3);
            this.btnAnswerCard.Name = "btnAnswerCard";
            this.btnAnswerCard.Size = new System.Drawing.Size(73, 21);
            this.btnAnswerCard.TabIndex = 14;
            this.btnAnswerCard.UseVisualStyleBackColor = true;
            this.btnAnswerCard.Click += new System.EventHandler(this.btnAnswerCard_Click);
            // 
            // rdoOptionD
            // 
            this.rdoOptionD.AutoSize = true;
            this.rdoOptionD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rdoOptionD.Location = new System.Drawing.Point(136, 311);
            this.rdoOptionD.Name = "rdoOptionD";
            this.rdoOptionD.Size = new System.Drawing.Size(35, 16);
            this.rdoOptionD.TabIndex = 12;
            this.rdoOptionD.TabStop = true;
            this.rdoOptionD.Tag = "";
            this.rdoOptionD.Text = "D.";
            this.rdoOptionD.UseVisualStyleBackColor = false;
            this.rdoOptionD.Click += new System.EventHandler(this.rdoOption_Click);
            // 
            // rdoOptionC
            // 
            this.rdoOptionC.AutoSize = true;
            this.rdoOptionC.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rdoOptionC.Location = new System.Drawing.Point(136, 289);
            this.rdoOptionC.Name = "rdoOptionC";
            this.rdoOptionC.Size = new System.Drawing.Size(35, 16);
            this.rdoOptionC.TabIndex = 13;
            this.rdoOptionC.TabStop = true;
            this.rdoOptionC.Tag = "";
            this.rdoOptionC.Text = "C.";
            this.rdoOptionC.UseVisualStyleBackColor = false;
            this.rdoOptionC.Click += new System.EventHandler(this.rdoOption_Click);
            // 
            // rdoOptionB
            // 
            this.rdoOptionB.AutoSize = true;
            this.rdoOptionB.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rdoOptionB.Location = new System.Drawing.Point(136, 267);
            this.rdoOptionB.Name = "rdoOptionB";
            this.rdoOptionB.Size = new System.Drawing.Size(35, 16);
            this.rdoOptionB.TabIndex = 10;
            this.rdoOptionB.TabStop = true;
            this.rdoOptionB.Tag = "";
            this.rdoOptionB.Text = "B.";
            this.rdoOptionB.UseVisualStyleBackColor = false;
            this.rdoOptionB.Click += new System.EventHandler(this.rdoOption_Click);
            // 
            // rdoOptionA
            // 
            this.rdoOptionA.AutoSize = true;
            this.rdoOptionA.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rdoOptionA.Location = new System.Drawing.Point(136, 245);
            this.rdoOptionA.Name = "rdoOptionA";
            this.rdoOptionA.Size = new System.Drawing.Size(35, 16);
            this.rdoOptionA.TabIndex = 11;
            this.rdoOptionA.TabStop = true;
            this.rdoOptionA.Tag = "";
            this.rdoOptionA.Text = "A.";
            this.rdoOptionA.UseVisualStyleBackColor = false;
            this.rdoOptionA.Click += new System.EventHandler(this.rdoOption_Click);
            // 
            // lblQuestionDetails
            // 
            this.lblQuestionDetails.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblQuestionDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuestionDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblQuestionDetails.Location = new System.Drawing.Point(53, 37);
            this.lblQuestionDetails.Name = "lblQuestionDetails";
            this.lblQuestionDetails.Size = new System.Drawing.Size(685, 178);
            this.lblQuestionDetails.TabIndex = 9;
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer.Location = new System.Drawing.Point(638, 2);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(100, 23);
            this.lblTimer.TabIndex = 8;
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(573, 369);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(165, 23);
            this.btnNext.TabIndex = 7;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // AnswerQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnswerQuestionForm";
            this.Opacity = 0D;
            this.Text = "AnswerQuestionForm";
            this.Load += new System.EventHandler(this.AnswerQuestionForm_Load);
            this.BasicFrame.Panel1.ResumeLayout(false);
            this.BasicFrame.Panel2.ResumeLayout(false);
            this.BasicFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CommonPanel.ResumeLayout(false);
            this.CommonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer countDown;
        private System.Windows.Forms.SplitContainer BasicFrame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel CommonPanel;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnAnswerCard;
        private System.Windows.Forms.RadioButton rdoOptionD;
        private System.Windows.Forms.RadioButton rdoOptionC;
        private System.Windows.Forms.RadioButton rdoOptionB;
        private System.Windows.Forms.RadioButton rdoOptionA;
        private System.Windows.Forms.Label lblQuestionDetails;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnNext;
    }
}