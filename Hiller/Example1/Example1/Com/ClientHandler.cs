using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example1.Com
{
    public class ClientHandler
    {
        private Socket socket;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
        }

        public void SendData(byte[] v)
        {
            socket.Send(v);
        }
    }
}
