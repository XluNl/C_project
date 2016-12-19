using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using VirtualTrain.common;
using Common.model;
using Common.common;

namespace VirtualTrain
{
    public partial class TeacherWelcomeForm : Form
    {
        public TeacherWelcomeForm()
        {

            InitializeComponent();
            //解决窗体闪烁
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
        private void cboMajorsInit()
        {
            cboMajors.Items.Clear();
            DBHelper db = new DBHelper();
            string sql = "select * from majors where id in(" + UserInfoForm.convertPermission(UserHelper.user.permission) + ")";
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
                cboMajors.Text = UserInfoForm.getMajorByMajorId(UserHelper.currentMajorId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TeacherWelcomeForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MdiChildrenAutoSize(this);
            this.Dock = DockStyle.Fill;
            cboMajorsInit();
            lblName.Text = UserHelper.user.name;
            switch (UserHelper.currentMajorId)
            {
                case 1: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.车教;
                    break;
                case 2: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.电教;
                    break;
                case 3: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.工教;
                    break;
                case 4: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.调教;
                    break;
                case 5: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.供教;
                    break;
                default:
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //弹出消息框向用户确认
            DialogResult result = MessageBox.Show("确定要退出吗？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //如果选择了“是”，退出应用程序
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cboMajors_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserHelper.currentMajorId = QuestionDialog.getMajorId(cboMajors);
            switch (UserHelper.currentMajorId)
            {
                case 1: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.车教;
                    break;
                case 2: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.电教;
                    break;
                case 3: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.工教;
                    break;
                case 4: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.调教;
                    break;
                case 5: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.供教;
                    break;
                default:
                    break;
            }
        }

        private void btnExamine_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiParent.MdiChildren)
            {
                if (f is TeacherFunctionForm)
                {
                    f.Activate();
                    return;
                }
            }
        }

        private void btnOnlineTeaching_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\TopDomain\e-Learning Class\TeacherMain.exe";
                process.StartInfo.CreateNoWindow = true;
                this.MdiParent.Hide();
                process.Start();
                process.WaitForExit();
                process.Close();
                this.MdiParent.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
