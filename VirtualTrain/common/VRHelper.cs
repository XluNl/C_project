using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace VirtualTrain
{
    class VRHelper
    {
        public static int sceneId;
        public static string SCId;
        //VR场景中玩家角色号集合
        public static int[] playerIndexs;
        //VR场景中所有角色号集合
        public static int[] indexs;
        //VR场景中需登记玩家角色号集合
        public static int[] registerIndexs;


        public enum Operation
        {
            Add,
            Remove
        }

        public static void setSC(int state, int sceneId)
        {
            DBHelper db = new DBHelper();
            string sql = "update vr_scene set sc_state=" + state + " where id=" + sceneId;
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
        }

        public static void setOnlineNum(Operation operation, int sceneId)
        {
            DBHelper db = new DBHelper();
            string sql = "";
            if (operation == Operation.Add)
            {
                sql = "update vr_scene set online_num=online_num+1 where id=" + sceneId;
            }
            else
            {
                sql = "update vr_scene set online_num=online_num-1 where id=" + sceneId;
            }
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
        }

        public enum PhoneOperation
        {
            Online,
            Offline
        }

        public static void setPhoneState(PhoneOperation operation, int index, int sceneId)
        {
            DBHelper db = new DBHelper();
            string sql = "";
            if (operation == PhoneOperation.Online)
            {
                sql = "update VR_role set communicationState='true' where id=" + index + " and VR_scene_id=" + sceneId;
            }
            else
            {
                sql = "update VR_role set communicationState='false' where id=" + index + " and VR_scene_id=" + sceneId;
            }
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);
        }

        public static bool checkPhoneState(int index, int sceneId)
        {
            bool state = false;
            DBHelper db = new DBHelper();
            string sql = "select communicationState from VR_role where id=" + index + " and VR_scene_id=" + sceneId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                state = (bool)db.ExecuteScalar(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            return state;
        }

        public static Role readerToRole(DbDataReader reader)
        {
            Role role = new Role();
            role.id = (int)reader["id"];
            role.name = reader["name"].ToString();
            role.major = UserInfoForm.getMajorByMajorId((int)reader["majorId"]);
            role.sceneId = (int)reader["VR_scene_id"];
            role.isRobot = (bool)reader["isRobot"];
            return role;
        }

        public static Role getUniqueRole(int id, int sceneId)
        {
            Role role = null;
            DBHelper db = new DBHelper();
            string sql = "select * from vr_role where id=" + id + " and VR_scene_id=" + sceneId;
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        role = readerToRole(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return role;
        }
    }
}
