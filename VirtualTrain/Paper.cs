using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain
{
    public class Paper
    {
        //试卷id
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        //试卷名
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        //发布时间
        private string _publishTime;
        public string publishTime
        {
            get { return _publishTime; }
            set { _publishTime = value; }
        }
        //所属专业
        private string _major;
        public string major
        {
            get { return _major; }
            set { _major = value; }
        }
        //出、评卷人姓名
        private string _teacherName;
        public string teacherName
        {
            get { return _teacherName; }
            set { _teacherName = value; }
        }
    }
}
