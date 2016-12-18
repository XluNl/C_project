using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using VirtualTrain.model;
using VirtualTrain.common;

namespace VirtualTrain
{
    public partial class QuestionInfoForm : Form
    {
        public QuestionInfoForm()
        {
            InitializeComponent();
        }

        QuestionDialog dialog;
        BatchDialog batchDialog;
        private void QuestionInfoForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MdiChildrenAutoSize(this);
            this.Dock = DockStyle.Fill;
            //创建一个题目信息对话框的实例
            dialog = new QuestionDialog();
            dialog.Owner = this;
            ////创建一个批量导入题目对话框的实例
            //batchDialog = new BatchDialog();
            //batchDialog.Owner = this;
            showAllQuestions();
        }

        private void showAllQuestions()
        {
            DBHelper db = new DBHelper();
            string sql = "select a.id,a.question,a.answer,a.difficulty,b.name,c.name from questions a,majors b,types c where a.majorId=b.id and a.typeId=c.id";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            dgvQuestionInfo.DataSource = dt;
            dgvQuestionInfo.Columns[1].FillWeight = 40;
            dgvQuestionInfo.Columns[2].FillWeight = 30;
            dgvQuestionInfo.Columns[3].FillWeight = 10;
            dgvQuestionInfo.Columns[4].FillWeight = 10;
            dgvQuestionInfo.Columns[5].FillWeight = 10;
            setColor(dgvQuestionInfo);
        }

        public static void setColor(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i += 2)
            {
                dataGridView.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            }
        }

        private void dgvQuestionInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            setColor(dgvQuestionInfo);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //没有在DataGridView中选中题目
            if (dgvQuestionInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("当前没有选择题目，请选择一个题目进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //在DataGridView中选中两个或两个以上题目
            if (dgvQuestionInfo.SelectedRows.Count > 1)
            {
                MessageBox.Show("无法同时对多个题目进行更新操作，请选择一个题目进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //根据DataGridView选中项，生成一个Question类的实例
            Question question = new Question();
            DataGridViewRow currentRow = dgvQuestionInfo.Rows[dgvQuestionInfo.SelectedRows[0].Index];
            question.id = Convert.ToInt32(currentRow.Cells[0].Value);
            question.question = currentRow.Cells[1].Value.ToString();
            question.answer = currentRow.Cells[2].Value.ToString();
            question.difficulty = currentRow.Cells[3].Value.ToString();
            question.major = currentRow.Cells[4].Value.ToString();
            question.type = currentRow.Cells[5].Value.ToString();
            DBHelper db = new DBHelper();
            string sql = "select OptionA,OptionB,OptionC,OptionD from questions where id=" + question.id;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        question.optionA = (reader["OptionA"] == null ? "" : reader["OptionA"].ToString());
                        question.optionB = (reader["OptionB"] == null ? "" : reader["OptionB"].ToString());
                        question.optionC = (reader["OptionC"] == null ? "" : reader["OptionC"].ToString());
                        question.optionD = (reader["OptionD"] == null ? "" : reader["OptionD"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //设置对话框的题目数据
            dialog.question = question;
            //显示对话框
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //更新题目信息
                if (updateQuestion(dialog.question) <= 0)
                {
                    return;
                }
                showAllQuestions();
            }
        }

        //更新题目
        public int updateQuestion(Question question)
        {
            int result = 0;
            if (checkQuestion(question.question, question.id))
            {
                MessageBox.Show("存在相同题目，请更改题目！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "update questions set question='" + question.question + "',answer='" + question.answer + "',difficulty='" + question.difficulty + "',majorId=" + UserInfoForm.getMajorIdByMajor(question.major) + ",typeId=" + getTypeIdByType(question.type) + ",OptionA=" + (question.optionA == null ? "null" : "'" + question.optionA + "'") + ",OptionB=" + (question.optionB == null ? "null" : "'" + question.optionB + "'") + ",OptionC=" + (question.optionC == null ? "null" : "'" + question.optionC + "'") + ",OptionD=" + (question.optionD == null ? "null" : "'" + question.optionD + "'") + " where id=" + question.id;
                try
                {
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    result = db.ExecuteNonQuery(cmd);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }

        public static Question readerToQuestion(DbDataReader reader)
        {
            Question question = new Question();
            question.id = (int)reader["id"];
            question.question = (string)reader["question"];
            question.answer = (string)reader["answer"];
            question.difficulty = (reader["difficulty"] is DBNull) ? null : ((string)reader["difficulty"]);
            question.major = UserInfoForm.getMajorByMajorId((int)reader["majorId"]);
            question.type = getTypeByTypeId((int)reader["typeId"]);
            question.optionA = (reader["OptionA"] is DBNull) ? null : ((string)reader["OptionA"]);
            question.optionB = (reader["OptionB"] is DBNull) ? null : ((string)reader["OptionB"]);
            question.optionC = (reader["OptionC"] is DBNull) ? null : ((string)reader["OptionC"]);
            question.optionD = (reader["OptionD"] is DBNull) ? null : ((string)reader["OptionD"]);
            return question;
        }

        public static Question getQuestionById(int id)
        {
            Question question = null;
            DBHelper db = new DBHelper();
            string sql = "select * from questions where id=" + id;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        question = readerToQuestion(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return question;
        }

        public static int getIdByQuestion(string question)
        {
            int id = 0;
            DBHelper db = new DBHelper();
            string sql = "select id from game_questions where question='" + question + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        id = (int)reader["id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return id;
        }

        //private void showDataTableSchema()
        //{
        //DBHelper db = new DBHelper();
        //string sql = "select a.id,a.question,a.answer,a.difficulty,b.name,c.name from questions a,majors b,types c where a.majorId=b.id and a.typeId=c.id";
        //DbCommand cmd = db.GetSqlStringCommand(sql);
        //SqlDataAdapter adapter = new SqlDataAdapter();
        //adapter.SelectCommand = (SqlCommand)cmd;
        //DataTable dataTable = new DataTable();
        //adapter.FillSchema(dataTable, SchemaType.Source);
        //for (int i = 0; i < dataTable.Columns.Count; i++)
        //{
        //    DataColumn column = dataTable.Columns[i];
        //    System.Diagnostics.Trace.Write(i + "  ");
        //    Trace.Write(column.ColumnName + "  ");
        //    Trace.Write(column.DataType.Name + "  ");
        //    Trace.WriteLine(column.MaxLength + "       ");
        //}
        //Trace.WriteLine("");
        //if (dataTable.PrimaryKey.Length > 0)
        //{
        //    string temp = "";
        //    for (int i = 0; i < dataTable.PrimaryKey.Length; i++)
        //    {
        //        temp += dataTable.PrimaryKey[i].ColumnName;
        //        temp += " ";
        //    }
        //    Trace.WriteLine("主键为：" + temp);
        //}
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //判断用户是否选择一行数据，true为没选择，false为选择
            if (dgvQuestionInfo.Rows[dgvQuestionInfo.CurrentRow.Index].Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除");
            }
            else
            {
                //判断用户是否点击确定按钮，true为点击，false为没有点击
                if (MessageBox.Show("确认删除？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int num = 0;
                    int count = dgvQuestionInfo.SelectedRows.Count;
                    //定义数组，用循环赋值
                    String[] array = new String[count];
                    for (int i = 0; i < count; i++)
                    {
                        int id = Convert.ToInt32(dgvQuestionInfo.Rows[dgvQuestionInfo.SelectedRows[i].Index].Cells[0].Value);
                        if (checkQuestionDeletable(id))
                        {
                            num++;
                            continue;
                        }
                        String strDelete = "delete from questions where id=" + id;
                        array[i] = strDelete;
                    }
                    if (num > 0)
                    {
                        MessageBox.Show("无法删除其中" + num + "道题目，因为题目已经在试卷中！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //遍历数组
                    foreach (String str in array)
                    {
                        if (str != null)
                        {
                            execute(str);
                        }
                    }
                    showAllQuestions();
                }
            }
        }

        public void execute(string sql)
        {
            DBHelper db = new DBHelper();
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkQuestionDeletable(int id)
        {
            DBHelper db = new DBHelper();
            string sql = "select count(*) from question_paper where questionId=" + id;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //清空题目信息对话框的数据
            dialog.question = null;
            //如果在对话框中选择了“确定”，则根据输入信息添加题目
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (addQuestion(dialog.question) <= 0)
                {
                    return;
                }
                showAllQuestions();
            }
        }

        //添加题目
        public int addQuestion(Question question)
        {
            int result = 0;
            if (checkQuestion(question.question))
            {
                MessageBox.Show("此题目已存在！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "insert into questions values('" + question.question + "','" + question.answer + "','" + question.difficulty + "'," + UserInfoForm.getMajorIdByMajor(question.major) + "," + getTypeIdByType(question.type) + "," + (question.optionA == null ? "null" : "'" + question.optionA + "'") + "," + (question.optionB == null ? "null" : "'" + question.optionB + "'") + "," + (question.optionC == null ? "null" : "'" + question.optionC + "'") + "," + (question.optionD == null ? "null" : "'" + question.optionD + "'") + ")";
                try
                {
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    result = db.ExecuteNonQuery(cmd);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }

        public static bool checkQuestion(string question)
        {
            DBHelper db = new DBHelper();
            string sql = "select count(*) from questions where question='" + question + "'";
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

        public bool checkQuestion(string question, int id)
        {
            DBHelper db = new DBHelper();
            string sql = "select count(*) from questions where question='" + question + "' and id!=" + id;
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

        public static int getTypeIdByType(string type)
        {
            int typeId = 0;
            DBHelper db = new DBHelper();
            string sql = "select id from types where name='" + type + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        typeId = (int)reader["id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return typeId;
        }

        public static string getTypeByTypeId(int typeId)
        {
            string type = "";
            DBHelper db = new DBHelper();
            string sql = "select name from types where id=" + typeId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        type = (string)reader["name"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return type;
        }

        private void btnBatchAdd_Click(object sender, EventArgs e)
        {
            batchDialog = new BatchDialog();
            //显示对话框
            if (batchDialog.ShowDialog() == DialogResult.OK)
            {
                showAllQuestions();
            }
        }

    }
}
