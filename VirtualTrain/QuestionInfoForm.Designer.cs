namespace VirtualTrain
{
    partial class QuestionInfoForm
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
            this.dgvQuestionInfo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difficulty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.major = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBatchAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuestionInfo
            // 
            this.dgvQuestionInfo.AllowUserToAddRows = false;
            this.dgvQuestionInfo.AllowUserToDeleteRows = false;
            this.dgvQuestionInfo.AllowUserToResizeColumns = false;
            this.dgvQuestionInfo.AllowUserToResizeRows = false;
            this.dgvQuestionInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestionInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuestionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestionInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.question,
            this.answer,
            this.difficulty,
            this.major,
            this.type});
            this.dgvQuestionInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvQuestionInfo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dgvQuestionInfo.Name = "dgvQuestionInfo";
            this.dgvQuestionInfo.ReadOnly = true;
            this.dgvQuestionInfo.RowTemplate.Height = 23;
            this.dgvQuestionInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestionInfo.Size = new System.Drawing.Size(471, 277);
            this.dgvQuestionInfo.TabIndex = 0;
            this.dgvQuestionInfo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvQuestionInfo_ColumnHeaderMouseClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // question
            // 
            this.question.DataPropertyName = "question";
            this.question.HeaderText = "题目";
            this.question.Name = "question";
            this.question.ReadOnly = true;
            // 
            // answer
            // 
            this.answer.DataPropertyName = "answer";
            this.answer.HeaderText = "答案";
            this.answer.Name = "answer";
            this.answer.ReadOnly = true;
            // 
            // difficulty
            // 
            this.difficulty.DataPropertyName = "difficulty";
            this.difficulty.HeaderText = "难度";
            this.difficulty.Name = "difficulty";
            this.difficulty.ReadOnly = true;
            // 
            // major
            // 
            this.major.DataPropertyName = "name";
            this.major.HeaderText = "所属专业";
            this.major.Name = "major";
            this.major.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "name1";
            this.type.HeaderText = "题目类型";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(160, 279);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 8);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(238, 279);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(34, 8);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(199, 279);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(34, 8);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBatchAdd
            // 
            this.btnBatchAdd.Location = new System.Drawing.Point(277, 279);
            this.btnBatchAdd.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnBatchAdd.Name = "btnBatchAdd";
            this.btnBatchAdd.Size = new System.Drawing.Size(34, 8);
            this.btnBatchAdd.TabIndex = 1;
            this.btnBatchAdd.Text = "导入题库";
            this.btnBatchAdd.UseVisualStyleBackColor = true;
            this.btnBatchAdd.Click += new System.EventHandler(this.btnBatchAdd_Click);
            // 
            // QuestionInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(3F, 5F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 308);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnBatchAdd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvQuestionInfo);
            this.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "QuestionInfoForm";
            this.Text = "QuestionInfoForm";
            this.Load += new System.EventHandler(this.QuestionInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuestionInfo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn question;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn difficulty;
        private System.Windows.Forms.DataGridViewTextBoxColumn major;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.Button btnBatchAdd;
    }
}