using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using Common.model;
using VirtualTrain.common;

namespace VirtualTrain
{
    public partial class UserInfoForm : Form
    {
        public UserInfoForm()
        {
            InitializeComponent();
        }

        UserDialog dialog;
        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            ViewHelper.MdiChildrenAutoSize(this);
            this.Dock = DockStyle.Fill;
            //设置ListView为详细视图，并添加5列
            //listView1.View = View.Details;
            //listView1.Columns.Add("", 80);
            //listView1.Columns.Add("", 100);
            //listView1.Columns.Add("", 100);
            //listView1.Columns.Add("", 100);
            //listView1.Columns.Add("", 150);
            //listView1.Columns.Add("", 100);
            //设置ListView选中一项时选中整行
            listView1.FullRowSelect = true;
            //设置ListView失去焦点时选中内容可见
            listView1.HideSelection = false;
            //设置ListView只能选中一行
            listView1.MultiSelect = false;
            //创建一个联系人对话框的实例
            dialog = new UserDialog();
            dialog.Owner = this;
            showAllUsers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ListView控件中是否有选中项
            if (listView1.SelectedIndices.Count > 0)
            {
                //请用户确认是否删除
                if (MessageBox.Show("确实要删除用户" + listView1.Items[listView1.SelectedIndices[0]].Text + "吗？所有有关该用户的信息都将被删除！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //根据ListView选中项，生成一个User类的实例
                    User user = new User();
                    ListViewItem item = listView1.SelectedItems[0];
                    user.name = item.Text;
                    user.loginId = item.SubItems[1].Text;
                    user.password = getPasswordByLoginId(user.loginId);
                    user.id = getIdByLoginId(user.loginId);
                    user.role = item.SubItems[2].Text;
                    user.major = item.SubItems[3].Text;
                    user.permission = item.SubItems[4].Text;
                    user.state = getStateById(user.id);
                    //从数据库中删除用户
                    //string loginId = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text;
                    //DBHelper db = new DBHelper();
                    //string sql = "delete from users where loginId='" + loginId + "'";
                    //try
                    //{
                    //    DbCommand cmd = db.GetSqlStringCommand(sql);
                    //    db.ExecuteNonQuery(cmd);
                    //}
                    //catch (Exception ex)
                    //{
                    //    throw ex;
                    //}
                    if (delUser(user.id))
                    {
                        MessageBox.Show("用户删除成功！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //从ListView中删除用户
                        listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                    }
                    else
                    {
                        MessageBox.Show("用户删除失败···", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择用户", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //删除用户
        public bool delUser(int id)
        {
            using (Trans t = new Trans())
            {
                try
                {
                    DBHelper db = new DBHelper();
                    string sql = "select id from papers where teacherId=" + id;
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    using (DbDataReader reader = db.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            TeacherFunctionForm.delPaper((int)reader[0]);
                        }
                    }
                    delInScores(id, t);
                    delInStu_answers(id, t);
                    delInUsers(id, t);
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

        public void delInScores(int id, Trans t)
        {
            string sql = "delete from scores where studentId=" + id;
            TeacherFunctionForm.executeDel(sql, t);
        }

        public void delInStu_answers(int id, Trans t)
        {
            string sql = "delete from stu_answers where studentId=" + id;
            TeacherFunctionForm.executeDel(sql, t);
        }

        public void delInUsers(int id, Trans t)
        {
            string sql = "delete from users where id=" + id;
            TeacherFunctionForm.executeDel(sql, t);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //清空用户信息对话框的数据
            dialog.user = null;
            //如果在对话框中选择了“确定”，则根据输入信息添加用户
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                addUser(dialog.user);
            }
        }

        //添加用户
        private void addUser(User user)
        {
            if (checkLoginId(user.loginId))
            {
                MessageBox.Show("用户名" + user.loginId + "已存在！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //在数据库中添加一项
            if (addUserInDb(user) <= 0)
            {
                return;
            }
            //在ListView中添加一项
            ListViewItem item = listView1.Items.Add(user.name);
            //根据用户信息更新此项
            updateUser(item, user);
        }

        //根据用户信息更新ListView的项
        private void updateUser(ListViewItem item, User user)
        {
            //先清除此项原来的子项
            item.SubItems.Clear();
            //根据用户信息，添加子项
            item.Text = user.name;
            item.SubItems.Add(user.loginId);
            item.SubItems.Add(user.role);
            item.SubItems.Add(user.major);
            item.SubItems.Add(user.permission);
            item.SubItems.Add((user.state == 0 ? "正常" : "锁定"));
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //没有在ListView中选中用户
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请先从列表中选择要修改的用户");
                return;
            }
            //根据ListView选中项，生成一个User类的实例
            User user = new User();
            ListViewItem item = listView1.SelectedItems[0];
            user.name = item.Text;
            user.loginId = item.SubItems[1].Text;
            user.password = getPasswordByLoginId(user.loginId);
            user.id = getIdByLoginId(user.loginId);
            user.role = item.SubItems[2].Text;
            user.major = item.SubItems[3].Text;
            user.permission = item.SubItems[4].Text;
            user.state = getStateById(user.id);
            //设置对话框的用户数据
            dialog.user = user;
            //显示对话框
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (checkLoginId(dialog.user.loginId, dialog.user.id))
                {
                    MessageBox.Show("用户名" + dialog.user.loginId + "已存在！", "基于虚拟现实的铁路综合运输训练系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //更新数据库中的用户信息
                if (updateUserInDb(dialog.user) <= 0)
                {
                    return;
                }
                //更新ListView中的用户信息
                updateUser(item, dialog.user);
            }
        }

        public bool checkLoginId(string loginId)
        {
            DBHelper db = new DBHelper();
            string sql = "select count(*) from users where loginId='" + loginId + "'";
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

        public bool checkLoginId(string loginId, int id)
        {
            DBHelper db = new DBHelper();
            string sql = "select count(*) from users where loginId='" + loginId + "' and id!=" + id;
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

        private void showAllUsers()
        {
            DBHelper db = new DBHelper();
            string sql = "select * from users where roleId!=3";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        User user = readerToUser(reader);
                        ListViewItem item = listView1.Items.Add(user.name);
                        updateUser(item, user);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static User readerToUser(DbDataReader reader)
        {
            User user = new User();
            user.id = (int)reader["id"];
            user.loginId = (string)reader["loginId"];
            user.password = (string)reader["password"];
            user.name = (string)reader["name"];
            user.major = getMajorByMajorId((int)reader["majorId"]);
            user.role = getRoleByRoleId((int)reader["roleId"]);
            user.permission = convertPermission((string)reader["permission"]);
            user.state = (int)reader["state"];
            return user;
        }

        public static string getMajorByMajorId(int majorId)
        {
            string major = "";
            DBHelper db = new DBHelper();
            string sql = "select name from majors where id=" + majorId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        major = (string)reader["name"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return major;
        }

        public static int getMajorIdByMajor(string major)
        {
            int majorId = 0;
            DBHelper db = new DBHelper();
            string sql = "select id from majors where name='" + major + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        majorId = (int)reader["id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return majorId;
        }

        public static string getRoleByRoleId(int roleId)
        {
            string role = "";
            DBHelper db = new DBHelper();
            string sql = "select name from roles where id=" + roleId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        role = (string)reader["name"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return role;
        }

        public int getRoleIdByRole(string role)
        {
            int roleId = 0;
            DBHelper db = new DBHelper();
            string sql = "select id from roles where name='" + role + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        roleId = (int)reader["id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return roleId;
        }

        public int getStateById(int id)
        {
            int state = 0;
            DBHelper db = new DBHelper();
            string sql = "select state from users where id=" + id;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                state = (int)db.ExecuteScalar(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            return state;
        }

        public int getIdByLoginId(string loginId)
        {
            int id = 0;
            DBHelper db = new DBHelper();
            string sql = "select id from users where loginId='" + loginId + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                id = (int)db.ExecuteScalar(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            return id;
        }

        public string getPasswordByLoginId(string loginId)
        {
            string password = "";
            DBHelper db = new DBHelper();
            string sql = "select password from users where loginId='" + loginId + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        password = (string)reader["password"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return password;
        }

        public static string convertPermission(string permissionBefore)
        {
            string permissionAfter = "";
            string[] str = permissionBefore.Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case "1": permissionAfter += "车务,";
                        break;
                    case "2": permissionAfter += "电务,";
                        break;
                    case "3": permissionAfter += "工务,";
                        break;
                    case "4": permissionAfter += "调度,";
                        break;
                    case "5": permissionAfter += "供电,";
                        break;
                    case "车务": permissionAfter += "1,";
                        break;
                    case "电务": permissionAfter += "2,";
                        break;
                    case "工务": permissionAfter += "3,";
                        break;
                    case "调度": permissionAfter += "4,";
                        break;
                    case "供电": permissionAfter += "5,";
                        break;
                }
            }
            permissionAfter = permissionAfter.Substring(0, permissionAfter.Length - 1);
            return permissionAfter;
        }

        public int addUserInDb(User user)
        {
            int result = 0;
            DBHelper db = new DBHelper();
            string sql = "insert into users values('" + user.loginId + "','" + user.password + "','" + user.name + "'," + getMajorIdByMajor(user.major) + "," + getRoleIdByRole(user.role) + ",'" + convertPermission(user.permission) + "',default)";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                result = db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public int updateUserInDb(User user)
        {
            int result = 0;
            DBHelper db = new DBHelper();
            string sql = "update users set loginId='" + user.loginId + "',password='" + user.password + "',name='" + user.name + "',majorId=" + getMajorIdByMajor(user.major) + ",roleId=" + getRoleIdByRole(user.role) + ",permission='" + convertPermission(user.permission) + "',state=" + user.state + " where id=" + user.id;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                result = db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public User getUserByListView(string selectedLoginId)
        {
            User user = new User();
            DBHelper db = new DBHelper();
            string sql = "select * from users where loginId='" + selectedLoginId + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        user.id = (int)reader["id"];
                        user.loginId = (string)reader["loginId"];
                        user.password = (string)reader["password"];
                        user.name = (string)reader["name"];
                        user.major = getMajorByMajorId((int)reader["majorId"]);
                        user.role = getRoleByRoleId((int)reader["roleId"]);
                        user.permission = convertPermission((string)reader["permission"]);
                        user.state = (int)reader["state"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }


    }
}
