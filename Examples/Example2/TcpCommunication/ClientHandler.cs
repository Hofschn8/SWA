using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TcpCommunication
{
    public class ClientHandler
    {
        private Socket socket;
        private Action<string, ClientHandler> guiUpdater;
        private byte[] buffer;
        private string message = "";
        

        public ClientHandler(Socket socket, System.Action<string, ClientHandler> guiUpdater)
        {
            this.buffer = new byte[1024];
            this.socket = socket;
            this.guiUpdater = guiUpdater;
            Thread receiveThread = new Thread(new ThreadStart(ReceivingMessage));
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void ReceivingMessage()
        {
            while (true)
            {
                while (!message.Contains("\n"))
                {
                    int length = socket.Receive(buffer);
                    message += Encoding.ASCII.GetString(buffer, 0, length);
                }
                
                guiUpdater(message, this);
                message = "";
            }
        }

        public void sendMessage(string msg)
        {
            socket.Send(Encoding.ASCII.GetBytes(msg));
        }

    }
}