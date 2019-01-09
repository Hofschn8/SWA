using Example6.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Example6.ViewModel
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
        bool isconnected = false;
        Com com;
        bool isserver = false;

        public List<string> Filterlist { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
        public ObservableCollection<Person> TmpPersons { get; set; }
        private string selectedFilter;

        public string SelectedFilter
        {
            get { return selectedFilter; }
            set { selectedFilter = value; RaisePropertyChanged(FilterChanged); }
        }

        private void FilterChanged()
        {
            ObservableCollection<Person> tmp = new ObservableCollection<Person>();
            foreach (var item in Persons)
            {
                if (item.IDType == SelectedFilter)
                {
                    tmp.Add(item);
                }
            }
            TmpPersons.Clear();
            foreach (var item in tmp)
            {
                TmpPersons.Add(item);
            }

        }

        private void RaisePropertyChanged(Action filterChanged)
        {
            filterChanged();
        }


        public RelayCommand ClientBtnCmd { get; set; }
        public RelayCommand ServerBtnCmd { get; set; }




        public MainViewModel()
        {
            Filterlist = new List<string>() { "Driving License", "identity card", "Signature" };
            Persons = new ObservableCollection<Person>();
            TmpPersons = new ObservableCollection<Person>();
            ClientBtnCmd = new RelayCommand(ClientClicked, CanExecClientClicked);
            ServerBtnCmd = new RelayCommand(ServerClicked, CanExecServerClicked);
            LoadDemoData();
        }



        private bool CanExecServerClicked()
        {
            return !isconnected;
        }

        private void ServerClicked()
        {
            isserver = true;
            isconnected = true;
            com = new Com(true, "127.0.0.1", 10100, NewMessageReceived);          
        }

        private bool CanExecClientClicked()
        {
            return !isconnected;
        }

        private void ClientClicked()
        {
            isconnected = true;
            com = new Com(false, "127.0.0.1", 10100, NewMessageReceived);
        }

        private void NewMessageReceived(string msg)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] tmp = msg.Split('|');
                    foreach (var item in Persons)
                    {
                        if (tmp[0] == item.Firstname && tmp[1] == item.Lastname)
                        {
                            item.Age = int.Parse(tmp[2]);
                            item.IDNumber = int.Parse(tmp[3]);
                            item.IDType = tmp[4];
                        }
                    }
                    foreach (var item in TmpPersons)
                    {
                        if (tmp[0] == item.Firstname && tmp[1] == item.Lastname)
                        {
                            item.Age = int.Parse(tmp[2]);
                            item.IDNumber = int.Parse(tmp[3]);
                            item.IDType = tmp[4];
                        }
                    }

                });
        }

        public void LoadDemoData()
        {
            Person p1 = new Person("Thomas", "Hiller", 23, 1234, "Driving License", 1, UpdateName);
            Person p2 = new Person("Kathi", "Hiller", 20, 1294, "Signature", 5, UpdateName);
            Person p3 = new Person("Sonja", "Filip", 30, 5643, "Driving License", 4, UpdateName);
            Persons.Add(p1);
            Persons.Add(p2);
            Persons.Add(p3);
            TmpPersons.Add(p1);
            TmpPersons.Add(p2);
            TmpPersons.Add(p3);
        }

        public void UpdateName(Person person)
        {
            if (isserver)
            {
                com.Send(person.ToString());
            }
        }
    }
}