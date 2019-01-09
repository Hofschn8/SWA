using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example6.Communication
{
    public class ClientHandler
    {
        public Socket socket;
        public Action<string> GuiUpdater;

        public ClientHandler(Socket socket, Action<string> update)
        {
            GuiUpdater = update;
            this.socket = socket;
        }

        public void Send(string msg)
        {
            socket.Send(Encoding.UTF8.GetBytes(msg));          
        }

    }
}
