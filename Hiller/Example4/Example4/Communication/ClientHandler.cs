using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example4.Communication
{
    public class ClientHandler
    {
        private Socket socket;
        Action<string> NewMessageReceived;
        byte[] buffer = new byte[512];


        public ClientHandler(Socket socket, Action<string> newMessageReceived)
        {
            this.socket = socket;
            NewMessageReceived = newMessageReceived;
            Task.Factory.StartNew(Receive);

        }

        public void Send(string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
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
    }
}
