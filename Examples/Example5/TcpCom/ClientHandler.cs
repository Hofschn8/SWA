using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpCom
{
    public class ClientHandler
    {
        private Socket socket;
        private Action<string, ClientHandler> guiUpdater;
        private byte[] buffer = new byte[1024];

        public ClientHandler(Socket socket, Action<string, ClientHandler> guiUpdater)
        {
            this.socket = socket;
            this.guiUpdater = guiUpdater;
            Thread receiveThread = new Thread(new ThreadStart(Receiving));
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void Receiving()
        {
            while (true)
            {
                int length=socket.Receive(buffer);
                string tmp = Encoding.ASCII.GetString(buffer, 0, length);
                guiUpdater(tmp, this);
            }
        }

        public void send(string msg)
        {
            this.socket.Send(Encoding.ASCII.GetBytes(msg));
        }

    }
}
