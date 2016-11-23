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
        //是否完成
        private bool _isCompleted;
        public bool isCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }
        //是否解锁
        private bool _isOpened;
        public bool isOpened
        {
            get { return _isOpened; }
            set { _isOpened = value; }
        }
        //场景号
        private int _sceneId;
        public int sceneId
        {
            get { return _sceneId; }
            set { _sceneId = value; }
        }
        //角色号
        private int _roleId;
        public int roleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }
    }
}
