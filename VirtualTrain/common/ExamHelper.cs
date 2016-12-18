using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain.common
{
    class ExamHelper
    {
        public static int totalSeconds = 1200;  //答题总时间20分钟
        public static int remainSeconds;    //剩余时间

        public static String[] selectAnswers;   //选择题学员答案数组
        public static String[] judgeAnswers;    //判断题学员答案数组

        //public static int questionNum; //试卷题目数量
        //public static Question[] questions = new Question[questionNum];    //试卷题目数组
        //public static string[] studentAnswer = new string[questionNum];   //学员答案数组
    }
}
