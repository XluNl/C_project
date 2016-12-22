using Common.common;
using Common.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.common;

namespace VirtualTrain.Home
{
    public partial class SelectRoleFrom : Form
    {
        public SelectRoleFrom()
        {
            InitializeComponent();
        }

        TaskDAL td = new TaskDAL();
        private string roleId;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ClientDAL.GetInstance().SendMessage("Login," + roleId);
            ClientDAL.GetInstance().SendMessage("ShowState");

            pnls.Enabled = false;
            btn_login.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectRoleFrom_Load(object sender, EventArgs e)
        {
            initView();
            ClientDAL.GetInstance().Register(new ClientDAL.ShowHandler(this.showstate));
            ClientDAL.GetInstance().Register(new ClientDAL.OperateHandler(this.startgame));

            ClientDAL.GetInstance().SendMessage("ShowState");
        }

        private void initView()
        {
            int space = 30;
            int index = 0;
            List<Role> roles = td.getAllRoleWithSenceID(UserHelper.sceneId);
            foreach (Role role in roles)
            {
                Panel pnl = new Panel();
                pnl.Width = 123;
                pnl.Height = 112;
                pnls.Controls.Add(pnl);
                pnl.Location = new Point(17 + index * (pnl.Width + space), 26);
                index++;

                PictureBox pic = new PictureBox();
                pic.Image = VirtualTrain.Properties.Resources.picgongdian;
                pic.Width = 106;
                pic.Height = 87;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pnl.Controls.Add(pic);
                pic.Location = new Point(8, 3);

                Button btn = new Button();
                btn.Click += btn_Click;
                btn.Text = role.name;
                btn.Tag = role.id;
                btn.Width = 117;
                btn.Height = 23;
                pnl.Controls.Add(btn);
                btn.Location = new Point(3, 89);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            foreach (Control con in pnls.Controls)
            {
                foreach (Control c in con.Controls)
                {
                    if (c is Button)
                    {
                        Button btn = c as Button;
                        btn.BackColor = SystemColors.Control;
                    }
                }

            }
            Button selectedBtn = (Button)sender;
            roleId = selectedBtn.Tag.ToString();
            selectedBtn.BackColor = Color.Red;
        }

        private void showstate(string info)
        {
            string[] ids = info.Split('_');
            foreach (string id in ids)
            {
                foreach (Control con in pnls.Controls)
                {
                    foreach (Control c in con.Controls)
                    {
                        if (c is Button)
                        {
                            Button btn = c as Button;
                            if (btn.Tag.ToString().Equals(id))
                            {
                                InvokeShowState(btn);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private delegate void InvokeShowStateDelegate(Button btn);
        private void InvokeShowState(Button btn)
        {
            if (btn.InvokeRequired)
            {
                InvokeShowStateDelegate d = new InvokeShowStateDelegate(InvokeShowState);
                btn.Invoke(d, btn);
            }
            else
            {
                btn.Text = "准备";
                btn.Enabled = false;
            }
        }

        private void startgame()
        {
            InvokeStartGame();
        }

        private delegate void InvokeStartGameDelegate();
        private void InvokeStartGame()
        {
            if (this.InvokeRequired)
            {
                InvokeStartGameDelegate isgd = new InvokeStartGameDelegate(InvokeStartGame);
                this.Invoke(isgd);
            }
            else
            {
                this.Opacity = 0;
                this.Close();
                new loadSceneForm().ShowDialog();
            }
        }
    }
}
