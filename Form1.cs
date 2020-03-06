using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using Packets;
using System.Collections;

namespace TheChatClient
{
    public partial class Form1 : Form
    {
        delegate void UpdateChatWindowDelegate(string message);
        UpdateChatWindowDelegate updateChatWindowDelegate;
 
        private TcpClient tcpClient = new TcpClient();
        private BinaryWriter writer;
        private BinaryReader reader;
        private NetworkStream stream;
        private BinaryFormatter formatter;
        private Socket udpSocket;
        private IPEndPoint IPEndPoint;
        private Thread udpThread;


        public Form1()
        {
            udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),  4444);
            udpSocket.Connect(IPEndPoint);
            formatter = new BinaryFormatter();
            tcpClient = new TcpClient();
            updateChatWindowDelegate = new UpdateChatWindowDelegate(UpdateChatWindow);
            InitializeComponent();
        }

        public bool Connect(String ipAddress, int port)
        {
            try
            {
                tcpClient.Connect(ipAddress, port);
                stream = tcpClient.GetStream();
                reader = new BinaryReader(stream, System.Text.Encoding.UTF8);
                writer = new BinaryWriter(stream, System.Text.Encoding.UTF8);

            }
            catch (Exception e)
            {
                ViewTextBox.Text += "Exception: " + e.Message + '\n';
                return false;
            }
            return true;
        }

        private void Send(Packet packet)
        {
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, packet);
            byte[] buffer = memoryStream.GetBuffer();

            writer.Write(buffer.Length);
            writer.Write(buffer);
            writer.Flush();
        }

        private void ProcessServerResponse()
        {
            int noOfIncomingBytes;
            while ((noOfIncomingBytes = reader.ReadInt32()) != 0)
            {
                byte[] bytes = reader.ReadBytes(noOfIncomingBytes);
                MemoryStream memoryStream = new MemoryStream(bytes);

                Packet packet = formatter.Deserialize(memoryStream) as Packet;

                HandlePacket(packet);
            }
        }

        private void HandlePacket(Packet packet)
        {
            switch (packet.type)
            {
                case PacketType.CHATMESSAGE:
                    string message = ((ChatMessagePacket)packet).message;
                    UpdateChatWindow(message);
                    break;

                case PacketType.NICKNAME:
                    string nickName = ((NickNamePacket)packet).nickName;
                    break;
                case PacketType.RESULT:
                    string result = ((ResultPacket)packet).result;
                    break;
                case PacketType.WINNER:
                    string winner = ((WinnerPacket)packet).winner;
                    UpdateChatWindow(winner);
                    break;
            }
        }

        public void UpdateChatWindow(string message)
        {
            if (InvokeRequired)
            {
                Invoke(updateChatWindowDelegate, message);
            }
            else
            {
                ViewTextBox.Text += message += '\n';
                ViewTextBox.SelectionStart = ViewTextBox.Text.Length;
                ViewTextBox.ScrollToCaret();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = enterText.Text;
            enterText.Text = string.Empty;
            ChatMessagePacket chatMessage = new ChatMessagePacket(message);
            Send(chatMessage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread readThread = new Thread(new ThreadStart(ProcessServerResponse));
            readThread.Start();
        }

        private void UdpProcessServerResponse()
        {
            int noOfIncomingBytes;
            byte[] bytes = new byte[256];
            MemoryStream memoryStream = new MemoryStream(bytes);
            while ((noOfIncomingBytes = udpSocket.Receive(bytes)) != 0)
            {
                Packet packet = formatter.Deserialize(memoryStream) as Packet;
            }
        }

        private void UdpSend(Packet packet)
        {
            packet = new Packet();
            
            byte[] bytes = new byte[256];
            MemoryStream memoryStream = new MemoryStream(bytes);
            byte[] buffer = memoryStream.GetBuffer();

            formatter.Serialize(memoryStream, packet);
            udpSocket.Send(buffer);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            udpThread.Abort();
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            pictureR.Visible = true;
            pictureP.Visible = false;
            pictureS.Visible = false;
            string r = "ROCK";
            ResultPacket result = new ResultPacket(r);
            Send(result);
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            pictureR.Visible = false;
            pictureP.Visible = true;
            pictureS.Visible = false;
            string r = "PAPER";
            ResultPacket result = new ResultPacket(r);
            Send(result);
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            pictureR.Visible = false;
            pictureP.Visible = false;
            pictureS.Visible = true;
            string r = "SCISSORS";
            ResultPacket result = new ResultPacket(r);
            Send(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureR.Visible = false;
            pictureP.Visible = false;
            pictureS.Visible = false;
            ResetPacket reset = new ResetPacket();
            Send(reset);
        }
    }
}
