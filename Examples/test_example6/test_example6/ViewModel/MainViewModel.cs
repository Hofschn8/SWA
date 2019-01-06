using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using test_example4.TcpCom;

namespace test_example6.ViewModel
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
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 

        public RelayCommand ClientBtnClickedCmd { get; set; }
        public RelayCommand ServerBtnClickedCmd { get; set; }
        private string _selectedIDType;
        public string SelectedIDType { get => _selectedIDType; set { _selectedIDType = value; RaisePropertyChanged("PersonList"); } }

        private ObservableCollection<PersonVm> personList;

        public ObservableCollection<PersonVm> PersonList
        {
            get
            {
                if (SelectedIDType != null && SelectedIDType.Length > 0)
                {
                    if (SelectedIDType.Equals("All"))
                    {
                        return personList;
                    }
                    ObservableCollection<PersonVm> personVms = new ObservableCollection<PersonVm>();
                    foreach (var item in personList)
                    {
                        if (item.IdType.Equals(SelectedIDType))
                        {
                            personVms.Add(item);
                        }
                    }
                    return personVms;
                }
                return personList;

            }
            set { personList = value; }
        }

        public ObservableCollection<string> IdTypes { get; set; }
        private bool isConnected;
        private int id = 0;

        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; RaisePropertyChanged(); }
        }

        private ClientServer connection;
   

        public MainViewModel()
        {
            IdTypes = new ObservableCollection<string>();
            IdTypes.Add("Driving Licence");
            IdTypes.Add("Identity Card");
            IdTypes.Add("Signature");
            IdTypes.Add("All");

            PersonList = new ObservableCollection<PersonVm>();
            ClientBtnClickedCmd = new RelayCommand(
                () =>
                {
                    connection = new ClientServer(false, updateGui);
                    isConnected = true;
                },
                () =>
                {
                    return !isConnected;
                }
                );
            ServerBtnClickedCmd = new RelayCommand(
                () =>
                {
                    connection = new ClientServer(true, updateGui);
                    DispatcherTimer t = new DispatcherTimer();
                    isConnected = true;
                    t.Tick += sendDemoData;
                    t.Interval = new TimeSpan(0, 0, 2);
                    t.Start();
                },
                () =>
                {
                    return !isConnected;
                }
                );



        }

        private void sendDemoData(object sender, EventArgs e)
        {
            Random r = new Random();
            int rating = r.Next(1, 6);
            int type = r.Next(0, 3);
            string person = "fname;lname;18;" + id + ";" + IdTypes[type] + ";" + rating;


            connection.SendMessageToAll(person, connection.Socket);
            PersonVm temp = new PersonVm("fname", "lname", 18, id, IdTypes[type], rating, changeData);
            id++;
            personList.Add(temp);
        }

        private void changeData(PersonVm id)
        {
            string person = id.Firstname + ";"+ id.Lastname+ ";"+ id.Age + ";" + id.Id + ";" + id.IdType + ";" + id.Rating;
            connection.SendMessageToAll(person, connection.Socket);
        }

        private void updateGui(string message)
        {
            string[] msgSplit = message.Split(';');
            PersonVm temp = new PersonVm(msgSplit[0], msgSplit[1], Convert.ToInt32(msgSplit[2]), Convert.ToInt32(msgSplit[3]), msgSplit[4], Convert.ToInt32(msgSplit[5]),changeData);
            PersonVm temp2 = new PersonVm();
            bool isNewItem = true;
            foreach (var item in personList)
            {
                if (item.Id.Equals(temp.Id))
                {
                    temp2 = item;
                    isNewItem = false;
                }
            }
            
            if (isNewItem) { 
                App.Current.Dispatcher.Invoke(() => PersonList.Add(temp));
            }
            else
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    personList[personList.IndexOf(temp2)] = temp;
                });
            }
        }
    }
}