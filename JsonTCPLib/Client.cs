using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using ModelLib;
using Newtonsoft.Json;

namespace JsonTCPLib
{
    public class Client
    {
        public void Start()
        {
            TcpClient socket = new TcpClient("127.0.0.1", 10002);

            DoClient(socket);
        }

        private void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);

            Car car = new Car("Berlingo", "Gray", "UZ624K");
            string json = JsonConvert.SerializeObject(car);

            sw.WriteLine(json);
            sw.Flush();

            Console.WriteLine($"Server response: {sr.ReadLine()}");

            socket.Close();
        }
    }
}
