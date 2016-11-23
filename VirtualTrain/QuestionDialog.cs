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
    public partial class QuestionDialog : Form
    {
        public QuestionDialog()
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
                question.type = cboTypes.Text.Trim();
                if (question.type.Equals("选择题"))
                {
                    foreach (Control con in innerSplitContainer.Panel2.Controls)
                    {
                        if (con is RadioButton)
                        {
                            RadioButton radioButton = con as RadioButton;
                            if (radioButton.Checked)
                            {
                                question.answer = radioButton.Tag.ToString().Trim();
                                break;
                            }
                        }
                    }
                    question.optionA = txtOptionA.Text;
                    question.optionB = txtOptionB.Text;
                    question.optionC = txtOptionC.Text;
                    question.optionD = txtOptionD.Text;
                }
                else if (question.type.Equals("判断题"))
                {
                    foreach (RadioButton radioButton in innerSplitContainer.Panel1.Controls)
                    {
                        if (radioButton.Checked)
                        {
                            question.answer = radioButton.Text.Trim();
                            break;
                        }
                    }
                }
                else
                {
                    question.answer = txtAnswer.Text;
                }
                question.difficulty = cboDifficulties.Text.Trim();
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
                    txtAnswer.Text = "";
                    cboDifficulties.Text = "";
                    cboMajors.Text = "";
                    cboTypes.Text = "";
                    txtOptionA.Text = "";
                    txtOptionB.Text = "";
                    txtOptionC.Text = "";
                    txtOptionD.Text = "";
                    foreach (Control con in innerSplitContainer.Panel2.Controls)
                    {
                        if (con is RadioButton)
                        {
                            RadioButton radioButton = con as RadioButton;
                            radioButton.Checked = false;
                        }
                    }
                    foreach (RadioButton radioButton in innerSplitContainer.Panel1.Controls)
                    {
                        radioButton.Checked = false;
                    }
                    outerSplitContainer.Panel1Collapsed = true;
                }
                else
                {
                    questionId = value.id;
                    //根据Question对象的值，设置相应控件
                    txtQuestion.Text = value.question;
                    cboDifficulties.Text = value.difficulty;
                    cboMajors.Text = value.major;
                    cboTypes.Text = value.type;
                    if (value.type.Equals("选择题"))
                    {
                        layoutOnSelect();
                        txtOptionA.Text = (value.optionA == null ? "" : value.optionA);
                        txtOptionB.Text = (value.optionB == null ? "" : value.optionB);
                        txtOptionC.Text = (value.optionC == null ? "" : value.optionC);
                        txtOptionD.Text = (value.optionD == null ? "" : value.optionD);
                        foreach (Control con in innerSplitContainer.Panel2.Controls)
                        {
                            if (con is RadioButton)
                            {
                                RadioButton radioButton = con as RadioButton;
                                if (radioButton.Tag.ToString().Trim() == value.answer)
                                {
                                    radioButton.Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (value.type.Equals("判断题"))
                    {
                        layoutOnJudge();
                        foreach (RadioButton radioButton in innerSplitContainer.Panel1.Controls)
                        {
                            if (radioButton.Text.Trim() == value.answer)
                            {
                                radioButton.Checked = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        layoutOnOther();
                        txtAnswer.Text = value.answer;
                    }
                }
            }
        }

        private void QuestionDialog_Load(object sender, EventArgs e)
        {
            cboTypesInit(cboTypes);
            cboMajorsInit(cboMajors);
            //cboDifficultiesInit();
        }

        public static void cboTypesInit(ComboBox cboTypes)
        {
            cboTypes.Items.Clear();
            DBHelper db = new DBHelper();
            string sql = "select * from types";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Type type = new Type();
                        type.id = (int)reader["id"];
                        type.name = (string)reader["name"];
                        cboTypes.Items.Add(type);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
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

        //private void cboDifficultiesInit()
        //{
        //cboDifficulties.Items.Clear();
        //ArrayList list = new ArrayList();
        //DBHelper db = new DBHelper();
        //string sql = "select distinct difficulty from questions";
        //try
        //{
        //    DbCommand cmd = db.GetSqlStringCommand(sql);
        //    using (DbDataReader reader = db.ExecuteReader(cmd))
        //    {
        //        while (reader.Read())
        //        {
        //            list.Add((string)reader["difficulty"]);
        //        }
        //    }
        //    cboDifficulties.Items.AddRange((string[])list.ToArray(typeof(string)));
        //}
        //catch (Exception e)
        //{
        //    throw e;
        //}
        //}

        //获得类型的id
        public static int getTypeId(ComboBox comboBox)
        {
            object item = comboBox.SelectedItem;
            if (item != null)
            {
                Type type = item as Type;
                return type.id;
            }
            else
            {
                return -1;
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

        private void cboTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem.ToString().Equals("选择题"))
            {
                layoutOnSelect();
            }
            else if (((ComboBox)sender).SelectedItem.ToString().Equals("判断题"))
            {
                layoutOnJudge();
            }
            else
            {
                layoutOnOther();
            }
        }

        //题型为选择题时的界面布局
        private void layoutOnSelect()
        {
            outerSplitContainer.Panel1Collapsed = false;
            outerSplitContainer.Panel2Collapsed = true;
            innerSplitContainer.Panel1Collapsed = true;
            innerSplitContainer.Panel2Collapsed = false;
        }

        //题型为判断题时的界面布局
        private void layoutOnJudge()
        {
            outerSplitContainer.Panel1Collapsed = false;
            outerSplitContainer.Panel2Collapsed = true;
            innerSplitContainer.Panel1Collapsed = false;
            innerSplitContainer.Panel2Collapsed = true;
        }

        //题型为其他题时的界面布局
        private void layoutOnOther()
        {
            outerSplitContainer.Panel1Collapsed = true;
            outerSplitContainer.Panel2Collapsed = false;
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
            //if (cboDifficulties.Text.Trim() == "")
            //{
            //    MessageBox.Show("请选择题目难度！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (cboMajors.Text.Trim() == "")
            {
                MessageBox.Show("请选择题目所属专业！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboTypes.Text.Trim() == "")
            {
                MessageBox.Show("请选择题目所属类型！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboTypes.Text.Equals("选择题"))
            {
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
                foreach (Control con in innerSplitContainer.Panel2.Controls)
                {
                    if (con is RadioButton)
                    {
                        RadioButton radioButton = con as RadioButton;
                        if (radioButton.Checked)
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
            }
            else if (cboTypes.Text.Equals("判断题"))
            {
                //判断innerSplitContainer.Panel1中控件是否为空
                bool isNull = true;
                foreach (RadioButton radioButton in innerSplitContainer.Panel1.Controls)
                {
                    if (radioButton.Checked)
                    {
                        isNull = false;
                        break;
                    }
                }
                if (isNull)
                {
                    MessageBox.Show("请选择判断题答案！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (txtAnswer.Text.Trim() == "")
                {
                    MessageBox.Show("请输入答案！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
