using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.common;

namespace VirtualTrain
{
    public partial class ModeSelectForm : Form
    {

        public ModeSelectForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameHelper.mode = GameHelper.Mode.Online;
            this.Opacity = 0;
            this.Close();
            new CreateRoomForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameHelper.mode = GameHelper.Mode.Offline;
            this.Opacity = 0;
            this.Close();
            new loadSceneForm().ShowDialog();
        }

        private void ModeSelectForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
