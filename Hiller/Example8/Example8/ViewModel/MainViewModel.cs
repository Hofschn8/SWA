using Example8.Communication;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Example8.ViewModel
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
        public Server server;

        public ObservableCollection<Ship> Ships { get; set; }

        private Ship selectedShip;

        public Ship SelectedShip
        {
            get { return selectedShip; }
            set { selectedShip = value; RaisePropertyChanged(); SumChanged(); }
        }

        private double weightsum;

        public double Weightsum
        {
            get { return weightsum; }
            set
            {
                weightsum = value;
                RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            if(IsInDesignMode)
            {

            } else
            {
                Ships = new ObservableCollection<Ship>();
                server = new Server("127.0.0.1", 10100, NewShipReceived);
                SelectedShip = new Ship(10);
                Weightsum = 0;
            }

        }

        public void NewShipReceived(string msg)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] tmp = msg.Split('@');
                    string shipId = tmp[0];
                    string[] cargos = tmp[1].Split('|');
                    
                    Ship ship = new Ship(int.Parse(shipId));
                    foreach (var cargo in cargos)
                    {
                        string[] tmp1 = cargo.Split(',');
                        ship.Cargos.Add(new Cargo(tmp1[0], int.Parse(tmp1[1]), double.Parse(tmp1[2])));
                    }
                    Ships.Add(ship);

                });
        }

        public void SumChanged()
        {
            double tmp = 0;
            foreach (var cargo in SelectedShip.Cargos)
            {
                tmp += cargo.Weight;
            }
            Weightsum = tmp;
        }

    }
}