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
        public ImageControl(TaskModel task)
        {
            InitializeComponent();
            this.curTask = task;
        }

        // 点击确认回调
        public event ICQueRen qr;

        private TaskModel curTask;

        public TaskModel CurTask
        {
            get { return curTask; }
            set { curTask = value; }
        }
       
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
        } 
    }
}
