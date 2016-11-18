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
    public partial class TMISDialogDialog : Form
    {
        public TMISDialogDialog()
        {
            InitializeComponent();
        }







        private void btnHd_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\ss-tmis\hd-run-old\dsp-run-freight.bat";
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

        private void btnXd_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\ss-tmis\xd1-train\fjxd.bat";
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

        private void btnJd_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\ss-tmis\jd-run\jd.bat";
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

        private void btnJh_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = Application.StartupPath + @"\MajorPractice\ss-tmis\jh-run\dsp-run-schd.bat";
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

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.OK;
        //}



    }
}
