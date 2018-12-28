using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TcpCommunication;

namespace Gui.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {


        private TcpCom myServer;
        private string ip = "127.0.0.1";
        private int port = 10100;
        private char[] sep = new char[] { '\n','\r' };

        private RelayCommand receiveCmd;

        public RelayCommand ReceiveCmd
        {
            get { return receiveCmd; }
            set { receiveCmd = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ClientHandlerVm> connectedClients;

        public ObservableCollection<ClientHandlerVm> ConnectedClients
        {
            get { return connectedClients; }
            set { connectedClients = value; }
        }

        private ClientHandlerVm selectedClient;

        public ClientHandlerVm SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<string> receivedMessage;

        public ObservableCollection<string> ReceivedMessages
        {
            get { return receivedMessage; }
            set { receivedMessage = value; }
        }








        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                
                
            }
            else
            {
                ConnectedClients = new ObservableCollection<ClientHandlerVm>();
                ReceivedMessages = new ObservableCollection<string>();

                receiveCmd = new RelayCommand(
                    () =>
                    {
                        myServer = new TcpCom(true, this.port, this.ip, GuiUpdater);
                    },
                    ()=>{
                        if (myServer==null) return true;
                        return false;
                });


            }
        }

        private void GuiUpdater(string msg, ClientHandler c)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    bool isnew = true;
                    if (msg.Contains("\n"))
                    {
                        var tmp = msg.Split(sep);
                        msg = tmp[0];
                    }
                    foreach (var item in ConnectedClients)
                    {
                        if (item.client.Equals(c))    
                        {
                            var time = DateTime.Now;
                            item.Messages.Add(new MessageVm(msg,time));
                            ReceivedMessages.Add(item.Name + ":" + msg);
                            isnew = false;
                            break;
                        }
                    }
                    if (isnew == true)
                    {
                        ClientHandlerVm tmp = new ClientHandlerVm(c, msg);
                        ConnectedClients.Add(tmp);
                        ReceivedMessages.Add(tmp.Name + " connected...");
                        tmp.Messages.Add(new MessageVm("connected...",DateTime.Now));
                    }
                    
                }
                );
        }
    }
}