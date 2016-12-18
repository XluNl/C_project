using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain.common
{
    class AutoSetQuestionHelper
    {
        public static int[] allQuestionId;  //所有问题的Id数组
        public static bool[] selectedState;    //记录对应索引的问题是否已经被随机抽中
        public static int[] selectedQuestionId; //选出问题的Id数组
    }
}
