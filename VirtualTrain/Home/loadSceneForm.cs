using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VirtualTrain.model;

namespace VirtualTrain
{
    public partial class loadSceneForm : Form
    {
        public loadSceneForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private delegate void WaitDelegate();

        private void wait()
        {
            //if (pnlquestion.InvokeRequired)
            //{
            //    WaitDelegate w = new WaitDelegate(wait);
            //    pnlquestion.Invoke(w, new object[] { });
            //}
            //else
            //{
            //    pnlquestion.Enabled = false;
            //}
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
