using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain
{
    public class Major
    {
        //专业id
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        //专业名
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string ToString()
        {
            return this.name;
        }

    }
}
