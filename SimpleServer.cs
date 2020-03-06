using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using Packets;

namespace SimpleServer
{
    class SimpleServer
    {
        private TcpListener tcpListener;
        private UdpClient udpListener;
        private IPEndPoint udpEndPoint;
        private Thread udpThread;
        private List<Client> clients;
        private List<string> strings;
        private BinaryFormatter formatter;

        public SimpleServer(string ipAddress, int port)
        {
            formatter = new BinaryFormatter();
            IPAddress ip = IPAddress.Parse(ipAddress);

            udpListener = new UdpClient(4444);
            udpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                tcpListener = new TcpListener(ip, port);
                clients = new List<Client>();
                strings = new List<string>(2);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Start()
        {
            udpThread = new Thread(UdpListen);
            udpThread.Start();

            tcpListener.Start();
            Console.WriteLine("Started listening for connections...");
            while (true)
            {
                Socket socket = tcpListener.AcceptSocket();
                Console.WriteLine("Accepting connections...");

                Console.WriteLine("Connection has been found.");

                Client client = new Client(socket);
                clients.Add(client);

                Thread t = new Thread(new ParameterizedThreadStart(ClientMethod));
                t.Start(client);
            }
        }

        private void HandlePacket(Client client, Packet packet)
        {
            switch (packet.type)
            {
                case PacketType.CHATMESSAGE:
                    string message = ((ChatMessagePacket)packet).message;

                    ChatMessagePacket chatMessage = new ChatMessagePacket(message);
                    foreach(Client sendToClient in clients)
                    {
                        Console.Write(message);
                        sendToClient.Send(chatMessage);
                    }
                    break;

                case PacketType.NICKNAME:
                    string nickName = ((NickNamePacket)packet).nickName;
                    break;
                case PacketType.RESULT:
                    string result = ((ResultPacket)packet).result;
                    Console.WriteLine(result);
                    strings.Add(result);
                    FindWinner();
                    break;
                case PacketType.RESET:
                    try
                    {
                        strings.Clear();
                    }
                    catch (Exception e)
                    {

                    }
                    break;
            }
        }
        private void FindWinner()
        {
            string winner = "";
            try
            {
                if (strings[0] != null || strings[1] != null)
                {
                    if(strings[0] == "ROCK" && strings[1] == "SCISSORS")
                    {
                        winner = "Rock wins";
                        SendWinnerToClient(winner);
                    }
                    if (strings[0] == "ROCK" && strings[1] == "PAPER")
                    {
                        winner = "Paper wins";
                        SendWinnerToClient(winner);
                    }
                    if (strings[0] == "ROCK" && strings[1] == "ROCK")
                    {
                        winner = "It's a Draw";
                        SendWinnerToClient(winner);
                    }
                    if (strings[0] == "PAPER" && strings[1] == "ROCK")
                    {
                        winner = "Paper wins";
                        SendWinnerToClient(winner);
                    }
                    if (strings[0] == "PAPER" && strings[1] == "SCISSORS")
                    {
                        winner = "Scissors wins";
                        SendWinnerToClient(winner);
                    }
                    if (strings[0] == "PAPER" && strings[1] == "PAPER")
                    {
                        winner = "It's a Draw";
                        SendWinnerToClient(winner);
                    }
                    if (strings[0] == "SCISSORS" && strings[1] == "PAPER")
                    {
                        winner = "Scissors wins";
                        SendWinnerToClient(winner);
                    }
                    if (strings[0] == "SCISSORS" && strings[1] == "ROCK")
                    {
                        winner = "Rock wins";
                        SendWinnerToClient(winner);
                    }
                    if (strings[0] == "SCISSORS" && strings[1] == "SCISSORS")
                    {
                        winner = "It's a Draw";
                        SendWinnerToClient(winner);
                    }
                }
            }
            catch(Exception e)
            {

            }
        }

        private void SendWinnerToClient(string winner)
        {
            WinnerPacket w = new WinnerPacket(winner);
            foreach (Client sendToClient in clients)
            {
                sendToClient.Send(w);
            }

        }

        public void Stop()
        {
            tcpListener.Stop();
        }

        private void SocketMethod(Socket socket)
        {
            String receivedMessage;
            NetworkStream stream = new NetworkStream(socket);
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8);

            writer.WriteLine("Hello");
            writer.Flush();

            while ((receivedMessage = reader.ReadLine()) != null)
            {
                writer.WriteLine(GetReturnMessage(receivedMessage));
                writer.Flush();

                if (receivedMessage == "9")
                {
                    break;
                }
            }

            socket.Close();
        }

        private void ClientMethod(object clientObj)
        {
            Client client = (Client)clientObj;
            int noOfIncomingBytes;

            ChatMessagePacket chatMessage = new ChatMessagePacket("Message to client ");
            client.Send(chatMessage);

            while ((noOfIncomingBytes = client.reader.ReadInt32()) != 0)
            {
                byte[] bytes = client.reader.ReadBytes(noOfIncomingBytes);
                MemoryStream memoryStream = new MemoryStream(bytes);

                Packet packet = formatter.Deserialize(memoryStream) as Packet;

                HandlePacket(client, packet);
            }
            client.Close();
        }

        private string GetReturnMessage(string code)
        { 
            return code;
        }

        private void UdpListen()
        {
            while(true)
            {
                UdpClient udpListener = new UdpClient();
                udpListener.Client.Bind(udpEndPoint);
                byte[] bytes = udpListener.Receive(ref udpEndPoint);
                MemoryStream memoryStream = new MemoryStream(bytes);
                Packet packet = formatter.Deserialize(memoryStream) as Packet;
                UdpHandlePacket(udpEndPoint, packet);
            }
        }

        private void UdpSend(IPEndPoint endpoint, Packet packet)
        {
            Byte[] bytes = udpListener.Receive(ref udpEndPoint);
            //udpListener.Send(bytes, bytes.Length, endpoint);
        }

        private void UdpHandlePacket(IPEndPoint endpoint, Packet packet)
        {
            
            switch (packet.type)
            {
                case PacketType.CHATMESSAGE:
                    string message = ((ChatMessagePacket)packet).message;

                    ChatMessagePacket chatMessage = new ChatMessagePacket("Message to client ");

                    break;

                case PacketType.NICKNAME:
                    string nickName = ((NickNamePacket)packet).nickName;


                    break;
            }
        }
    }
}
