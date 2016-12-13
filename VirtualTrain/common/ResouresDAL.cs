using System;
using System.Collections.Generic;
using System.Text;
using VirtualTrain.model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace VirtualTrain.common
{
   public class ResouresDAL
    {
        //////////////////////////////////////////////////////

        /// <summary>
        ///获取全部资源
        /// </summary>
        public DataTable getAllResources(int type)
        {
            string sql = "";
            if (type < 3)
            {
                sql = "select *from game_questions where type="+type;
            }
            else { 
                 sql = "select *from game_questions";
            }
            return SQLHelper.ExecuteTable(sql);

           
        }

       
    }
}
