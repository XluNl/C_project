using System;
using System.Collections.Generic;
using System.Text;
using Common.common;
using Common.model;

namespace Common.model
{
    public class Room
    {
        TaskDAL td = new TaskDAL();
        public Room(int sceneId)
        {
            this.sceneId = sceneId;
            this._tasks = td.getAllWitnSenceID(sceneId);
            this._maxNum = td.getAllRoleWithSenceID(sceneId).Count.ToString();
        }

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
        }

        private List<Gamer> _gamerList;
        public List<Gamer> gamerList
        {
            get { return _gamerList; }
            set { _gamerList = value; }
        }

        private List<TaskModel> _tasks;

        private int _taskIndex;
        public int taskIndex
        {
            get { return _taskIndex; }
            set { _taskIndex = value; }
        }

        private int _sceneId;
        public int sceneId
        {
            get { return _sceneId; }
            set { _sceneId = value; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
