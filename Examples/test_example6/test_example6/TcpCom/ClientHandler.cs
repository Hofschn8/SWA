using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test_example4.TcpCom
{
    public class ClientHandler
    {
        private Socket socket;
        public Socket Socket
        {
            get { return socket; }
            set { socket = value; }
        }

        private Action<string> updateGui;
        private Action<string, Socket> sendMessageToAll;
        private byte[] buffer = new byte[512];

        public ClientHandler(Socket socket, Action<string> updateGui, Action<string, Socket> sendMessageToAll)
        {
            this.socket = socket;
            this.updateGui = updateGui;
            this.sendMessageToAll = sendMessageToAll;
            Thread t = new Thread(new ThreadStart(Receive));
            t.Start();
        }

        private void Receive()
        {
            string message = "";
            while (true)
            {
                int length = socket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                sendMessageToAll(message, socket);
                updateGui(message);
            }
        }

        internal void Send(string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
