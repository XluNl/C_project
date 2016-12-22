using System;
using System.Collections.Generic;
using System.Text;
using Common.common;
namespace Common.model
{
    public class Room
    {
        TaskDAL td = new TaskDAL();
        public Room(int sceneId)
        {
            this.sceneId = sceneId;
            this._tasks = td.getAllWitnSenceID(sceneId);
            this._maxNum = td.getAllRoleWithSenceID(sceneId).Count;
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
        private int _maxNum;
        public int maxNum
        {
            get { return _maxNum; }
        }

        private List<Gamer> _gamerList = new List<Gamer>();
        public List<Gamer> gamerList
        {
            get { return _gamerList; }
            set { _gamerList = value; }
        }

        private List<TaskModel> _tasks;
        public List<TaskModel> tasks
        {
            get { return _tasks; }
        }

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
