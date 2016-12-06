using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain
{
    public class Mission
    {
        //id
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        //任务名称
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        //代码
        private string _code;
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        //场景号
        private int _sceneId;
        public int sceneId
        {
            get { return _sceneId; }
            set { _sceneId = value; }
        }
        //角色
        private string _role;
        public string role
        {
            get { return _role; }
            set { _role = value; }
        }
    }
}
