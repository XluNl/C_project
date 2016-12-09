using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.Properties;
namespace VirtualTrain
{
    public partial class EditScriptFrom : Form
    {
        private PictureBox _picbox;

        public PictureBox Picbox
        {
            get { return _picbox; }
            set { _picbox = value; }
        }
        public EditScriptFrom()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            loadAddScriptContent();
        }

        private void EditScriptFrom_Load(object sender, EventArgs e)
        {

            //// 0 表是没有数据，1表示有数据

            List<string> liststr = new List<string>();
            liststr.Add("第1条：视频");
            liststr.Add("第2条：图像选择");
            liststr.Add("第3条：文字选择");
            liststr.Add("第4条：视频");
            liststr.Add("第5条：图像选择");

            //1、创建添加按钮
            this.creatAddBtn();
            //2、创建任务
          
            if (1 > 0){//没有数据，显示+号
                int i = 0;
                foreach (string str in liststr){
                    i++;
                    this.creatRW(str,i);
                }
            }

        }

        /// <summary>
        /// 点击添加按钮 添加一条任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRW(object sender, EventArgs e)
        {
            this.creatRW("添加成功-----哈哈哈哈哈哈哈",222);
        }

        /// <summary>
        /// 创建添加任务的按钮
        /// </summary>
        private void creatAddBtn(){
        
            int org = 10;
            int pan_W = Convert.ToInt32(this.panel_pr.Width * 0.88);
            int pan_X = (this.panel_pr.Width - pan_W) / 2;

            int btn_org = (int)(org * 0.5);
            int btn_W = pan_W - org;
            int btn_Y = (int)(org * 1.1);

            this.panel_pr.AutoScroll = true;
            // 添加按钮
            int addimg_H = 45;
            int count = this.panel_pr.Controls.Count;
            PictureBox addimg = new PictureBox();
            addimg.Text = "添加";
            //addimg.BackColor = Color.Red;
            addimg.Size = new Size(btn_W, addimg_H);
            addimg.Click += addRW;
            addimg.Location = new Point(pan_X + btn_org, btn_Y);
            
            addimg.Image = new Bitmap(Resources.add);
            //string str  = Application.StartupPath+"\\add_rw.png";
            //addimg.Image = Image.FromFile(str);
            //addimg.Image = new Bitmap(Application.StartupPath + @"/Resources/add_rw_JT.jpg");
            addimg.SizeMode = PictureBoxSizeMode.Zoom;
            this.panel_pr.Controls.Add(addimg);
            this.Picbox = addimg;
        }
        /// <summary>
        /// 创建任务UI布局
        /// </summary>
        private void creatRW(string content,int id) { 
   
            int pan_H = 70;
            int org = 10;
            int pan_W = Convert.ToInt32(this.panel_pr.Width * 0.88);
            int pan_X = (this.panel_pr.Width - pan_W) / 2;

            // 1、添加一条任务
            GroupBox pan = new GroupBox();
            pan.Text = content;
            pan.Width = pan_W;
            pan.Height = pan_H;
            int count = this.panel_pr.Controls.Count;
            if (count > 1)//说明已经有添加过group元素,默认只有一个加号 index = 0；
            {
                int addimg_Y = this.panel_pr.Controls[count - 1].Location.Y + pan_H;
                pan.Location = new Point(pan_X, addimg_Y);
            }
            else { //还没有添加过

                pan.Location = new Point(pan_X, org);
            }
            this.panel_pr.Controls.Add(pan);//走到这一步已经 才算添加了一个
            

            // 2、更改addimg 的位置
            int newcount = this.panel_pr.Controls.Count;
            int pic_Y = this.panel_pr.Controls[newcount - 1].Location.Y + pan_H;
            this.Picbox.Location = new Point(this.Picbox.Location.X, pic_Y);

            // 3、添加元素
            int btn_W = pan_W - org;
            int btn_H = (pan_H - org) / 2;
            int btn_org = (int)(org * 0.5);
            int btn_Y = (int)(org * 1.1);
            Button btn = new Button();
            btn.Text = content;
            btn.Size = new Size(btn_W, btn_H);
            btn.Location = new Point(btn_org, btn_Y);
            btn.Tag = id;
            // 添加选项卡
            btn.ContextMenuStrip = this.contextMenuStrip1;
            btn.MouseDown += MouseDown;
            pan.Controls.Add(btn);

            PictureBox img = new PictureBox();
            img.Text = "图像";
            //img.BackColor = Color.Blue;
            img.Size = new Size(btn_W, btn_H - btn_org);
            img.Location = new Point(btn_org, btn_Y + btn_H);
            img.Image = new Bitmap(Resources.add);
            //string str = Application.StartupPath + "\\add_rw_JT.jpg";
            //img.Image = Image.FromFile(str);
            img.SizeMode = PictureBoxSizeMode.Zoom;
            pan.Controls.Add(img);
        }

        /// <summary>
        /// 点击右键 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Button btn = (Button)sender;
                int tt = (int)btn.Tag;
                btn.ContextMenuStrip.Tag = btn.Tag;
            }

        }
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            int id = (int)btn.GetCurrentParent().Tag;
            loadAddScriptContent();
        }

        private void 插入一项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadAddScriptContent();
        }

        private void loadAddScriptContent() {

            AddScriptContent addcon = new AddScriptContent();
            addcon.ShowDialog();
        }
    }
}
