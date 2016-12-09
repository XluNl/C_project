using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.Properties;
using VirtualTrain.model;
using VirtualTrain.common;
namespace VirtualTrain
{
    public partial class EditScriptFrom : Form
    {
        private List<TaskModel> _listTask_pub;

        public List<TaskModel> ListTask_pub
        {
            get { return _listTask_pub; }
            set { _listTask_pub = value; }
        }

        TaskDAL DAL = new TaskDAL();
        // 存储添加按钮
        private PictureBox _picbox;

        public PictureBox Picbox
        {
            get { return _picbox; }
            set { _picbox = value; }
        }

        // 存储场景页面 传过来的场景ID
        private int _senceid;

        public int Senceid
        {
            get { return _senceid; }
            set { _senceid = value; }
        }


        public EditScriptFrom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditScriptFrom_Load(object sender, EventArgs e)
        {
            //1、从数据库加载全部任务数据
            this.ListTask_pub =  DAL.getAllWitnSenceID(this.Senceid);

            //2、初始化
            this.initData();
        }

        /// <summary>
        /// init 函数，包含删除，修改，增加，后调用此函数刷新
        /// </summary>
        private void initData() {

            //0、全部清除;
            this.panel_pr.Controls.Clear();

            //2、创建添加按钮
            this.creatAddBtn();
            //3、任务布局
            if (this.ListTask_pub.Count > 0)
            {
                int i = 0;
                foreach (TaskModel str in this.ListTask_pub)
                {
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
            loadAddScriptContent(0);
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
        private void creatRW(TaskModel tast,int id) { 
   
            int pan_H = 70;
            int org = 10;
            int pan_W = Convert.ToInt32(this.panel_pr.Width * 0.88);
            int pan_X = (this.panel_pr.Width - pan_W) / 2;

            // 1、添加一条任务
            GroupBox pan = new GroupBox();
            pan.Text = tast.Taskname;
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
            btn.Text = "任务ID="+tast.Taskid+"  任务name = "+tast.Taskname+" 任务序号 = "+id+"   sort = "+tast.Sortindex+"";
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

        /// <summary>
        /// 修改任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            //int id = (int)btn.GetCurrentParent().Tag;
            loadAddScriptContent(1);
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 插入一项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadAddScriptContent(2);
        }

        /// <summary>
        /// 记载内容编辑页的公共方法
        /// </summary>
        /// <param name="tag">标记，0代表添加；1表示修改；2代表插入</param>
        private void loadAddScriptContent(int tag) {

            AddScriptContent addcon = new AddScriptContent();
            addcon.Call += callAddRW;
            addcon.Senceid = this.Senceid;
            if (tag==1)
            {
                //传入修改的模型
                int index = (int)this.contextMenuStrip1.Tag;
                TaskModel task = new TaskModel();
                task = this.ListTask_pub[index-1];
                addcon.Taskmode = task;
            }
            addcon.Tag1 = tag;
            addcon.ShowDialog();
        }

        /// <summary>
        /// 点击确认后 的回调方法，创建一项任务，更新UI
        /// </summary>
        /// <param name="taskId">任务id</param>
        /// <param name="roleId">角色id</param>
        /// <param name="tg">tag标记（增、插入、改）</param>
        public void callAddRW(TaskModel task, int tg)
        {
            string str = tg == 2 ? "新---插入---的" : "新---添加---的";
            // 0、组织模型
            task.Taskname = str + task.Taskroleid + "";
            // 修改操作
            if (tg == 1){
               if(DAL.editTask(task)){
                   //将修改的值 更新到数据库
                   int index = (int)this.contextMenuStrip1.Tag;
                   TaskModel edTask = this.ListTask_pub[index - 1];
                   edTask.Taskroleid = task.Taskroleid;
                   edTask.Taskid = task.Taskid;
                  }              
            } else {
                // 1、返回创建行的ID
                int taskID = DAL.addOneTask(task);
                task.Keyid = taskID;
                if (taskID > 1)
                {
                    if (tg == 2){//插入操作
                        // 01将模型插入到指定list指定位置
                        int index = (int)this.contextMenuStrip1.Tag;
                        // 02、将模型插入到对应的位置
                        this.ListTask_pub.Insert(index, task);

                    }else{//添加操作
                        // 2、将要创建的模型 添加到数组中
                        this.ListTask_pub.Add(task); 
                    }

                    // 3、插入数据时为数据库中任务重新排序
                    int number = 0;
                    foreach (TaskModel tast in this.ListTask_pub)
                    {
                        number++;
                        tast.Sortindex = number;
                        DAL.sortWithIndex(tast);
                    }
                }
            }
            
            // 3、刷新
            this.initData();
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)this.contextMenuStrip1.Tag;
            //2、获取对应的模型
            TaskModel task = this.ListTask_pub[id - 1];
            //3、更新数据库
            DAL.delectTask(task);
            //4、删除数组对应的模型
            this.ListTask_pub.Remove(task);
            //5、刷新
            this.initData();
        }
    }
}
