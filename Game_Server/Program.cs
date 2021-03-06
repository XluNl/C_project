﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Configuration;
using Common.model;
using Common.common;
using System.Runtime.InteropServices;

namespace Game_Server
{
    class Program
    {
        /// <summary>
        /// 保存连接的所有用户
        /// </summary>
        private static List<Gamer> gamerList;
        private static List<TaskModel> tasks;
        //当前任务序号
        private static int taskIndex;
        //所有房间
        private static List<Room> roomList = new List<Room>();

        private static Room room;
        static TaskDAL dal = new TaskDAL();

        /// <summary>
        /// 服务器IP地址
        /// </summary>;
        private static string ServerIP = ConfigurationManager.AppSettings["ip"];
        /// <summary>
        /// 监听端口
        /// </summary>
        private static int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);


        private static TcpListener myListener;

        /// <summary>
        /// 是否正常退出所有接收线程
        /// </summary>
        static bool isNormalExit = false;


        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void startServer()
        {
            myListener = new TcpListener(IPAddress.Parse(ServerIP), port);
            myListener.Start();
            statusInfo(string.Format("开始在{0}:{1}监听客户连接", ServerIP, port));
            //创建一个线程监客户端连接请求
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();
        }

        /// <summary>
        /// 接收客户端连接
        /// </summary>
        private static void ListenClientConnect()
        {
            TcpClient newClient = null;
            while (true)
            {
                try
                {
                    newClient = myListener.AcceptTcpClient();
                }
                catch
                {
                    //当单击‘停止监听’或者退出此窗体时 AcceptTcpClient() 会产生异常
                    //因此可以利用此异常退出循环
                    break;
                }
                //每接收一个客户端连接，就创建一个对应的线程循环接收该客户端发来的信息；
                Gamer gamer = new Gamer(newClient);
                Thread threadReceive = new Thread(ReceiveData);
                threadReceive.Start(gamer);
                statusInfo(string.Format("[{0}]进入", newClient.Client.RemoteEndPoint));
                //statusInfo(string.Format("当前连接用户数：{0}", gamerList.Count));
            }

        }

        /// <summary>
        /// 处理接收的客户端信息
        /// </summary>
        /// <param name="userState">客户端信息</param>
        private static void ReceiveData(object userState)
        {
            Gamer gamer = (Gamer)userState;
            TcpClient client = gamer.client;
            int sceneId;
            while (isNormalExit == false)
            {
                string receiveString = null;
                try
                {
                    //从网络流中读出字符串，此方法会自动判断字符串长度前缀
                    receiveString = gamer.br.ReadString();
                }
                catch (Exception)
                {
                    if (isNormalExit == false)
                    {
                        statusInfo(string.Format("与[{0}]失去联系，已终止接收该用户信息", client.Client.RemoteEndPoint));
                        //RemoveGamer(gamer);
                    }
                    break;
                }
                statusInfo(string.Format("来自[{0}]：{1}", gamer.client.Client.RemoteEndPoint, receiveString));
                string[] splitString = receiveString.Split(',');
                switch (splitString[0])
                {
                    case "Login":      //玩家选定角色接口，格式Login,角色号

                        gamer.roleId = splitString[1];
                        statusInfo(string.Format(client.Client.RemoteEndPoint + "选择了{0}角色", splitString[1]));

                        break;
                    case "Logout":  //玩家退出房间接口，格式Logout
                        room = dal.getRoomByGamer(roomList, gamer);
                        RemoveGamer(gamer);

                        break;
                    case "Next":
                        NextMission(gamer);
                        break;
                    case "CreateRoom":      //创建房间接口，格式CreateRoom,场景号,房间名称,房间密码
                        sceneId = Convert.ToInt32(splitString[1]);
                        string rName = splitString[2];
                        string rPwd = splitString[3];
                        room = new Room(sceneId);
                        room.name = rName;
                        room.pwd = rPwd;
                        room.gamerList.Add(gamer);
                        roomList.Add(room);
                        statusInfo(string.Format("创建{0}房间成功", rName));

                        break;
                    case "ShowRoom":    //返回某场景所有房间，格式ShowRoom,场景号
                        sceneId = Convert.ToInt32(splitString[1]);
                        if (roomList != null && roomList.Count > 0)
                        {
                            SendToClient(gamer, "showroom," + dal.getRoomBySceneId(roomList, sceneId));
                        }
                        break;
                    case "EnterRoom":   //将玩家加入某房间，格式EnterRoom,房间名
                        string roomName = splitString[1];
                        room = dal.getRoomByName(roomList, roomName);
                        room.gamerList.Add(gamer);
                        statusInfo(string.Format(client.Client.RemoteEndPoint + "进入{0}房间", roomName));
                        break;
                    case "ShowState":    //返回某房间在线玩家选择状态，格式ShowState
                        if (dal.getRoomByGamer(roomList, gamer)!=null)
                        {
                            room = dal.getRoomByGamer(roomList, gamer);
                        }
                       
                        gamerList = room.gamerList;
                        string gamerInfo = dal.getGamerStateByRoom(room);
                        if (!string.IsNullOrEmpty(gamerInfo))
                        {
                            if (room.gamerList.Count >= room.maxNum && dal.regexStr(gamerInfo, "_") == (room.maxNum - 1))
                            {
                                SendToAllClient(gamer, "startgame");
                            }
                            else
                            {
                                SendToAllClient(null, "showstate," + gamerInfo);
                            }
                        }
                        else
                        {
                            SendToAllClient(null, "showstate,-1" );
                        }
                        break;
                    default:
                        statusInfo("什么意思啊：" + receiveString);
                        break;
                }
            }
        }

        /// <summary>
        /// 发送消息给所有客户
        /// </summary>
        /// <param name="gamer">指定发给哪个用户</param>
        /// <param name="message">信息内容</param>
        private static void SendToAllClient(Gamer gamer, string message)
        {
            string command = message.Split(',')[0].ToLower();
            if (command == "login")
            {
                //获取所有客户端在线信息到当前登录用户
                for (int i = 0; i < gamerList.Count; i++)
                {
                    SendToClient(gamer, "login," + gamerList[i].roleId);
                }
                //把自己上线，发送给所有客户端
                for (int i = 0; i < gamerList.Count; i++)
                {
                    if (gamer.roleId != gamerList[i].roleId)
                    {
                        SendToClient(gamerList[i], "login," + gamer.roleId);
                    }
                }
            }
            else if (command == "logout")
            {
                for (int i = 0; i < gamerList.Count; i++)
                {
                    if (gamerList[i].roleId != gamer.roleId)
                    {
                        SendToClient(gamerList[i], message);
                    }
                }
            }
            else if (command == "showstate" || command == "wait")
            {
                for (int i = 0; i < gamerList.Count; i++)
                {
                    SendToClient(gamerList[i], message);
                }
            }
            else if (command == "startgame")
            {
                for (int i = 0; i < gamerList.Count; i++)
                {
                    if (gamerList[i].roleId != gamer.roleId)
                    {
                        SendToClient(gamerList[i], message + ",false");
                    }
                    else
                    {
                        SendToClient(gamer, message + ",true");
                    }
                }
            }
        }

        /// <summary>
        /// 发送 message 给 gamer
        /// </summary>
        /// <param name="gamer">指定发给哪个用户</param>
        /// <param name="message">信息内容</param>
        private static void SendToClient(Gamer gamer, string message)
        {
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                gamer.bw.Write(message);
                gamer.bw.Flush();
                statusInfo(string.Format("向[{0}]发送：{1}", gamer.roleId, message));
            }
            catch
            {
                statusInfo(string.Format("向[{0}]发送信息失败", gamer.roleId));
            }
        }

        /// <summary>
        /// 移除用户
        /// </summary>
        /// <param name="gamer">指定要移除的用户</param>
        private static void RemoveGamer(Gamer gamer)
        {
            gamer.roleId = null;
            room = dal.getRoomByGamer(roomList, gamer);
            gamerList = room.gamerList;
            gamerList.Remove(gamer);
            //gamer.Close();
            statusInfo(string.Format("{0}退出房间{1}", gamer.client.Client.RemoteEndPoint, room.name));
            statusInfo(string.Format("房间{0}当前连接用户数：{1}", room.name, gamerList.Count));
            if (gamerList.Count <= 0)
            {
                roomList.Remove(room);
                statusInfo(string.Format("房间{0}已关闭", room.name));
            }
        }

        private static void NextMission(Gamer gamer)
        {
            room = dal.getRoomByGamer(roomList, gamer);
            gamerList = room.gamerList;
            tasks = room.tasks;
            taskIndex = room.taskIndex;
            if (taskIndex < tasks.Count)
            {
                foreach (Gamer g in gamerList)
                {
                    if (g.roleId.Equals(tasks[taskIndex].Taskroleid.ToString()))
                    {
                        SendToClient(g, "play," + tasks[taskIndex].Taskid);
                    }
                    else
                    {
                        SendToClient(g, "wait,false");
                    }
                }
                room.taskIndex++;
            }
            //游戏流程结束
            else
            {
                SendToAllClient(null, "wait,true");
                for (int i = gamerList.Count - 1; i >= 0; i--)
                {
                    RemoveGamer(gamerList[i]);
                }

            }

        }


        private static void statusInfo(string str)
        {
            Console.WriteLine(str);
        }


        /// <summary>
        /// 停止监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void stopServer()
        {
            statusInfo("开始停止服务，并依次使用户退出！");
            isNormalExit = true;
            for (int i = gamerList.Count - 1; i >= 0; i--)
            {
                RemoveGamer(gamerList[i]);
            }
            //通过停止监听让 myListener.AcceptTcpClient() 产生异常退出监听线程
            myListener.Stop();
        }


        static void Main(string[] args)
        {
            startServer();
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                stopServer();
            }

        }



    }
}
