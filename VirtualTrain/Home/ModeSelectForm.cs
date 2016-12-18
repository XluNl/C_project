using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    //public delegate void loadSceneDelegate(ModeSelectForm from);
    //public delegate void CreateRoomDelegate(ModeSelectForm from);
    public partial class ModeSelectForm : Form
    {
        //public event loadSceneDelegate loadSceneDele;
        //public event CreateRoomDelegate CreateRoomDele;
        public ModeSelectForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Close();
            new CreateRoomForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Close();
            new loadSceneForm().ShowDialog();
        }
    }
}
