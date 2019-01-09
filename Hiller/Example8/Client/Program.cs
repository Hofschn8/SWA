using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Client
{
    class Program
    {
        public static Random rand = new Random();
        

        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10100));
            Socket socket = client.Client;

            while (true)
            {
                int id = rand.Next(10, 99);
                string tmp = id + "@recorder,20000,25000|DVDPlayer,10000,20000|PCs,50000,200000";
                socket.Send(Encoding.UTF8.GetBytes(tmp));
                Console.WriteLine(tmp);
                Thread.Sleep(5000);
            }

        }

    }
}
