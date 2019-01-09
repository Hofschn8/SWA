using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example6.Communication
{
    public class Com
    {
        public Socket socket;
        public List<ClientHandler> clients = new List<ClientHandler>();
        byte[] buffer = new byte[512];
        Action<string> Guiupdater;

        public Com(bool isServer, string ip, int port, Action<string> Guiupdate)
        {
            if (isServer)
            {
                Guiupdater = Guiupdate;
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
                socket.Listen(5);
                Task.Factory.StartNew(Accept);
            } else
            {
                Guiupdater = Guiupdate;
                TcpClient client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                socket = client.Client;
                Task.Factory.StartNew(Receive);
            }

        }

        private void Receive()
        {
            int length;
            while (true)
            {
                length = socket.Receive(buffer);
                Guiupdater(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }

        private void Accept()
        {
            while (true)
            {
                clients.Add(new ClientHandler(socket.Accept(), Guiupdater));
            }
        }

        public void Send(string msg)
        {
            foreach (var item in clients)
            {
                item.Send(msg);
            }
        }
    }
}
