using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example8.Communication
{
    public class ClientHandler
    {
        private Socket socket;
        private Action<string> guiUpdate;
        byte[] buffer = new byte[512];

        public ClientHandler(Socket socket, Action<string> guiUpdate)
        {
            this.socket = socket;
            this.guiUpdate = guiUpdate;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            int length;
            while (true)
            {
                length = socket.Receive(buffer);
                guiUpdate(Encoding.UTF8.GetString(buffer, 0, length));
            }
        }
    }
}