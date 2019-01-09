using Example4.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Example4.ViewModel
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
        Com com;
        bool isConnected = false;
        bool isServer;
        private string prodId = "";
        private string name = "";
        private double price = 0;
        private string type = "";
        public List<string> AllTypes { get; set; }
        public RelayCommand ActClientBtnClicked { get; set; }
        public RelayCommand ActServerBtnClicked { get; set; }
        public RelayCommand AddBtnClicked { get; set; }
        public ObservableCollection<CarVm> AllCars { get; set; }


        public string Type
        {
            get { return type; }
            set { type = value; RaisePropertyChanged(); }
        }


        public double Price
        {
            get { return price; }
            set { price = value; RaisePropertyChanged(); }
        }


        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }


        public string ProdId
        {
            get { return prodId; }
            set { prodId = value; RaisePropertyChanged(); }
        }


        public MainViewModel()
        {
            AllTypes = new List<string>();
            AllTypes.Add("Diesel, 5, Limosine");
            AllTypes.Add("Benzin, 6, Sport");
            AllTypes.Add("Diesel, 6, Sport");
            ActServerBtnClicked = new RelayCommand(ActServerClicked, CanExecServerClicked);
            ActClientBtnClicked = new RelayCommand(ActClientClicked, CanExecClientClicked);
            AddBtnClicked = new RelayCommand(AddClicked, CanExecAddClicked);
            AllCars = new ObservableCollection<CarVm>();
        }

        private void AddClicked()
        {            
            string message = ProdId + ";" + Name + ";" + Price + ";" + Type;
            if(isServer)
            {
                com.SendFromServer(message);
                AllCars.Add(new CarVm(ProdId, Name, Price, Type));
            } else
            {
                com.Send(message);
            }
            
        }

        private bool CanExecAddClicked()
        {
            if (ProdId.Length > 0 && Name.Length > 0 && Price > 0 && Type.Length > 0)
            {
                return true;
            }
            else return false;
        }

        private bool CanExecClientClicked()
        {
            return !isConnected;
        }

        private void ActClientClicked()
        {
            isConnected = true;
            isServer = false;
            com = new Com(false, "127.0.0.1", 10100, UpdateGui);
        }

        private void ActServerClicked()
        {
            isConnected = true;
            isServer = true;
            com = new Com(true, "127.0.0.1", 10100, UpdateGui);
        }

        private bool CanExecServerClicked()
        {
            return !isConnected;
        }

        public void UpdateGui(string message)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] tmp = message.Split(';');
                    double d = Convert.ToDouble(tmp[2]);
                    AllCars.Add(new CarVm(tmp[0], tmp[1], d, tmp[3]));
                });
        }
    }
}