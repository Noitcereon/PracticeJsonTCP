using System;
using JsonTCPLib;

namespace JsonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Start();
            Console.ReadKey();
        }
    }
}
