using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.Common;
using VirtualTrain.common;

namespace VirtualTrain
{
    public partial class BasicForm : Form
    {
        public BasicForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BasicForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MaximizedAutoSize(this);
            this.Opacity = 100D;
            

            btnCW.Tag = 1;
            btnDW.Tag = 2;
            btnGW.Tag = 3;
            btnDD.Tag = 4;
            btnGD.Tag = 5;

        }



        private void picCheWuVideo_Click(object sender, EventArgs e)
        {

            CheWuForm frmCheWu = new CheWuForm();
            this.Hide();
            if (frmCheWu.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }

        }




        private void pictureBox_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(((Button)sender).Tag);
            Process process = new Process();
            try
            {
                process.StartInfo.UseShellExecute = false;
                switch (index)
                {
                    case 1: process.StartInfo.FileName = Application.StartupPath + @"\电子书\车务电子书.exe";
                        break;
                    case 2: process.StartInfo.FileName = Application.StartupPath + @"\电子书\电务电子书.exe";
                        break;
                    case 3: process.StartInfo.FileName = Application.StartupPath + @"\电子书\工务电子书.exe";
                        break;
                    case 4: process.StartInfo.FileName = Application.StartupPath + @"\电子书\调度电子书.exe";
                        break;
                    case 5: process.StartInfo.FileName = Application.StartupPath + @"\电子书\供电电子书.exe";
                        break;
                    default:
                        break;
                }
                process.StartInfo.CreateNoWindow = true;
                this.Hide();
                process.Start();
                process.WaitForExit();
                process.Close();
                this.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String name = btn.Name;
            switch (name)
            {
                case "btnCW":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.车务电子书2;
                    break;
                case "btnDW":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.电务电子书2;
                    break;
                case "btnGD":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.供电电子书2;
                    break;
                case "btnDD":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.调度电子书2;
                    break;
                case "btnGW":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.工务电子书2;
                    break;
                case "btnVideo":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.视频资料2;
                    break;
                case "btnBack":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.返回2;
                    break;
                default:
                    break;
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String name = btn.Name;
            switch (name)
            {
                case "btnCW":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.车务电子书1;
                    break;
                case "btnDW":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.电务电子书1;
                    break;
                case "btnGD":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.供电电子书1;
                    break;
                case "btnDD":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.调度电子书1;
                    break;
                case "btnGW":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.工务电子书1;
                    break;
                case "btnVideo":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.视频资料1;
                    break;
                case "btnBack":
                    btn.BackgroundImage = VirtualTrain.Properties.Resources.返回1;
                    break;
                default:
                    break;
            }
        }



    }
}
