namespace VirtualTrain
{
    partial class StudentFunctionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentFunctionForm));
            this.BasicFrame = new System.Windows.Forms.SplitContainer();
            this.dataGridViewDisableButtonColumn1 = new VirtualTrain.DataGridViewDisableButtonColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CommonPanel = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnScore = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnExam = new System.Windows.Forms.Button();
            this.ScorePanel = new System.Windows.Forms.Panel();
            this.dgvScoreInfo = new System.Windows.Forms.DataGridView();
            this.sid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.examTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnScoreToCommon = new System.Windows.Forms.Button();
            this.paperPanel = new System.Windows.Forms.Panel();
            this.btnPaperToCommon = new System.Windows.Forms.Button();
            this.dgvPaperInfo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.major = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExam = new VirtualTrain.DataGridViewDisableButtonColumn();
            this.BasicFrame.Panel1.SuspendLayout();
            this.BasicFrame.Panel2.SuspendLayout();
            this.BasicFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CommonPanel.SuspendLayout();
            this.ScorePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScoreInfo)).BeginInit();
            this.paperPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaperInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // BasicFrame
            // 
            this.BasicFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicFrame.Location = new System.Drawing.Point(0, 0);
            this.BasicFrame.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
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
            this.BasicFrame.Panel2.Controls.Add(this.ScorePanel);
            this.BasicFrame.Panel2.Controls.Add(this.paperPanel);
            this.BasicFrame.Size = new System.Drawing.Size(750, 450);
            this.BasicFrame.SplitterDistance = 45;
            this.BasicFrame.SplitterWidth = 1;
            this.BasicFrame.TabIndex = 15;
            // 
            // dataGridViewDisableButtonColumn1
            // 
            this.dataGridViewDisableButtonColumn1.HeaderText = "";
            this.dataGridViewDisableButtonColumn1.Name = "dataGridViewDisableButtonColumn1";
            this.dataGridViewDisableButtonColumn1.Width = 173;
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
            this.CommonPanel.Controls.Add(this.btnMenu);
            this.CommonPanel.Controls.Add(this.btnScore);
            this.CommonPanel.Controls.Add(this.btnTest);
            this.CommonPanel.Controls.Add(this.btnExam);
            this.CommonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommonPanel.Location = new System.Drawing.Point(0, 0);
            this.CommonPanel.Name = "CommonPanel";
            this.CommonPanel.Size = new System.Drawing.Size(750, 404);
            this.CommonPanel.TabIndex = 12;
            // 
            // btnMenu
            // 
            this.btnMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMenu.BackgroundImage")));
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Location = new System.Drawing.Point(319, 299);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(113, 23);
            this.btnMenu.TabIndex = 10;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnScore
            // 
            this.btnScore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnScore.BackgroundImage")));
            this.btnScore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScore.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScore.Location = new System.Drawing.Point(319, 243);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(113, 23);
            this.btnScore.TabIndex = 10;
            this.btnScore.UseVisualStyleBackColor = true;
            this.btnScore.Click += new System.EventHandler(this.btnScore_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTest.BackgroundImage")));
            this.btnTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTest.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Location = new System.Drawing.Point(319, 131);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(113, 23);
            this.btnTest.TabIndex = 7;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnExam
            // 
            this.btnExam.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExam.BackgroundImage")));
            this.btnExam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExam.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExam.Location = new System.Drawing.Point(319, 187);
            this.btnExam.Name = "btnExam";
            this.btnExam.Size = new System.Drawing.Size(113, 23);
            this.btnExam.TabIndex = 6;
            this.btnExam.UseVisualStyleBackColor = true;
            this.btnExam.Click += new System.EventHandler(this.btnExam_Click);
            // 
            // ScorePanel
            // 
            this.ScorePanel.BackgroundImage = global::VirtualTrain.Properties.Resources.背景;
            this.ScorePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ScorePanel.Controls.Add(this.dgvScoreInfo);
            this.ScorePanel.Controls.Add(this.btnScoreToCommon);
            this.ScorePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScorePanel.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ScorePanel.Location = new System.Drawing.Point(0, 0);
            this.ScorePanel.Name = "ScorePanel";
            this.ScorePanel.Size = new System.Drawing.Size(750, 404);
            this.ScorePanel.TabIndex = 13;
            // 
            // dgvScoreInfo
            // 
            this.dgvScoreInfo.AllowUserToAddRows = false;
            this.dgvScoreInfo.AllowUserToDeleteRows = false;
            this.dgvScoreInfo.AllowUserToResizeColumns = false;
            this.dgvScoreInfo.AllowUserToResizeRows = false;
            this.dgvScoreInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScoreInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScoreInfo.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvScoreInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScoreInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sid,
            this.sname,
            this.pname,
            this.score,
            this.examTime,
            this.mname,
            this.tname});
            this.dgvScoreInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvScoreInfo.Name = "dgvScoreInfo";
            this.dgvScoreInfo.ReadOnly = true;
            this.dgvScoreInfo.RowTemplate.Height = 23;
            this.dgvScoreInfo.Size = new System.Drawing.Size(750, 365);
            this.dgvScoreInfo.TabIndex = 0;
            this.dgvScoreInfo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvScoreInfo_ColumnHeaderMouseClick);
            // 
            // sid
            // 
            this.sid.DataPropertyName = "id";
            this.sid.HeaderText = "id";
            this.sid.Name = "sid";
            this.sid.ReadOnly = true;
            this.sid.Visible = false;
            // 
            // sname
            // 
            this.sname.DataPropertyName = "sname";
            this.sname.HeaderText = "姓名";
            this.sname.Name = "sname";
            this.sname.ReadOnly = true;
            // 
            // pname
            // 
            this.pname.DataPropertyName = "pname";
            this.pname.HeaderText = "试卷名称";
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            // 
            // score
            // 
            this.score.DataPropertyName = "score";
            this.score.HeaderText = "总分";
            this.score.Name = "score";
            this.score.ReadOnly = true;
            // 
            // examTime
            // 
            this.examTime.DataPropertyName = "examTime";
            this.examTime.HeaderText = "考试时间";
            this.examTime.Name = "examTime";
            this.examTime.ReadOnly = true;
            // 
            // mname
            // 
            this.mname.DataPropertyName = "mname";
            this.mname.HeaderText = "专业";
            this.mname.Name = "mname";
            this.mname.ReadOnly = true;
            // 
            // tname
            // 
            this.tname.DataPropertyName = "tname";
            this.tname.HeaderText = "评分人";
            this.tname.Name = "tname";
            this.tname.ReadOnly = true;
            // 
            // btnScoreToCommon
            // 
            this.btnScoreToCommon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnScoreToCommon.BackgroundImage")));
            this.btnScoreToCommon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScoreToCommon.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnScoreToCommon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScoreToCommon.Location = new System.Drawing.Point(339, 376);
            this.btnScoreToCommon.Name = "btnScoreToCommon";
            this.btnScoreToCommon.Size = new System.Drawing.Size(73, 21);
            this.btnScoreToCommon.TabIndex = 11;
            this.btnScoreToCommon.UseVisualStyleBackColor = true;
            this.btnScoreToCommon.Click += new System.EventHandler(this.btnScoreToCommon_Click);
            // 
            // paperPanel
            // 
            this.paperPanel.BackgroundImage = global::VirtualTrain.Properties.Resources.背景;
            this.paperPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paperPanel.Controls.Add(this.btnPaperToCommon);
            this.paperPanel.Controls.Add(this.dgvPaperInfo);
            this.paperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paperPanel.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.paperPanel.Location = new System.Drawing.Point(0, 0);
            this.paperPanel.Name = "paperPanel";
            this.paperPanel.Size = new System.Drawing.Size(750, 404);
            this.paperPanel.TabIndex = 14;
            // 
            // btnPaperToCommon
            // 
            this.btnPaperToCommon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPaperToCommon.BackgroundImage")));
            this.btnPaperToCommon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaperToCommon.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPaperToCommon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaperToCommon.Location = new System.Drawing.Point(339, 376);
            this.btnPaperToCommon.Name = "btnPaperToCommon";
            this.btnPaperToCommon.Size = new System.Drawing.Size(73, 21);
            this.btnPaperToCommon.TabIndex = 1;
            this.btnPaperToCommon.UseVisualStyleBackColor = true;
            this.btnPaperToCommon.Click += new System.EventHandler(this.btnPaperToCommon_Click);
            // 
            // dgvPaperInfo
            // 
            this.dgvPaperInfo.AllowUserToAddRows = false;
            this.dgvPaperInfo.AllowUserToDeleteRows = false;
            this.dgvPaperInfo.AllowUserToResizeColumns = false;
            this.dgvPaperInfo.AllowUserToResizeRows = false;
            this.dgvPaperInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaperInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaperInfo.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvPaperInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaperInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.recordCount,
            this.name,
            this.teacher,
            this.major,
            this.colExam});
            this.dgvPaperInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvPaperInfo.Name = "dgvPaperInfo";
            this.dgvPaperInfo.ReadOnly = true;
            this.dgvPaperInfo.RowTemplate.Height = 23;
            this.dgvPaperInfo.Size = new System.Drawing.Size(750, 365);
            this.dgvPaperInfo.TabIndex = 0;
            this.dgvPaperInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaperInfo_CellContentClick);
            this.dgvPaperInfo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPaperInfo_ColumnHeaderMouseClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // recordCount
            // 
            this.recordCount.HeaderText = "记录列";
            this.recordCount.Name = "recordCount";
            this.recordCount.ReadOnly = true;
            this.recordCount.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "试卷名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // teacher
            // 
            this.teacher.DataPropertyName = "name1";
            this.teacher.HeaderText = "出题人";
            this.teacher.Name = "teacher";
            this.teacher.ReadOnly = true;
            // 
            // major
            // 
            this.major.DataPropertyName = "name2";
            this.major.HeaderText = "专业";
            this.major.Name = "major";
            this.major.ReadOnly = true;
            // 
            // colExam
            // 
            this.colExam.HeaderText = "";
            this.colExam.Name = "colExam";
            this.colExam.ReadOnly = true;
            // 
            // StudentFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.BasicFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Name = "StudentFunctionForm";
            this.Text = "StudentFunctionForm";
            this.Load += new System.EventHandler(this.StudentFunctionForm_Load);
            this.BasicFrame.Panel1.ResumeLayout(false);
            this.BasicFrame.Panel2.ResumeLayout(false);
            this.BasicFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CommonPanel.ResumeLayout(false);
            this.ScorePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScoreInfo)).EndInit();
            this.paperPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaperInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CommonPanel;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnScore;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnExam;
        private System.Windows.Forms.Panel ScorePanel;
        private System.Windows.Forms.DataGridView dgvScoreInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn examTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn mname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tname;
        private System.Windows.Forms.Button btnScoreToCommon;
        private System.Windows.Forms.Panel paperPanel;
        private System.Windows.Forms.Button btnPaperToCommon;
        private System.Windows.Forms.DataGridView dgvPaperInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn major;
        private DataGridViewDisableButtonColumn colExam;
        private System.Windows.Forms.SplitContainer BasicFrame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DataGridViewDisableButtonColumn dataGridViewDisableButtonColumn1;

    }
}