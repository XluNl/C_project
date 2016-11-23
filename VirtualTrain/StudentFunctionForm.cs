using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;

namespace VirtualTrain
{
    public partial class StudentFunctionForm : Form
    {
        public StudentFunctionForm()
        {
            InitializeComponent();
        }

        AnswerDialog dialog;
        private void StudentFunctionForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MdiChildrenAutoSize(this);
            this.Dock = DockStyle.Fill;
            CommonPanel.Show();
            paperPanel.Hide();
            ScorePanel.Hide();
            ////创建一个答题对话框的实例
            //dialog = new AnswerDialog();
            //dialog.Owner = this;
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            CommonPanel.Hide();
            paperPanel.Show();
            showAllPapers();
        }

        private void showAllPapers()
        {
            DBHelper db = new DBHelper();
            string sql = "select a.id,a.name,b.name,c.name from papers a,users b,majors c where a.teacherId=b.id and a.majorId=c.id and a.majorId=" + UserHelper.currentMajorId;
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            dgvPaperInfo.DataSource = dt;
            //对记录数列填充数据
            updateColumns();
            //记录列
            //按钮列
            dgvPaperInfo.Columns[1].FillWeight = 10;
            //id
            //试卷名称
            dgvPaperInfo.Columns[3].FillWeight = 50;
            //出题人
            dgvPaperInfo.Columns[4].FillWeight = 30;
            //专业
            dgvPaperInfo.Columns[5].FillWeight = 10;
            QuestionInfoForm.setColor(dgvPaperInfo);
        }

        private void updateColumns()
        {
            DBHelper db = new DBHelper();
            int sid = UserHelper.user.id;
            for (int i = 0; i < dgvPaperInfo.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dgvPaperInfo.Rows[i].Cells[2].Value);
                string sql = "select count(*) as recordCount from scores where studentId=" + sid + " and paperId=" + id;
                DbCommand cmd = db.GetSqlStringCommand(sql);
                int recordCount = Convert.ToInt32(db.ExecuteScalar(cmd));
                dgvPaperInfo.Rows[i].Cells[0].Value = recordCount;
                if (recordCount == 0)
                {
                    dgvPaperInfo.Rows[i].Cells[1].Value = "开始考试";
                }
                else
                {
                    dgvPaperInfo.Rows[i].Cells[1].Value = "已完成";
                    ((DataGridViewDisableButtonCell)dgvPaperInfo.Rows[i].Cells[1]).Enabled = false;
                }
            }
        }

        private void dgvPaperInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            updateColumns();
            QuestionInfoForm.setColor(dgvPaperInfo);
        }

        private void dgvPaperInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int recordCount = Convert.ToInt32(dgvPaperInfo.Rows[e.RowIndex].Cells[0].Value);
                if (e.ColumnIndex == 1 && recordCount == 0)
                {
                    int id = Convert.ToInt32(dgvPaperInfo.Rows[e.RowIndex].Cells[2].Value);
                    dialog = new AnswerDialog();
                    dialog.paperId = id;
                    this.MdiParent.Hide();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        showAllPapers();
                        this.MdiParent.Show();
                    }
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiParent.MdiChildren)
            {
                if (f is StudentWelcomeForm)
                {
                    f.Activate();
                    return;
                }
            }
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            CommonPanel.Hide();
            ScorePanel.Show();
            showAllScores();
        }

        private void showAllScores()
        {
            DBHelper db = new DBHelper();
            string sql = "select a.id,a.sname,a.pname,a.score,a.examTime,c.name as mname,b.name as tname from (select a.id,a.score,a.examTime,c.name as sname,b.name as pname,b.majorId,b.teacherId from scores a,papers b,users c where a.paperId=b.id and a.studentId=c.id and a.studentId=" + UserHelper.user.id + " and b.majorId=" + UserHelper.currentMajorId + " and a.state=1) a,users b,majors c where a.majorId=c.id and a.teacherId=b.id";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            dgvScoreInfo.DataSource = dt;
            //id
            //姓名
            dgvScoreInfo.Columns[1].FillWeight = 10;
            //试卷名称
            dgvScoreInfo.Columns[2].FillWeight = 40;
            //总分
            dgvScoreInfo.Columns[3].FillWeight = 10;
            //考试时间
            dgvScoreInfo.Columns[4].FillWeight = 20;
            //专业
            dgvScoreInfo.Columns[5].FillWeight = 10;
            //评分人
            dgvScoreInfo.Columns[6].FillWeight = 10;
            QuestionInfoForm.setColor(dgvScoreInfo);
        }

        private void dgvScoreInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            QuestionInfoForm.setColor(dgvScoreInfo);
        }

        private void btnPaperToCommon_Click(object sender, EventArgs e)
        {
            paperPanel.Hide();
            CommonPanel.Show();
        }

        private void btnScoreToCommon_Click(object sender, EventArgs e)
        {
            ScorePanel.Hide();
            CommonPanel.Show();
        }

        private static Test _test = new Test();
        public static Test test
        {
            get
            {
                return _test;
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            this.MdiParent.Hide();
            if (test.ShowDialog() == DialogResult.OK)
            {
                this.MdiParent.Show();
            }
        }

    }
}
