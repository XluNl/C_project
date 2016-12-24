using Common.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.common;
using VirtualTrain.model;
using VirtualTrain.Properties;
namespace VirtualTrain
{
    public partial class IndexLoadePag : Form
    {
        ScriptDAL DAL = new ScriptDAL();

        private Image[] imgs =  {
                                 Resources.g01,
                                 Resources.g02,
                                 Resources.g03,
                                 Resources.g04,
                                 Resources.g05
                                };

        private Font myfont = new Font(new FontFamily("微软雅黑"), 12);
        public IndexLoadePag()
        {
            
            InitializeComponent();

            //this.panel2.BackColor = Color.Transparent;
            //解决窗体闪烁
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.UpdateStyles();
        }

        //private Font myfontWith(int size,params string str) {

        //    string s = str.Length > 0 ? str : "微软雅黑";
        //    int siz = size>1 ? size : 11;
        //    Font myfont = new Font(new FontFamily(s), siz);
        //    return myfont;
        //}
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
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
                MessageBox.Show("提示!","没有可用场景！");
            }
        }

        private void initproject(List<script> scrs)
        {
            int num = 0;
            foreach (script item in scrs)
            {
                if (num >= 5) num = 0;//素材只有5个
                this.creatSenceWithMode(item,this.imgs[num]);
                num++;
            }

            // 添加退出按钮
            Button canlebtn = new Button();
            canlebtn.Text = "退出";
            canlebtn.Location = new Point(panel2.Location.X, panel2.Location.Y + panel2.Height + 20);
            canlebtn.Size = new Size(panel2.Width, 45);
            canlebtn.BackgroundImage = new Bitmap(VirtualTrain.Properties.Resources.g01);
            canlebtn.FlatStyle = FlatStyle.Flat;
            canlebtn.BackgroundImageLayout = ImageLayout.Stretch;
            canlebtn.Font = this.myfont;
            canlebtn.ForeColor = Color.White;
            canlebtn.Click += (oo, evt) =>
            {

                this.Close();
            };
            this.Controls.Add(canlebtn);

        }
        private void creatSenceWithMode(script sc,Image img)
        {

            int btn_H = 40;
            int btn_X_or = Convert.ToInt32(this.panel2.Width * 0.12);
            int btn_Y_or = 15;
            if (this.panel2.Controls.Count > 0)
            {
                int y = this.panel2.Controls[this.panel2.Controls.Count - 1].Location.Y;

                btn_Y_or = y + (btn_Y_or + btn_H);
            }

            int btn_W = this.panel2.Width - (2 * btn_X_or);

            Button btn = new Button();
            btn.Location = new Point(btn_X_or, btn_Y_or);
            btn.Width = btn_W;
            btn.Height = btn_H;
            btn.Tag = sc;
            btn.Text = sc.Scencname;
            btn.Click += btn_Click;
            btn.BackgroundImage = new Bitmap(img);
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.ForeColor = Color.White;
            btn.Font =this.myfont;
            this.panel2.Controls.Add(btn);
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            script sc = (script)btn.Tag;
            UserHelper.sceneId = sc.Id;
            if (sc.Isonline == 1)
            {
                new ModeSelectForm().ShowDialog();
            }
            else
            { //直接进入教学模式

                new LoadSceneForm().ShowDialog();
            }

        }

    }
}
