using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace VirtualTrain
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //“登录”按钮的单击事件
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                return;     //检查输入
            }
            bool loginResult = false;
            DBHelper db = new DBHelper();
            string sql = "select * from users where loginId='" + txtLoginId.Text + "' and password='" + txtLoginPwd.Text + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        if ((int)reader["state"] != 0)
                        {
                            MessageBox.Show("该用户已被锁定，详细情况请联系管理员！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        rememberPwd();
                        loginResult = true;
                        int roleId = (int)reader["roleId"];
                        UserHelper.loginId = txtLoginId.Text.Trim();
                        if (roleId != 3)
                        {
                            UserHelper.user = UserInfoForm.readerToUser(reader);
                            UserHelper.currentMajorId = (int)reader["majorId"];
                          
                        }
                        switch (roleId)
                        {
                            case 1: UserHelper.loginType = "student";
                                break;
                            case 2: UserHelper.loginType = "teacher";
                                break;
                            case 3: UserHelper.loginType = "admin";
                                break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("数据库连接失败，请检查网络连接！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (loginResult)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("登录失败，请检查用户名或密码是否有误！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

   
             //记住密码
        private void rememberPwd()
        {
           
            if (chkPwd.Checked)
            {
                string str = "";
                string line;
                System.IO.StreamReader sr = new System.IO.StreamReader(txtFileName, Encoding.GetEncoding("gb2312"));
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim().Contains(txtLoginId.Text.Trim()))
                    {
                        break;
                    }
                    str += (line.Trim() + "\n");
                }
                sr.Close();
                if (line == null)
                {
                    str += (txtLoginId.Text.Trim() + "@" + txtLoginPwd.Text.Trim() + "\n");
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(txtFileName, false, Encoding.GetEncoding("gb2312"));
                    sw.Flush();
                    sw.Write(str);
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                string str = "";
                string line;
                System.IO.StreamReader sr = new System.IO.StreamReader(txtFileName, Encoding.GetEncoding("gb2312"));
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim().Contains(txtLoginId.Text.Trim()))
                    {
                        continue;
                    }
                    str += (line.Trim() + "\n");
                }
                sr.Close();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(txtFileName, false, Encoding.GetEncoding("gb2312"));
                sw.Flush();
                sw.Write(str);
                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// 主要用于校验客户端的输入的合法性
        /// </summary>
        /// <returns>true:合法    false:不合法</returns>
        private bool checkInput()
        {
            string userName = txtLoginId.Text.Trim();
            string passWord = txtLoginPwd.Text;
            if (userName == "")
            {
                MessageBox.Show("账号不允许为空！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (passWord == "")
            {
                MessageBox.Show("密码不允许为空！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ViewHelper.X = this.Width;
            ViewHelper.Y = this.Height;
            ViewHelper.setTag(this);
            this.WindowState = FormWindowState.Maximized;
            float newx = (this.Width) / ViewHelper.X;
            float newy = this.Height / ViewHelper.Y;
            ViewHelper.setControls(newx, newy, this);
            this.Opacity = 100D;


            //解决窗体闪烁
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
        }

        string txtFileName = Application.StartupPath + @"\MajorPractice\data\pwd.txt";
        private void txtLoginPwd_Enter(object sender, EventArgs e)
        {
            string line;    //文件内容的一行
            System.IO.StreamReader sr = new System.IO.StreamReader(txtFileName, Encoding.GetEncoding("gb2312"));
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Trim().Contains(txtLoginId.Text.Trim()) && txtLoginId.Text.Trim() != "")
                {
                    txtLoginPwd.Text = line.Trim().Substring(line.Trim().IndexOf('@') + 1);
                    break;
                }
            }
            if (line == null)
            {
                txtLoginPwd.Text = "";
            }
            sr.Close();
        }

        private int i = 0;
        private void viewTime_Tick(object sender, EventArgs e)
        {
            if (i > 3)
            {
                viewTime.Stop();
                this.Opacity = 100D;
            }
            i++;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String name = btn.Name;
            switch (name)
            {
                case "btnLogin":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.登录2;
                    break;
                case "btnCancel":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.退出2;
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
                case "btnLogin":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.登录1;
                    break;
                case "btnCancel":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.退出1;
                    break;

                default:
                    break;
            }
        }

    }
}
