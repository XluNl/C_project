using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using VirtualTrain.model;

namespace VirtualTrain.common
{
    class GameHelper
    {

        public enum Mode
        {
            Offline,
            Online
        }

        public static Mode mode;

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



        //秒的时间格式显示
        public static String secondsToStr(double time)
        {
            String result = "";
            int seconds = (int)(time / 1000);
            //System.out.println("毫秒数:-->"+time+" 秒-->"+seconds);
            int hour = 0;
            int minute = 0;
            int second = 0;
            if (seconds > 60)
            {
                if (seconds > 3600)
                {
                    hour = seconds / 3600;
                    minute = seconds % 3600 / 60;
                    second = seconds % 3600 % 60 % 60;
                }
                else
                {
                    second = seconds % 60;
                    minute = seconds / 60;
                }
            }
            else
            {
                second = seconds;
            }
            result = parseStr(hour) + ":" + parseStr(minute) + ":"
            + parseStr(second);
            return result;
        }

        private static String parseStr(int time)
        {
            if (time >= 10)
            {
                return time + "";
            }
            return "0" + time;
        }

    }
}
