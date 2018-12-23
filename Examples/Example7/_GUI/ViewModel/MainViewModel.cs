using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using TcpCom;

namespace _GUI.ViewModel
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

        private ObservableCollection<BluePrintVm> blueprints;

        public ObservableCollection<BluePrintVm> BluePrints
        {
            get { return blueprints; }
            set { blueprints = value; }
        }

        private BluePrintVm selectedBluePrint;

        public BluePrintVm SelectedBluePrint
        {
            get { return selectedBluePrint; }
            set { selectedBluePrint = value; RaisePropertyChanged(); }
        }

        private bool isServer = true;

        private ClientServer server;


        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                
            }
            else
            {
                server = new ClientServer(isServer, 10100, "127.0.0.1", guiUpdater);
                BluePrints = new ObservableCollection<BluePrintVm>();
                GenerateDemoData();
            }
        }


        private void guiUpdater(string messaage, ClientHandler client)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    // To Do 
                });


        }

        private void GenerateDemoData()
        {
            BluePrintVm bp1 = new BluePrintVm(Enums.Types.Bicycle, "rack,Tires,Pedals", 10, "10:20");
            BluePrints.Add(bp1);
        }
    }
}