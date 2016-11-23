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
    public partial class UserDialog : Form
    {
        public UserDialog()
        {
            InitializeComponent();
        }

        private void UserDialog_Load(object sender, EventArgs e)
        {
            button2.DialogResult = DialogResult.Cancel;
            //设置stateButton上的文字
            if (state == 0)
            {
                stateButton.Text = "锁定";
            }
            else
            {
                stateButton.Text = "解锁";
            }
        }

        private static int userId;
        private static int state;

        //用户信息
        public User user
        {
            get
            {
                //根据各控件的值，生成一个User类的实例并返回
                User user = new User();
                user.id = userId;
                user.state = state;
                user.loginId = textBox1.Text.Trim();
                user.password = textBox2.Text.Trim();
                user.name = textBox3.Text.Trim();
                foreach (RadioButton radioButton in panel1.Controls)
                {
                    if (radioButton.Checked)
                    {
                        user.major = radioButton.Text.Trim();
                        break;
                    }
                }
                foreach (RadioButton radioButton in panel2.Controls)
                {
                    if (radioButton.Checked)
                    {
                        user.role = radioButton.Text.Trim();
                        break;
                    }
                }
                string permission = "";
                foreach (CheckBox checkBox in panel3.Controls)
                {
                    if (checkBox.Checked)
                    {
                        permission += (checkBox.Text.Trim() + ",");
                    }
                }
                permission = permission.Substring(0, permission.Length - 1);
                user.permission = permission;
                return user;
            }
            set
            {
                //根据User对象的值，设置相应控件
                if (value == null)
                {
                    panel3.Enabled = false;
                    stateButton.Visible = false;
                    //如果User对象为空，则清空各控件
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    state = 0;
                    foreach (RadioButton radioButton in panel1.Controls)
                    {
                        radioButton.Checked = false;
                    }
                    foreach (RadioButton radioButton in panel2.Controls)
                    {
                        radioButton.Checked = false;
                    }
                    foreach (CheckBox checkBox in panel3.Controls)
                    {
                        checkBox.Checked = false;
                    }
                }
                else
                {
                    stateButton.Visible = true;
                    userId = value.id;
                    state = value.state;
                    //根据User对象的值，设置相应控件
                    textBox1.Text = value.loginId;
                    textBox2.Text = value.password;
                    textBox3.Text = value.name;
                    foreach (RadioButton radioButton in panel1.Controls)
                    {
                        if (value.major == radioButton.Text.Trim())
                        {
                            radioButton.Checked = true;
                            break;
                        }
                    }
                    foreach (RadioButton radioButton in panel2.Controls)
                    {
                        if (value.role == radioButton.Text.Trim())
                        {
                            radioButton.Checked = true;
                            break;
                        }
                    }
                    string[] str = value.permission.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        foreach (CheckBox checkBox in panel3.Controls)
                        {
                            if (str[i] == checkBox.Text.Trim())
                            {
                                checkBox.Checked = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private bool checkInput()
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (checkLoginId(textBox1.Text.Trim()))
            //{
            //    MessageBox.Show("用户名" + textBox1.Text.Trim() + "已存在！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户姓名！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //判断panel1中控件是否为空
            bool isNull = true;
            foreach (RadioButton radioButton in panel1.Controls)
            {
                if (radioButton.Checked)
                {
                    isNull = false;
                    break;
                }
            }
            if (isNull)
            {
                MessageBox.Show("请选择用户专业！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //判断panel2中控件是否为空
            isNull = true;
            foreach (RadioButton radioButton in panel2.Controls)
            {
                if (radioButton.Checked)
                {
                    isNull = false;
                    break;
                }
            }
            if (isNull)
            {
                MessageBox.Show("请选择用户角色！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = radioButton1.Checked;
            panel3.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = radioButton2.Checked;
            panel3.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = radioButton3.Checked;
            panel3.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Checked = radioButton4.Checked;
            panel3.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = radioButton5.Checked;
            panel3.Enabled = true;
        }

        private void stateButton_Click(object sender, EventArgs e)
        {
            if (state == 1)
            {
                state = 0;
                stateButton.Text = "锁定";
            }
            else
            {
                state = 1;
                stateButton.Text = "解锁";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
