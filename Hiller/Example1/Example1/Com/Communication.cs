using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example1.Com
{
    public class Communication
    {
        Socket socket;
        List<ClientHandler> clients = new List<ClientHandler>();
        byte[] buffer = new byte[512];
        Action<string> guiInformer;

        public Communication(bool isServer, string ip, int port, Action<string> GuiInformer)
        {
            if (isServer)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                socket.Listen(5);
                Task.Factory.StartNew(Accept);
            }
            else
            {
                this.guiInformer = GuiInformer;
                TcpClient client = new TcpClient();
                client.Connect(ip, port);
                socket = client.Client;
                Task.Factory.StartNew(Receive);
            }
        }

        public void Accept()
        {
            while (true)
            {
                clients.Add(new ClientHandler(socket.Accept()));
            }
        }

        public void Receive()
        {
            int length;
            while (true)
            {
                length = socket.Receive(buffer);
                string tmp = Encoding.UTF8.GetString(buffer, 0, length);
                guiInformer(tmp);
            }


        }

        public void Send(string message)
        {
            foreach (var item in clients)
            {
                item.SendData(Encoding.UTF8.GetBytes(message));
            }
        }

    }
}
