using Common.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.common;
using VirtualTrain.Home;

namespace VirtualTrain
{
    public partial class TapCreateRoom : Form
    {
        public TapCreateRoom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建完毕，切换到角色选择界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                return;
            }
            ClientDAL.GetInstance().SendMessage("CreateRoom," + UserHelper.sceneId + "," + txtName.Text + "," + txtPwd.Text);
            new SelectRoleFrom().ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        TaskDAL td = new TaskDAL();
        private void TapCreateRoom_Load(object sender, EventArgs e)
        {
            txtMaxNum.Text = td.getAllRoleWithSenceID(UserHelper.sceneId).Count.ToString();
        }

        private bool checkInput()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入名称！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
