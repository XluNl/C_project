using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using VirtualTrain.common;

namespace VirtualTrain
{
    public partial class CheWuForm : Form
    {
        public CheWuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private static string path = Application.StartupPath + @"\基础知识视频\";
        DirectoryInfo dir = new DirectoryInfo(path);
        private void CheWuForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MaximizedAutoSize(this);
            this.Opacity = 100D;
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                listBox1.Items.Add(file.Name.Substring(0, file.Name.IndexOf('.')));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = path + listBox1.Text+".wmv";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
