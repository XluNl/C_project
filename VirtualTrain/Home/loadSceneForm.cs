using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VirtualTrain.Home;
using VirtualTrain.model;
using Common.model;
using Common.common;
namespace VirtualTrain
{
    public partial class loadSceneForm : Form
    {
        TaskDAL DAL = new TaskDAL();

        // 默认第一条元素
        private int curTaskId = 0;
        private List<TaskModel> _taskmodes;
        //根据场景ID获取场景全部task实体
        public List<TaskModel> Taskmodes
        {
            get {
                _taskmodes = this.DAL.getAllWitnSenceID(UserHelper.sceneId);
                return _taskmodes; 
            }
            set { _taskmodes = value; }
        }
        private List<ResouresModel> _resModes;

        //根据tast实体，获取全部res资源实体
        public List<ResouresModel> ResModes
        {
            get {
                List<ResouresModel> temp = new List<ResouresModel>();
                foreach (TaskModel item in this.Taskmodes)
                {
                    temp.Add(DAL.getOneResourcesWithId(item.Taskid));
                }
                _resModes = temp;
                return _resModes;
            }
            set { _resModes = value; }
        }
        public loadSceneForm()
        {
            InitializeComponent();
           
            this.panel1.BackColor = Color.Transparent;
            this.panel2.BackColor = Color.Transparent;
            this.panel3.BackColor = Color.Transparent;
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox2.BackColor = Color.Transparent;
            //解决窗体闪烁
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private delegate void WaitDelegate();

        private void wait()
        {
            //if (pnlquestion.InvokeRequired)
            //{
            //    WaitDelegate w = new WaitDelegate(wait);
            //    pnlquestion.Invoke(w, new object[] { });
            //}
            //else
            //{
            //    pnlquestion.Enabled = false;
            //}
        }


////////////////////////////////////////////////////////////////////////////////////////////////////
        private void loadSceneForm_Load(object sender, EventArgs e)
        {
            this.InItdata();
        }

        private void InItdata()
        {
            // 1、每次创建之前，先移除之前的
            this.panel1.Controls.Clear();

            // 2、创建
            ResouresModel res = this.ResModes[this.curTaskId];

            this.creatDispaypanelWithRestype(res);
        }
        /// <summary>
        /// 根据资源类型创建 展示面板
        /// </summary>
        /// <param name="type">0、文字 2、图像 3、视频</param>
        private void creatDispaypanelWithRestype(ResouresModel resmode){

            switch (resmode.Type)
            {
                case 0:
                    this.creatQuestionBy(resmode);
                    break;
                case 1:
                    this.creatImageBy(resmode);
                    break;
                case 2:
                    this.creatVideoBy(resmode);
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// 创建视频
        /// </summary>
        /// <param name="taskmode"></param>
        public void creatVideoBy(ResouresModel resmode)
        {
            VideoControl vc = new VideoControl(resmode);
            vc.Size = this.panel1.Size;
            vc.qr += (VideoControl v, int tag) =>
            {
                //1、创建一个新的元素时，将当前这个删除
                v.Dispose();
                //2、创建
                MessageBox.Show("创建一个VideoControl-------" + tag.ToString());
                //3、创建下一个
                this.button2_Click(this, new EventArgs());
            };
            this.panel1.Controls.Add(vc);
        }
 
     
        /// <summary>
        /// 创建常规多选题
        /// </summary>
        /// <param name="taskmode"></param>
        public void creatQuestionBy(ResouresModel resmode)
        {
            QuestionControl QC = new QuestionControl(resmode);
            QC.Size = this.panel1.Size;
            QC.qr += (QuestionControl v, int tag) =>
            {
                //1、创建一个新的元素时，将当前这个删除
                v.Dispose();
                //2、创建
                MessageBox.Show("创建一个Question-------" + tag.ToString());
                //3、创建下一个
                this.button2_Click(this, new EventArgs());
            };
            this.panel1.Controls.Add(QC);
        }

       
        /// <summary>
        /// 创建img多选
        /// </summary>
        /// <param name="taskmode"></param>
        public void creatImageBy(ResouresModel resmode)
        {
            ImageControl IC = new ImageControl(resmode);
            IC.Size = this.panel1.Size;
            IC.qr += (ImageControl v, int tag) =>
            {
                //1、创建一个新的元素时，将当前这个删除
                v.Dispose();
                //2、创建
                MessageBox.Show("创建一个ImageControl-------" + tag.ToString());
                //3、创建下一个
                this.button2_Click(this, new EventArgs());
            };
            this.panel1.Controls.Add(IC);
        }

        /// <summary>
        /// 上一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //
            if (this.curTaskId<=0)
            {
                this.curTaskId=0;
                return;
            }
            this.curTaskId--;
            this.InItdata();
        }
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.curTaskId>=this.ResModes.Count-1)
            {
                this.curTaskId = this.ResModes.Count - 1;
                return;
            }
            this.curTaskId++;
            this.InItdata();
        }

        

    }
}
