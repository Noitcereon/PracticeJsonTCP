﻿using System;
using JsonTCPLib;

namespace JsonServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
}
