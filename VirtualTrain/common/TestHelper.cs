using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain
{
    class TestHelper
    {
        public static int totalSeconds = 1200;  //答题总时间20分钟
        public static int remainSeconds;    //剩余时间

        public static int[] allQuestionId;  //所有问题的Id数组
        public static bool[] selectedState;    //记录对应索引的问题是否已经被随机抽中

        public static int questionNum = 20; //题目数量
        public static int[] selectedQuestionId = new int[questionNum];    //选出问题的Id数组
        public static string[] correctAnswer = new string[questionNum];   //标准答案数组
        public static string[] studentAnswer = new string[questionNum];   //学员答案数组
    }
}
