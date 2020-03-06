using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Packets;

namespace SimpleServer
{
    class Client
    {
        Socket socket;
        NetworkStream stream;
        public BinaryReader reader { get; private set; }
        public BinaryWriter writer { get; private set; }
        BinaryFormatter formatter;


        public Client(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);
            reader = new BinaryReader(stream, System.Text.Encoding.UTF8);
            writer = new BinaryWriter(stream, System.Text.Encoding.UTF8);
            formatter = new BinaryFormatter();
        }

        public void Close()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public void Send(Packet packet)
        {
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, packet);
            byte[] buffer = memoryStream.GetBuffer();

            writer.Write(buffer.Length);
            writer.Write(buffer);
            writer.Flush();
        }
    }
}
