using Example10___Horses.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Example10___Horses.ViewModel
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
        Com com;

        private string visibility;

        public string Visibility
        {
            get { return visibility; }
            set { visibility = value; RaisePropertyChanged(); }
        }

        private string fastestHorse;

        public string FastestHorse
        {
            get { return fastestHorse; }
            set { fastestHorse = value; RaisePropertyChanged(); }
        }


        private string selectedName;

        public string SelectedName
        {
            get { return selectedName; }
            set { selectedName = value; RaisePropertyChanged(); }
        }

        private int selectedSpeed;

        public int SelectedSpeed
        {
            get { return selectedSpeed; }
            set { selectedSpeed = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<Horse> Horses { get; set; }
        public RelayCommand ServerClickedCmd { get; set; }
        public RelayCommand ClientClickedCmd { get; set; }
        public RelayCommand AddClickedCmd { get; set; }

        public MainViewModel()
        {
            SelectedSpeed = 0;
            SelectedName = "";
            Visibility = "Hidden";
            Horses = new ObservableCollection<Horse>();
            ServerClickedCmd = new RelayCommand(ServerClicked, CanExecServerClicked);
            ClientClickedCmd = new RelayCommand(ClientClicked, CanExecClientClicked);
            AddClickedCmd = new RelayCommand(AddClicked, CanExecAddClicked);
        }

        private bool CanExecAddClicked()
        {
            return (selectedName.Length > 0 && selectedSpeed > 0);
        }

        private void AddClicked()
        {
            string msg = SelectedName + ";" + SelectedSpeed;
            com.Send(msg);
            Horses.Add(new Horse(SelectedName, SelectedSpeed));
            Sort(Horses);
            FastestHorse = Horses[0].Name;
        }

        private bool CanExecClientClicked()
        {
            return !isConnected;
        }

        private void ClientClicked()
        {
            isConnected = true;
            com = new Com(false, "127.0.0.1", 10100, NewHorseReceived);
            Visibility = "Visible";
        }

        private bool CanExecServerClicked()
        {
            return !isConnected;
        }

        private void ServerClicked()
        {
            isConnected = true;
            com = new Com(true, "127.0.0.1", 10100, NewHorseReceived);
        }

        private void NewHorseReceived(string msg)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] tmp = msg.Split(';');
                    Horses.Add(new Horse(tmp[0],int.Parse(tmp[1])));
                    Sort(Horses);
                    FastestHorse = Horses[0].Name;
                });
        }

        private void Sort(ObservableCollection<Horse> list)
        {
            int size = list.Count;
            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < (size - i); j++)
                {
                    if (list[j].Speed < list[j + 1].Speed)
                    {
                        Horse temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
    }
}