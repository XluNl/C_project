using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Configuration;

namespace Game_Server
{
    class Program
    {
        /// <summary>
        /// 保存连接的所有用户
        /// </summary>
        private static List<Gamer> gamerList = new List<Gamer>();

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
                gamerList.Add(gamer);
                statusInfo(string.Format("[{0}]进入", newClient.Client.RemoteEndPoint));
                statusInfo(string.Format("当前连接用户数：{0}", gamerList.Count));
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
                        RemoveGamer(gamer);
                    }
                    break;
                }
                statusInfo(string.Format("来自[{0}]：{1}", gamer.client.Client.RemoteEndPoint, receiveString));
                string[] splitString = receiveString.Split(',');
                switch (splitString[0])
                {
                    case "Login":
                        gamer.name = splitString[1];
                        SendToAllClient(gamer, receiveString);
                        break;
                    case "Logout":
                        SendToAllClient(gamer, receiveString);
                        RemoveGamer(gamer);
                        return;
                    case "Game":
                        SendToClient(gamer,"wait,");
                        foreach (Gamer g in gamerList)
                        {
                            if (!gamer.Equals(g))
                            {
                                SendToClient(g, "video,");
                            }
                        }
                        break;
                    case "Talk":
                        string talkString = receiveString.Substring(splitString[0].Length + splitString[1].Length + 2);
                        statusInfo(string.Format("{0}对{1}说：{2}", gamer.name, splitString[1], talkString));
                        SendToClient(gamer, "talk," + gamer.name + "," + talkString);
                        foreach (Gamer g in gamerList)
                        {
                            if (g.name == splitString[1] && gamer.name != splitString[1])
                            {
                                SendToClient(g, "talk," + gamer.name + "," + talkString);
                                break;
                            }
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
                    SendToClient(gamer, "login," + gamerList[i].name);
                }
                //把自己上线，发送给所有客户端
                for (int i = 0; i < gamerList.Count; i++)
                {
                    if (gamer.name != gamerList[i].name)
                    {
                        SendToClient(gamerList[i], "login," + gamer.name);
                    }
                }
            }
            else if (command == "logout")
            {
                for (int i = 0; i < gamerList.Count; i++)
                {
                    if (gamerList[i].name != gamer.name)
                    {
                        SendToClient(gamerList[i], message);
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
                statusInfo(string.Format("向[{0}]发送：{1}", gamer.name, message));
            }
            catch
            {
                statusInfo(string.Format("向[{0}]发送信息失败", gamer.name));
            }
        }

        /// <summary>
        /// 移除用户
        /// </summary>
        /// <param name="gamer">指定要移除的用户</param>
        private static void RemoveGamer(Gamer gamer)
        {
            gamerList.Remove(gamer);
            gamer.Close();
            statusInfo(string.Format("当前连接用户数：{0}", gamerList.Count));
        }

        private static void statusInfo(string str)
        {
            Console.WriteLine(str);
        }

        //private delegate void AddItemToListBoxDelegate(string str);
        /// <summary>
        /// 在ListBox中追加状态信息
        /// </summary>
        /// <param name="str">要追加的信息</param>
        //private void statusInfo(string str)
        //{
        //    if (lst_State.InvokeRequired)
        //    {
        //        AddItemToListBoxDelegate d = statusInfo;
        //        lst_State.Invoke(d, str);
        //    }
        //    else
        //    {
        //        lst_State.Items.Add(str);
        //        lst_State.SelectedIndex = lst_State.Items.Count - 1;
        //        lst_State.ClearSelected();
        //    }
        //}

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

        /// <summary>
        /// 关闭窗口时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (myListener != null)
        //        btn_Stop.PerformClick();    //引发 btn_Stop 的Click事件
        //}

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
