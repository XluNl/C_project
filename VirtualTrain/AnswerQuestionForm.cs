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
    public partial class AnswerQuestionForm : Form
    {
        public AnswerQuestionForm()
        {
            InitializeComponent();
        }

        //当前的问题对应的数组索引
        public int index = 0;

        private void AnswerQuestionForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MaximizedAutoSize(this);
            this.Opacity = 100D;
            //启动计时器
            countDown.Start();
            //显示题目信息
            getQuestionDetails();
            //如果题目已经答过，让相应的选项选中
            checkOption();
            //确定是否到了最后一题
            checkBtnNext();
            rdoOptionA.Tag = "A";
            rdoOptionB.Tag = "B";
            rdoOptionC.Tag = "C";
            rdoOptionD.Tag = "D";
        }

        //确定"下一题"按钮应该显示的文字
        private void checkBtnNext()
        {
            //如果达到20题，就让"下一题"按钮的文字显示为“检查答案”
            if (index >= TestHelper.selectedQuestionId.Length - 1)
            {
                //undo
                btnNext.BackgroundImage = VirtualTrain.Properties.Resources._14;
                //btnNext.Text = "检查答案";
            }
        }

        //单击“下一题”按钮时，为答案数组赋值，并显示下一题的信息
        private void btnNext_Click(object sender, EventArgs e)
        {
            //如果没有到最后一题，就继续显示新题目信息
            if (index < TestHelper.selectedQuestionId.Length - 1)
            {
                index++;
                //显示试题信息
                getQuestionDetails();
                //如果题目已经答过，让相应的选项选中
                checkOption();
                //确定是否到了最后一题
                checkBtnNext();
            }
            else
            {
                openAnswerCard();
            }
        }

        private void openAnswerCard()
        {
            AnswerCardForm answerCard = new AnswerCardForm();
            //answerCard.MdiParent = this.MdiParent;
            answerCard.Show();
            this.Close();
        }

        private void countDown_Tick(object sender, EventArgs e)
        {
            int minute; //当前的分钟
            int second; //秒
            //如果还有剩余时间，就显示剩余的分钟和秒数
            if (TestHelper.remainSeconds > 0)
            {
                TestHelper.remainSeconds--;
                minute = TestHelper.remainSeconds / 60;
                second = TestHelper.remainSeconds % 60;
                lblTimer.Text = string.Format("{0:00}:{1:00}", minute, second);
            }
            else        //否则，提示交卷
            {
                countDown.Stop();
                MessageBox.Show("时间到了，该交卷了！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TestResultForm testResult = new TestResultForm();
                //testResult.MdiParent = this.MdiParent;
                testResult.Show();
                this.Close();
            }
        }

        private void rdoOption_Click(object sender, EventArgs e)
        {
            TestHelper.studentAnswer[index] = ((RadioButton)sender).Tag.ToString();
        }

        private void btnAnswerCard_Click(object sender, EventArgs e)
        {
            openAnswerCard();
        }

        //根据问题的Id，显示题目的详细信息
        public void getQuestionDetails()
        {
            lblQuestion.Text = string.Format("问题{0}", index + 1);
            DBHelper db = new DBHelper();
            string sql = "select question,OptionA,OptionB,OptionC,OptionD from questions where id=" + TestHelper.selectedQuestionId[index];
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        lblQuestionDetails.Text = reader["question"].ToString();
                        rdoOptionA.Text = string.Format("A.{0}", reader["OptionA"].ToString());
                        rdoOptionB.Text = string.Format("B.{0}", reader["OptionB"].ToString());
                        rdoOptionC.Text = string.Format("C.{0}", reader["OptionC"].ToString());
                        rdoOptionD.Text = string.Format("D.{0}", reader["OptionD"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //如果已经答了题目，选中相应的选项
        private void checkOption()
        {
            switch (TestHelper.studentAnswer[index])
            {
                case "A":
                    rdoOptionA.Checked = true;
                    break;
                case "B":
                    rdoOptionB.Checked = true;
                    break;
                case "C":
                    rdoOptionC.Checked = true;
                    break;
                case "D":
                    rdoOptionD.Checked = true;
                    break;
                default:
                    rdoOptionA.Checked = false;
                    rdoOptionB.Checked = false;
                    rdoOptionC.Checked = false;
                    rdoOptionD.Checked = false;
                    break;
            }
        }

    }
}
