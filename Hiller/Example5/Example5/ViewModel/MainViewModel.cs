using Example5.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Example5.ViewModel
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
        bool isConnected = false;
        bool isServer;
        Com com;
        public List<ToggleButton> Toggles { get; set; }
        private ObservableCollection<Entry> history;

        public ObservableCollection<Entry> History
        {
            get { return history; }
            set { history = value; RaisePropertyChanged(); }
        }

        public RelayCommand ListenBtnClickedCmd { get; set; }
        public RelayCommand ConnectBtnClickedCmd { get; set; }
        public RelayCommand ClearBtnClickedCmd { get; set; }
        public RelayCommand<int> ToggleBtnClickedCmd { get; set; }

        public MainViewModel()
        {
            Toggles = new List<ToggleButton>();
            History = new ObservableCollection<Entry>();
            Toggles.Add(new ToggleButton(1));
            Toggles.Add(new ToggleButton(2));
            Toggles.Add(new ToggleButton(3));
            Toggles.Add(new ToggleButton(4));
            Toggles.Add(new ToggleButton(5));
            ListenBtnClickedCmd = new RelayCommand(ListenClicked, CanExecListenClicked);
            ConnectBtnClickedCmd = new RelayCommand(ConnectClicked, CanExecConnectClicked);
            ToggleBtnClickedCmd = new RelayCommand<int>(ToggleClicked);
            ClearBtnClickedCmd = new RelayCommand(ClearClicked);
        }

        private void ClearClicked()
        {
            History.Clear();
        }

        private void ToggleClicked(int id)
        {
            string tmp = "";
            tmp += id;
            if (isServer)
            {
                com.SendFromServer(tmp);
            } else
            {
                com.Send(tmp);
            }
            
            foreach (var item in Toggles)
            {
                if (item.Id == id)
                {
                    item.IsOn = !item.IsOn;
                }
            }
            History.Add(new Entry("Green", id));
            RaisePropertyChanged("History");
        }

        private void ConnectClicked()
        {
            isServer = false;
            isConnected = true;
            com = new Com(false, "127.0.0.1", 10100, NewMessageReceived);
        }

        private bool CanExecConnectClicked()
        {
            return !isConnected;
        }

        private void ListenClicked()
        {
            isServer = true;
            isConnected = true;
            com = new Com(true, "127.0.0.1", 10100, NewMessageReceived);
        }

        private bool CanExecListenClicked()
        {
            return !isConnected;
        }

        private void NewMessageReceived(string msg)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    int id = int.Parse(msg);
                    foreach (var item in Toggles)
                    {
                        if (item.Id == id)
                        {
                            item.IsOn = !item.IsOn;
                        }
                    }
                    History.Add(new Entry("Red", id));

                });         
        }
    }
}