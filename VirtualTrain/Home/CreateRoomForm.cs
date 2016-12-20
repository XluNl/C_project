using Common.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.common;

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

        private void CreateRoomForm_Load(object sender, EventArgs e)
        {
            ClientDAL.GetInstance().ShowRoomEvent += this.showRoom;
            ClientDAL.GetInstance().SendMessage("ShowRoom," + UserHelper.sceneId);
        }

        private void showRoom(string roomInfo)
        {
            gb.Controls.Clear();
            int index = 0;
            int Y_space = 50;
            string[] rooms = roomInfo.Split(';');
            foreach (var room in rooms)
            {
                string[] room_detail = room.Split('_');
                string name = room_detail[0];
                string pwd = room_detail[1];
                string online_num = room_detail[2];
                string max_num = room_detail[3];
                Button btn = new Button();
                btn.Width = 380;
                btn.Height = 25;
                btn.Text = online_num + "/" + max_num;
                btn.Tag = pwd;
                btn.Click += btn_Click;
                gb.Controls.Add(btn);
                btn.Location = new Point(30, Y_space * index);
                index++;
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            JoinTeamForm jtf = new JoinTeamForm();
            jtf.pwd = btn.Tag.ToString();
            jtf.ShowDialog();
        }

    }
}
