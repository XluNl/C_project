using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;

namespace VirtualTrain
{
    public partial class VideoEditedFrom : Form
    {
        public VideoEditedFrom()
        {
            InitializeComponent();
        }

        private void VideoEditedFrom_Load(object sender, EventArgs e)
        {
            cboMajorsInit(cboMajors);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "请选择要打开的文件";
            //file.InitialDirectory = "c";
            file.Multiselect = false;
            //file.Filter = "视屏文件|*.MP4";
            if (file.ShowDialog() == DialogResult.OK)
            {
                url = file.FileName;
                axwmp.URL = url;
            }
        }

        private static int vid;
        private static string url;

        //video属性
        public Video video
        {
            get
            {
                //根据各控件的值，生成一个video类的实例并返回
                Video video= new Video();
                video.id = vid;
                video.url = url;
                video.name = txtName.Text;
                video.startTime = txtStart.Text;
                video.endTime = txtEnd.Text;

                video.major = cboMajors.Text.Trim();
                return video;
            }
            set
            {
                //根据Video对象的值，设置相应控件
                if (value == null)
                {
                    //如果Video对象为空，则清空各控件
                    txtName.Text = "";
                    txtStart.Text = "";
                    txtEnd.Text = "";
                    cboMajors.Text = "";
                    //axwmp.URL = "";
                }
                else
                {
                    vid = value.id;
                    url= value.url;
                    axwmp.URL = url;
                    //根据Video对象的值，设置相应控件
                    txtName.Text = value.name;
                    txtStart.Text = value.startTime;
                    txtEnd.Text = value.endTime;
                    cboMajors.Text = value.major;
                }
            }
        }

        public static void cboMajorsInit(ComboBox cboMajors)
        {
            cboMajors.Items.Clear();
            DBHelper db = new DBHelper();
            string sql = "select * from majors";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Major major = new Major();
                        major.id = (int)reader["id"];
                        major.name = (string)reader["name"];
                        cboMajors.Items.Add(major);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private static bool isDispose = false;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                return;
            }
            axwmp.Ctlcontrols.stop();
            axwmp.Dispose();
            isDispose = true;
            this.DialogResult = DialogResult.OK;
        }

        private bool checkInput()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入名称！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboMajors.Text.Trim() == "")
            {
                MessageBox.Show("请选择题目所属专业！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtStart.Text.Trim() == "")
            {
                MessageBox.Show("请输入开始时间！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtEnd.Text.Trim() == "")
            {
                MessageBox.Show("请输入结束时间！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(axwmp.URL))
            {
                MessageBox.Show("请选择视频！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void VideoEditedFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isDispose)
            {
                axwmp.Ctlcontrols.stop();
                axwmp.Dispose();
            }
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtStart.Text = axwmp.Ctlcontrols.currentPositionString;
            
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            txtEnd.Text = axwmp.Ctlcontrols.currentPositionString;
            //axwmp.Ctlcontrols.currentPosition= 05 ;
        }

        //private void axwmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        //{
        //    AxWMPLib.AxWindowsMediaPlayer axwmp = (AxWMPLib.AxWindowsMediaPlayer)sender;
        //    if (e.newState==3)
        //    {
        //        axwmp.Ctlcontrols.pause();
        //    }
        //}
    }
}
