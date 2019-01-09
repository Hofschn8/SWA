using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example2_Server.Communication
{
    public class ClientHandler
    {
        bool isFirstMessage = true;
        private Socket socket;
        public string name;
        byte[] buffer = new byte[512];
        Action<string> ReceiveUpdater;

        public ClientHandler(Socket socket, Action<string> ReceiveUpdate)
        {
            
            this.socket = socket;
            this.ReceiveUpdater = ReceiveUpdate;
            Task.Factory.StartNew(Receive);
            
        }

        public void Receive()
        {
            string tmp;
            while (true)
            {
                int length = socket.Receive(buffer);
                tmp = Encoding.UTF8.GetString(buffer, 0, length);
                if(isFirstMessage)
                {
                    this.name = tmp;
                    isFirstMessage = false;
                    ReceiveUpdater(tmp);
                } else
                {
                    string toSend = this.name + ": " + tmp;
                    ReceiveUpdater(toSend);
                }
            }
              

            
        }
    }
}
