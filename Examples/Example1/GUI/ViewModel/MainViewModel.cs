using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using TcpCom;

namespace GUI.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private ServerClient myServerClient;
        private bool isRunning = false;
        private bool isServer;

      

        #endregion

        #region Properties
        private RelayCommand listenCommand;

        public RelayCommand ListenCommand
        {
            get { return listenCommand; }
            set { listenCommand = value; }
        }

        private RelayCommand connectCommand;

        public RelayCommand ConnectCommand
        {
            get { return connectCommand; }
            set { connectCommand = value; }
        }

        private ObservableCollection<string> receivedMessages = new ObservableCollection<string>();

        public ObservableCollection<string> ReceivedMessages  // darin wird die History später gebunden
        {
            get { return receivedMessages; }
            set { receivedMessages = value; }
        }

        private RelayCommand toogle1;

        public RelayCommand Toogle1
        {
            get { return toogle1; }
            set { toogle1 = value; }
        }

        private RelayCommand toogle2;

        public RelayCommand Toogle2
        {
            get { return toogle2; }
            set { toogle2 = value; }
        }
        private RelayCommand toogle3;

        public RelayCommand Toogle3
        {
            get { return toogle3; }
            set { toogle3 = value; }
        }
        private RelayCommand toogle4;

        public RelayCommand Toogle4
        {
            get { return toogle4; }
            set { toogle4 = value; }
        }

        private string is1_On = "false";
        public string Is1_On { get { return is1_On; } set { is1_On = value; RaisePropertyChanged(); } }

        private string is2_On = "false";
        public string Is2_On { get { return is2_On; } set { is2_On = value; RaisePropertyChanged(); } }

        private string is3_On = "false";
        public string Is3_On { get { return is3_On; } set { is3_On = value; RaisePropertyChanged(); } }

        private string is4_On = "false";
        public string Is4_On { get { return is4_On; } set { is4_On = value; RaisePropertyChanged(); } }


        #endregion


        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                
            }
            else
            {
                ListenCommand = new RelayCommand(
                    () =>  // Execute
                    {
                        isServer = true;
                        myServerClient = new ServerClient(isServer, UpdateGui); // Server
                        isRunning = true;
                    },
                    () => //  CanExecute
                    {
                        if (isRunning==false) return true;
                        return false;
                    });

                ConnectCommand = new RelayCommand(

                    () => // Execute
                    {
                        isServer = false;
                        myServerClient = new ServerClient(isServer, UpdateGui); // Client
                        isRunning = true;
                    },
                    () =>
                    {
                        if (isRunning == false) return true;
                        return false;
                    }
                    );

                Toogle1 = new RelayCommand(
                    () => //Execute
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        if (Is1_On.Equals("true"))
                        {
                            Is1_On = "false";
                            this.myServerClient.SendReceivedMessageToAllConnectedClientes(time + ": Button 1 [state off]", myServerClient.sock);
                        }
                        else
                        {
                            Is1_On = "true";
                            this.myServerClient.SendReceivedMessageToAllConnectedClientes(time + ": Button 1 [state On]", myServerClient.sock);
                        }

                    },
                    () => // CanExecute
                    {
                        if (isServer == true && isRunning == true) return true;
                        return false;
                    }

                    );


            }
        }

        private void UpdateGui(string msg)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                receivedMessages.Add(msg);
            }
            );

            App.Current.Dispatcher.Invoke(() =>
            {
                ChangeCircleColor(msg);
            }
            );

            

            
        }


        private void ChangeCircleColor(string msg)
        {
            if(msg.Contains("Button 1 [state off]"))
            {
                Is1_On = "false";
            }
            if (msg.Contains("Button 1 [state On]"))
            {
                Is1_On = "true";
            }
            if (msg.Contains("Button 2 [state off]"))
            {
                Is2_On = "false";
            }
            if (msg.Contains("Button 2 [state On]"))
            {
                Is2_On = "true";
            }
            if (msg.Contains("Button 3 [state off]"))
            {
                Is3_On = "false";
            }
            if (msg.Contains("Button 3 [state On]"))
            {
                Is3_On = "true";
            }
            if (msg.Contains("Button 4 [state off]"))
            {
                Is4_On = "false";
            }
            if (msg.Contains("Button 4 [state On]"))
            {
                Is4_On = "true";
            }

        }

    }
}