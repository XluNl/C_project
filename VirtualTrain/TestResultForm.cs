using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    public partial class TestResultForm : Form
    {
        public TestResultForm()
        {
            InitializeComponent();
        }

        private void TestResultForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MaximizedAutoSize(this);
            this.Opacity = 100D;
            int correctNum = 0;
            for (int i = 0; i < TestHelper.questionNum; i++)
            {
                if (TestHelper.studentAnswer[i] == TestHelper.correctAnswer[i])
                {
                    correctNum++;
                }
            }
            int score = (correctNum * 100) / TestHelper.questionNum;
            lblScore.Text = score.ToString() + "分";
            lblStudentScoreStrip.Width = (lblFullScoreStrip.Width * score) / 100;
            if (score < 60)
            {
                lblComment.Text = "该好好复习了！";
                lblStudentScoreStrip.BackColor = Color.Red;
                picFace.Image = faces.Images[0];
            }
            else if (score >= 60 && score < 85)
            {
                lblComment.Text = "还不错，继续努力！";
                lblStudentScoreStrip.BackColor = Color.Blue;
                picFace.Image = faces.Images[1];
            }
            else if (score >= 85 && score < 100)
            {
                lblComment.Text = "真厉害，得优秀了！";
                lblStudentScoreStrip.BackColor = Color.CornflowerBlue;
                picFace.Image = faces.Images[2];
            }
            else if (score == 100)
            {
                lblComment.Text = "太厉害了，得满分了！";
                lblStudentScoreStrip.BackColor = Color.Green;
                picFace.Image = faces.Images[3];
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            StudentFunctionForm.test.Show();
            StudentFunctionForm.test.Opacity = 100D;
            this.Close();
        }
    }
}
