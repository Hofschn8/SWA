using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpCommunication;

namespace Gui.ViewModel
{
    public class ClientHandlerVm : ViewModelBase
    {

        private ClientHandler _client;

        public ClientHandler client
        {
            get { return _client; }
            private set { _client = value; }   // Wichtig wir wollen den client "Schützen", daherher private set
        }



        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<MessageVm>  messages;

        public ObservableCollection<MessageVm> Messages
        {
            get { return messages; }
            set { messages = value; }
        }



        public ClientHandlerVm(ClientHandler client, string name)
        {
            Messages = new ObservableCollection<MessageVm>();
            this.client = client;
            this.name = name;
            
        }

    }
}
