using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        UserInfoForm userInfoForm = new UserInfoForm();
        private void UserInfoManage_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is UserInfoForm)
                {
                    f.Activate();
                    return;
                }
            }
        }

        QuestionInfoForm questionInfoForm = new QuestionInfoForm();
        private void QuestionInfoManage_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is QuestionInfoForm)
                {
                    f.Activate();
                    return;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            //弹出消息框向用户确认
            DialogResult result = MessageBox.Show("确定要退出吗？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //如果选择了“是”，退出应用程序
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            ViewHelper.size = this.Size;
            questionInfoForm.MdiParent = this;
            userInfoForm.MdiParent = this;
            questionInfoForm.Show();
            userInfoForm.Show();
        }

    }
}
