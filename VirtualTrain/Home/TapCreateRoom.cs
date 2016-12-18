using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

            this.Close();
        }
    }
}
