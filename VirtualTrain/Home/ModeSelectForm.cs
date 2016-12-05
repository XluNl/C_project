using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            new CreateRoomForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new loadSceneForm().ShowDialog();
        }
    }
}
