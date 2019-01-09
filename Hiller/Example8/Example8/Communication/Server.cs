using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example8.Communication
{
    public class Server
    {
        public Socket socket;
        public List<ClientHandler> clients;
        public Action<string> GuiUpdate;

        public Server(string ip, int port, Action<string> action)
        {
            GuiUpdate = action;
            clients = new List<ClientHandler>();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            socket.Listen(5);
            Task.Factory.StartNew(Accept);
        }

        private void Accept()
        {
            while (true)
            {
                clients.Add(new ClientHandler(socket.Accept(), GuiUpdate));
            }
        }
    }
}
