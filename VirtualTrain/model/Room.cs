using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain
{
    public class Room
    {
        //名称
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        //密码
        private string _pwd;
        public string pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }

        //最大人数
        private string _maxNum;
        public string maxNum
        {
            get { return _maxNum; }
            set { _maxNum = value; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
