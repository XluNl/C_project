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
    public delegate void VCQueRen(VideoControl IC, int tag);
    public partial class VideoControl : UserControl
    {
        //public VideoControl()
        //{
        //    InitializeComponent();
        //}
        // 自定义构造函数
        public VideoControl(TaskModel task)
        {
            InitializeComponent();
            this.curTask = task;
        }
        // 点击确认回调
        public event VCQueRen qr;

        // 存储当前任务模型
        private TaskModel curTask;

        public TaskModel CurTask
        {
            get { return curTask; }
            set { curTask = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.qr(this,4);
        }
    }
}
