using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace Communications
{
    internal class ClientHandler
    {
        private Socket socket;
        private Action<string> guiUpdater;
        private byte[] buffer = new byte[1024];

        public ClientHandler(Socket socket, Action<string> guiUpdater)
        {
            this.guiUpdater = guiUpdater;
            this.socket = socket;
            Thread receiving = new Thread(new ThreadStart(Receiving));
            receiving.IsBackground = true;
            receiving.Start();
        }

        private void Receiving()
        {
            while (true)
            {
                int lenght = socket.Receive(buffer);
                string tmp = Encoding.UTF8.GetString(buffer, 0, lenght);

                System.Windows.MessageBox.Show("ClientHandler_Receivinig: " + tmp);
                guiUpdater(tmp);
                
            }
        }

        public void Send(string msg)
        {
            MessageBox.Show("ClientHandler_Send:" + msg);
            this.socket.Send(Encoding.UTF8.GetBytes(msg));
        }


    }
}