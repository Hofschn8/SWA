using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example10___Horses.Communication
{
    public class ClientHandler
    {
        public Socket socket;
        private Action<string, Socket> guiUpdate;
        byte[] buffer = new byte[512];

        public ClientHandler(Socket socket, Action<string, Socket> guiUpdate)
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
                guiUpdate(Encoding.UTF8.GetString(buffer, 0, length), this.socket);
            }
        }

        public void Send(string msg)
        {

            socket.Send(Encoding.UTF8.GetBytes(msg));
        }
    }
}