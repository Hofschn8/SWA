using _GUI.Enums;
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

        private char[] seperatorComponents = new char[] { '{', '}' };
        private char[] seperatorRest = new char[] { ';' };


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
            //"Motorcycle{Engine;Tires;Chasis;Tank}5;10:20"



            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] temp = new string[3];
                    temp = messaage.Split(seperatorComponents);
                    string typ = temp[0];
                    string comp = temp[1];
                    string rest = temp[2];
                    string[] temp1 = new string[2];
                    temp1 = temp[2].Split(seperatorRest);
                    string amount = temp1[0];
                    string time = temp1[1];
                    Types t =(Types)Enum.Parse(typeof(Types), typ);
                    int amount1 = int.Parse(amount);
                    BluePrints.Add(new BluePrintVm(t, comp, amount1, time));



                });


        }

        private void GenerateDemoData()
        {
            BluePrintVm bp1 = new BluePrintVm(Enums.Types.Bicycle, "rack,Tires,Pedals", 10, "10:20");
            BluePrints.Add(bp1);
        }
    }
}