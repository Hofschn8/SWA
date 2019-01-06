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
    public class ServerClient
    {
        private bool isServer;
        private string ip;
        private int port;
        
        private Action<string, ClientHandler> guiUpdater;

        Socket sock;
        private byte[] buffer = new byte[1024]; // Buffer wenn Client

        public List<ClientHandler> connectedClients { get; set; }

        public ServerClient(bool isServer, string ip, int port, Action<string, ClientHandler> action)
        {
            this.isServer = isServer;
            this.ip = ip;
            this.port = port;
            this.guiUpdater = action;

            if (isServer)
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                sock.Listen(5);
                connectedClients = new List<ClientHandler>();
                Thread listenThread = new Thread(new ThreadStart(Listening));
                listenThread.IsBackground = true;
                listenThread.Start();
            }

            else
            {
                TcpClient client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                sock = client.Client;
                Thread receiveThreadClient = new Thread(new ThreadStart(ReceivingClient));
                receiveThreadClient.IsBackground = true;
                receiveThreadClient.Start();
            }

        }

        private void ReceivingClient()
        {
            while (true)
            {
                int length = sock.Receive(buffer);
                string tmp = Encoding.ASCII.GetString(buffer, 0, length);
                guiUpdater(tmp, null);
            }
        }

        public void SendToServer(string msg)
        {
            sock.Send(Encoding.ASCII.GetBytes(msg));
        }

        private void Listening()
        {
            while (true)
            {
                connectedClients.Add(new ClientHandler(sock.Accept(), guiUpdater));

            }
        }

        public void sendToAllClients(string msg)
        {
            foreach (var client in connectedClients)
            {
                client.send(msg);
            }
        }
    }
}
