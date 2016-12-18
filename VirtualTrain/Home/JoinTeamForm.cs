using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new SelectRoleFrom().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
