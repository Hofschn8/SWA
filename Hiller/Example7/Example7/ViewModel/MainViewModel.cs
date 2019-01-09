using Example7.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Example7.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Blueprint> Blueprints { get; set; }
        private Blueprint selectedItem;
        public RelayCommand StartServer { get; set; }

        public Blueprint SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged(); }
        }

        public Server server;

        public MainViewModel()
        {
            Blueprints = new ObservableCollection<Blueprint>();
            StartServer = new RelayCommand(Startserver);
        }

        private void Startserver()
        {
            server = new Server("127.0.0.1", 10100, Guiupdater);
        }

        private void Guiupdater(string msg)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] tmp = msg.Split('{');
                    string description = tmp[0];
                    string[] tmp2 = tmp[1].Split('}');
                    string components = tmp2[0];
                    string[] tmp3 = tmp2[1].Split(';');
                    int amount = int.Parse(tmp3[0]);
                    string[] times = tmp3[1].Split(':');
                    DateTime time = new DateTime(2019, DateTime.Now.Month, DateTime.Now.Day, int.Parse(times[0]), int.Parse(times[1]),0);
                    Blueprint blue = new Blueprint(description, amount, time);
                    blue.Components = components;
                    Blueprints.Add(blue);
                });
        }
    }
}