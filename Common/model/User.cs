using System;
using System.Collections.Generic;
using System.Text;

namespace Common.model
{
    public class User
    {
        //用户id
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        //用户名
        private string _loginId;
        public string loginId
        {
            get { return _loginId; }
            set { _loginId = value; }
        }
        //密码
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        //姓名
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        //专业
        private string _major;
        public string major
        {
            get { return _major; }
            set { _major = value; }
        }
        //角色，1代表学员，2代表教员，3代表管理员
        private string _role;
        public string role
        {
            get { return _role; }
            set { _role = value; }
        }
        //权限
        private string _permission;
        public string permission
        {
            get { return _permission; }
            set { _permission = value; }
        }
        //状态    0代表正常，1代表锁定
        private int _state;
        public int state
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
