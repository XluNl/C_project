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
    public delegate void ICQueRen(ImageControl IC, int tag);
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
        private ResouresModel ResMode { get; set; }

        //动态图片相关参数
        //private static string i_path = @"\\" + ConfigurationManager.AppSettings["ip"] + ConfigurationManager.AppSettings["img_net_path"];
        private static string i_path = ConfigurationManager.AppSettings["img_net_path"];
        private static List<string> optionList = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        int currentOption = 0;
        private static int space = 30;
        private static int vspace = 30;
        private static int initX = 20;
        private static int initY = 20;

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 点击确定答案是否正确，正确就回调，错误弹出提示信息，并显示正确答案\
            if (!checkInput())
            {
                return;
            }
            if (!checkAnswer(this.ResMode.Answer))
            {
                MessageBox.Show(this.ResMode.Answer, "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.qr(this, 3);
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
        private void InItlayout()
        {

            this.lbl.Text = this.ResMode.Question;

            // 返回一个数组
            string[] images = this.ResMode.FileName.Split(',');

            foreach (string item in images)
            {
                // 一个图像选项
                generatePicBox(item);
            }

        }

        private void generatePicBox(string fileName)
        {
            PictureBox pic = new PictureBox();
            pic.Tag = optionList[currentOption];

            pic.Load(i_path + @"\" + fileName);
            pic.Width = 100;
            pic.Height = 100;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            pnl.Controls.Add(pic);
            pic.Location = new Point((currentOption % 5) * (pic.Width + space) + initX, (currentOption > 4 ? 1 : 0) * (pic.Height + vspace) + initY);
            currentOption++;
            generateCheckBox(pic.Tag.ToString(), pic.Location);
        }

        private void generateCheckBox(string tag, Point point)
        {
            CheckBox chk = new CheckBox();
            chk.Tag = tag;
            chk.Checked = false;
            chk.BringToFront();
            pnl.Controls.Add(chk);
            chk.Location = new Point(point.X - 20, point.Y + 50);
        }

        private bool checkInput()
        {
            foreach (Control con in pnl.Controls)
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
            MessageBox.Show("请选择答案！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private bool checkAnswer(string answerInfo)
        {
            string info = "";
            foreach (Control con in pnl.Controls)
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
