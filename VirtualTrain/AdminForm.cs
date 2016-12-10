﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using VirtualTrain.model;
using VirtualTrain.common;
using System.IO;
using VirtualTrain;
using System.Configuration;

namespace VirtualTrain
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private static string img_path = ConfigurationManager.AppSettings["img_path"];
        private static string video_path = ConfigurationManager.AppSettings["video_path"];

        UserInfoForm userInfoForm = new UserInfoForm();
        private void UserInfoManage_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is UserInfoForm)
                {
                    tabControl1.Visible = false;
                    userInfoForm.Show();
                    f.Activate();
                    return;
                }
            }
        }

        QuestionInfoForm questionInfoForm = new QuestionInfoForm();
        private void QuestionInfoManage_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is QuestionInfoForm)
                {
                    tabControl1.Visible = false;
                    questionInfoForm.Show();
                    f.Activate();
                    return;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            //弹出消息框向用户确认
            DialogResult result = MessageBox.Show("确定要退出吗？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //如果选择了“是”，退出应用程序
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        TextQuestionDialog t_dialog;
        ImageQuestionFrom i_dialog;
        VideoEditedFrom v_dialog;
        AddRoleFrom r_dialog;
        private void AdminForm_Load(object sender, EventArgs e)
        {
            //解决窗体闪烁
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);


            tabControl1.Visible = false;
            ViewHelper.size = this.Size;
            questionInfoForm.MdiParent = this;
            userInfoForm.MdiParent = this;
            questionInfoForm.Show();
            userInfoForm.Show();


            //toolTip1.SetToolTip(button1, "配置脚本内容");
            toolTip1.SetToolTip(pictureBox1, "创建一个新的脚本");
            //文本选择题初始化
            t_dialog = new TextQuestionDialog();
            t_dialog.Owner = this;
            show_text_Questions();
            //图片选择题初始化
            i_dialog = new ImageQuestionFrom();
            i_dialog.Owner = this;
            show_img_Questions();
            //视频列表初始化
            v_dialog = new VideoEditedFrom();
            v_dialog.Owner = this;
            show_video();
            //角色列表初始化
            r_dialog = new AddRoleFrom();
            r_dialog.Owner = this;
            show_role();

            // 初始化加载全部场景
            this.getAllSence();
        }

        private void show_text_Questions()
        {
            DBHelper db = new DBHelper();
            string sql = "select a.id,a.question,a.answer,b.name from game_questions a,majors b where a.majorId=b.id and a.type='false'";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            dgvText.DataSource = dt;
            dgvText.Columns[1].FillWeight = 40;
            dgvText.Columns[2].FillWeight = 30;
            dgvText.Columns[3].FillWeight = 10;
        }

        private void show_img_Questions()
        {
            DBHelper db = new DBHelper();
            string sql = "select a.id,a.question,a.answer,b.name from game_questions a,majors b where a.majorId=b.id and a.type='true'";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            dgvimg.DataSource = dt;
            dgvimg.Columns[1].FillWeight = 40;
            dgvimg.Columns[2].FillWeight = 30;
            dgvimg.Columns[3].FillWeight = 10;
        }

        private void show_video()
        {
            DBHelper db = new DBHelper();
            string sql = "select a.id,a.name,b.name from game_videos a,majors b where a.majorId=b.id ";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            dgvvideo.DataSource = dt;
            dgvvideo.Columns[1].FillWeight = 40;
            dgvvideo.Columns[2].FillWeight = 30;
        }

        private void show_role()
        {
            DBHelper db = new DBHelper();
            string sql = "select a.id,a.name,b.name from vr_roleid a,majors b where a.majorid=b.id";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable dt = db.ExecuteDataTable(cmd);
            dgvRole.DataSource = dt;
            dgvRole.Columns[1].FillWeight = 40;
            dgvRole.Columns[2].FillWeight = 30;
        }

        private void 脚本配置_Click(object sender, EventArgs e)
        {
            questionInfoForm.Visible = false;
            userInfoForm.Visible = false;
            tabControl1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddScript addScript = new AddScript();
            addScript.Call = creatScript; ;
            // 创建脚本面板
            addScript.ShowDialog();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }







        #region 角色编辑面板
        private void btn_r_update_Click(object sender, EventArgs e)
        {
            //没有在DataGridView中选中
            if (dgvRole.SelectedRows.Count <= 0)
            {
                MessageBox.Show("当前没有选择，请选择一个进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //在DataGridView中选中两个或两个以上
            if (dgvRole.SelectedRows.Count > 1)
            {
                MessageBox.Show("无法同时对多个进行更新操作，请选择一个进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //根据DataGridView选中项，生成一个Mission类的实例
            Role role = new Role();
            DataGridViewRow currentRow = dgvRole.Rows[dgvRole.SelectedRows[0].Index];
            role.id = Convert.ToInt32(currentRow.Cells[0].Value);
            role.name = currentRow.Cells[1].Value.ToString();
            role.major = currentRow.Cells[2].Value.ToString();
            //设置对话框的题目数据
            r_dialog.role = role;
            //显示对话框
            if (r_dialog.ShowDialog() == DialogResult.OK)
            {
                //更新信息
                if (update_role(r_dialog.role) <= 0)
                {
                    return;
                }
                show_role();
            }
        }

        //更新
        public int update_role(Role role)
        {
            int result = 0;
            if (checkTable(role.name, role.id, "vr_roleid", "name"))
            {
                MessageBox.Show("存在相同名称，请更改名称！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "update vr_roleid set name='" + role.name + "',majorId=" + UserInfoForm.getMajorIdByMajor(role.major) + " where id=" + role.id;
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

        private void btn_r_delete_Click(object sender, EventArgs e)
        {
            //判断用户是否选择一行数据，true为没选择，false为选择
            if (dgvRole.Rows[dgvRole.CurrentRow.Index].Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除");
            }
            else
            {
                //判断用户是否点击确定按钮，true为点击，false为没有点击
                if (MessageBox.Show("确认删除？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int count = dgvRole.SelectedRows.Count;
                    //定义数组，用循环赋值
                    String[] array = new String[count];
                    for (int i = 0; i < count; i++)
                    {
                        int id = Convert.ToInt32(dgvRole.Rows[dgvRole.SelectedRows[i].Index].Cells[0].Value);
                        String strDelete = "delete from vr_roleid where id=" + id;
                        array[i] = strDelete;
                    }
                    //遍历数组
                    foreach (String str in array)
                    {
                        if (str != null)
                        {
                            execute(str);
                        }
                    }
                    show_role();
                }
            }
        }



        private void btn_r_Add_Click(object sender, EventArgs e)
        {
            //清空信息对话框的数据
            r_dialog.role = null;
            //如果在对话框中选择了“确定”，则根据输入信息添加题目
            if (r_dialog.ShowDialog() == DialogResult.OK)
            {
                if (add_role(r_dialog.role) <= 0)
                {
                    return;
                }
                show_role();
            }
        }

        //添加
        public int add_role(Role role)
        {
            int result = 0;
            if (checkTable(role.name, "vr_roleid", "name"))
            {
                MessageBox.Show("此名称已存在！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "insert into vr_roleid values('" + role.name + "'," + UserInfoForm.getMajorIdByMajor(role.major) + ")";
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
        #endregion

        #region 文本选择面板
        private void btn_t_update_Click(object sender, EventArgs e)
        {
            //没有在DataGridView中选中题目
            if (dgvText.SelectedRows.Count <= 0)
            {
                MessageBox.Show("当前没有选择题目，请选择一个题目进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //在DataGridView中选中两个或两个以上题目
            if (dgvText.SelectedRows.Count > 1)
            {
                MessageBox.Show("无法同时对多个题目进行更新操作，请选择一个题目进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //根据DataGridView选中项，生成一个Question类的实例
            Question question = new Question();
            DataGridViewRow currentRow = dgvText.Rows[dgvText.SelectedRows[0].Index];
            question.id = Convert.ToInt32(currentRow.Cells[0].Value);
            question.question = currentRow.Cells[1].Value.ToString();
            question.answer = currentRow.Cells[2].Value.ToString();
            question.major = currentRow.Cells[3].Value.ToString();
            DBHelper db = new DBHelper();
            string sql = "select OptionA,OptionB,OptionC,OptionD from game_questions where id=" + question.id;
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
            t_dialog.question = question;
            //显示对话框
            if (t_dialog.ShowDialog() == DialogResult.OK)
            {
                //更新题目信息
                if (update_t_Question(t_dialog.question) <= 0)
                {
                    return;
                }
                show_text_Questions();
            }
        }

        //更新题目
        public int update_t_Question(Question question)
        {
            int result = 0;
            if (checkTable(question.question, question.id, "game_questions", "question"))
            {
                MessageBox.Show("存在相同题目，请更改题目！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "update game_questions set question='" + question.question + "',answer='" + question.answer + "',majorId=" + UserInfoForm.getMajorIdByMajor(question.major) + ",type='false',OptionA=" + (question.optionA == null ? "null" : "'" + question.optionA + "'") + ",OptionB=" + (question.optionB == null ? "null" : "'" + question.optionB + "'") + ",OptionC=" + (question.optionC == null ? "null" : "'" + question.optionC + "'") + ",OptionD=" + (question.optionD == null ? "null" : "'" + question.optionD + "'") + " where id=" + question.id;
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

        private void btn_t_delete_Click(object sender, EventArgs e)
        {
            //判断用户是否选择一行数据，true为没选择，false为选择
            if (dgvText.Rows[dgvText.CurrentRow.Index].Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除");
            }
            else
            {
                //判断用户是否点击确定按钮，true为点击，false为没有点击
                if (MessageBox.Show("确认删除？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int num = 0;
                    int count = dgvText.SelectedRows.Count;
                    //定义数组，用循环赋值
                    String[] array = new String[count];
                    for (int i = 0; i < count; i++)
                    {
                        int id = Convert.ToInt32(dgvText.Rows[dgvText.SelectedRows[i].Index].Cells[0].Value);
                        String strDelete = "delete from game_questions where id=" + id;
                        array[i] = strDelete;
                    }
                    //遍历数组
                    foreach (String str in array)
                    {
                        if (str != null)
                        {
                            execute(str);
                        }
                    }
                    show_text_Questions();
                }
            }
        }



        private void btn_t_Add_Click(object sender, EventArgs e)
        {
            //清空题目信息对话框的数据
            t_dialog.question = null;
            //如果在对话框中选择了“确定”，则根据输入信息添加题目
            if (t_dialog.ShowDialog() == DialogResult.OK)
            {
                if (add_t_Question(t_dialog.question) <= 0)
                {
                    return;
                }
                show_text_Questions();
            }
        }

        //添加题目
        public int add_t_Question(Question question)
        {
            int result = 0;
            if (checkTable(question.question, "game_questions", "question"))
            {
                MessageBox.Show("此题目已存在！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "insert into game_questions values('" + question.question + "','" + question.answer + "'," + UserInfoForm.getMajorIdByMajor(question.major) + ",'false'," + (question.optionA == null ? "null" : "'" + question.optionA + "'") + "," + (question.optionB == null ? "null" : "'" + question.optionB + "'") + "," + (question.optionC == null ? "null" : "'" + question.optionC + "'") + "," + (question.optionD == null ? "null" : "'" + question.optionD + "'") + ",null)";
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
        #endregion

        #region 图像选择面板
        private void btn_i_update_Click(object sender, EventArgs e)
        {
            //没有在DataGridView中选中题目
            if (dgvimg.SelectedRows.Count <= 0)
            {
                MessageBox.Show("当前没有选择题目，请选择一个题目进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //在DataGridView中选中两个或两个以上题目
            if (dgvimg.SelectedRows.Count > 1)
            {
                MessageBox.Show("无法同时对多个题目进行更新操作，请选择一个题目进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //根据DataGridView选中项，生成一个Question类的实例
            Question question = new Question();
            DataGridViewRow currentRow = dgvimg.Rows[dgvimg.SelectedRows[0].Index];
            question.id = Convert.ToInt32(currentRow.Cells[0].Value);
            question.question = currentRow.Cells[1].Value.ToString();
            question.answer = currentRow.Cells[2].Value.ToString();
            question.major = currentRow.Cells[3].Value.ToString();
            DBHelper db = new DBHelper();
            string sql = "select multiOption from game_questions where id=" + question.id;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        question.multiOption = string2list((reader["multiOption"] == null ? "" : reader["multiOption"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //设置对话框的题目数据
            i_dialog.question = question;


            //显示对话框
            if (i_dialog.ShowDialog() == DialogResult.OK)
            {
                //更新题目信息
                if (update_i_Question(i_dialog.question) <= 0)
                {
                    return;
                }
                show_img_Questions();
            }
        }

        //更新题目
        public int update_i_Question(Question question)
        {
            int result = 0;
            if (checkTable(question.question, question.id, "game_questions", "question"))
            {
                MessageBox.Show("存在相同题目，请更改题目！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "update game_questions set question='" + question.question + "',answer='" + question.answer + "',majorId=" + UserInfoForm.getMajorIdByMajor(question.major) + ",type='true',multiOption=" + (question.multiOption == null ? "null" : "'" + list2string(question.multiOption) + "'") + " where id=" + question.id;
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

        private void btn_i_delete_Click(object sender, EventArgs e)
        {
            //判断用户是否选择一行数据，true为没选择，false为选择
            if (dgvimg.Rows[dgvimg.CurrentRow.Index].Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除");
            }
            else
            {
                //判断用户是否点击确定按钮，true为点击，false为没有点击
                if (MessageBox.Show("确认删除？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int count = dgvimg.SelectedRows.Count;
                    //定义数组，用循环赋值
                    String[] array = new String[count];
                    for (int i = 0; i < count; i++)
                    {
                        int id = Convert.ToInt32(dgvimg.Rows[dgvimg.SelectedRows[i].Index].Cells[0].Value);
                        String strDelete = "delete from game_questions where id=" + id;
                        array[i] = strDelete;
                    }
                    //遍历数组
                    foreach (String str in array)
                    {
                        if (str != null)
                        {
                            execute(str);
                        }
                    }
                    show_img_Questions();
                }
            }
        }



        private void btn_i_Add_Click(object sender, EventArgs e)
        {
            //清空题目信息对话框的数据
            i_dialog.question = null;
            //如果在对话框中选择了“确定”，则根据输入信息添加题目
            if (i_dialog.ShowDialog() == DialogResult.OK)
            {
                if (add_i_Question(i_dialog.question) <= 0)
                {
                    return;
                }
                show_img_Questions();
            }
        }

        //添加题目
        public int add_i_Question(Question question)
        {
            int result = 0;
            if (checkTable(question.question, "game_questions", "question"))
            {
                MessageBox.Show("此题目已存在！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "insert into game_questions values('" + question.question + "','" + question.answer + "'," + UserInfoForm.getMajorIdByMajor(question.major) + ",'true',null,null,null,null," + (question.multiOption == null ? "null" : "'" + list2string(question.multiOption) + "'") + ")";
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



        #endregion

        #region 视屏编辑面板
        private void btn_v_update_Click(object sender, EventArgs e)
        {
            //没有在DataGridView中选中项目
            if (dgvvideo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("当前没有选择项目，请选择一个项目进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //在DataGridView中选中两个或两个以上题目
            if (dgvvideo.SelectedRows.Count > 1)
            {
                MessageBox.Show("无法同时对多个项目进行更新操作，请选择一个项目进行更新！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //根据DataGridView选中项，生成一个Video类的实例
            Video video = new Video();
            DataGridViewRow currentRow = dgvvideo.Rows[dgvvideo.SelectedRows[0].Index];
            video.id = Convert.ToInt32(currentRow.Cells[0].Value);
            video.name = currentRow.Cells[1].Value.ToString();
            video.major = currentRow.Cells[2].Value.ToString();
            DBHelper db = new DBHelper();
            string sql = "select startTime,endTime,fileName from game_videos where id=" + video.id;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        video.startTime = float.Parse(reader["startTime"].ToString());
                        video.endTime = float.Parse(reader["endTime"].ToString());
                        video.url = reader["fileName"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //设置对话框的题目数据
            v_dialog.video = video;

            //显示对话框
            if (v_dialog.ShowDialog() == DialogResult.OK)
            {
                //更新题目信息
                if (update_video(v_dialog.video) <= 0)
                {
                    return;
                }
                show_video();
            }
        }

        //更新题目
        public int update_video(Video video)
        {
            int result = 0;
            if (checkTable(video.name, video.id, "game_videos", "name"))
            {
                MessageBox.Show("存在相同项目，请更改！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "update game_videos set name='" + video.name + "',startTime='" + video.startTime + "',endTime='" + video.endTime + "',majorId=" + UserInfoForm.getMajorIdByMajor(video.major) + ",fileName='" + video.url + "' where id=" + video.id;
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

        private void btn_v_delete_Click(object sender, EventArgs e)
        {
            //判断用户是否选择一行数据，true为没选择，false为选择
            if (dgvvideo.Rows[dgvvideo.CurrentRow.Index].Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("请选择一项进行删除");
            }
            else
            {
                //判断用户是否点击确定按钮，true为点击，false为没有点击
                if (MessageBox.Show("确认删除？", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int count = dgvvideo.SelectedRows.Count;
                    //定义数组，用循环赋值
                    String[] array = new String[count];
                    for (int i = 0; i < count; i++)
                    {
                        int id = Convert.ToInt32(dgvvideo.Rows[dgvvideo.SelectedRows[i].Index].Cells[0].Value);
                        String strDelete = "delete from game_videos where id=" + id;
                        array[i] = strDelete;
                    }
                    //遍历数组
                    foreach (String str in array)
                    {
                        if (str != null)
                        {
                            execute(str);
                        }
                    }
                    show_video();
                }
            }
        }



        private void btn_v_Add_Click(object sender, EventArgs e)
        {
            //清空题目信息对话框的数据
            v_dialog.video = null;
            //如果在对话框中选择了“确定”，则根据输入信息添加
            if (v_dialog.ShowDialog() == DialogResult.OK)
            {
                if (add_video(v_dialog.video) <= 0)
                {
                    return;
                }
                show_video();
            }
        }

        //添加
        public int add_video(Video video)
        {
            int result = 0;
            if (checkTable(video.name, "game_videos", "name"))
            {
                MessageBox.Show("此项目已存在！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DBHelper db = new DBHelper();
                string sql = "insert into game_videos values('" + video.name + "','" + video.startTime + "','" + video.endTime + "'," + UserInfoForm.getMajorIdByMajor(video.major) + ",'" + video.url + "')";
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

        #endregion

        public static bool checkTable(string value, string tableName, string columnName)
        {
            DBHelper db = new DBHelper();
            string sql = "select count(*) from " + tableName + " where " + columnName + "='" + value + "'";
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

        public bool checkTable(string value, int id, string tableName, string columnName)
        {
            DBHelper db = new DBHelper();
            string sql = "select count(*) from " + tableName + " where " + columnName + "='" + value + "' and id!=" + id;
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

        private string list2string(List<string> list)
        {
            string result = "";
            foreach (string str in list)
            {
                result += (str + ",");
            }
            result.Substring(0, result.Length - 1);
            return result;

        }

        private List<string> string2list(string strs)
        {
            List<string> list = new List<string>();
            foreach (string str in strs.Split(','))
            {
                list.Add(str);
            }
            return list;

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 初始化记载全部场景
        /// </summary>
        public void getAllSence()
        {

            ScriptDAL scrDAL = new ScriptDAL();
            List<script> scp = scrDAL.getAllSence();

            foreach (script scr in scp)
            {

                this.creatScript(scr, scr.Id);
            }
        }

        /// <summary>
        /// 创建脚本UI展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void creatScript(script scp, int senceid)
        {

            int btn_H = 30;
            int btn_W = Convert.ToInt32(this.panel2.Size.Width * 0.5);
            int org = 10;
            int org_Y = org;
            int org_X = Convert.ToInt32(btn_W * 0.48);

            int count = this.panel2.Controls.Count;
            if (count > 0)
            {
                org_Y = this.panel2.Controls[count - 1].Location.Y + btn_H + org;
            }
            Button btn = new Button();
            btn.MouseDown += MouseDown;
            btn.Width = btn_W;
            btn.Height = btn_H;
            btn.Location = new Point(org_X, org_Y);
            btn.Tag = senceid;
            btn.Text = "scencID=" + btn.Tag + "    " + scp.Scencname;
            this.contextMenuStrip1.Tag = btn.Tag;
            btn.ContextMenuStrip = this.contextMenuStrip1;
            this.panel2.Controls.Add(btn);
            this.panel2.AutoScroll = true;
        }

        /// <summary>
        /// 删除一个场景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            int id = (int)btn.GetCurrentParent().Tag;
            ScriptDAL scrDAL = new ScriptDAL();
            if (scrDAL.delectSenceWithID(id))
            {
                // 刷新
                this.panel2.Controls.Clear();
                this.getAllSence();
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Button btn = (Button)sender;
                int tt = (int)btn.Tag;
                btn.ContextMenuStrip.Tag = btn.Tag;
            }

        }


        /// <summary>
        /// 编辑场景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditScriptFrom edit = new EditScriptFrom();
            edit.ShowDialog();
        }

    }
}
