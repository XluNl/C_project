using Common.common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VirtualTrain
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
       static  void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //如果显示进度条，让进度条与主窗体作为独立的窗体显示，主窗体的显示时间比进度条的消失时间慢一秒
            //ProgressBarForm frmFalse = new ProgressBarForm();
            LoginForm frmLogin = new LoginForm();
            //frmFalse.Owner = frmLogin;
            //frmFalse.ShowDialog();

            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                string loginType = UserHelper.loginType;
                Form frmMain = null;
                if (loginType == "teacher")
                {
                    frmMain = new TeacherForm();
                }
                else if (loginType == "admin")
                {
                    frmMain = new AdminForm();
                }
                else
                {
                    frmMain = new StudentForm();
                }
                Application.Run(frmMain);
            }

            //Application.Run(new VRForm());
        }
    }
}
