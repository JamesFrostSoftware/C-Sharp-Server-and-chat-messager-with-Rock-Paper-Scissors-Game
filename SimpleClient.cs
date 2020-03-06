using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Packets;

namespace SimpleClient
{
    class SimpleClient
    {


        private TcpClient tcpClient = new TcpClient();
        private BinaryWriter writer;
        private BinaryReader reader;
        private NetworkStream stream;
        private BinaryFormatter formatter;

        public SimpleClient()
        {
            TcpClient tcpClient = new TcpClient();
        }

        public bool Connect(String ipAddress, int port)
        {
            try
            {
                tcpClient.Connect("127.0.0.1", 4444);
                stream = tcpClient.GetStream();
                reader = new BinaryReader(stream, System.Text.Encoding.UTF8);
                writer = new BinaryWriter(stream, System.Text.Encoding.UTF8);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
            return true;
        }

        public void Run()
        {
            String userInput = "";
            ProcessServerResponse();

            while ((userInput = Console.ReadLine()) != null)
            {
                writer.Write(userInput);
                writer.Flush();
                ProcessServerResponse();
                if (userInput == "9")
                {
                    break;
                }
            }
            tcpClient.Close();
        }

        private void ProcessServerResponse()
        {
            //Console.WriteLine("Server says : " + reader.ReadLine());
            Console.WriteLine();
        }

        private void Send(Packet packet)
        {

        }
    }
}
