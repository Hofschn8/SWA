using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Example3.ViewModel
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
        Random random = new Random();
        DispatcherTimer cargotimer = new DispatcherTimer();
        TimeSpan span = new TimeSpan(0, 0, 5);
        public ObservableCollection<CargoVm> WaitingCargos { get; set; }
        public ObservableCollection<CargoVm> ReadyCargos { get; set; }
        private CargoVm detailcargo;
        public CargoVm[] Cargos { get; set; }

        private CargoVm anzeigecargo;

        public CargoVm Anzeigecargo
        {
            get { return anzeigecargo; }
            set { anzeigecargo = value;  RaisePropertyChanged(); }
        }


        public RelayCommand<CargoVm> DetailBtnClickedCmd { get; set; }
        public RelayCommand StartBtnClickedCmd { get; set; }
        public RelayCommand ClearBtnClickedCmd { get; set; }


        public CargoVm Detailcargo
        {
            get { return detailcargo; }
            set { detailcargo = value; RaisePropertyChanged(); }
        }


        public MainViewModel()
        {
            WaitingCargos = new ObservableCollection<CargoVm>();
            ReadyCargos = new ObservableCollection<CargoVm>();
            LoadCargos();
            StartBtnClickedCmd = new RelayCommand(StartClicked);
            ClearBtnClickedCmd = new RelayCommand(ClearClicked);
            DetailBtnClickedCmd = new RelayCommand<CargoVm>(DetailClicked);
        }

        private void DetailClicked(CargoVm obj)
        {
            Anzeigecargo = obj;
            
        }

        private void ClearClicked()
        {
            WaitingCargos.Clear();
            ReadyCargos.Clear();
        }

        private void StartClicked()
        {
            Task.Factory.StartNew(LoadData);
        }

        private void LoadCargos()
        {
            
            CargoItemVm i1 = new CargoItemVm("Pellets", 500.5, 4);
            CargoItemVm i2 = new CargoItemVm("Holz", 345, 3);
            CargoItemVm i3 = new CargoItemVm("Türen", 500.5, 1);
            CargoItemVm i4 = new CargoItemVm("Wasser", 500.5, 4);
            CargoItemVm[] cargoitems = new CargoItemVm[4] {i1, i2, i3, i4 };
            
            CargoVm c1 = new CargoVm("Vienna", random.Next(1, 5));
            c1.Cargos.Add(i1);
            c1.Cargos.Add(i4);
            CargoVm c2 = new CargoVm("Salzburg", random.Next(1, 5));
            c2.Cargos.Add(i2);
            c2.Cargos.Add(i1);
            CargoVm c3 = new CargoVm("Graz", random.Next(1, 5));
            c3.Cargos.Add(i2);
            c3.Cargos.Add(i3);
            CargoVm c4 = new CargoVm("Linz", random.Next(1, 5));
            c4.Cargos.Add(i1);
            c4.Cargos.Add(i2);
            CargoVm c5 = new CargoVm("Schwechat", random.Next(1, 5));
            c5.Cargos.Add(i3);
            c5.Cargos.Add(i4);
            Cargos = new CargoVm[5] {c1,c2,c3,c4,c5 };

        }

        private void UpdateWaiting(CargoVm obj)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                       ReadyCargos.Add(obj);
                       WaitingCargos.Remove(obj);
                });

        }

        public void LoadData()
        {
            cargotimer.Interval = span;
            cargotimer.Tick += NewCargo;
            cargotimer.Start();

        }

        private void NewCargo(object sender, EventArgs e)
        {
            WaitingCargos.Add(new CargoVm(Cargos[random.Next(0, 4)], UpdateWaiting));           
        }
    }
}