using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace VirtualTrain
{
    class GameHelper
    {

        public static Question getQuestion()
        {
            Question question = null;
            DBHelper db = new DBHelper();
            string sql = "select question,OptionA,OptionB,OptionC,OptionD from questions where id=1";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        question = new Question();
                        question.id = (int)reader["id"];
                        question.question = (string)reader["question"];
                        question.answer = (string)reader["answer"];
                        question.major = UserInfoForm.getMajorByMajorId((int)reader["majorId"]);
                        question.optionA = (reader["OptionA"] is DBNull) ? null : ((string)reader["OptionA"]);
                        question.optionB = (reader["OptionB"] is DBNull) ? null : ((string)reader["OptionB"]);
                        question.optionC = (reader["OptionC"] is DBNull) ? null : ((string)reader["OptionC"]);
                        question.optionD = (reader["OptionD"] is DBNull) ? null : ((string)reader["OptionD"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return question;
        }

        public static int getIdByVideo(string name)
        {
            int id = 0;
            DBHelper db = new DBHelper();
            string sql = "select id from game_videos where name='" + name + "'";
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(sql);
                using (DbDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        id = (int)reader["id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return id;
        }
    }
}
