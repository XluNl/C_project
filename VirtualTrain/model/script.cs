using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain.model
{
   public class script
    {
        //场景id
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        //是否联机
        private int _isonline;

        public int Isonline
        {
            get { return _isonline; }
            set { _isonline = value; }
        }


        //场景名称
        private string _scencname;

        public string Scencname
        {
            get { return _scencname; }
            set { _scencname = value; }
        }

        // 
        private int _screncscriptid;

        public int Screncscriptid
        {
            get { return _screncscriptid; }
            set { _screncscriptid = value; }
        }
        private string _screncscriptname;

        public string Screncscriptname
        {
            get { return _screncscriptname; }
            set { _screncscriptname = value; }
        }
    }
}
