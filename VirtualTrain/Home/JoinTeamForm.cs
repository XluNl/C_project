﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualTrain.Home;
namespace VirtualTrain
{
    public partial class JoinTeamForm : Form
    {
        public JoinTeamForm()
        {
            InitializeComponent();
        }

        private string _pwd;
        public string pwd
        {
            set
            {
                _pwd = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this._pwd.Equals(textBox1.Text))
            {
                new SelectRoleFrom().ShowDialog();
                this.Close();
            }
            else
            {
                lbl.Text = "密码错误";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
