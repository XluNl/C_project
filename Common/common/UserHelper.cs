using Common.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.common
{
    //用来记录登录的用户名、登录类型
    public  class UserHelper
    {
        private UserHelper() { }

        public static string loginId;   //登录用户名
        public static string loginType;   //登录类型
        public static User user;

        public static int currentMajorId;   //当前所在专业

        public static int sceneId = -1;     //当前场景号
        public static int roleId = -1;       //用户在场景中角色号

        public static List<TaskModel> tasks; //存储当前场景tasks;

    }
}
