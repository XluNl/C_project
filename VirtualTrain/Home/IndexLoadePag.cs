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
    public partial class IndexLoadePag : Form
    {
        ScriptDAL DAL = new ScriptDAL();
        public IndexLoadePag()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexLoadePag_Load(object sender, EventArgs e)
        {
            List<script> scrs = this.DAL.getAllSence();
            if (scrs.Count > 0){
                this.initproject(scrs);
            }else {
                MessageBox.Show("提示!","没有发现可用场景！");
            }   
        }

        private void initproject(List<script> scrs)
        {
            foreach (script item in scrs)
            {
                // 如果有任务模式，则将场景对应的角色全部查出来
                if (item.Isonline == 1)
                {
                    // 加载角色选择页面时，再更具角色id，加载对应角色具体信息
                    item.Sceceroles = this.DAL.getAllScencRoleWithScencid(item.Id);
                }
                this.creatSenceWithMode(item);
            }
        }
        private void creatSenceWithMode(script sc){
        
            int btn_H = 40;
            int btn_X_or = Convert.ToInt32(this.panel2.Width*0.12);
            int btn_Y_or = 15;
            if (this.panel2.Controls.Count>0)
            {
                int y = this.panel2.Controls[this.panel2.Controls.Count - 1].Location.Y;
                
                btn_Y_or = y+ (btn_Y_or+btn_H);
            }
            
            int btn_W = this.panel2.Width-(2*btn_X_or);

            Button btn = new Button();
            btn.Location = new Point(btn_X_or,btn_Y_or);
            btn.Width = btn_W;
            btn.Height = btn_H;
            btn.Tag = sc;
            btn.Text = sc.Scencname;
            btn.Click += btn_Click;
            this.panel2.Controls.Add(btn);
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            script sc = (script)btn.Tag;
            if (sc.Isonline == 1)
            {
                new ModeSelectForm().ShowDialog();
            }
            else { //直接进入教学模式

                new loadSceneForm().ShowDialog();
            }
            
        }
    }
}
