using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example10___Horses.Communication
{
    public class Com
    {
        public Socket socket;
        public List<ClientHandler> clients;
        Action<string> GuiUpdate;
        byte[] buffer = new byte[512];

        public Com(bool isServer, string ip, int port, Action<string> action)
        {
            if (isServer)
            {
                GuiUpdate = action;
                clients = new List<ClientHandler>();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                socket.Listen(5);
                Task.Factory.StartNew(Accept);
            }
            else
            {
                GuiUpdate = action;
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
                GuiUpdate(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }

        private void Accept()
        {
            while (true)
            {
                clients.Add(new ClientHandler(socket.Accept(), NewMessageReceived));
            }
        }

        public void Send(string msg)
        {
            socket.Send(Encoding.UTF8.GetBytes(msg));
        }

        public void NewMessageReceived(string msg, Socket thissocket)
        {
            GuiUpdate(msg);
            foreach (var item in clients)
            {
                if (item.socket != thissocket)
                {
                    item.Send(msg);
                }
            }

        }
    }
}
