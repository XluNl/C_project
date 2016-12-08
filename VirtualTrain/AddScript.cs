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
    public delegate void call(script scr,int cenceid);
    public partial class AddScript : Form
    {
        ScriptDAL scDAL = new ScriptDAL();
        public AddScript()
        {
            InitializeComponent();
        }

        private call _call;

        public call Call
        {
            get { return _call; }
            set { _call = value; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            // 添加场景到数据库
            script scp = new script();
            scp.Scencname = textBox1.Text;
            scp.Isonline = checkBox9.Checked ? 1 : 0;

            // 获取所有选中的checkbox
            List<script> scencScripts = new List<script>();
            foreach(CheckBox box in this.panel1.Controls){
            
                if(box.Checked){
                    script sc = new script();
                    sc.Screncscriptid = (int)box.Tag;
                    sc.Screncscriptname = box.Text;
                    scencScripts.Add(sc);
                }
            }
            int senceid;
            if (scDAL.addScript(scp, scencScripts,out senceid)) {
               
                this.Call(scp,senceid);
            };

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

            int num = 5; //个数
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
