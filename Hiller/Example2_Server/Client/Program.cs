using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10100));
            Socket socket = client.Client;
            socket.Send(Encoding.UTF8.GetBytes("Hallo1"));
            socket.Send(Encoding.UTF8.GetBytes("Hallo2"));

            socket.Send(Encoding.UTF8.GetBytes("Hallo2"));
            socket.Send(Encoding.UTF8.GetBytes("Hallo3"));

            Console.ReadLine();
        }
    }
}
