using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    public partial class EditScriptFrom : Form
    {
        public EditScriptFrom()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            loadAddScriptContent();
        }

        private void EditScriptFrom_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox5,"点击添加一项");
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadAddScriptContent();
        }

        private void 插入一项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadAddScriptContent();
        }

        private void loadAddScriptContent() {

            AddScriptContent addcon = new AddScriptContent();
            addcon.ShowDialog();
        }
    }
}
