using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TcpCom;

namespace Gui.ViewModel
{
    public class DataVm : ViewModelBase
    {
        private ObservableCollection<ItemVm> buttonList = new ObservableCollection<ItemVm>();

        public ObservableCollection<ItemVm> ButtonList
        {
            get { return buttonList; }
            set { buttonList = value; RaisePropertyChanged(); }
        }

        private RelayCommand<ItemVm> toogleCmd;

        public RelayCommand<ItemVm> ToogleCmd
        {
            get { return toogleCmd; }
            set { toogleCmd = value; RaisePropertyChanged(); }
        }

        public ServerClient myServerClient { get; set; }

        private RelayCommand listenCmd;

        public RelayCommand ListenCmd
        {
            get { return listenCmd; }
            set { listenCmd = value; RaisePropertyChanged(); }
        }

        private RelayCommand connectCmd;

        public RelayCommand ConnectCmd
        {
            get { return connectCmd; }
            set { connectCmd = value; RaisePropertyChanged(); }
        }

        private bool isOn = false;

        private bool isServer = false;

        private char[] seperator = new char[] { ('*') };

        private Messenger myMessenger = SimpleIoc.Default.GetInstance<Messenger>();


        public DataVm()
        {
            
            FillButtonList();
            ToogleCmd = new RelayCommand<ItemVm>(ToogleExec,ToogleCanExec);
            ListenCmd = new RelayCommand(ListenExec, ListenCanExec);
            ConnectCmd = new RelayCommand(ConnectExec, ConnectCanExec);
            
        }

        private bool ConnectCanExec()
        {
            if (isOn) return false;
            return true;
        }

        private void ConnectExec()
        {
            isServer = false;
            myServerClient = new ServerClient(false, "127.0.0.1", 10100, GuiUpdater);
            isOn = true;
        }

        private bool ListenCanExec()
        {
            if (isOn) return false;
            return true;
        }

        private void ListenExec()
        {
            isServer = true;
            myServerClient = new ServerClient(isServer, "127.0.0.1", 10100, new Action<string, ClientHandler>(GuiUpdater));
            isOn = true;
        }

        private bool ToogleCanExec(ItemVm arg)
        {
            if (isOn) return true;
            return false;
        }

        private void ToogleExec(ItemVm obj)
        {
            if (obj.IsOn)
            {
                SendDeactivateMessage(obj);
            }
            else
            {
                SendActivateMessage(obj);
            }

            MessageBox.Show(obj.IsOn + "" + obj.Num);
            
        }

        private void SendActivateMessage(ItemVm obj)
        {
            if (isServer)
            {
                myServerClient.sendToAllClients(obj.Num + "*" + "on");
            }
            else { myServerClient.SendToServer(obj.Num + "*" + "on"); }
            obj.IsOn = true;
            DateTime t = new DateTime();
            t = DateTime.Now;
            myMessenger.Send<string>(obj.Num + "*on*" + t + "*Sended");
        }

        private void SendDeactivateMessage(ItemVm obj)
        {
            if (isServer)
            {
                myServerClient.sendToAllClients(obj.Num + "*" + "off");
            }
            else { myServerClient.SendToServer(obj.Num + "*" + "off"); }
            obj.IsOn = false;
            DateTime t = new DateTime();
            t = DateTime.Now;
            myMessenger.Send<string>(obj.Num + "*"+"off" +"*"+ t + "*Sended");
        }

        private void FillButtonList()
        {
            ButtonList.Add(new ItemVm());
            ButtonList.Add(new ItemVm());
            ButtonList.Add(new ItemVm());
            ButtonList.Add(new ItemVm());
        }

        private void GuiUpdater(string message, ClientHandler client)
        {
            App.Current.Dispatcher.Invoke(() =>
            {

                string[] tmp = message.Split(seperator);
                string number = tmp[0];
                string switchTo = tmp[1];
                int num = int.Parse(number);
                bool status;
                if (switchTo.Equals("on"))
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                foreach (var item in ButtonList)
                {
                    if (item.Num == num)
                    {
                        item.IsOn = status;
                    break;
                    }
                }

                DateTime t = new DateTime();
                t = DateTime.Now;
                myMessenger.Send<string>(num +"*"+ switchTo + "*"+ t  + "*Received");

            });
            

        }


    }
}
