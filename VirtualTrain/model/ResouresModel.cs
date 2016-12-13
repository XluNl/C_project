using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain.model
{
   public class ResouresModel
    {
       private int id;//资源ID

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string question;//资源名称

        public string Question
        {
            get { return question; }
            set { question = value; }
        }
        private string answer;//选择题答案

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        private int majorId;//所属专业

        public int MajorId
        {
            get { return majorId; }
            set { majorId = value; }
        }
        private int type;//所属问题类型

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        private string optionA;

        public string OptionA
        {
            get { return optionA; }
            set { optionA = value; }
        }
        private string optionB;

        public string OptionB
        {
            get { return optionB; }
            set { optionB = value; }
        }
        private string optionC;

        public string OptionC
        {
            get { return optionC; }
            set { optionC = value; }
        }
        private string optionD;

        public string OptionD
        {
            get { return optionD; }
            set { optionD = value; }
        }
        private string fileName;//文件名称

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private float startTime;//开始时间

        public float StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private float endTime;//结束时间

        public float EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }
}
