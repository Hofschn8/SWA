using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communications
{
    public class Client
    {
        private Action<string> guiUpdater;
        private Socket clientSocket;
        private byte[] buffer = new byte[1024];

        public Client(Action<string> guiUpdater)
        {
            this.guiUpdater = guiUpdater;
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10100));
            this.clientSocket=client.Client;
            Thread receiving = new Thread(new ThreadStart(Receiving));
            receiving.IsBackground = true;
            receiving.Start();

        }

        public void Send(string msg)
        {
             this.clientSocket.Send(Encoding.UTF8.GetBytes(msg));
        }

        public void Receiving()
        {
            while (true)
            {
                int lenght = clientSocket.Receive(buffer);
                string tmp = Encoding.UTF8.GetString(buffer, 0, lenght);
                System.Windows.MessageBox.Show("Client_Receivinig: "+tmp);
                guiUpdater(tmp);
            }
        }

    }
}
