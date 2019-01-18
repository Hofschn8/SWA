using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Einheit4_Server.Communication
{
    public class ClientHandler
    {
        private Socket clientSocket;
        byte[] buffer = new byte[512];
        Action<string> Updater;

        public ClientHandler(Socket socket, Action<string> updater)
        {
            clientSocket = socket;
            Updater = updater;

            Task.Factory.StartNew(Receive);
        }

        public void Receive()
        {
            int length;

            while (true)
            {
                length = clientSocket.Receive(buffer);
                Updater(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }
    }
}
