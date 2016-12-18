using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    public partial class CreateRoomForm : Form
    {
        public CreateRoomForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 点击创建一个房间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Close();
            new TapCreateRoom().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Close();
            new JoinTeamForm().ShowDialog();
        }

        private void CreateRoomForm_Load(object sender, EventArgs e)
        {

        }
    }
}
