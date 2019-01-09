using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example2_Server.Communication
{
    public class Server
    {
        Socket serversocket;
        List<ClientHandler> clients = new List<ClientHandler>();
        Action<string> GuiUpdater;
        Action<string> UpdateName;
        byte[] buffer = new byte[512];

        public Server(string ip, int port, Action<string> guiupdate, Action<string> nameupdater)
        {
            serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serversocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            serversocket.Listen(5);
            Task.Factory.StartNew(Accept);
            GuiUpdater = guiupdate;
            UpdateName = nameupdater;
        }

        public void Accept()
        {
            while (true)
            {
                clients.Add(new ClientHandler(serversocket.Accept(), NewMessageReceived));
            } 
        }


        public void NewMessageReceived(string message)
        {
            GuiUpdater(message);          
        }

    }
}
