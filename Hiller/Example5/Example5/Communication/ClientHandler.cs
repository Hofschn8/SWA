using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example5.Communication
{
    public class ClientHandler
    {
        private Socket socket;
        Action<string> GuiUpdater;
        byte[] buffer = new byte[512];


        public ClientHandler(Socket socket, Action<string> updater)
        {
            GuiUpdater = updater;
            this.socket = socket;
            Task.Factory.StartNew(Receive);
        }

        internal void Send(string msg)
        {
            socket.Send(Encoding.UTF8.GetBytes(msg));
        }

        private void Receive()
        {
            int length;
            while (true)
            {
                length = socket.Receive(buffer);
                GuiUpdater(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }
    }
}
