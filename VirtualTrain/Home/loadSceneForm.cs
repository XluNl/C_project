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

namespace VirtualTrain
{
    public partial class loadSceneForm : Form
    {
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

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }


////////////////////////////////////////////////////////////////////////////////////////////////////
        private void loadSceneForm_Load(object sender, EventArgs e)
        {

           
            //测试 默认加载一个视频任务
            this.creatVideoBy(new TaskModel());

        }

        /// <summary>
        /// 创建视频
        /// </summary>
        /// <param name="taskmode"></param>
        public void creatVideoBy(TaskModel taskmode) {

            VideoControl vc = new VideoControl(taskmode);
            vc.Size = this.panel1.Size;
            vc.qr += VCCallBackByQR;
            this.panel1.Controls.Add(vc);
        }
        // voideo确认回调方法
        private void VCCallBackByQR(VideoControl VC, int tag)
        {
            //1、创建一个新的元素时，将当前这个删除
            VC.Dispose();
            //2、创建
            MessageBox.Show("创建一个Question-------" + tag.ToString());
            this.creatQuestionBy(new TaskModel());
        }
       
        /// <summary>
        /// 创建常规多选题
        /// </summary>
        /// <param name="taskmode"></param>
        public void creatQuestionBy(TaskModel taskmode)
        {
            QuestionControl QC = new QuestionControl(taskmode);
            QC.Size = this.panel1.Size;
            QC.qr += QCCallBackByQR;
            this.panel1.Controls.Add(QC);
        }
        // Question确认回调方法
        private void QCCallBackByQR(Control QC, int tag)
        {
 
            //1、创建一个新的元素时，将当前这个删除;
            QC.Dispose();
            //2、创建
            MessageBox.Show("创建一个Image-------" + tag.ToString());
            this.creatImageBy(new TaskModel());
        }
      
        
        /// <summary>
        /// 创建img多选
        /// </summary>
        /// <param name="taskmode"></param>
        public void creatImageBy(TaskModel taskmode)
        {
            ImageControl IC = new ImageControl(taskmode);
            IC.Size = this.panel1.Size;
            IC.qr += ImgCallBackByQR;
            this.panel1.Controls.Add(IC);
        }

        // images确认回调方法
        private void ImgCallBackByQR(ImageControl IC, int tag)
        {
            //1、创建一个新的元素时，将当前这个删除
            IC.Dispose();
            //2、创建
            MessageBox.Show("创建一个Video-------" + tag.ToString());
            this.creatVideoBy(new TaskModel());
        }

    }
}
