using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain.model
{
   public class TaskModel
    {
        //任务排序编号
        private int _sortindex;

        public int Sortindex
        {
            get { return _sortindex; }
            set { _sortindex = value; }
        }
        //任务所属场景id
        private int _senceid;

        public int Senceid
        {
            get { return _senceid; }
            set { _senceid = value; }
        }
        //任务名称
        private string _taskname;

        public string Taskname
        {
            get { return _taskname; }
            set { _taskname = value; }
        }

        //任务对应角色
        private int _taskroleid;

        public int Taskroleid
        {
            get { return _taskroleid; }
            set { _taskroleid = value; }
        }

        //任务在对应场景中的唯一ID
        private int _keyid;

        public int Keyid
        {
            get { return _keyid; }
            set { _keyid = value; }
        }

       
        //任务在资源表中的唯一ID
        private int _taskid;

        public int Taskid
        {
            get { return _taskid; }
            set { _taskid = value; }
        }

    }
}
