using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.Common;
using System.IO;

namespace VirtualTrain
{
    public partial class VRForm : Form
    {
        public VRForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        TMISDialogDialog tmisDialogDialog;
        private void VRForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MaximizedAutoSize(this);
            this.Opacity = 100D;

            cboMajorsInit();

            btnADX.Tag = 1;
            btnDian.Tag = 2;
            btnZhuan.Tag = 3;
            btnU3D.Tag = 4;
            btnCangku.Tag = 5;

            tmisDialogDialog = new TMISDialogDialog();
            tmisDialogDialog.Owner = this;

            //解决窗体闪烁
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void picMajor_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(((Button)sender).Tag);
            Process process = new Process();
            try
            {
                process.StartInfo.UseShellExecute = false;
                switch (index)
                {
                    case 1:

                        process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\车-教学及模拟操作\TYJL-ADX教学及模拟操作.exe";
                        break;
                    case 2: process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\电-轨道电路故障演练\25hz轨道电路.exe";
                        break;
                    case 3: process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\jixiang.exe";
                        break;
                    //这里写U3D的路径
                    case 4:
                        //if (this.cboMajors.Text == null || this.cboMajors.Text == "")
                        //{
                        //    this.cboMajors.DroppedDown = true;
                        //    return;
                        //}
                        //saveInfo(this.cboMajors.Text + "|" + UserHelper.user.name);
                        //process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\交通轨道4.0.exe";
                        new GameForm().ShowDialog();
                        break;
                    //这里写仓库的路径
                    case 5: process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\ck.exe";
                        break;
                    default:
                        break;
                }
                if (!File.Exists(process.StartInfo.FileName))
                {
                    MessageBox.Show("请检查文件是否存在", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                process.StartInfo.CreateNoWindow = true;
                this.Hide();
                process.Start();
                process.WaitForExit();
                process.Close();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }






        private void picTMIS_Click(object sender, EventArgs e)
        {
            if (tmisDialogDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }


        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String name = btn.Name;
            switch (name)
            {
                case "btnU3D":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.VR虚拟演练2;
                    break;
                case "btnZhuan":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.转辙机拆装2;
                    break;
                case "btnCangku":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.仓库2;
                    break;
                case "btnADX":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.ADX教学2;
                    break;
                case "btnTMIS":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.TMIS2;
                    break;
                case "btnDian":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.轨道电路演练2;
                    break;
                case "btnBack":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.返回2;
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
                case "btnU3D":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.VR虚拟演练1;
                    break;
                case "btnZhuan":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.转辙机拆装1;
                    break;
                case "btnCangku":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.仓库1;
                    break;
                case "btnADX":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.ADX教学1;
                    break;
                case "btnTMIS":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.TMIS1;
                    break;
                case "btnDian":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.轨道电路演练1;
                    break;
                case "btnBack":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.返回1;
                    break;
                default:
                    break;
            }
        }

        private void cboMajors_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                //   cboMajors.Text = UserInfoForm.getMajorByMajorId(UserHelper.currentMajorId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //保存用户名、工种
        String User_name = Application.StartupPath + @"\MajorPractice\data\User_name.txt";
        private void saveInfo(String info)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(User_name, false, Encoding.GetEncoding("utf-8"));
            sw.Flush();
            sw.Write(info);
            sw.Flush();
            sw.Close();
        }


    }
}
