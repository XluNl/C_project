using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Collections;

namespace VirtualTrain
{
    public partial class AnswerDialog : Form
    {
        public AnswerDialog()
        {
            InitializeComponent();
        }

        //试卷id
        private int _paperId;
        public int paperId
        {
            get { return _paperId; }
            set { _paperId = value; }
        }

        private void AnswerDialog_Load(object sender, EventArgs e)
        {
            ExamHelper.remainSeconds = ExamHelper.totalSeconds;
            countDown.Start();
            showAllQuestions();
        }

        List<Question> selectList = new List<Question>();
        List<Question> blankList = new List<Question>();
        List<Question> judgeList = new List<Question>();
        List<Question> shortAnswerList = new List<Question>();
        private void showAllQuestions()
        {
            DBHelper db = new DBHelper();
            string sql = "select * from question_paper where paperId=" + paperId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Question question = QuestionInfoForm.getQuestionById((int)reader["questionId"]);
                        question.mark = (int)reader["mark"];
                        question.question_paper_id = (int)reader["id"];
                        switch (question.type)
                        {
                            case "选择题":
                                selectList.Add(question);
                                break;
                            case "填空题":
                                blankList.Add(question);
                                break;
                            case "判断题":
                                judgeList.Add(question);
                                break;
                            case "简答题":
                                shortAnswerList.Add(question);
                                break;
                            default:
                                break;
                        }
                    }
                }
                ExamHelper.selectAnswers = new String[selectList.Count];
                ExamHelper.judgeAnswers = new String[judgeList.Count];
                layoutAllQuestions(selectList, blankList, judgeList, shortAnswerList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public const int SPACE = 12;
        public static int mark;

        private void layoutAllQuestions(List<Question> slist, List<Question> blist, List<Question> jlist, List<Question> salist)
        {
            lblPaperName.Text = PaperDialog.getPaperNameById(paperId);
            lblTimer.Location = new Point(this.Width - lblTimer.Width - SPACE, 9);
            lblPaperName.Location = new Point((this.Width - lblPaperName.Width) / 2, 9);
            mark = lblPaperName.Location.Y + lblPaperName.Height;
            //大题题号标示
            int j = 1;
            //小题题号标示
            int i;
            if (slist.Count != 0)
            {
                //选择题
                i = 0;
                Label slbl = new Label();
                slbl.Text = "一、选择题";
                j++;
                slbl.AutoSize = true;
                this.Controls.Add(slbl);
                slbl.Location = new Point(SPACE, mark + 2 * SPACE);
                int hit = slbl.Location.Y + 2 * SPACE;
                foreach (Question question in slist)
                {
                    Label lbl = new Label();
                    lbl.Text = (i + 1) + "." + question.question + "(" + question.mark + "分)";
                    i++;
                    lbl.Width = 50 * SPACE;
                    //得到lbl所占行数，从而确定lbl的高度
                    lbl.Height = getLineNum(lbl.Text) * SPACE;
                    this.Controls.Add(lbl);
                    lbl.Location = new Point(SPACE, hit);
                    hit += (lbl.Height + 2 * SPACE);
                    Panel pnl = new Panel();
                    pnl.AutoSize = true;
                    pnl.Height = 2 * SPACE;
                    //pnl.BackColor = Color.Green;
                    this.Controls.Add(pnl);
                    pnl.Location = new Point(SPACE, lbl.Location.Y + lbl.Height);
                    mark = pnl.Location.Y + pnl.Height;
                    String[] str = { "A", "B", "C", "D" };
                    int len = 0;
                    //获得当前问题索引
                    int index = slist.IndexOf(question);
                    foreach (string s in str)
                    {
                        RadioButton rdo = new RadioButton();
                        rdo.Tag = index + "." + s;
                        rdo.Click += new EventHandler(rdo_Click);
                        switch (s)
                        {
                            case "A":
                                rdo.Text = s + "." + question.optionA;
                                break;
                            case "B":
                                rdo.Text = s + "." + question.optionB;
                                break;
                            case "C":
                                rdo.Text = s + "." + question.optionC;
                                break;
                            case "D":
                                rdo.Text = s + "." + question.optionD;
                                break;
                            default:
                                break;
                        }
                        //rdo.BackColor = Color.Gray;
                        rdo.AutoSize = true;
                        pnl.Controls.Add(rdo);
                        rdo.Location = new Point(len, (2 * SPACE - rdo.Height) / 2);
                        len += (rdo.Width + SPACE);
                    }
                }
            }
            if (blist.Count != 0)
            {
                //填空题
                i = 0;
                Label blbl = new Label();
                if (j == 1)
                {
                    blbl.Text = "一、填空题";
                }
                else
                {
                    blbl.Text = "二、填空题";
                }
                j++;
                blbl.AutoSize = true;
                this.Controls.Add(blbl);
                blbl.Location = new Point(SPACE, mark + 2 * SPACE);
                int hit = blbl.Location.Y + 2 * SPACE;
                foreach (Question question in blist)
                {
                    Label lbl = new Label();
                    lbl.Text = (i + 1) + "." + question.question + "(" + question.mark + "分)";
                    i++;
                    lbl.Width = 50 * SPACE;
                    lbl.Height = getLineNum(lbl.Text) * SPACE;
                    this.Controls.Add(lbl);
                    lbl.Location = new Point(SPACE, hit);
                    hit += (lbl.Height + 2 * SPACE);
                    TextBox txt = new TextBox();
                    txt.Tag = question.question_paper_id;
                    txt.Width = 10 * SPACE;
                    this.Controls.Add(txt);
                    txt.Location = new Point(SPACE, lbl.Location.Y + lbl.Height + 2);
                    mark = txt.Location.Y + txt.Height;
                }
            }
            if (jlist.Count != 0)
            {
                //判断题
                i = 0;
                Label jlbl = new Label();
                if (j == 1)
                {
                    jlbl.Text = "一、判断题";
                }
                else if (j == 2)
                {
                    jlbl.Text = "二、判断题";
                }
                else
                {
                    jlbl.Text = "三、判断题";
                }
                j++;
                jlbl.AutoSize = true;
                this.Controls.Add(jlbl);
                jlbl.Location = new Point(SPACE, mark + 2 * SPACE);
                int hit = jlbl.Location.Y + 2 * SPACE;
                foreach (Question question in jlist)
                {
                    Label lbl = new Label();
                    lbl.Text = (i + 1) + "." + question.question + "(" + question.mark + "分)";
                    i++;
                    lbl.Width = 50 * SPACE;
                    lbl.Height = getLineNum(lbl.Text) * SPACE;
                    this.Controls.Add(lbl);
                    lbl.Location = new Point(SPACE, hit);
                    hit += (lbl.Height + SPACE);
                    //获得当前问题索引
                    int index = jlist.IndexOf(question);
                    CheckBox chk = new CheckBox();
                    chk.Tag = index;
                    chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
                    chk.AutoSize = true;
                    this.Controls.Add(chk);
                    chk.Location = new Point(55 * SPACE, lbl.Location.Y);
                    if (getLineNum(lbl.Text) == 1)
                    {
                        mark = chk.Location.Y + chk.Height;
                    }
                    else
                    {
                        mark = lbl.Location.Y + lbl.Height;
                    }
                }
            }
            if (salist.Count != 0)
            {
                //简答题
                i = 0;
                Label salbl = new Label();
                if (j == 1)
                {
                    salbl.Text = "一、简答题";
                }
                else if (j == 2)
                {
                    salbl.Text = "二、简答题";
                }
                else if (j == 3)
                {
                    salbl.Text = "三、简答题";
                }
                else
                {
                    salbl.Text = "四、简答题";
                }
                j++;
                salbl.AutoSize = true;
                this.Controls.Add(salbl);
                salbl.Location = new Point(SPACE, mark + 2 * SPACE);
                int hit = salbl.Location.Y + 2 * SPACE;
                foreach (Question question in salist)
                {
                    Label lbl = new Label();
                    lbl.Text = (i + 1) + "." + question.question + "(" + question.mark + "分)";
                    i++;
                    lbl.Width = 50 * SPACE;
                    lbl.Height = getLineNum(lbl.Text) * SPACE;
                    this.Controls.Add(lbl);
                    lbl.Location = new Point(SPACE, hit);
                    hit += (lbl.Height + 6 * SPACE);
                    TextBox txt = new TextBox();
                    txt.Tag = question.question_paper_id;
                    txt.Multiline = true;
                    txt.Width = 50 * SPACE;
                    txt.Height = 5 * SPACE;
                    this.Controls.Add(txt);
                    txt.Location = new Point(SPACE, lbl.Location.Y + lbl.Height + 2);
                    mark = txt.Location.Y + txt.Height;
                }
            }
            Button btn = new Button();
            btn.Click += new EventHandler(btn_Click);
            btn.Text = "交卷";
            btn.Width = 6 * SPACE;
            btn.Height = 2 * SPACE;
            this.Controls.Add(btn);
            btn.Location = new Point((this.Width - btn.Width) / 2, mark + 3 * SPACE);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            submitPaper();
            this.DialogResult = DialogResult.OK;
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            int index = Convert.ToInt32(chk.Tag);
            if (chk.Checked)
            {
                chk.Text = "√";
                ExamHelper.judgeAnswers[index] = "对";
            }
            else
            {
                chk.Text = "×";
                ExamHelper.judgeAnswers[index] = "错";
            }
        }

        private void rdo_Click(object sender, EventArgs e)
        {
            string[] str = (((RadioButton)sender).Tag.ToString()).Split('.');
            int index = Convert.ToInt32(str[0]);
            ExamHelper.selectAnswers[index] = str[1];
        }

        //评阅选择题及判断题分数
        private int autoGiveMark()
        {
            int score = 0;
            for (int i = 0; i < ExamHelper.selectAnswers.Length; i++)
            {
                if (ExamHelper.selectAnswers[i] == selectList[i].answer)
                {
                    score += selectList[i].mark;
                }
            }
            for (int i = 0; i < ExamHelper.judgeAnswers.Length; i++)
            {
                if (ExamHelper.judgeAnswers[i] == judgeList[i].answer)
                {
                    score += judgeList[i].mark;
                }
            }
            return score;
        }

        //提交试卷
        private void submitPaper()
        {
            using (Trans t = new Trans())
            {
                try
                {
                    addInScores(t);
                    addInAnswers(t);
                    t.Commit();
                }
                catch
                {
                    t.RollBack();
                    //MessageBox.Show(e.Message);
                    MessageBox.Show("试卷提交中发生异常！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void addInScores(Trans t)
        {
            DBHelper db = new DBHelper();
            string sql;
            if (blankList.Count + shortAnswerList.Count == 0)
            {
                sql = "insert into scores values(" + autoGiveMark() + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + UserHelper.user.id + "," + paperId + ",1)";
            }
            else
            {
                sql = "insert into scores values(" + autoGiveMark() + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + UserHelper.user.id + "," + paperId + ",default)";
            }
            DbCommand cmd = db.GetSqlStringCommand(sql);
            if (t == null)
            {
                db.ExecuteNonQuery(cmd);
            }
            else
            {
                db.ExecuteNonQuery(cmd, t);
            }
        }

        private void addInAnswers(Trans t)
        {
            DBHelper db = new DBHelper();
            DbCommand cmd;
            foreach (Control con in this.Controls)
            {
                if (con is TextBox)
                {
                    TextBox txt = con as TextBox;
                    string sql = "insert into stu_answers values('" + txt.Text + "'," + UserHelper.user.id + "," + Convert.ToInt32(txt.Tag) + ")";
                    cmd = db.GetSqlStringCommand(sql);
                    if (t == null)
                    {
                        db.ExecuteNonQuery(cmd);
                    }
                    else
                    {
                        db.ExecuteNonQuery(cmd, t);
                    }
                }
            }
        }

        //得到str所占行数
        public static int getLineNum(string str)
        {
            //行数
            int lineNum = 0;
            //每行字符数
            int characterNumPerLine = 99;
            //字符总数
            int characterNum = 0;
            byte[] strlength = System.Text.Encoding.Default.GetBytes(str);
            characterNum = strlength.Length;
            if (characterNum % characterNumPerLine == 0)
            {
                lineNum = (int)(characterNum / characterNumPerLine);
            }
            else
            {
                lineNum = (int)(characterNum / characterNumPerLine) + 1;
            }
            return lineNum;
        }

        private void countDown_Tick(object sender, EventArgs e)
        {
            int minute; //当前的分钟
            int second; //秒
            //如果还有剩余时间，就显示剩余的分钟和秒数
            if (ExamHelper.remainSeconds > 0)
            {
                ExamHelper.remainSeconds--;
                minute = ExamHelper.remainSeconds / 60;
                second = ExamHelper.remainSeconds % 60;
                lblTimer.Text = string.Format("{0:00}:{1:00}", minute, second);
            }
            else        //否则，提示交卷
            {
                countDown.Stop();
                MessageBox.Show("时间到了，该交卷了！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                submitPaper();
                this.DialogResult = DialogResult.OK;
            }
        }

    }
}
