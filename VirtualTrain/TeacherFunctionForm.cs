using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Collections;

namespace VirtualTrain
{
    public partial class TeacherFunctionForm : Form
    {
        public TeacherFunctionForm()
        {
            InitializeComponent();
        }

        PaperNameDialog pNameDialog;
        PaperDialog dialog;
        private void TeacherFunctionForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MdiChildrenAutoSize(this);
            this.Dock = DockStyle.Fill;
            CommonPanel.Show();
            autoSetQuestionPanel.Hide();
            setQuestionConfirmPanel.Hide();
            setQuestionPanel.Hide();
            paperInfoPanel.Hide();
            scoreInfoPanel.Hide();
            //给tlpMark中的button的tag赋值，必须在 ViewHelper.MdiChildrenAutoSize(this)之后
            btnSelect1.Tag = "1,1";
            btnSelect2.Tag = "1,2";
            btnSelect3.Tag = "1,3";
            btnSelect4.Tag = "1,4";
            btnSelect5.Tag = "1,5";
            btnBlank1.Tag = "2,1";
            btnBlank2.Tag = "2,2";
            btnBlank3.Tag = "2,3";
            btnBlank4.Tag = "2,4";
            btnBlank5.Tag = "2,5";
            btnJudge1.Tag = "4,1";
            btnJudge2.Tag = "4,2";
            btnJudge3.Tag = "4,3";
            btnJudge4.Tag = "4,4";
            btnJudge5.Tag = "4,5";
            btnShortAnswer1.Tag = "3,3";
            btnShortAnswer2.Tag = "3,5";
            btnShortAnswer3.Tag = "3,7";
            btnShortAnswer4.Tag = "3,10";
            btnShortAnswer5.Tag = "3,15";
            //给自动出题题目个数选择框的tag赋值，必须在 ViewHelper.MdiChildrenAutoSize(this)之后
            nudSelectNum.Tag = "1";
            nudBlankNum.Tag = "2";
            nudJudgeNum.Tag = "4";
            nudShortAnswerNum.Tag = "3";
            nudSelectMark.Tag = nudBlankMark.Tag = nudJudgeMark.Tag = nudShortAnswerMark.Tag = null;
            //按下NumericUpDown控件的上或下箭头2s后，数值变化将以10为单位
            NumericUpDownAcceleration acceleration = new NumericUpDownAcceleration(2, 10);
            nudMark.Accelerations.Add(acceleration);
            nudSelectNum.Accelerations.Add(acceleration);
            nudSelectMark.Accelerations.Add(acceleration);
            nudBlankNum.Accelerations.Add(acceleration);
            nudBlankMark.Accelerations.Add(acceleration);
            nudJudgeNum.Accelerations.Add(acceleration);
            nudJudgeMark.Accelerations.Add(acceleration);
            nudShortAnswerNum.Accelerations.Add(acceleration);
            nudShortAnswerMark.Accelerations.Add(acceleration);
            //创建一个试卷名称对话框的实例
            pNameDialog = new PaperNameDialog();
            pNameDialog.Owner = this;
            ////创建一个评分对话框的实例
            //dialog = new PaperDialog();
            //dialog.Owner = this;
        }

        private void btnSetTheme_Click(object sender, EventArgs e)
        {
            autoSetQuestionPanel.Show();
            CommonPanel.Hide();
        }

        private void btnGiveMark_Click(object sender, EventArgs e)
        {
            paperInfoPanel.Show();
            CommonPanel.Hide();
            showAllPapers();
        }

        private void showAllPapers()
        {
            DBHelper db = new DBHelper();
            string sql = "select a.id,a.name,a.publishTime,b.name from papers a,majors b where a.majorId=b.id and teacherId=" + UserHelper.user.id + " and a.majorId=" + UserHelper.currentMajorId;
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            dgvPaperInfo.DataSource = dt;
            //对考生人数列填充数据
            fillColumnExamineeNum();
            //考生人数列
            dgvPaperInfo.Columns[0].FillWeight = 20;
            //按钮列
            dgvPaperInfo.Columns[1].FillWeight = 5;
            //试卷id
            //试卷名称
            dgvPaperInfo.Columns[3].FillWeight = 50;
            //发布时间
            dgvPaperInfo.Columns[4].FillWeight = 20;
            //专业
            dgvPaperInfo.Columns[5].FillWeight = 5;
            QuestionInfoForm.setColor(dgvPaperInfo);
        }

        private void fillColumnExamineeNum()
        {
            DBHelper db = new DBHelper();
            for (int i = 0; i < dgvPaperInfo.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dgvPaperInfo.Rows[i].Cells[2].Value);
                string sql = "select count(*) from scores where paperId=" + id;
                DbCommand cmd = db.GetSqlStringCommand(sql);
                string str = "已有 " + db.ExecuteScalar(cmd) + " 人考试";
                dgvPaperInfo.Rows[i].Cells[0].Value = str;
            }
        }

        private void dgvPaperInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fillColumnExamineeNum();
            QuestionInfoForm.setColor(dgvPaperInfo);
        }

        private void dgvPaperInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                paperId = Convert.ToInt32(dgvPaperInfo.Rows[e.RowIndex].Cells[2].Value);
                //点击答题人数超链接
                if (e.ColumnIndex == 0)
                {
                    paperInfoPanel.Hide();
                    scoreInfoPanel.Show();
                    showAllScores(paperId);
                }
                //点击删除
                else if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("确定要删除试卷 “" + dgvPaperInfo.Rows[e.RowIndex].Cells[3].Value.ToString() + "“ 吗？所有有关该试卷的成绩都将被删除！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (delPaper(paperId))
                        {
                            MessageBox.Show("试卷删除成功！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showAllPapers();
                        }
                        else
                        {
                            MessageBox.Show("试卷删除失败···", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void showAllScores(int paperId)
        {
            DBHelper db = new DBHelper();
            string sql = "select a.id,b.id,b.name,a.score,c.name,a.state from scores a,users b,majors c where a.studentId=b.id and b.majorId=c.id and a.paperId=" + paperId;
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            dgvScoreInfo.DataSource = dt;
            //对总分列与按钮列进行更新
            updateColumns();
            //按钮列
            dgvScoreInfo.Columns[0].FillWeight = 10;
            //成绩id列
            //学员id列
            //姓名列
            dgvScoreInfo.Columns[3].FillWeight = 35;
            //总分列
            dgvScoreInfo.Columns[4].FillWeight = 35;
            //学员来自列
            dgvScoreInfo.Columns[5].FillWeight = 20;
            //状态列
            QuestionInfoForm.setColor(dgvScoreInfo);
        }

        private void updateColumns()
        {
            for (int i = 0; i < dgvScoreInfo.Rows.Count; i++)
            {
                int state = Convert.ToInt32(dgvScoreInfo.Rows[i].Cells[6].Value);
                if (state == 0)
                {
                    dgvScoreInfo.Rows[i].Cells[4].Value = DBNull.Value;
                    dgvScoreInfo.Rows[i].Cells[0].Value = "评分";
                }
                else
                {
                    ((DataGridViewDisableButtonCell)dgvScoreInfo.Rows[i].Cells[0]).Enabled = false;
                    dgvScoreInfo.Rows[i].Cells[0].Value = "已评分";
                }
            }
        }

        private void dgvScoreInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            updateColumns();
            QuestionInfoForm.setColor(dgvScoreInfo);
        }

        private void dgvScoreInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int state = Convert.ToInt32(dgvScoreInfo.Rows[e.RowIndex].Cells[6].Value);
                if (e.ColumnIndex == 0 && state == 0)
                {
                    //成绩id
                    int scoreId = Convert.ToInt32(dgvScoreInfo.Rows[e.RowIndex].Cells[1].Value);
                    //学员id
                    int stuId = Convert.ToInt32(dgvScoreInfo.Rows[e.RowIndex].Cells[2].Value);
                    dialog = new PaperDialog();
                    dialog.scoreId = scoreId;
                    dialog.stuId = stuId;
                    this.MdiParent.Hide();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        showAllScores(paperId);
                    }
                    this.MdiParent.Show();
                }
            }
        }

        //删除试卷
        public static bool delPaper(int id)
        {
            using (Trans t = new Trans())
            {
                try
                {
                    DBHelper db = new DBHelper();
                    string sql = "select id from question_paper where paperId=" + id;
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    using (DbDataReader reader = db.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            delQuestion_paper((int)reader[0]);
                        }
                    }
                    delInScores(id, t);
                    delInPapers(id, t);
                    t.Commit();
                    return true;
                }
                catch
                {
                    t.RollBack();
                    return false;
                }
            }
        }

        public static void delQuestion_paper(int id)
        {
            using (Trans t = new Trans())
            {
                try
                {
                    delInStu_answers(id, t);
                    delInQuestion_paper(id, t);
                    t.Commit();
                }
                catch
                {
                    t.RollBack();
                }
            }
        }

        public static void delInStu_answers(int id, Trans t)
        {
            string sql = "delete from stu_answers where question_paper_id=" + id;
            executeDel(sql, t);
        }

        public static void delInQuestion_paper(int id, Trans t)
        {
            string sql = "delete from question_paper where id=" + id;
            executeDel(sql, t);
        }

        public static void delInScores(int id, Trans t)
        {
            string sql = "delete from scores where paperId=" + id;
            executeDel(sql, t);
        }

        public static void delInPapers(int id, Trans t)
        {
            string sql = "delete from papers where id=" + id;
            executeDel(sql, t);
        }

        public static void executeDel(string sql, Trans t)
        {
            DBHelper db = new DBHelper();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            if (t == null)
            {
                db.ExecuteNonQuery(cmd);
            }
            else
            {
                db.ExecuteNonQuery(cmd, t);
            }
        }

        private void btnAutoSetQuestionConfirm_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(nudSelectNum.Tag.ToString());
            if (!checkInput())
            {
                return;
            }
            if (pNameDialog.ShowDialog() == DialogResult.OK)
            {
                Paper paper = new Paper();
                paper.name = pNameDialog.paperName;
                paper.publishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                paper.major = UserInfoForm.getMajorByMajorId(UserHelper.currentMajorId);
                paper.teacherName = UserHelper.user.name;
                if (extractQuestion() == null)
                {
                    MessageBox.Show("题库中没有足够的题目，详情请联系管理员···", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (addPaper(paper, extractQuestion()))
                {
                    MessageBox.Show("试卷 ”" + paper.name + "“ 添加失败···", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("试卷 ”" + paper.name + "“ 添加成功！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showAllPapers();
                paperInfoPanel.Show();
                autoSetQuestionPanel.Hide();
            }
        }

        private bool checkInput()
        {
            if (((int)nudSelectNum.Value + (int)nudBlankNum.Value + (int)nudJudgeNum.Value + (int)nudShortAnswerNum.Value) == 0)
            {
                MessageBox.Show("请输入试卷题目个数！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (((int)nudSelectNum.Value + (int)nudBlankNum.Value + (int)nudJudgeNum.Value + (int)nudShortAnswerNum.Value) > 100)
            {
                MessageBox.Show("试卷总题数超过限制！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (((int)nudSelectNum.Value * (int)nudSelectMark.Value + (int)nudBlankNum.Value * (int)nudBlankMark.Value + (int)nudJudgeNum.Value * (int)nudJudgeMark.Value + (int)nudShortAnswerNum.Value * (int)nudShortAnswerMark.Value) > 100)
            {
                MessageBox.Show("试卷总分超过100分，需要去掉" + (((int)nudSelectNum.Value * (int)nudSelectMark.Value + (int)nudBlankNum.Value * (int)nudBlankMark.Value + (int)nudJudgeNum.Value * (int)nudJudgeMark.Value + (int)nudShortAnswerNum.Value * (int)nudShortAnswerMark.Value) - 100) + "分的题！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (((int)nudSelectNum.Value * (int)nudSelectMark.Value + (int)nudBlankNum.Value * (int)nudBlankMark.Value + (int)nudJudgeNum.Value * (int)nudJudgeMark.Value + (int)nudShortAnswerNum.Value * (int)nudShortAnswerMark.Value) < 100)
            {
                MessageBox.Show("试卷总分不足100分，还需要出" + (100 - ((int)nudSelectNum.Value * (int)nudSelectMark.Value + (int)nudBlankNum.Value * (int)nudBlankMark.Value + (int)nudJudgeNum.Value * (int)nudJudgeMark.Value + (int)nudShortAnswerNum.Value * (int)nudShortAnswerMark.Value)) + "分的题！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //自动出题抽取试题
        private ArrayList extractQuestion()
        {
            ArrayList list = new ArrayList();
            foreach (Control con in autoSetQuestionPanel.Controls)
            {
                if (con is NumericUpDown && con.Tag != null)
                {
                    NumericUpDown nud = con as NumericUpDown;
                    if ((int)nud.Value != 0)
                    {
                        int allQuestionCount = Test.getQuestionCount(UserHelper.currentMajorId, Convert.ToInt32(nud.Tag));
                        AutoSetQuestionHelper.allQuestionId = new int[allQuestionCount];
                        AutoSetQuestionHelper.selectedState = new bool[allQuestionCount];
                        AutoSetQuestionHelper.selectedQuestionId = new int[Convert.ToInt32(nud.Value)];
                        if (allQuestionCount < AutoSetQuestionHelper.selectedQuestionId.Length)
                        {
                            return null;
                        }
                        Test.setAllQuestionId(UserHelper.currentMajorId, Convert.ToInt32(nud.Tag));
                        Test.setSelectedQuestionId(AutoSetQuestionHelper.selectedQuestionId.Length);
                        for (int i = 0; i < AutoSetQuestionHelper.selectedQuestionId.Length; i++)
                        {
                            Question question = QuestionInfoForm.getQuestionById(AutoSetQuestionHelper.selectedQuestionId[i]);
                            switch (Convert.ToInt32(nud.Tag))
                            {
                                case 1:
                                    question.mark = (int)nudSelectMark.Value;
                                    break;
                                case 2:
                                    question.mark = (int)nudBlankMark.Value;
                                    break;
                                case 3:
                                    question.mark = (int)nudShortAnswerMark.Value;
                                    break;
                                case 4:
                                    question.mark = (int)nudJudgeMark.Value;
                                    break;
                                default:
                                    break;
                            }
                            list.Add(question);
                        }
                    }
                }
            }
            return list;
        }

        int paperId;
        //添加试卷
        public bool addPaper(Paper paper, ArrayList list)
        {
            using (Trans t = new Trans())
            {
                try
                {
                    addInPapers(paper, t);
                    addInQuestion_paper(list, t);
                    t.Commit();
                    return false;
                }
                catch
                {
                    t.RollBack();
                    return true;
                }
            }
        }

        public void addInPapers(Paper paper, Trans t)
        {
            DBHelper db = new DBHelper();
            string sql = "insert into papers values('" + paper.name + "','" + paper.publishTime + "'," + UserHelper.currentMajorId + "," + UserHelper.user.id + ")";
            string selectSql = "select @@identity";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            if (t == null)
            {
                //db.ExecuteNonQuery(cmd);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = selectSql;
                paperId = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
            }
            else
            {
                //db.ExecuteNonQuery(cmd,t);
                cmd.Connection.Close();
                cmd.Connection = t.DbConnection;
                cmd.Transaction = t.DbTrans;
                cmd.ExecuteNonQuery();
                cmd.CommandText = selectSql;
                paperId = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void addInQuestion_paper(ArrayList list, Trans t)
        {
            DBHelper db = new DBHelper();
            DbCommand cmd;
            String[] array = new String[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                string sql = "insert into question_paper values(" + ((Question)list[i]).id + "," + paperId + "," + ((Question)list[i]).mark + ")";
                array[i] = sql;
            }
            if (t == null)
            {
                foreach (String str in array)
                {
                    cmd = db.GetSqlStringCommand(str);
                    db.ExecuteNonQuery(cmd);
                }
            }
            else
            {
                foreach (String str in array)
                {
                    cmd = db.GetSqlStringCommand(str);
                    db.ExecuteNonQuery(cmd, t);
                }
            }
        }

        private void btnSetQuestionConfirm_Click(object sender, EventArgs e)
        {
            if (!checkList())
            {
                return;
            }
            if (pNameDialog.ShowDialog() == DialogResult.OK)
            {
                Paper paper = new Paper();
                paper.name = pNameDialog.paperName;
                paper.publishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                paper.major = UserInfoForm.getMajorByMajorId(UserHelper.currentMajorId);
                paper.teacherName = UserHelper.user.name;
                if (addPaper(paper, list))
                {
                    MessageBox.Show("试卷 ”" + paper.name + "“ 添加失败···", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("试卷 ”" + paper.name + "“ 添加成功！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showAllPapers();
                paperInfoPanel.Show();
                setQuestionPanel.Hide();
            }
        }

        private bool checkList()
        {
            int totalMark = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (((Question)list[i]).mark == 0)
                {
                    MessageBox.Show("请设置题目分数！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lstQuestion.SelectedIndex = i;
                    return false;
                }
                else
                {
                    totalMark += ((Question)list[i]).mark;
                }
            }
            if (totalMark > 100)
            {
                MessageBox.Show("试卷总分超过100分，需要去掉" + (totalMark - 100) + "分的题！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (totalMark < 100)
            {
                MessageBox.Show("试卷总分不足100分，还需要出" + (100 - totalMark) + "分的题！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void refreshLstQuestion()
        {
            lstQuestion.Items.Clear();
            foreach (Question question in list)
            {
                lstQuestion.Items.Add(question);
            }
        }

        private void nudMark_Leave(object sender, EventArgs e)
        {
            if (lstQuestion.SelectedIndex != -1)
            {
                ((Question)list[lstQuestion.SelectedIndex]).mark = (int)nudMark.Value;
                refreshLstQuestion();
                nudMark.Hide();
            }
        }

        private void lstQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQuestion.SelectedIndex != -1)
            {
                nudMark.Show();
                if (((Question)list[lstQuestion.SelectedIndex]).mark != 0)
                {
                    nudMark.Value = ((Question)list[lstQuestion.SelectedIndex]).mark;
                }
                else
                {
                    nudMark.Value = 1;
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            setQuestionConfirmPanel.Hide();
        }

        ArrayList list = new ArrayList();
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clbQuestion.CheckedItems.Count == 0)
            {
                MessageBox.Show("您没有选择任何题目！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (clbQuestion.CheckedItems.Count > 100)
            {
                MessageBox.Show("试卷总题数超过限制！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            list.Clear();
            for (int i = 0; i < clbQuestion.CheckedItems.Count; i++)
            {
                list.Add(clbQuestion.CheckedItems[i]);
            }
            setQuestionConfirmPanel.Show();
            refreshLstQuestion();
        }

        private void btnShortcut_Click(object sender, EventArgs e)
        {
            string[] str = (((Button)sender).Tag.ToString()).Split(',');
            string type = QuestionInfoForm.getTypeByTypeId(Convert.ToInt32(str[0]));
            int mark = Convert.ToInt32(str[1]);
            foreach (Question question in list)
            {
                if (question.type == type)
                {
                    question.mark = mark;
                }
            }
            refreshLstQuestion();
        }

        private void lblSetQuestion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setQuestionPanel.Show();
            setQuestionConfirmPanel.Hide();
            autoSetQuestionPanel.Hide();
            //加载当前专业题目信息
            clbQuestionInit();
        }

        private void clbQuestionInit()
        {
            clbQuestion.Items.Clear();
            DBHelper db = new DBHelper();
            string sql = "select * from questions where majorId=" + UserHelper.currentMajorId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Question question = QuestionInfoForm.readerToQuestion(reader);
                        clbQuestion.Items.Add(question);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void clbQuestion_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (clbQuestion.CheckedItems.Count > 100)
                {
                    MessageBox.Show("试卷总题数超过限制！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.NewValue = CheckState.Unchecked;
                }
            }
        }

        private void lblAutoSetQuestion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            autoSetQuestionPanel.Show();
            setQuestionPanel.Hide();
        }

        private void btnScoreToPaper_Click(object sender, EventArgs e)
        {
            paperInfoPanel.Show();
            scoreInfoPanel.Hide();
        }

        private void btnPaperToCommon_Click(object sender, EventArgs e)
        {
            CommonPanel.Show();
            paperInfoPanel.Hide();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiParent.MdiChildren)
            {
                if (f is TeacherWelcomeForm)
                {
                    f.Activate();
                    return;
                }
            }
        }

        private void btnAutoSetQuestionToCommon_Click(object sender, EventArgs e)
        {
            CommonPanel.Show();
            autoSetQuestionPanel.Hide();
        }

        private void nud_Leave(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            //暂存一下当前的值
            decimal value = nud.Value;
            //设置一个与当前的值不相等的新值
            if (value != nud.Minimum)
                nud.Value = nud.Minimum;
            else
                nud.Value = nud.Maximum;
            //还原当前值
            nud.Value = value;
        }

        private void nud_LostFocus(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            //暂存一下当前的值
            decimal value = nud.Value;
            //设置一个与当前的值不相等的新值
            if (value != nud.Minimum)
                nud.Value = nud.Minimum;
            else
                nud.Value = nud.Maximum;
            //还原当前值
            nud.Value = value;
        }
    }
}
