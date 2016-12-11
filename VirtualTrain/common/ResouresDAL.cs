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
        public DataTable getAllResources()
        {
            string sql = "select *from game_questions";
            return SQLHelper.ExecuteTable(sql);

            string sq = "select *from game_questions where id = 4;";
        }

       
    }
}
