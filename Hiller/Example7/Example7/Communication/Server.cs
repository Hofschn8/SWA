using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example7.Communication
{
    public class Server
    {
        public Socket socket;
        public Action<string> Guiupdater;
        public List<ClientHandler> clients;

        public Server(string ip, int port, Action<string> action)
        {
            clients = new List<ClientHandler>();
            Guiupdater = action;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            socket.Listen(5);
            Task.Factory.StartNew(Accept);
        }

        private void Accept()
        {
            while (true)
            {
                clients.Add(new ClientHandler(socket.Accept(), Guiupdater));
            }
        }
    }
}
