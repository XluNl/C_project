using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain
{
    public class Role
    {
        //id
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        //角色职位
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        //角色部门
        private string _major;
        public string major
        {
            get { return _major; }
            set { _major = value; }
        }
        //角色所属场景号
        private int _sceneId;
        public int sceneId
        {
            get { return _sceneId; }
            set { _sceneId = value; }
        }
        //是否为机器人
        private bool _isRobot;
        public bool isRobot
        {
            get { return _isRobot; }
            set { _isRobot = value; }
        }
    }
}
