using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Einheit4_Client.Communication
{
    class Client
    {
        public Socket connection { get; set; }
        private byte[] buffer = new byte[512];
        Thread t;

        public Client()
        {
            Thread.Sleep(1000);
            TcpClient tcp = new TcpClient();
            tcp.Connect(new IPEndPoint(IPAddress.Loopback, 10100));
            connection = tcp.Client;
            t = new Thread(new ThreadStart(Receive));

        }

        private void Receive()
        {
            string message = "";
            while (true)
            {
                int length = connection.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);

            }
        }

        public void Send(string Message)
        {
            connection.Send(Encoding.UTF8.GetBytes(Message));
        }
    }
}
