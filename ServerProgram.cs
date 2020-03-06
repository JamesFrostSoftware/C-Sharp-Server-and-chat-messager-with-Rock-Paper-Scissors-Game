using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleServer
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            //Chat Client
            SimpleServer simpleServer = new SimpleServer("127.0.0.1", 4444);
            simpleServer.Start();
            simpleServer.Stop();

        }
    }
}
