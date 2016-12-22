using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.model;
namespace VirtualTrain.Home
{

    // 点击确认
    public delegate void ICQueRen(ImageControl IC,int tag);
    public partial class ImageControl : UserControl
    {
        //public ImageControl()
        //{
        //    InitializeComponent();
        //}
        // 自定义构造函数
        public ImageControl(ResouresModel resmod)
        {
            InitializeComponent();
            this.ResMode = resmod;
          
        }

        // 点击确认回调
        public event ICQueRen qr;

        // 存储当前任务模型
        private ResouresModel ResMode{get;set;}
       
        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.qr(this,3);
        }

        /// <summary>
        /// 页面加载时，初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageControl_Load(object sender, EventArgs e)
        {
           //更具当前curmode 初始化控件数据
            this.InItlayout();
        }

        /// <summary>
        /// 初始化UI
        /// </summary>
        private void InItlayout() {

            this.textBox1.Text = this.ResMode.Question;

            // 返回一个数组
            string[] images = this.ResMode.FileName.Split(',');

            foreach (string item in images)
            {
                // 一个图像选项
                Panel pan = new Panel();

                this.panel1.Controls.Add(pan);
            }
           
        }
    }
}
