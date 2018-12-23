using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpCom
{
    public class ClientServer
    {

        private int port;
        private string ip;
        private Action<string, ClientHandler> guiUpdater;
        private List<ClientHandler> connectedClients;
        private Socket socket;

        public ClientServer(bool isServer,  int port, string ip, Action<string, ClientHandler> guiUpdater)
        {
            if (isServer)  // ACT as Server
            {
                this.port = port;
                this.ip = ip;
                this.guiUpdater = guiUpdater;
                connectedClients = new List<ClientHandler>();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                socket.Listen(5);
                Thread listenThread = new Thread(new ThreadStart(Listening));
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            else  // ACT as Client
            {
                TcpClient client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                socket = client.Client;

            }
        }

        private void Listening()
        {
            while (true)
            {
                connectedClients.Add(new ClientHandler(socket.Accept(), guiUpdater));
            }
        }

        public void sendToServer(string toSend)
        {
            socket.Send(Encoding.ASCII.GetBytes(toSend));
        }


    }
}
