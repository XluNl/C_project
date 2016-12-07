using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain.model
{
    class script
    {
        //场景id
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        //是否联机
        private bool _isonline;

        public bool Isonline
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
    }
}
