using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            SelectDifficultyForm selectDifficulty = new SelectDifficultyForm();
            selectDifficulty.MdiParent = this.MdiParent;
            selectDifficulty.Show();
            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //弹出消息框向用户确认
            DialogResult result = MessageBox.Show("确定要退出吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
