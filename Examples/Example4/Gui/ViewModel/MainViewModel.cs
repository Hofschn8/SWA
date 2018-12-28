using Communications;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Gui.ViewModel
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
        
         private RelayCommand actClientCmd;

        public RelayCommand ActClientCmd
        {
            get { return actClientCmd; }
            set { actClientCmd = value; }
        }

        private RelayCommand actServerCmd;

        public RelayCommand ActServerCmd
        {
            get { return actServerCmd; }
            set { actServerCmd = value; }
        }

        private RelayCommand addCmd;

        public RelayCommand AddCmd
        {
            get { return addCmd; }
            set { addCmd = value; }
        }

        public Server MyServer { get; set; }
        public Client MyClient { get; set; }

        private string prodId = "";

        public string ProdId
        {
            get { return prodId; }
            set { prodId = value; RaisePropertyChanged(); UpdateIsAddVisible(); }
        }

        private void UpdateIsAddVisible()
        {
            if(ProdId.Length>0 && Name.Length>0 && Type.Length>0 && Price > 0)
            {
                IsAddVisible = true;
            }
            else
            {
                IsAddVisible = false;
            }
        }

        private string name = "";

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); UpdateIsAddVisible(); }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; RaisePropertyChanged(); UpdateIsAddVisible(); }
        }

        private string type = "";

        public string Type
        {
            get { return type; }
            set { type = value; RaisePropertyChanged(); UpdateIsAddVisible(); }
        }

        private ObservableCollection<string> types = new ObservableCollection<string>();

        public ObservableCollection<string> Types
        {
            get { return types; }
            set { types = value; }
        }

        private ObservableCollection<ProductVm> products = new ObservableCollection<ProductVm>();

        public ObservableCollection<ProductVm> Products
        {
            get { return products; }
            set { products = value; }
        }


        private bool isOn = false;
        private string[] seperator = new string[1];
        private bool isAddVisible = false;

        public bool IsAddVisible
        {
            get { return isAddVisible; }
            set { isAddVisible = value; RaisePropertyChanged(); }
        }



        public MainViewModel()
        {


            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                seperator[0] = "*";
                types.Add("Engine");
                types.Add("gears");
                types.Add("body");
                ActClientCmd = new RelayCommand(ActClientExec, ActClientCanExec);
                ActServerCmd = new RelayCommand(ActServerExec, ActServerCanExec);
                AddCmd = new RelayCommand(AddExec, AddCanExec);
                //MyServer = new Server(new Action<string>(GuiUpdater));
                //MyClient = new Client(new Action<string>(GuiUpdater));

            }
        }

        private void AddExec()
        {
            string temp = ProdId + "*" + Name + "*" + Price + "*" + Type;
            if (MyServer != null)
            {
                CreateAndAddProduct(temp);
                MyServer.Send(temp);
            }
            else
            {
                MyClient.Send(temp);
            }
        }

        private bool AddCanExec()
        {
            return true;
        }

        private bool ActServerCanExec()
        {
            if (isOn != true) return true;
            return false;
        }

        private void ActServerExec()
        {
            MyServer = new Server(new Action<string>(GuiUpdater));
            isOn = true;
        }

        private bool ActClientCanExec()
        {
            if (isOn != true) return true;
            return false;
        }

        private void ActClientExec()
        {
            MyClient = new Client(new Action<string>(GuiUpdater));
            isOn = true;
        }



        private void GuiUpdater(string msg)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    CreateAndAddProduct(msg);
                    if (MyServer != null)
                    {
                        MyServer.Send(msg);
                    }
                }

                );
        }

        private void CreateAndAddProduct(string msg)
        {
            string[] temp = new string[4];
            temp = msg.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            string id = temp[0];
            string name = temp[1];
            string priceTemp = temp[2];
            double price;
            double.TryParse(priceTemp,out price);
            string type = temp[3];
            ProductVm product = new ProductVm(new Model.Product(name, id, price, type));
            Products.Add(product);
        }

    }
}