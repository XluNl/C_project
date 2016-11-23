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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        ////窗体加载时，将科目从数据库中读取出来显示在组合框中
        //private void SelectSubjectForm_Load(object sender, EventArgs e)
        //{
        //    cboSubjects.Items.Clear();
        //    DBHelper db = new DBHelper();
        //    string sql = "select * from majors where id in(" + UserInfoForm.convertPermission(UserHelper.user.permission) + ")";
        //    try
        //    {
        //        DbCommand cmd = db.GetSqlStringCommand(sql);
        //        using (DbDataReader reader = db.ExecuteReader(cmd))
        //        {
        //            while (reader.Read())
        //            {
        //                Major major = new Major();
        //                major.id = (int)reader["id"];
        //                major.name = (string)reader["name"];
        //                cboSubjects.Items.Add(major);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        //放弃答题，回到学生欢迎界面
        private void btnGiveUp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要放弃此次测试吗？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        //开始答题
        private void btnBegin_Click(object sender, EventArgs e)
        {
            //if (cboSubjects.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请选择科目！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cboSubjects.Focus();
            //}
            //else
            //{
            ////获得选中科目的Id
            //int majorId = getMajorId(cboSubjects);
            //该科目问题总数
            int allQuestionCount = getQuestionCount(UserHelper.currentMajorId, 1);
            if (allQuestionCount < 20)
            {
                MessageBox.Show("该专业题库中没有足够的题目！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //指定所有问题数组的长度
            TestHelper.allQuestionId = new int[allQuestionCount];
            //指定记录问题是否选中的数组的长度
            TestHelper.selectedState = new bool[allQuestionCount];
            //为所有问题数组元素赋值
            setAllQuestionId(UserHelper.currentMajorId);
            //抽题
            setSelectedQuestionId();
            //取出标准答案
            setRightAnswer();
            //剩余时间为20分钟
            TestHelper.remainSeconds = TestHelper.totalSeconds;
            //将学生答案数组初始化
            for (int i = 0; i < TestHelper.studentAnswer.Length; i++)
            {
                TestHelper.studentAnswer[i] = "未回答";
            }
            //打开答题窗体
            AnswerQuestionForm answerQuestion = new AnswerQuestionForm();
            //answerQuestion.MdiParent = this.MdiParent;
            answerQuestion.Show();
            //不能hide，会导致DialogResult不为ok
            this.Opacity = 0D;
            //}
        }

        //获得对应科目的题目的总数
        public static int getQuestionCount(int majorId, int typeId)
        {
            DBHelper db = new DBHelper();
            string sql = "select count(*) from questions where majorId=" + majorId + " and typeId=" + typeId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //获得科目的Id
        public static int getMajorId(ComboBox comboBox)
        {
            object item = comboBox.SelectedItem;
            if (item != null)
            {
                Major major = item as Major;
                return major.id;
            }
            else
            {
                return -1;
            }
        }

        //获得某科目所有问题的id
        private void setAllQuestionId(int majorId)
        {
            DBHelper db = new DBHelper();
            string sql = "select id from questions where majorId=" + majorId + " and typeId=1";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        TestHelper.allQuestionId[i] = (int)reader[0];
                        TestHelper.selectedState[i] = false;
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void setAllQuestionId(int majorId, int typeId)
        {
            DBHelper db = new DBHelper();
            string sql = "select id from questions where majorId=" + majorId + " and typeId=" + typeId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        AutoSetQuestionHelper.allQuestionId[i] = (int)reader[0];
                        AutoSetQuestionHelper.selectedState[i] = false;
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //抽取试题
        private void setSelectedQuestionId()
        {
            Random random = new Random();
            //随机产生问题的索引值
            int index = 0;
            int i = 0;
            while (i < TestHelper.questionNum)
            {
                index = random.Next(TestHelper.allQuestionId.Length);
                if (TestHelper.selectedState[index] == false)
                {
                    TestHelper.selectedQuestionId[i] = TestHelper.allQuestionId[index];
                    TestHelper.selectedState[index] = true;
                    i++;
                }
            }
        }

        public static void setSelectedQuestionId(int questionNum)
        {
            Random random = new Random();
            //随机产生问题的索引值
            int index = 0;
            int i = 0;
            while (i < questionNum)
            {
                index = random.Next(AutoSetQuestionHelper.allQuestionId.Length);
                if (AutoSetQuestionHelper.selectedState[index] == false)
                {
                    AutoSetQuestionHelper.selectedQuestionId[i] = AutoSetQuestionHelper.allQuestionId[index];
                    AutoSetQuestionHelper.selectedState[index] = true;
                    i++;
                }
            }
        }

        //取出试题的标准答案
        private void setRightAnswer()
        {
            for (int i = 0; i < TestHelper.selectedQuestionId.Length; i++)
            {
                int questionId = TestHelper.selectedQuestionId[i];
                TestHelper.correctAnswer[i] = getAnswerByQuestionId(questionId);
            }
        }

        //根据题目编号得题目答案
        private string getAnswerByQuestionId(int questionId)
        {
            DBHelper db = new DBHelper();
            string sql = "select answer from questions where id=" + questionId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                return db.ExecuteScalar(cmd).ToString();
            }
            catch
            {
                return "";
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {
            ViewHelper.X = this.Width;
            ViewHelper.Y = this.Height;
            ViewHelper.setTag(this);
            this.WindowState = FormWindowState.Maximized;
            float newx = (this.Width) / ViewHelper.X;
            float newy = this.Height / ViewHelper.Y;
            ViewHelper.setControls(newx, newy, this);
            this.Opacity = 100D;
        }

    }
}
