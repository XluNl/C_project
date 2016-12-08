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
            return sp;
        }


       /// <summary>
       /// 删除场景（分两步1、删除场景。2、删除场景对应的角色、3、删除场景对应的任务流）
       /// </summary>
       /// <param name="id"></param>
        public bool delectSenceWithID(int id) {

            string sql = "delete from dbo.VR_scenc where id="+id;

            // 场景删除成功
            bool isnot = SQLHelper.ExecuteNonQuery(sql) > 0;
            if (isnot)
            {
                //第2步删除场景对应角色
                //第3步删除场景对应的任
            }
            return isnot;
        }

    }
}
