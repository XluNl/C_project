using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.common;
using VirtualTrain.model;
namespace VirtualTrain
{
    public partial class AddScript : Form
    {
        public AddScript()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddScript_Load(object sender, EventArgs e)
        {
            // 加载全部角色

            ScriptDAL scrDAL = new ScriptDAL();
            List<VR_Role> scrs = scrDAL.getRolesWith();

            int num = 6; //个数
            int org = 10;//间隙
            int with = this.panel1.Width; //父控件with
            double check_w = (with - ((num + 1) * org)) / num;//计算控件with
            int check_h = 20;
            int i = 0;
            foreach (VR_Role bi in scrs)
            {
                int row = i / num;
                int colum = i % num;
                double check_X = (colum * (check_w + org)) + org;
                CheckBox check = new CheckBox();
                check.Text = bi.Name;
                check.Tag = bi.Id;
                check.Location = new Point((int)check_X, org+row*(check_h+org));
                check.BackColor = Color.Gray;
                this.panel1.AutoScroll = true;
                this.panel1.Controls.Add(check);
                i++;
            }
        }
    }
}
