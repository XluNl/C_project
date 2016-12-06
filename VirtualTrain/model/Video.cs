using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain
{
    public class Video
    {
        //id
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        //视频名称
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        //开始时刻
        private string _startTime;
        public string startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        //结束时刻
        private string _endTime;
        public string endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        //视频所属专业
        private string _major;
        public string major
        {
            get { return _major; }
            set { _major = value; }
        }

        //视频所属专业
        private string _url;
        public string url
        {
            get { return _url; }
            set { _url = value; }
        }
    }
}
