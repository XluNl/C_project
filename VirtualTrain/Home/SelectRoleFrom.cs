﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain.Home
{
    public partial class SelectRoleFrom : Form
    {
        public SelectRoleFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new loadSceneForm().ShowDialog();
        }
    }
}
