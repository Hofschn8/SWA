using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example11.Com
{
    public class ClientHandler
    {
        private Socket socket;
        public byte[] buffer = new byte[512];
        Action<string> guiinformer;

        public ClientHandler(Socket socket, Action<string> action)
        {
            guiinformer = action;
            this.socket = socket;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            int length;
            while (true)
            {
                length = socket.Receive(buffer);
                guiinformer(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }
    }
}
