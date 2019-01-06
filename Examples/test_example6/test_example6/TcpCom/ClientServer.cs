using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test_example4.TcpCom
{
    public class ClientServer
    {
        private List<ClientHandler> clients = new List<ClientHandler>();
        private Socket socket;
        public Socket Socket { get => socket; set => socket = value; }
        private Action<string> updateGui;
        private Action<string, Socket> sendMessageToAll;

        public ClientServer(bool isServer, Action<string> updateGui)
        {
            this.sendMessageToAll = new Action<string, Socket>(SendMessageToAll);
            this.updateGui = updateGui;
            if (isServer)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                socket.Bind(new IPEndPoint(IPAddress.Loopback, 10100));
                socket.Listen(5);
                Thread t = new Thread(new ThreadStart(acceptClients));
                t.Start();
            }
            else
            {
                TcpClient tcp = new TcpClient();
                tcp.Connect(new IPEndPoint(IPAddress.Loopback, 10100));
                clients.Add(new ClientHandler(tcp.Client, updateGui, sendMessageToAll));

            }
        }

        public void SendMessageToAll(string arg1, Socket arg2)
        {
            foreach (var item in clients)
            {
                if (!item.Socket.Equals(arg2))
                {
                    item.Send(arg1);
                }
            }
        }

        private void acceptClients()
        {
            while (true)
            {
                clients.Add(new ClientHandler(socket.Accept(), updateGui, sendMessageToAll));
            }
        }
    }
}
