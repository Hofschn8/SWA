using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example4.Communication
{

    public class Com
    {

        public Socket socket;
        private Action<string> updateGui;
        public List<ClientHandler> clients = new List<ClientHandler>();
        byte[] buffer = new byte[512];
        


        public Com(bool isServer, string ip, int port, Action<string> updateGui)
        {
            if (isServer)
            {
                this.updateGui = updateGui;
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                socket.Listen(5);
                Task.Factory.StartNew(Accept);
            }
            else
            {
                this.updateGui = updateGui;
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(ip), port);
                socket = client.Client;
                StartReceiving();
                
            }     
        }

        public void StartReceiving()
        {
            Task.Factory.StartNew(Receive);
        }

        public void Receive()
        {
            string tmp = "";
            while (true)
            {
                int length = socket.Receive(buffer);
                tmp = Encoding.UTF8.GetString(buffer, 0, length);
                NewMessageReceived(tmp);
            }
        }

        public void NewMessageReceived (string message)
        {       
            updateGui(message);
            SendFromServer(message);
        }

        public void Send(string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
        }

        public void SendFromServer(string message)
        {
            foreach (var item in clients)
            {
                item.Send(message);
            }
        }

        public void Accept()
        {
            while (true)
            {
                clients.Add(new ClientHandler(socket.Accept(), NewMessageReceived));
            }
        }

    }
}
