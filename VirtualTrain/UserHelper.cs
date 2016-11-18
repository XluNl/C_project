using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace VirtualTrain
{
    //用来记录登录的用户名、登录类型
    class UserHelper
    {
        public static string loginId;   //登录用户名
        public static string loginType;   //登录类型
        public static User user;

        public static int currentMajorId;   //当前所在专业
        public static int index = -1;       //用户在VR场景中角色号

    }
}
