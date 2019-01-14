using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TcpCom
{
    internal class ClientHandler
    {
        private Socket sock;
        public Socket Sock
        {
            get;
            private set;
            
        }

        private byte[] buffer = new byte[1024];
        private Action<string> GuiUpdater;
        private Action<string, Socket> SendReceivedMessageToAllConnectedClientes;

        public ClientHandler(Socket socket, Action<string> GuiUpdater,Action<string,Socket> SendReceivedMessageToAllConnectedClientes)
        {
            this.Sock = socket;
            this.GuiUpdater += GuiUpdater;
            this.SendReceivedMessageToAllConnectedClientes += SendReceivedMessageToAllConnectedClientes;
            Thread receiveThread = new Thread(new ThreadStart(Receive));
            receiveThread.IsBackground = true;
            receiveThread.Start();
            
        }

        private void Receive()
        {
            while (true)
            {
               int lenght = Sock.Receive(buffer);
               string message= Encoding.ASCII.GetString(buffer, 0, lenght);
                GuiUpdater(message);
               SendReceivedMessageToAllConnectedClientes(message, this.Sock);

            }
        }

        internal void Send(string msg)
        {
            this.Sock.Send(Encoding.ASCII.GetBytes(msg));
        }
    }
}