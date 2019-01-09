using Example2_Server.Communication;
using Example2_Server.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Example2_Server.ViewModel
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
        bool isStarted = false;
        public Server server;
        public RelayCommand StartBtnClickedCmd { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<string> Usernames { get; set; }
        private ObservableCollection<string> allMessages;

        public ObservableCollection<string> AllMessages
        {
            get { return allMessages; }
            set { allMessages = value; RaisePropertyChanged(); }
        }

        private User selectedUser;

        public User SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; RaisePropertyChanged(); }
        }



        public MainViewModel()
        {
            StartBtnClickedCmd = new RelayCommand(StartClicked, CanExeStart);
            Users = new ObservableCollection<User>();
            Users.Add(new User("Thomas"));
            AllMessages = new ObservableCollection<string>();
            Usernames = new ObservableCollection<string>();
            AllMessages.Add("Thomas: Hallo");
            Users[0].Messages.Add("Hallo");
        }

        private bool CanExeStart()
        {
            return !isStarted;
        }

        private void StartClicked()
        {
            server = new Server("127.0.0.1", 10100, UpdateGui, UpdateName);
            isStarted = true;
        }

        private void UpdateGui(string message)
        {
            App.Current.Dispatcher.Invoke(
                () => {
                    string[] tmp = message.Split(':');
                    if (tmp.Length == 1)
                    {
                        UpdateName(tmp[0]);
                    } else
                    {
                        AllMessages.Add(message);
                        foreach (var item in Users)
                        {
                            if (tmp[0].Equals(item.Name)) {
                                item.Messages.Add(tmp[1]);
                            }
                        }
                    }
                }
                );
        }

        private void UpdateName(string username)
        {
            Users.Add(new User(username));
            Usernames.Add(username);        
        }
    }
}