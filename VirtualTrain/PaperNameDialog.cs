using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using VirtualTrain.common;

namespace VirtualTrain
{
    public partial class PaperNameDialog : Form
    {
        public PaperNameDialog()
        {
            InitializeComponent();
        }

        public string paperName
        {
            get
            {
                return txtName.Text.Trim();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private bool checkInput()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入试卷名称", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtName.Text.Trim().Contains("'"))
            {
                MessageBox.Show("非法的试卷名称", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (checkPaperName(txtName.Text.Trim()))
            {
                MessageBox.Show("已存在试卷" + txtName.Text.Trim() + ",请更改试卷名称", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool checkPaperName(string name)
        {
            DBHelper db = new DBHelper();
            string sql = "select count(*) from papers where name='" + name + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                int count = Convert.ToInt32(db.ExecuteScalar(cmd));
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
