using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using VirtualTrain.common;

namespace VirtualTrain
{
    public partial class BatchDialog : Form
    {
        public BatchDialog()
        {
            InitializeComponent();
        }

        private void BatchDialog_Load(object sender, EventArgs e)
        {
            QuestionDialog.cboMajorsInit(cboMajors);
            QuestionDialog.cboTypesInit(cboTypes);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                return;
            }
            if (ofdExcel.ShowDialog() == DialogResult.OK)
            {
                if (ReadExcel(ofdExcel.FileName))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("题库读取中发生异常！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool ReadExcel(string sExcelFile)
        {
            DBHelper oleDb;
            DBHelper sqlDb = new DBHelper();
            string connectionString;
            string dbProviderName = "System.Data.OleDb";
            string fileType = System.IO.Path.GetExtension(sExcelFile);
            if (string.IsNullOrEmpty(fileType))
            {
                return false;
            }
            if (fileType == ".xls")
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sExcelFile + ";" + "Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                oleDb = new DBHelper(connectionString, dbProviderName);
            }
            else
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sExcelFile + ";" + "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
                oleDb = new DBHelper(connectionString, dbProviderName);
            }
            OleDbConnection conn = new OleDbConnection(connectionString);
            conn.Open();
            System.Data.DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            conn.Close();
            if (dt.Rows.Count > 1)
            {
                MessageBox.Show("只支持对单工作表Excel文件的导入！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string sheetName = dt.Rows[0][2].ToString();
            string sql;
            string oleSql = "select * from [" + sheetName + "]";
            int result = 0;
            try
            {
                DbCommand cmd = oleDb.GetSqlStringCommand(oleSql);
                using (DbDataReader reader = oleDb.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        string reader0, reader1, reader2, reader3, reader4, reader5;
                        reader0 = (reader[0].ToString().Contains("'")) ? (reader[0].ToString().Replace("'", "''")) : (reader[0].ToString());
                        reader1 = (reader[1].ToString().Contains("'")) ? (reader[1].ToString().Replace("'", "''")) : (reader[1].ToString());
                        reader2 = (reader[2].ToString().Contains("'")) ? (reader[2].ToString().Replace("'", "''")) : (reader[2].ToString());
                        reader3 = (reader[3].ToString().Contains("'")) ? (reader[3].ToString().Replace("'", "''")) : (reader[3].ToString());
                        reader4 = (reader[4].ToString().Contains("'")) ? (reader[4].ToString().Replace("'", "''")) : (reader[4].ToString());
                        reader5 = (reader[5].ToString().Contains("'")) ? (reader[5].ToString().Replace("'", "''")) : (reader[5].ToString());
                        if (QuestionInfoForm.checkQuestion(reader0))
                        {
                            continue;
                        }
                        if (QuestionDialog.getTypeId(cboTypes) == 1)
                        {
                            sql = "insert into questions values('" + reader0 + "','" + reader5 + "',null," + QuestionDialog.getMajorId(cboMajors) + ",1,'" + reader1 + "','" + reader2 + "','" + reader3 + "','" + reader4 + "')";
                        }
                        else
                        {
                            sql = "insert into questions values('" + reader0 + "','" + reader1 + "',null," + QuestionDialog.getMajorId(cboMajors) + "," + QuestionDialog.getTypeId(cboTypes) + ",null,null,null,null)";
                        }
                        cmd = sqlDb.GetSqlStringCommand(sql);
                        result += sqlDb.ExecuteNonQuery(cmd);
                    }
                }
                MessageBox.Show("成功导入了" + result + "条数据", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool checkInput()
        {
            if (cboMajors.Text.Trim() == "")
            {
                MessageBox.Show("请选择题目所属专业！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboTypes.Text.Trim() == "")
            {
                MessageBox.Show("请选择题目所属类型！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
