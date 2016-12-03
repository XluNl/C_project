using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VirtualTrain
{
    public partial class GameForm : Form
    {
        private static string ServerIP = ConfigurationManager.AppSettings["ip"];
        private static int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
        private bool isExit = false;
        private TcpClient client;
        private BinaryReader br;
        private BinaryWriter bw;

        public GameForm()
        {
            InitializeComponent();
        }

        private void login()
        {
            try
            {
                //此处为方便演示，实际使用时要将Dns.GetHostName()改为服务器域名
                //IPAddress ipAd = IPAddress.Parse("182.150.193.7");
                client = new TcpClient();
                client.Connect(IPAddress.Parse(ServerIP), port);
                MessageBox.Show("连接成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败，原因：" + ex.Message);
                return;
            }
            //获取网络流
            NetworkStream networkStream = client.GetStream();
            //将网络流作为二进制读写对象
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
            //SendMessage("Login," + txt_UserName.Text);
            Thread threadReceive = new Thread(new ThreadStart(ReceiveData));
            threadReceive.IsBackground = true;
            threadReceive.Start();
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
                        MessageBox.Show("与服务器失去连接");
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
                    case "answer":    //格式： talk,用户名,对话信息
                        Question question = GameHelper.getQuestion();
                        lblQuestion.Text = question.question;
                        OptionA.Text = question.optionA;
                        OptionB.Text = question.optionB;
                        OptionC.Text = question.optionC;
                        OptionD.Text = question.optionD;
                        //AddTalkMessage(splitString[1] + "：\r\n");
                        //AddTalkMessage(receiveString.Substring(splitString[0].Length + splitString[1].Length + 2));
                        break;
                    case "video":
                        wmp.URL = Application.StartupPath + @"\data\" + "Wildlife.wmv";
                        wmp.Ctlcontrols.play();
                        break;
                    case "wait":
                        wait();
                        break;
                    default:
                        break;
                }
            }
            Application.Exit();
        }

        /// <summary>
        /// 向服务端发送消息
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                bw.Write(message);
                bw.Flush();
            }
            catch
            {
                MessageBox.Show("发送失败");
            }
        }

        private delegate void WaitDelegate();

        private void wait()
        {
            if (pnlquestion.InvokeRequired)
            {
                WaitDelegate w = new WaitDelegate(wait);
                pnlquestion.Invoke(w, new object[] { });
            }
            else
            {
                pnlquestion.Enabled = false;
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SendMessage("Game,");
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            login();
        }

        private void wmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState==8)
            {
                SendMessage("Game,");
            }
        }
    }
}
