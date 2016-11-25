﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "请选择要打开的文件";
            //file.InitialDirectory = "c";
            file.Multiselect = false;
            file.Filter = "文本文件|*.txt|图片文件|*.jpg|视屏文件|*.MP4";
            file.ShowDialog();
        }
    }
}
