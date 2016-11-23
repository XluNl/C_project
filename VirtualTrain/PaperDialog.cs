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
    public partial class PaperDialog : Form
    {
        public PaperDialog()
        {
            InitializeComponent();
        }

        //学员id
        private int _stuId;
        public int stuId
        {
            get { return _stuId; }
            set { _stuId = value; }
        }

        //成绩id
        private int _scoreId;
        public int scoreId
        {
            get { return _scoreId; }
            set { _scoreId = value; }
        }

        private void PaperDialog_Load(object sender, EventArgs e)
        {
            showAllQuestions();
        }

        private void showAllQuestions()
        {
            List<Question> blankList = new List<Question>();
            List<Question> shortAnswerList = new List<Question>();
            DBHelper db = new DBHelper();
            string sql = "select a.answer,b.questionId,b.paperId,b.mark from stu_answers a,question_paper b where a.question_paper_id=b.id and a.studentId=" + stuId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Question question = QuestionInfoForm.getQuestionById((int)reader["questionId"]);
                        question.mark = (int)reader["mark"];
                        question.stuAnswer = reader["answer"].ToString();
                        lblPaperName.Text = getPaperNameById((int)reader["paperId"]);
                        switch (question.type)
                        {
                            case "填空题":
                                blankList.Add(question);
                                break;
                            case "简答题":
                                shortAnswerList.Add(question);
                                break;
                            default:
                                break;
                        }
                    }
                }
                layoutAllQuestions(blankList, shortAnswerList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public const int SPACE = 12;
        public static int mark;
        private void layoutAllQuestions(List<Question> blist, List<Question> salist)
        {
            lblPaperName.Location = new Point((this.Width - lblPaperName.Width) / 2, 9);
            mark = lblPaperName.Location.Y + lblPaperName.Height;
            //按下NumericUpDown控件的上或下箭头1s后，数值变化将以5为单位
            NumericUpDownAcceleration acceleration = new NumericUpDownAcceleration(1, 5);
            int i;
            if (blist.Count != 0)
            {
                //填空题
                i = 0;
                Label blbl = new Label();
                blbl.Text = "填空题部分";
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
                    lbl.Height = AnswerDialog.getLineNum(lbl.Text) * SPACE;
                    this.Controls.Add(lbl);
                    lbl.Location = new Point(SPACE, hit);
                    hit += (lbl.Height + 7 * SPACE);
                    Label answerlbl = new Label();
                    answerlbl.Text = "参考答案：" + question.answer;
                    answerlbl.Width = 50 * SPACE;
                    answerlbl.Height = AnswerDialog.getLineNum(answerlbl.Text) * SPACE;
                    this.Controls.Add(answerlbl);
                    answerlbl.Location = new Point(SPACE, lbl.Location.Y + lbl.Height + 6);
                    Label stuAnswerlbl = new Label();
                    stuAnswerlbl.Text = "学员答案：" + question.stuAnswer;
                    stuAnswerlbl.Width = 50 * SPACE;
                    stuAnswerlbl.Height = AnswerDialog.getLineNum(stuAnswerlbl.Text) * SPACE;
                    this.Controls.Add(stuAnswerlbl);
                    stuAnswerlbl.Location = new Point(SPACE, answerlbl.Location.Y + answerlbl.Height + 6);
                    MyNumericUpDown nud = new MyNumericUpDown();
                    nud.Width = 6 * SPACE;
                    nud.Maximum = question.mark;
                    nud.Minimum = 0;
                    nud.Increment = 1;
                    nud.Accelerations.Add(acceleration);
                    this.Controls.Add(nud);
                    nud.Location = new Point(SPACE, stuAnswerlbl.Location.Y + stuAnswerlbl.Height + 6);
                    mark = nud.Location.Y + nud.Height;
                }
            }
            if (salist.Count != 0)
            {
                //简答题
                i = 0;
                Label salbl = new Label();
                salbl.Text = "简答题部分";
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
                    lbl.Height = AnswerDialog.getLineNum(lbl.Text) * SPACE;
                    this.Controls.Add(lbl);
                    lbl.Location = new Point(SPACE, hit);
                    hit += (lbl.Height + 7 * SPACE);
                    Label answerlbl = new Label();
                    answerlbl.Text = "参考答案：" + question.answer;
                    answerlbl.Width = 50 * SPACE;
                    answerlbl.Height = AnswerDialog.getLineNum(answerlbl.Text) * SPACE;
                    this.Controls.Add(answerlbl);
                    answerlbl.Location = new Point(SPACE, lbl.Location.Y + lbl.Height + 6);
                    Label stuAnswerlbl = new Label();
                    stuAnswerlbl.Text = "学员答案：" + question.stuAnswer;
                    stuAnswerlbl.Width = 50 * SPACE;
                    stuAnswerlbl.Height = AnswerDialog.getLineNum(stuAnswerlbl.Text) * SPACE;
                    this.Controls.Add(stuAnswerlbl);
                    stuAnswerlbl.Location = new Point(SPACE, answerlbl.Location.Y + answerlbl.Height + 6);
                    MyNumericUpDown nud = new MyNumericUpDown();
                    nud.Width = 6 * SPACE;
                    nud.Maximum = question.mark;
                    nud.Minimum = 0;
                    nud.Increment = 1;
                    nud.Accelerations.Add(acceleration);
                    this.Controls.Add(nud);
                    nud.Location = new Point(SPACE, stuAnswerlbl.Location.Y + stuAnswerlbl.Height + 6);
                    mark = nud.Location.Y + nud.Height;
                }
            }
            Button btnOk = new Button();
            btnOk.Click += new EventHandler(btnOk_Click);
            btnOk.Text = "提交";
            btnOk.Width = 6 * SPACE;
            btnOk.Height = 2 * SPACE;
            this.Controls.Add(btnOk);
            Button btnCancel = new Button();
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnCancel.Text = "取消";
            btnCancel.Width = 6 * SPACE;
            btnCancel.Height = 2 * SPACE;
            this.Controls.Add(btnCancel);
            btnOk.Location = new Point((this.Width - btnOk.Width - btnCancel.Width) / 3, mark + 3 * SPACE);
            btnCancel.Location = new Point(btnOk.Location.X + btnOk.Width + (this.Width - btnOk.Width - btnCancel.Width) / 3, mark + 3 * SPACE);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            submitScore();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //提交成绩
        private void submitScore()
        {
            DBHelper db = new DBHelper();
            string sql = "update scores set score=" + giveMark() + ",state=1 where id=" + scoreId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //学员最终得分
        private int giveMark()
        {
            int score = 0;
            DBHelper db = new DBHelper();
            string sql = "select score from scores where id=" + scoreId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                score = Convert.ToInt32(db.ExecuteScalar(cmd));
                foreach (Control con in this.Controls)
                {
                    if (con is MyNumericUpDown)
                    {
                        MyNumericUpDown nud = con as MyNumericUpDown;
                        score += (int)nud.Value;
                    }
                }
                return score;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string getPaperNameById(int paperId)
        {
            string paperName = "";
            DBHelper db = new DBHelper();
            string sql = "select name from papers where id=" + paperId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                paperName = db.ExecuteScalar(cmd).ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            return paperName;
        }

    }
}
