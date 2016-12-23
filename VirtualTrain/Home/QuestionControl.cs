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
            // 点击确定室判断答案是否正确，正确就回调，错误弹出提示信息，并显示正确答案\
            if (!checkInput())
            {
                return;
            }
            if (!checkAnswer(this.ResMode.Answer))
            {
                MessageBox.Show(this.ResMode.Answer, "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.qr(this, 5);
        }

        private void QuestionControl_Load(object sender, EventArgs e)
        {
            this.lblQ.Text = this.ResMode.Question;
            lblA.Text = this.ResMode.OptionA;
            lblB.Text = this.ResMode.OptionB;
            lblC.Text = this.ResMode.OptionC;
            lblD.Text = this.ResMode.OptionD;

        }

        private bool checkInput()
        {
            foreach (GroupBox gb in pnl.Controls)
            {
                foreach (Control con in gb.Controls)
                {
                    if (con is CheckBox)
                    {
                        CheckBox chk = con as CheckBox;
                        if (chk.Checked)
                        {
                            return true;
                        }
                    }
                }
            }
            MessageBox.Show("请选择选择题答案！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private bool checkAnswer(string answerInfo)
        {
            string info = "";
            foreach (GroupBox gb in pnl.Controls)
            {
                foreach (Control con in gb.Controls)
                {
                    if (con is CheckBox)
                    {
                        CheckBox chk = con as CheckBox;
                        if (chk.Checked)
                        {
                            info += chk.Tag.ToString() + ",";
                        }
                    }
                }
            }
            info = info.Substring(0, info.Length - 1);
            string[] infos = info.Split(',');
            if (info.Length == answerInfo.Length)
            {
                foreach (string str in infos)
                {
                    if (!answerInfo.Contains(str))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
