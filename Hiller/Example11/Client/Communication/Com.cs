using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Communication
{
    public class Com
    {
        public Socket socket;

        public Com(string ip, int port)
        {
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
            socket = client.Client;

        }

        public void Send(string msg)
        {
            socket.Send(Encoding.UTF8.GetBytes(msg));
        }

    }
}
