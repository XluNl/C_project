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
    public partial class TextQuestionDialog : Form
    {
        public TextQuestionDialog()
        {
            InitializeComponent();
        }

        private static int questionId;

        //问题信息
        public Question question
        {
            get
            {
                //根据各控件的值，生成一个Question类的实例并返回
                Question question = new Question();
                question.id = questionId;
                question.question = txtQuestion.Text;
                question.type = "false";
                foreach (Control con in pnlanswer.Controls)
                {
                    if (con is CheckBox)
                    {
                        CheckBox chk = con as CheckBox;
                        if (chk.Checked)
                        {
                            question.answer += chk.Tag.ToString().Trim() + ",";
                        }
                    }
                }
                question.answer = question.answer.Substring(0, question.answer.Length - 1);
                question.optionA = txtOptionA.Text;
                question.optionB = txtOptionB.Text;
                question.optionC = txtOptionC.Text;
                question.optionD = txtOptionD.Text;

                question.major = cboMajors.Text.Trim();
                return question;
            }
            set
            {
                //根据Question对象的值，设置相应控件
                if (value == null)
                {
                    //如果Question对象为空，则清空各控件
                    txtQuestion.Text = "";
                    cboMajors.Text = "";
                    txtOptionA.Text = "";
                    txtOptionB.Text = "";
                    txtOptionC.Text = "";
                    txtOptionD.Text = "";
                    foreach (Control con in pnlanswer.Controls)
                    {
                        if (con is CheckBox)
                        {
                            CheckBox chk = con as CheckBox;
                            chk.Checked = false;
                        }
                    }
                }
                else
                {
                    questionId = value.id;
                    //根据Question对象的值，设置相应控件
                    txtQuestion.Text = value.question;
                    cboMajors.Text = value.major;
                    txtOptionA.Text = (value.optionA == null ? "" : value.optionA);
                    txtOptionB.Text = (value.optionB == null ? "" : value.optionB);
                    txtOptionC.Text = (value.optionC == null ? "" : value.optionC);
                    txtOptionD.Text = (value.optionD == null ? "" : value.optionD);
                    foreach (Control con in pnlanswer.Controls)
                    {
                        if (con is CheckBox)
                        {
                            CheckBox chk = con as CheckBox;
                            string[] answers = value.answer.Split(',');
                            foreach (string str in answers)
                            {
                                if (chk.Tag.ToString().Trim() == str)
                                {
                                    chk.Checked = true;
                                    break;
                                }
                            }

                        }
                    }
                }
            }
        }

        private void QuestionDialog_Load(object sender, EventArgs e)
        {
            cboMajorsInit(cboMajors);
        }


        public static void cboMajorsInit(ComboBox cboMajors)
        {
            cboMajors.Items.Clear();
            DBHelper db = new DBHelper();
            string sql = "select * from majors";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Major major = new Major();
                        major.id = (int)reader["id"];
                        major.name = (string)reader["name"];
                        cboMajors.Items.Add(major);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //获得专业的id
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


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private bool checkInput()
        {
            if (txtQuestion.Text.Trim() == "")
            {
                MessageBox.Show("请输入问题！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboMajors.Text.Trim() == "")
            {
                MessageBox.Show("请选择题目所属专业！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtOptionA.Text.Trim() == "")
            {
                MessageBox.Show("请输入选择题选项A！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtOptionB.Text.Trim() == "")
            {
                MessageBox.Show("请输入选择题选项B！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtOptionC.Text.Trim() == "")
            {
                MessageBox.Show("请输入选择题选项C！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtOptionD.Text.Trim() == "")
            {
                MessageBox.Show("请输入选择题选项D！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //判断innerSplitContainer.Panel2中控件是否为空
            bool isNull = true;
            foreach (Control con in pnlanswer.Controls)
            {
                if (con is CheckBox)
                {
                    CheckBox chk = con as CheckBox;
                    if (chk.Checked)
                    {
                        isNull = false;
                        break;
                    }
                }
            }
            if (isNull)
            {
                MessageBox.Show("请选择选择题答案！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
