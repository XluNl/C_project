using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;

namespace VirtualTrain
{
    public partial class AddRoleFrom : Form
    {
        public AddRoleFrom()
        {
            InitializeComponent();
        }

        private static int roleId;

        //问题信息
        public Role role
        {
            get
            {
                //根据各控件的值，生成一个Role类的实例并返回
                Role role = new Role();
                role.id = roleId;
                role.name = txtName.Text;

                role.major = cboMajors.Text.Trim();
                return role;
            }
            set
            {
                //根据Role对象的值，设置相应控件
                if (value == null)
                {
                    //如果Role对象为空，则清空各控件
                    txtName.Text = "";
                    cboMajors.Text = "";
                }
                else
                {
                    roleId = value.id;
                    //根据Role对象的值，设置相应控件
                    txtName.Text = value.name;
                    cboMajors.Text = value.major;
                }
            }
        }

        private void AddRoleFrom_Load(object sender, EventArgs e)
        {
            cboMajorsInit(cboMajors);
        }

        public static void cboMajorsInit(ComboBox cboMajors)
        {
            cboMajors.Items.Clear();
            DBHelper db = new DBHelper();
            string sql = "select * from majors";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Major major = new Major();
                        major.id = (int)reader["id"];
                        major.name = (string)reader["name"];
                        cboMajors.Items.Add(major);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
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
                MessageBox.Show("请输入名称！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboMajors.Text.Trim() == "")
            {
                MessageBox.Show("请选择所属专业！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


    }
}
