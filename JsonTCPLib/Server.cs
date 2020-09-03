using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JsonTCPLib
{
    public class Server
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 10002);
            server.Start();
            Console.WriteLine("Server ready.");
            while (true)
            {
                TcpClient tempSocket = server.AcceptTcpClient();
                Task.Run(() => HandleClient(tempSocket));
            }
        }

        private void HandleClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);

            string serializedCar = sr.ReadLine();
            Car deserializedCar = JsonConvert.DeserializeObject<Car>(serializedCar);

            Console.WriteLine(deserializedCar.ToString());

            sw.WriteLine(deserializedCar.ToString());
            sw.Flush();

            socket.Close();
        }
    }
}
