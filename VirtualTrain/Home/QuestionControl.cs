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
    public delegate void QCQueRen(QuestionControl IC, int tag);
    public partial class QuestionControl : UserControl
    {
        //public QuestionControl()
        //{
        //    InitializeComponent();
        //}
        // 自定义构造函数
        public QuestionControl(ResouresModel resMode)
        {
            InitializeComponent();
            this.ResMode = resMode;
        }
        // 点击确认回调
        public event QCQueRen qr;

        // 存储当前任务模型
        private ResouresModel ResMode { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            // 点击确定室判断答案是否正确，正确就回调，错误弹出提示信息，并显示正确答案
            this.qr(this,5);
        }

        private void QuestionControl_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.ResMode.Question;
        }
    }
}
