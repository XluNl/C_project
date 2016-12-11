using System;
using System.Collections.Generic;
using System.Text;
using VirtualTrain.model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace VirtualTrain.common
{
   public class ScriptDAL
    {

        /// <summary>
        /// 获取所有角色信息
        /// </summary>
        /// <returns></returns>
        public  List<VR_Role> getRolesWith(){

            List<VR_Role> roles = new List<VR_Role>();

            // 读取所有角色
            DBHelper db = new DBHelper();
           
            string sql = "select * from dbo.VR_roleId as vr_ro where name is not null";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            DataTable table = db.ExecuteDataTable(cmd);

            foreach (DataRow dr in table.Rows)
            {
                roles.Add(RowtoBuliding(dr));
            }
            
            return roles;
        
        }

        private VR_Role RowtoBuliding(DataRow dr)
        {

            VR_Role sc = new VR_Role();
            sc.Id = Convert.ToInt32(dr["id"]);
            sc.Majorld = Convert.ToString(dr["majorId"]);//majorId
            sc.Name = Convert.ToString(dr["name"]);
            return sc;
        }

       /// <summary>
       /// 获取场景 的全部角色
       /// </summary>
       /// <param name="scid"></param>
       /// <returns></returns>
        public List<script> getAllScencRoleWithScencid(int scid) {

            List<script> list = new List<script>();
            string sql = "select *from VR_scenc_roleId where scenc_Id =" + scid;
           
            DataTable tabel = SQLHelper.ExecuteTable(sql);

            foreach (DataRow row in tabel.Rows)
            {
                list.Add(roleWitnRow(row));
            }
            return list;
        }

        private script roleWitnRow(DataRow row)
        {
            script role = new script();
            role.Id = Convert.ToInt32(row["scenc_Id"]);
            role.Screncscriptid = Convert.ToInt32(row["role_Id"]);
            return role;
        }

        /// <summary>
        /// 添加场景
        /// </summary>
        /// <param name="scp">场景信息</param>
        /// <param name="senceScriptS">场景对应的角色</param>
        public bool addScript(script scp,List<script> senceScriptS,out int senceid) {

            string sql = "insert into dbo.VR_scenc values(@scene_isonline,@scenc_name) select @@identity;";
            SqlParameter[] ps = { 
                                new SqlParameter("@scene_isonline",scp.Isonline),
                                new SqlParameter("@scenc_name",scp.Scencname)
                                };
           int num = Convert.ToInt32(SQLHelper.ExecuteScalar(sql, ps));
           senceid = num;
            // 根据场景ID添加对应角色
            if(num>0){
                
                foreach(script sc in senceScriptS){

                    string ss = "insert dbo.VR_scenc_roleId(role_Id,scenc_Id) values(@role_Id,@scenc_Id)";
                    SqlParameter[] pss = { 
                                new SqlParameter("@role_Id",sc.Screncscriptid),
                                new SqlParameter("@scenc_Id",num)
                                };
                   SQLHelper.ExecuteNonQuery(ss,pss);
                }
            }

            return num > 0;
        }

       /// <summary>
       /// 修改场景信息
       /// </summary>
       /// <param name="sc">场景信息</param>
       /// <param name="roles">场景下面所有的任务</param>
       /// <returns></returns>
        public void editSenceWith(script sc,List<script> roles) { 
        
            // 1、第一步修改场景的信息（名称，和是否多人）
            string sql = "update VR_scenc set scenc_name =@scenc_name,scene_isonline=@scene_isonline where id=@id;";
            SqlParameter[] pss = { 
                                new SqlParameter("@scenc_name",sc.Scencname),
                                new SqlParameter("@scene_isonline",sc.Isonline),
                                new SqlParameter("@id",sc.Id)
                                };
            SQLHelper.ExecuteNonQuery(sql, pss);
            // 2、将场景修改后的角色，更新到数据库（先删除所有，再添加）
 
                //01、先删除全部
                string sql_sc = " delete from VR_scenc_roleId where scenc_Id="+sc.Id;
                SQLHelper.ExecuteNonQuery(sql_sc);
                
                //02、再添加
                foreach (script ro in roles)
                {
                string ss = "insert VR_scenc_roleId(role_Id,scenc_Id) values(@role_Id,@scenc_Id)";
                    SqlParameter[] sp = { 
                                new SqlParameter("@role_Id",ro.Screncscriptid),
                                new SqlParameter("@scenc_Id",sc.Id)
                                };
                    SQLHelper.ExecuteNonQuery(ss, sp);
                }

        }

       /// <summary>
       /// 获取全部场景
       /// </summary>
       /// <returns></returns>
        public List<script> getAllSence() {

            List<script> list = new List<script>();

            string sql = "select *from dbo.VR_scenc";

            DataTable tabel = SQLHelper.ExecuteTable(sql);

            foreach(DataRow scp in tabel.Rows){

                list.Add(ScrptTabelWithMode(scp));
            }

            return list;
        }

        private script ScrptTabelWithMode(DataRow scp)
        {
            script sp = new script();
            sp.Id = Convert.ToInt32(scp["id"]);
            sp.Scencname = scp["scenc_name"].ToString();
            sp.Isonline = Convert.ToInt32(scp["scene_isonline"]);
            return sp;
        }


       /// <summary>
       /// 删除场景（分两步1、删除场景。2、删除场景对应的角色、3、删除场景对应的任务流）
       /// </summary>
       /// <param name="id"></param>
        public bool delectSenceWithID(int scencid) {

            string sql = "delete from dbo.VR_scenc where id=" + scencid;

            // 3、场景删除成功
            bool isnot = SQLHelper.ExecuteNonQuery(sql) > 0;
            if (isnot)
            {
                //2、删除场景对应角色
                string sql_role = "delete from VR_scenc_roleId where scenc_Id ="+scencid;
                //1、步删除场景对应的任务
                string sql_task = "delete from task where Senceid ="+scencid;
            }
            return isnot;
        }

        public bool checkRoleOnScencIsNotWith(int scencid,int roleid) {

            string sql = "select COUNT(*) from task where Senceid =@Senceid and Taskroleid =@Taskroleid";

            SqlParameter[] sp = { 
                                new SqlParameter("@Senceid",scencid),
                                new SqlParameter("@Taskroleid",roleid),
                                };

            int num =  (int)SQLHelper.ExecuteScalar(sql,sp);

            return num > 0;

        }


    }
}
