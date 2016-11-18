using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Diagnostics;

namespace VirtualTrain
{
    public partial class StudentWelcomeForm : Form
    {
        public StudentWelcomeForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //弹出消息框向用户确认
            DialogResult result = MessageBox.Show("确定要退出吗？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVR_Click(object sender, EventArgs e)
        {
            BasicForm frmBasic = new BasicForm();
            this.MdiParent.Hide();
            if (frmBasic.ShowDialog() == DialogResult.OK)
            {
                this.MdiParent.Show();
            }

        }

        private void StudentWelcomeForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MdiChildrenAutoSize(this);
            this.Dock = DockStyle.Fill;
            cboMajorsInit();
            lblName.Text = UserHelper.user.name;
            //switch (UserHelper.currentMajorId)
            //{
            //    case 1: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.车学;
            //        break;
            //    case 2: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.电学;
            //        break;
            //    case 3: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.工学;
            //        break;
            //    case 4: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.调学;
            //        break;
            //    case 5: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.供学;
            //        break;
            //    default:
            //        break;
            //}
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

        private void btnExamine_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiParent.MdiChildren)
            {
                if (f is StudentFunctionForm)
                {
                    f.Activate();
                    return;
                }
            }
        }

        private void btnBasics_Click(object sender, EventArgs e)
        {
            VRForm frmVR = new VRForm();
            this.MdiParent.Hide();
            if (frmVR.ShowDialog() == DialogResult.OK)
            {
                this.MdiParent.Show();
            }

        }

        private void cboMajors_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserHelper.currentMajorId = QuestionDialog.getMajorId(cboMajors);
            //switch (UserHelper.currentMajorId)
            //{
            //    case 1: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.车学;
            //        break;
            //    case 2: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.电学;
            //        break;
            //    case 3: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.工学;
            //        break;
            //    case 4: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.调学;
            //        break;
            //    case 5: upDownSplitContainer.Panel1.BackgroundImage = VirtualTrain.Properties.Resources.供学;
            //        break;
            //    default:
            //        break;
            //}
        }

        private void btnElectronicSandTable_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = Application.StartupPath + @"\ElectronicSandTable\ElectronicSandTable\bin\Debug\ElectronicSandTable.exe";
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
            //this.MdiParent.Hide();
            //frmMain.ShowDialog();
            //this.MdiParent.Show();
        }

        int HeightZoomIn = 10;
        int WidthZoomIn = 10;
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String name = btn.Name;
            switch (name)
            {
                case "btnVR":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.虚拟演练2;
                    //btn.Height += HeightZoomIn;
                    //btn.Width += WidthZoomIn;
                    break;
                case "btnBasics":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.在线学习2;
                    break;
                case "btnExamine":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.在线考试2;
                    break;
                case "btnElectronicSandTable":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.电子沙盘2;
                    break;
                case "btnExit":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.退出22;
                    break;
                default:
                    break;
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String name = btn.Name;
            switch (name)
            {
                case "btnVR":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.虚拟演练1;
                    //  btn.Height -= HeightZoomIn;
                    //btn.Width -= WidthZoomIn;
                    break;
                case "btnBasics":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.在线学习1;
                    break;
                case "btnExamine":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.在线考试1;
                    break;
                case "btnElectronicSandTable":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.电子沙盘1;
                    break;
                case "btnExit":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.退出11;
                    break;
                default:
                    break;
            }
        }

    }
}
