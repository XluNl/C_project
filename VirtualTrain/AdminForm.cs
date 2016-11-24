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
                    tabControl1.Visible = false;
                    userInfoForm.Show();
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
                    tabControl1.Visible = false;
                    questionInfoForm.Show();
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
            //解决窗体闪烁
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);


            tabControl1.Visible = false;
            ViewHelper.size = this.Size;
            questionInfoForm.MdiParent = this;
            userInfoForm.MdiParent = this;
            questionInfoForm.Show();
            userInfoForm.Show();


            toolTip1.SetToolTip(button1,"配置脚本内容");
            toolTip1.SetToolTip(pictureBox1,"创建一个新的脚本");
        }

        private void 脚本配置_Click(object sender, EventArgs e)
        {
            questionInfoForm.Visible = false;
            userInfoForm.Visible = false;
            tabControl1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddScript addScript = new AddScript();
            addScript.ShowDialog();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditScriptFrom edit = new EditScriptFrom();
            edit.ShowDialog();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 视屏编辑面板调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            loadVideoEditedFrom();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            loadVideoEditedFrom();
        }
        private void loadVideoEditedFrom()
        {
            VideoEditedFrom video = new VideoEditedFrom();
            video.ShowDialog();
        }

        /// <summary>
        /// 图像选择题编辑面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button14_Click(object sender, EventArgs e)
        {
            loadImageSelectFrom();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            loadImageSelectFrom();
        }

        private void loadImageSelectFrom() {

            ImageSelectFrom imgSelect = new ImageSelectFrom();
            imgSelect.ShowDialog();
        }


 



        /// <summary>
        /// 单选题编辑面板调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            loadAddSelectFrom();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadAddSelectFrom();
        }
        private void loadAddSelectFrom()
        {
            AddSelectFrom Select = new AddSelectFrom();
            Select.ShowDialog();
        }


        /// <summary>
        /// 角色编辑面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            loadAddRoleFrom();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadAddRoleFrom();
        }
        private void loadAddRoleFrom()
        {
            AddRoleFrom addRole = new AddRoleFrom();
            addRole.ShowDialog();
        }


    }
}
