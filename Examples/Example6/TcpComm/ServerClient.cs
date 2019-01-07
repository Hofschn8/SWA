using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpComm
{
    public class ServerClient
    {
        private bool isServer;
        private int port;
        private string ip;
        private Action<string,ClientHandler> action;
        private Socket sock;
        private List<ClientHandler> connectedClients = new List<ClientHandler>();
        private byte[] buffer; // buffer wenn Client

        public ServerClient(bool isServer, int port, string ip, Action<string,ClientHandler> action)
        {
            this.port = port;
            this.ip = ip;
            this.action = action;
            this.isServer = isServer;

            if (isServer)  // act as Server
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                sock.Listen(5);
                Thread acceptThread = new Thread(new ThreadStart(Accepting));
                acceptThread.IsBackground = true;
                acceptThread.Start();
            }
            else  // act as Client
            {
                buffer = new byte[1024];
                TcpClient client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                sock = client.Client;
                Thread receiveThread = new Thread(new ThreadStart(ReceivingClient));
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }

        }

        private void ReceivingClient()
        {
            while (true)
            {
                int lenght = sock.Receive(buffer);
                string tmp = Encoding.ASCII.GetString(buffer, 0, lenght);
                action(tmp, null);
            }
        }


        private void Accepting()
        {
            while (true)
            {
                connectedClients.Add(new ClientHandler(sock.Accept(),action));
            }
        }

        public void SendToAllClients(string message,ClientHandler client)
        {
            foreach (var c in connectedClients)
            {
                if (c.Equals(client))
                {
                    //tu nix
                }
                else
                {
                    // schicke es an den client
                    c.Send(message);
                }
            }
        }

        public void SendToServer(string message)
        {
            sock.Send(Encoding.ASCII.GetBytes(message));
        }
        

    }
}
