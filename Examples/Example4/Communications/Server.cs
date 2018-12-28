using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Communications
{
    public class Server
    {
        private Action<string> guiUpdater;

        private Socket serverSocket;

        private List<ClientHandler> connectedClients;

        public object MessageBox { get; private set; }

        public Server(Action<string> guiUpdater)
        {
            connectedClients = new List<ClientHandler>();
            this.guiUpdater = guiUpdater;
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10100));
            serverSocket.Listen(5);
            Thread accepting = new Thread(new ThreadStart(Accepting));
            accepting.IsBackground = true;
            accepting.Start();
        }

        private void Accepting()
        {
            while (true)
            {
                
                connectedClients.Add(new ClientHandler(serverSocket.Accept(), guiUpdater));

                
            }
        }

        public void Send(string msg)
        {
            foreach (var item in connectedClients)
            {
                item.Send(msg);
            }
        }


    }
}
