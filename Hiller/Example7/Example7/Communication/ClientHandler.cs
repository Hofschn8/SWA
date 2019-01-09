using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example7.Communication
{
    public class ClientHandler
    {
        public Socket socket;
        byte[] buffer = new byte[512];
        private Action<string> guiupdater;

        public ClientHandler(Socket socket, Action<string> guiupdater)
        {
            this.socket = socket;
            this.guiupdater = guiupdater;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            int length;
            while (true)
            {
                length = socket.Receive(buffer);
                guiupdater(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }
    }
}
