namespace VirtualTrain
{
    partial class BatchDialog
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
            this.label5 = new System.Windows.Forms.Label();
            this.cboTypes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMajors = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "题型";
            // 
            // cboTypes
            // 
            this.cboTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypes.FormattingEnabled = true;
            this.cboTypes.Location = new System.Drawing.Point(149, 98);
            this.cboTypes.Name = "cboTypes";
            this.cboTypes.Size = new System.Drawing.Size(121, 20);
            this.cboTypes.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "所属专业";
            // 
            // cboMajors
            // 
            this.cboMajors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMajors.FormattingEnabled = true;
            this.cboMajors.Location = new System.Drawing.Point(149, 152);
            this.cboMajors.Name = "cboMajors";
            this.cboMajors.Size = new System.Drawing.Size(121, 20);
            this.cboMajors.TabIndex = 8;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(92, 199);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "导入";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel文件|*.xls;*.xlsx";
            // 
            // BatchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(408, 320);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboMajors);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboTypes);
            this.Name = "BatchDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据导入";
            this.Load += new System.EventHandler(this.BatchDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTypes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMajors;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog ofdExcel;

    }
}