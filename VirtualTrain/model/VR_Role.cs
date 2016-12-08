using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrain.model
{
   public class VR_Role
    {
        //场景id
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        //角色工种
        private string _majorld;

        public string Majorld
        {
            get { return _majorld; }
            set { _majorld = value; }
        }

        //角色名称
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
