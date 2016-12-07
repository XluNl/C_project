using System;
using System.Collections.Generic;
using System.Text;
using VirtualTrain.model;
using System.Data;
using System.Data.Common;
namespace VirtualTrain.common
{
    class ScriptDAL
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

    }
}
