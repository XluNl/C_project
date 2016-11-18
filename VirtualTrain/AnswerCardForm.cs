using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    public partial class AnswerCardForm : Form
    {
        public AnswerCardForm()
        {
            InitializeComponent();
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
                testResult.MdiParent = this.MdiParent;
                testResult.Show();
                this.Close();
            }
        }

        Button[] btns = new Button[TestHelper.questionNum];
        Label[] lbls = new Label[TestHelper.questionNum];
        private void AnswerCardForm_Load(object sender, EventArgs e)
        {
            layoutInit();
            ViewHelper.MaximizedAutoSize(this);
            this.Opacity = 100D;
            for (int i = 0; i < TestHelper.questionNum; i++)
            {
                btns[i].Tag = i;
                lbls[i].Tag = i;
            }
            lblTimer.Tag = -1;
            countDown.Start();
            int index = 0;
            foreach (Control item in CommonPanel.Controls)
            {
                if (item is Label)
                {
                    index = Convert.ToInt32(item.Tag);
                    if (index != -1)
                    {
                        item.Text = TestHelper.studentAnswer[index];
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //创建答题结果窗体并显示，关闭当前窗体
            TestResultForm testResult = new TestResultForm();
            //testResult.MdiParent = this.MdiParent;
            testResult.Show();
            this.Close();
        }

        //转到相应的题目
        private void btnQuestion_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(((Button)sender).Tag);
            AnswerQuestionForm answerQuestion = new AnswerQuestionForm();
            answerQuestion.index = index;
            //answerQuestion.MdiParent = this.MdiParent;
            answerQuestion.Show();
            this.Close();
        }

        public const int SPACE = 12;
        private void layoutInit()
        {
            int wid = SPACE;
            int hit = lblTimer.Location.Y + 2 * SPACE;
            for (int i = 0; i < TestHelper.questionNum; i++)
            {
                wid += 10 * SPACE;
                if (i % 5 == 0)
                {
                    wid = SPACE;
                    hit += 4 * SPACE;
                }
                Button btn = new Button();
                //btn.Tag = i;
                btn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                btn.Click += new EventHandler(btnQuestion_Click);
                btn.Text = (i + 1) + "";
                btn.Width = 4 * SPACE;
                btn.Height = 2 * SPACE;
                CommonPanel.Controls.Add(btn);
                btn.Location = new Point(wid, hit);
                btns[i] = btn;
                Label lbl = new Label();
                //lbl.Tag = i;
                lbl.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                lbl.AutoSize = true;
                CommonPanel.Controls.Add(lbl);
                lbl.Location = new Point(btn.Location.X + btn.Width + SPACE, btn.Location.Y + (btn.Height - lbl.Height) / 2);
                lbls[i] = lbl;
            }
        }

    }
}
