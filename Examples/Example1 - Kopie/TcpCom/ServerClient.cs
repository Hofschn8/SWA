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
        public Socket sock;
        private string ip = "127.0.0.1";
        private int port = 10100;
        private List<ClientHandler> connectedClients = new List<ClientHandler>();
        private Action<string> GuiUpdater;
        string time = DateTime.Now.ToShortTimeString();
        private string Name;


        public ServerClient(bool isServer, Action<string>GuiUpdater) // 
        {
            this.GuiUpdater += GuiUpdater;

            if (isServer == true)
            {
                // act as Server
                Name = "I am Server";
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                sock.Listen(5);
                Thread acceptThread = new Thread(new ThreadStart(AcceptClients));
                acceptThread.IsBackground = true;
                acceptThread.Start();
                GuiUpdater(time + ": Server startet...");
            }
            else
            {
                Random r = new Random();
                Name = "I am Client" + r.Next(1, 10);
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                connectedClients.Add(new ClientHandler(tcpClient.Client, GuiUpdater, SendReceivedMessageToAllConnectedClientes));
                SendReceivedMessageToAllConnectedClientes(DateTime.Now.ToShortTimeString() + ": connected with Server",this.sock);
            }

        }

        private void AcceptClients()
        {
            while (true)
            {
                connectedClients.Add(new ClientHandler(sock.Accept(),GuiUpdater, SendReceivedMessageToAllConnectedClientes));
            }
        }

        public void SendReceivedMessageToAllConnectedClientes(string msg, Socket sender)
        {
            foreach (var clientHandler in connectedClients)
            {
                if (clientHandler.Sock != sender) // ohne dieser Abfrage wird eine Dauerschleife mit der gleichen Nachricht gesendet und empfangen,...
                {
                    clientHandler.Send(msg);
                }
            }
        }

    }
}
