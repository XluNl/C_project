using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace VirtualTrain.common
{
    class ClientDAL
    {
        private static ClientDAL _instance = new ClientDAL();

        private ClientDAL()
        {
            try
            {
                ServerIP = ConfigurationManager.AppSettings["ip"];
                port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
                client = new TcpClient();
                client.Connect(IPAddress.Parse(ServerIP), port);
                //MessageBox.Show("连接成功");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("连接失败，原因：" + ex.Message);
                return;
            }
            //获取网络流
            NetworkStream networkStream = client.GetStream();
            //将网络流作为二进制读写对象
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
            //SendMessage("Login," + txt_UserName.Text);
            startNewThread();
        }

        public void  startNewThread(){
            Thread threadReceive = new Thread(new ThreadStart(ReceiveData));
            threadReceive.IsBackground = true;
            threadReceive.Start();
        }
        /// <summary>
        /// 获取单一实例
        /// </summary>
        /// <returns></returns>
        public static ClientDAL GetInstance()
        {
            return _instance;
        }

        private static string ServerIP;

        private static int port;

        private bool isExit = false;
        private TcpClient client;
        private BinaryReader br;
        private BinaryWriter bw;

        public delegate void OperateHandler();
        private event OperateHandler OperateEvent;

        public delegate void ShowHandler(string Info);
        private event ShowHandler ShowEvent;

        public delegate void OperateWithConditionHandler(bool condition);
        private event OperateWithConditionHandler OperateWithConditionEvent;

        // 注册事件
        public void Register(Delegate method)
        {
            if (method is ShowHandler)
            {
                ShowEvent = method as ShowHandler;
            }
            else if (method is OperateHandler)
            {
                OperateEvent = method as OperateHandler;
            }
            else if (method is OperateWithConditionHandler)
            {
                OperateWithConditionEvent = method as OperateWithConditionHandler;
            }

        }

        // 取消注册
        public void UnRegister(Delegate method)
        {
            //NumberChanged -= method;
        }

        /// <summary>
        /// 处理服务器信息
        /// </summary>
        private void ReceiveData()
        {
            string receiveString = null;
            while (isExit == false)
            {
                try
                {
                    //从网络流中读出字符串
                    //此方法会自动判断字符串长度前缀，并根据长度前缀读出字符串
                    receiveString = br.ReadString();
                }
                catch
                {
                    if (isExit == false)
                    {
                        //MessageBox.Show("与服务器失去连接");
                    }
                    break;
                }
                string[] splitString = receiveString.Split(',');
                string command = splitString[0].ToLower();
                switch (command)
                {
                    case "login":   //格式： login,用户名
                        //AddOnline(splitString[1]);
                        break;
                    case "logout":  //格式： logout,用户名
                        //RemoveUserName(splitString[1]);
                        break;


                    case "wait":
                        if (OperateEvent != null)
                        {
                            OperateEvent();
                        }
                        break;
                    case "play":    //格式：play,资源id
                    case "showroom":     //得到某场景所有房间，格式showroom,房间名_密码_在线人数_最大人数;房间名_```
                    //if (ShowEvent!=null)
                    //{
                    //    ShowEvent(splitString[1]);
                    //}
                    //break;
                    case "showstate":   //得到某房间在线玩家选择状态，格式showstate,角色号_角色号···
                        if (ShowEvent != null)
                        {
                            ShowEvent(splitString[1]);
                        }
                        break;
                    case "startgame":
                        bool condition = Convert.ToBoolean(splitString[1]);
                        if (OperateWithConditionEvent != null)
                        {
                            OperateWithConditionEvent(condition);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 向服务端发送消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                bw.Write(message);
                bw.Flush();
            }
            catch
            {
                //MessageBox.Show("发送失败");
            }
        }

        private void close()
        {
            //未与服务器连接前 client 为 null
            if (client != null)
            {
                try
                {
                    //SendMessage("Logout," + txt_UserName.Text);
                    isExit = true;
                    br.Close();
                    bw.Close();
                    client.Close();
                }
                catch
                {
                }
            }
        }
    }
}
