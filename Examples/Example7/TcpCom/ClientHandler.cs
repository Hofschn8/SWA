using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TcpCom
{
    public class ClientHandler
    {
        private Socket socket;
        private Action<string, ClientHandler> guiUpdater;
        private byte[] buffer;

        public ClientHandler(Socket socket, Action<string, ClientHandler> guiUpdater)
        {
            this.socket = socket;
            this.guiUpdater = guiUpdater;
            buffer = new byte[1024];
            Thread receiveThread = new Thread(new ThreadStart(Receiving));
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void Receiving()
        {
            while (true)
            {
                int lenght = socket.Receive(buffer);
                guiUpdater(Encoding.ASCII.GetString(buffer, 0, lenght), this);
            }
        }
    }
}