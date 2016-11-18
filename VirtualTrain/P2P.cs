using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace VirtualTrain
{
    public class P2P
    {
        public delegate void DelgMsgListened();
        public event DelgMsgListened OnMsgListened;
        public event DelgMsgListened OnPhoneCalled;
        public event DelgMsgListened OnPhoneHangUp;
        public event DelgMsgListened OnPhoneReplayed;
        public event DelgMsgListened OnPhoneOver;

        public static bool answerPhone = false;
        public static int oppositeIndex;
        public static bool isListenerNow;
        public static bool lastSentence = false;
        private string m_msgListened;
        private bool isConnected = false;
        public enum Operation
        {
            query,
            update
        }

        public void communicationState(Operation operation, int id)
        {

        }

        private Thread thread;
        private TcpListener client;

        private NetworkStream tcpStream;
        private StreamWriter reqStreamW;
        private TcpClient tcpClientPere;
        private Socket socket;

        public string MsgListened
        {
            get
            {
                return m_msgListened;
            }
        }

        public bool Connected
        {
            get
            {
                return isConnected;
            }
        }

        public void DisposeMe()
        {
            try
            {
                isListenerNow = false;
                thread.Abort();
                thread = null;
                client.Stop();
                if (socket != null)
                {
                    socket.Close();
                }
                if (tcpClientPere != null)
                {
                    tcpClientPere.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void beginListen()
        {
            try
            {
                client = new TcpListener(8877);
                client.Start();
                while (true)
                {
                    isListenerNow = true;
                    //等待电话信号
                    socket = client.AcceptSocket();
                    string message = receiveMsg();
                    string communicationStr = message.Substring(0, message.IndexOf('\0'));
                    string[] communicationStrs = communicationStr.Split('@');
                    string communicationType = communicationStrs[0];
                    string oppositeIp = "";
                    if (communicationStrs.Length > 1)
                    {
                        oppositeIndex = Convert.ToInt32(communicationStrs[1]);
                        //oppositeIp = ShowVRForm.index_ip[oppositeIndex];
                    }
                    switch (communicationType)
                    {
                        //接受对方拨打信息
                        case "call":

                            phone_call(oppositeIp);

                            break;
                        //接受对方回复信息
                        case "replay":

                            phone_replay();

                            break;
                        //接受对方挂断信息
                        case "noreplay":
                            phone_noreplay();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (System.Security.SecurityException)
            {
                isConnected = false;
            }
        }

        public void phone_call(string ip)
        {
            //本机为非通话状态
            if (!answerPhone)
            {
                //触发接电话事件
                OnPhoneCalled();
                //接电话
                if (answerPhone)
                {
                    connectToRemote(ip, "replay");
                    while (isListenerNow)
                    {
                        m_msgListened = receiveMsg();
                        OnMsgListened();
                        OnPhoneReplayed();
                    }
                    //OnPhoneOver();
                }
                //不接电话
                else
                {
                    connectToRemote(ip, "noreplay");
                }
            }
            //本机为通话状态
            else
            {
                connectToRemote(ip, "noreplay");
            }
        }

        //打电话者，台词单数行
        public void phone_replay()
        {
            while (isListenerNow)
            {
                //提示对方已接听
                OnPhoneReplayed();
                m_msgListened = receiveMsg();
                isConnected = true;
                OnMsgListened();
                if (!isListenerNow)
                {
                    lastSentence = true;
                    OnPhoneReplayed();
                }
                Thread.Sleep(3000);
            }
            OnPhoneOver();
        }

        public void phone_noreplay()
        {
            OnPhoneHangUp();
        }

        public string receiveMsg()
        {
            Byte[] stream = new Byte[80];
            //等待接受信息
            int i = socket.Receive(stream);
            string msg = System.Text.Encoding.UTF8.GetString(stream);
            if (msg.Contains("[通话结束]"))
            {
                isListenerNow = false;
            }
            return msg;
        }

        public void threadToListen()
        {
            thread = new Thread(new ThreadStart(this.beginListen));
            thread.Start();
        }

        public bool connectToRemote(string svrName, string state)
        {
            try
            {
                tcpClientPere = new TcpClient();
                tcpClientPere.Connect(svrName, 8877);
                tcpStream = tcpClientPere.GetStream();
                sendMsg(state);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void disConnectToRemote()
        {
            tcpClientPere.Close();
            tcpClientPere = null;
        }

        public bool sendMsg(string msgToSend)
        {
            try
            {
                reqStreamW = new StreamWriter(tcpStream);
                reqStreamW.Write(msgToSend);
                reqStreamW.Flush();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
