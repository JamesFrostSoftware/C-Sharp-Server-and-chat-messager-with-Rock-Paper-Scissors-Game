﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClient
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            SimpleClient simpleClient = new SimpleClient();

            simpleClient.Connect("127.0.0.1", 4444);

            simpleClient.Run();
        }
    }
}
