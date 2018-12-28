using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TcpCommunication
{
    public class TcpCom
    {

        private Socket sock;
        private int port;
        private string ip;
        private Action<string, ClientHandler> guiUpdater;
        public List<ClientHandler> connectedClients;

        

        public TcpCom(bool isServer, int port, string ip, Action<string,ClientHandler> guiUpdater)
        {
            if (isServer)
            {
                
                this.port = port;
                this.ip = ip;
                this.guiUpdater = guiUpdater;
                connectedClients = new List<ClientHandler>();
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Bind(new IPEndPoint(IPAddress.Parse(this.ip), this.port));
                sock.Listen(5);
                Thread listenThread = new Thread(new ThreadStart(Listening));
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            else
            {
                
            }



        }

        private void Listening()
        {
            while (true)
            {
                MessageBox.Show("Anzahl an Connected Clients" + connectedClients.Count);
                connectedClients.Add(new ClientHandler(sock.Accept(),guiUpdater));
                MessageBox.Show("Anzahl an Connected Clients" + connectedClients.Count);
            }
        }


        public void sendToAllCleints(string message,ClientHandler c)
        {
            foreach (var client in connectedClients)
            {
                if (!c.Equals(client))
                {
                    client.sendMessage(message);
                }
            }
        }

    }
}
