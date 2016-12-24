using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.model;
using System.Configuration;
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
        public VideoControl(ResouresModel resmod)
        {
            InitializeComponent();
            this.ResMode = resmod;
        }

        // 点击确认回调
        public event VCQueRen qr;


        private static string v_path = ConfigurationManager.AppSettings["video_path"];
        // 存储当前任务模型
        public ResouresModel ResMode { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.qr(this, 4);
        }

        private void VideoControl_Load(object sender, EventArgs e)
        {
            this.lbl.Text = this.ResMode.Question;
            wmp.URL = v_path + @"\" + ResMode.FileName;
        }
    }
}
