using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        private static int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i >= 7)
            {
                timer1.Stop();
                this.Close();
            }
            i++;
        }

        private void FalseForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


    }
}
