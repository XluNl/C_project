using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Common.model;
using System.Text.RegularExpressions;
namespace Common.common
{
    public class TaskDAL
    {

        /// <summary>
        /// 添加一条任务
        /// </summary>
        /// <param name="task">要添加的任务模型</param>
        public int addOneTask(TaskModel task)
        {

            string sql = "insert into task values(@Senceid,@Taskname,@Taskroleid,@Taskid,@Sortindex) select @@identity";
            SqlParameter[] sp = {
                        new SqlParameter("@Senceid",task.Senceid),
                        new SqlParameter("@Taskname",task.Taskname),
                        new SqlParameter("@Taskroleid",task.Taskroleid),
                        new SqlParameter("@Taskid",task.Taskid),
                        new SqlParameter("@Sortindex",task.Sortindex)
           };
            return Convert.ToInt32(SQLHelper.ExecuteScalar(sql, sp));
        }

        /// <summary>
        /// 获得一个场景所有的任务
        /// </summary>
        /// <param name="senceid">场景id</param>
        public List<TaskModel> getAllWitnSenceID(int senceid)
        {

            List<TaskModel> tasklist = new List<TaskModel>();
            string sql = "select  *from task where Senceid=" + senceid + "ORDER BY Sortindex";
            DataTable tabel = SQLHelper.ExecuteTable(sql);

            foreach (DataRow row in tabel.Rows)
            {

                tasklist.Add(taskWitnRow(row));
            }

            return tasklist;
        }

        private TaskModel taskWitnRow(DataRow row)
        {
            TaskModel task = new TaskModel();
            task.Senceid = Convert.ToInt32(row["Senceid"]);
            task.Sortindex = Convert.ToInt32(row["Sortindex"]);
            task.Taskid = Convert.ToInt32(row["Taskid"]);
            task.Taskroleid = Convert.ToInt32(row["Taskroleid"]);
            task.Taskname = row["Taskname"].ToString();
            task.Keyid = Convert.ToInt32(row["id"]);
            return task;
        }

        /// <summary>
        /// 删除场景中的一条任务
        /// </summary>
        /// <param name="task">要删除的任务模型</param>
        public bool delectTask(TaskModel task)
        {

            string sql = "delete from task where Senceid =@Senceid and Taskroleid =@Taskroleid and id=@id";

            SqlParameter[] sp = { 
                                new SqlParameter("@Senceid",task.Senceid),
                                new SqlParameter("@Taskroleid",task.Taskroleid),
                                new SqlParameter("@id",task.Keyid)
                               };

            return SQLHelper.ExecuteNonQuery(sql, sp) > 0;

        }

        /// <summary>
        /// 修改一条任务
        /// </summary>
        /// <param name="task">要修改的任务模型</param>
        public bool editTask(TaskModel task)
        {
            string sql_adit = "update task set Taskroleid = @Taskroleid,Taskid=@Taskid where id=@id and Senceid=@Senceid";
            SqlParameter[] sp = { 
                                new SqlParameter("@Taskid",task.Taskid),
                                new SqlParameter("@Taskroleid",task.Taskroleid),
                                 new SqlParameter("@id",task.Keyid),
                                  new SqlParameter("@Senceid",task.Senceid)
                              };
            return SQLHelper.ExecuteNonQuery(sql_adit, sp) > 0;
        }

        /// <summary>
        /// 为任务排序
        /// </summary>
        /// <param name="task"></param>
        public void sortWithIndex(TaskModel task)
        {

            string sql_sort = "update task set Sortindex =@Sortindex where Taskroleid=@Taskroleid and Senceid=@Senceid and id = @id";

            SqlParameter[] sp = { 
                               new SqlParameter("@Sortindex",task.Sortindex),
                               new SqlParameter("@Taskroleid",task.Taskroleid),
                               new SqlParameter("@Senceid",task.Senceid),
                               new SqlParameter("@id",task.Keyid)
                               };

            SQLHelper.ExecuteNonQuery(sql_sort, sp);
        }
        /// <summary>
        /// 更具场景id 查出场景里所有的角色
        /// </summary>
        /// <returns></returns>
        public List<Role> getAllRoleWithSenceID(int senceid)
        {

            List<Role> list = new List<Role>();

            string sql = "select orsc.role_Id,rol.name from  VR_scenc_roleId as orsc inner join VR_roleId as rol on orsc.role_Id = rol.id where scenc_Id=" + senceid;

            DataTable tabel = SQLHelper.ExecuteTable(sql);

            foreach (DataRow row in tabel.Rows)
            {

                list.Add(roleWitnRow(row));
            }

            return list;
        }

        private Role roleWitnRow(DataRow row)
        {
            Role rol = new Role();
            rol.id = Convert.ToInt32(row["role_Id"]);
            rol.name = row["name"].ToString();
            return rol;
        }

        /// <summary>
        /// 根据场景任务 id获得一条资源
        /// </summary>
        /// <param name="resid"></param>
        /// <returns></returns>
        public ResouresModel getOneResourcesWithId(int resid)
        {
            string sq = "select *from game_questions where id =" + resid;
            DataTable table = SQLHelper.ExecuteTable(sq);

            // 取一个，正常情况下也只有一个
            ResouresModel res = new ResouresModel();
            res.Id = Convert.ToInt32(table.Rows[0]["id"]);
            res.Question = table.Rows[0]["question"].ToString();
            res.MajorId = Convert.ToInt32(table.Rows[0]["majorId"]);
            res.Type = Convert.ToInt32(table.Rows[0]["type"]);

            res.Answer = !table.Rows[0].IsNull("answer")?table.Rows[0]["answer"].ToString():"";
            res.OptionA = !table.Rows[0].IsNull("OptionA")?table.Rows[0]["OptionA"].ToString():"";
            res.OptionB = !table.Rows[0].IsNull("OptionB") ? table.Rows[0]["OptionB"].ToString() : "";
            res.OptionC = !table.Rows[0].IsNull("OptionC") ? table.Rows[0]["OptionC"].ToString() : "";
            res.OptionD = !table.Rows[0].IsNull("OptionD") ? table.Rows[0]["OptionD"].ToString() : "";
            res.FileName =!table.Rows[0].IsNull("fileName")?table.Rows[0]["fileName"].ToString():"";
            res.StartTime =!table.Rows[0].IsNull("startTime")? Convert.ToDouble(table.Rows[0]["startTime"]):-1;
            res.EndTime = !table.Rows[0].IsNull("endTime") ? Convert.ToDouble(table.Rows[0]["endTime"]) : -1; ;
            return res;
        }

        public string getRoomBySceneId(List<Room> rooms, int sceneId)
        {
            string roomInfo = "";
            List<Room> room = new List<Room>();
            foreach (var r in rooms)
            {
                if (r.sceneId == sceneId)
                {
                    room.Add(r);
                }
            }
            foreach (Room r in room)
            {
                roomInfo += r.name + "_";
                roomInfo += r.pwd + "_";
                roomInfo += r.gamerList.Count + "_";
                roomInfo += r.maxNum + ";";
            }
            roomInfo = roomInfo.Substring(0, roomInfo.Length - 1);
            return roomInfo;
        }

        public Room getRoomByName(List<Room> rooms, string roomName)
        {
            Room room = null;
            foreach (Room r in rooms)
            {
                if (r.name == roomName)
                {
                    room = r;
                    break;
                }
            }
            return room;
        }

        //获取房间中玩家选择状态
        public string getGamerStateByRoom(Room room)
        {
            string gamerInfo = "";

            if (room != null && room.gamerList != null && room.gamerList.Count > 0)
            {
                foreach (Gamer gamer in room.gamerList)
                {
                    if (!string.IsNullOrEmpty(gamer.ToString()))
                    {
                        gamerInfo += gamer.ToString() + "_";
                    }
                }
                if (!string.IsNullOrEmpty(gamerInfo))
                {
                    gamerInfo = gamerInfo.Substring(0, gamerInfo.Length - 1);
                }

            }
            return gamerInfo;
        }

        public Room getRoomByGamer(List<Room> rooms, Gamer gamer)
        {
            Room room = null;
            foreach (Room r in rooms)
            {
                if (r.gamerList.Contains(gamer))
                {
                    room = r;
                    break;
                }
            }
            return room;
        }

        //获得字符串中某字符个数
        public int regexStr(string str, string reg)
        {
            Regex rg = new Regex(reg);
            MatchCollection mc = rg.Matches(str);
            return mc.Count;
        }
    }
}
