using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example5.Communication
{
    public class Com
    {
        bool isServer;
        public Socket socket;
        public ClientHandler client;
        byte[] buffer = new byte[512];
        Action<string> GuiUpdater;

        public Com(bool isServer, string ip, int port, Action<string> updater)
        {
            if (isServer)
            {
                GuiUpdater = updater;
                isServer = true;
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                socket.Listen(5);
                Task.Factory.StartNew(Accept);
                
            } else
            {
                GuiUpdater = updater;
                isServer = false;
                TcpClient client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                socket = client.Client;
                Task.Factory.StartNew(Receive);
            }
        }

        private void Receive()
        {
            int length;
            while (true)
            {
                length = socket.Receive(buffer);
                GuiUpdater(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }

        private void Accept()
        {
            client = new ClientHandler(socket.Accept(), GuiUpdater);
        }

        public void SendFromServer(string msg)
        {
            client.Send(msg);
        }

        public void Send(string msg)
        {
            socket.Send(Encoding.UTF8.GetBytes(msg));  
        }
    }
}
