using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain
{
    public class Question
    {
        //题目id
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        //问题
        private string _question;
        public string question
        {
            get { return _question; }
            set { _question = value; }
        }
        //答案
        private string _answer;
        public string answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        //题目难度
        private string _difficulty;
        public string difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }
        //题目所属专业
        private string _major;
        public string major
        {
            get { return _major; }
            set { _major = value; }
        }
        //题目所属类型
        private string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        //选项A
        private string _optionA;
        public string optionA
        {
            get { return _optionA; }
            set { _optionA = value; }
        }
        //选项B
        private string _optionB;
        public string optionB
        {
            get { return _optionB; }
            set { _optionB = value; }
        }
        //选项C
        private string _optionC;
        public string optionC
        {
            get { return _optionC; }
            set { _optionC = value; }
        }
        //选项D
        private string _optionD;
        public string optionD
        {
            get { return _optionD; }
            set { _optionD = value; }
        }
        //题目分数
        private int _mark;
        public int mark
        {
            get { return _mark; }
            set { _mark = value; }
        }
        //题目的question_paper_id
        private int _question_paper_id;
        public int question_paper_id
        {
            get { return _question_paper_id; }
            set { _question_paper_id = value; }
        }
        //题目的学员答案
        private string _stuAnswer;
        public string stuAnswer
        {
            get { return _stuAnswer; }
            set { _stuAnswer = value; }
        }

        public override string ToString()
        {
            if (mark == 0)
            {
                if (difficulty == null)
                {
                    return string.Format("{0,-60}\t{1,-4}", cutQuestion(this.question, 7), this.type);
                }
                else
                {
                    return string.Format("{0,-60}\t{1,-4},{2,-4}", cutQuestion(this.question, 7), this.type, this.difficulty);
                }
            }
            else
            {
                if (difficulty == null)
                {
                    return string.Format("{0,-60}\t{1,-4},{2,-1}分", cutQuestion(this.question, 7), this.type, this.mark);
                }
                else
                {
                    return string.Format("{0,-60}\t{1,-4},{2,-4},{3,-1}分", cutQuestion(this.question, 7), this.type, this.difficulty, this.mark);
                }
            }
        }

        public string cutQuestion(string question, int len)
        {
            if (question.Length > len)
            {
                return question.Substring(0, len) + "···";
            }
            else
            {
                return question;
            }
        }

    }
}
