using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

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

        private List<string> categoryList;

        public List<string> CategoryList
        {
            get { return categoryList; }
            set { categoryList = value; RaisePropertyChanged(); }
        }

        private string selectedCatory = "";

        public string SelectedCategory
        {
            get { return selectedCatory; }
            set { selectedCatory = value; RaisePropertyChanged(); }
        }


        private string descr = "";

        public string Descr
        {
            get { return descr; }
            set { descr = value; RaisePropertyChanged(); }
        }

        private List<string> typeList;

        public List<string> TypeList
        {
            get { return typeList; }
            set { typeList = value; RaisePropertyChanged(); }
        }

        private string selectedType = "";

        public string SelectedType
        {
            get { return selectedType; }
            set { selectedType = value; RaisePropertyChanged(); }
        }


        private List<int> priority;

        public List<int> PriorityList
        {
            get { return priority; }
            set { priority = value; RaisePropertyChanged(); }
        }

        private int selectedPrio;

        public int SelectedPrio
        {
            get { return selectedPrio; }
            set { selectedPrio = value; RaisePropertyChanged(); }
        }


        private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged(); }
        }

        private List<string> statusList;

        public List<string> StatusList
        {
            get { return statusList; }
            set { statusList = value; RaisePropertyChanged(); }
        }

        private string selectedStatus;

        public string SelectedStatus
        {
            get { return selectedStatus; }
            set { selectedStatus = value; RaisePropertyChanged(); }
        }


        private RelayCommand addCmd;

        public RelayCommand AddCmd
        {
            get { return addCmd; }
            set { addCmd = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ItemVm>  cat2List ;

        public ObservableCollection<ItemVm> Cat2List
        {
            get { return cat2List; }
            set { cat2List = value; }
        }

        private ObservableCollection<ItemVm> cat1List;

        public ObservableCollection<ItemVm> Cat1List
        {
            get { return cat1List; }
            set { cat1List = value; }
        }

        private ObservableCollection<ItemVm> cat3List;

        public ObservableCollection<ItemVm> Cat3List
        {
            get { return cat3List; }
            set { cat3List = value; }
        }

        private ObservableCollection<ItemVm> cat4List;

        public ObservableCollection<ItemVm> Cat4List
        {
            get { return cat4List; }
            set { cat4List = value; }
        }

        private BitmapImage karroserie= new BitmapImage(new Uri(@"../Pictures/Karroserie.JPG", UriKind.Relative));

        public BitmapImage Karroserie
        {
            get { return karroserie; }
            set { karroserie = value; RaisePropertyChanged(); }
        }

        private BitmapImage motor = new BitmapImage(new Uri(@"../Pictures/Motor.JPG", UriKind.Relative));

        public BitmapImage Motor
        {
            get { return motor; }
            set { motor = value; RaisePropertyChanged(); }
        }




        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                DemoData();
            }
            else
            {

                CategoryList = new List<string>();
                TypeList = new List<string>();
                PriorityList = new List<int>();
                StatusList = new List<string>();
                Cat1List = new ObservableCollection<ItemVm>();
                Cat2List = new ObservableCollection<ItemVm>();
                Cat3List = new ObservableCollection<ItemVm>();
                Cat4List = new ObservableCollection<ItemVm>();
                AddCmd = new RelayCommand(AddExec, AddCanExec);
                FillLists();
                Karroserie = new BitmapImage(new Uri(@"..\Pictures\Karroserie.JPG", UriKind.Relative));
                Motor = new BitmapImage(new Uri(@"..\Pictures\Motor.JPG", UriKind.Relative));
                DemoData();


            }
        }

        private void DemoData()
        {
            //SelectedCategory = "Categorie 1";
            //Descr = "Testdesc";
            //SelectedType = "Karroserie";
            //SelectedPrio = 2;
            //Amount = 10;
            //SelectedStatus = "Ready";

            Cat1List = new ObservableCollection<ItemVm>();
            Cat1List.Add(new KarrosierieVm("Categorie 1", "Test1", 1, 1, "Ready"));
            Cat1List.Add(new MotorVm("Categorie 1", "Test1", 1, 2, "Ready"));

          
            Cat2List.Add(new MotorVm("Categorie 2","Moto", 4, 4, "Processed"));
            Cat2List.Add(new KarrosierieVm("Categorie 2", "Karrose", 3, 3, "Ready"));

            Cat3List.Add(new KarrosierieVm("Categorie 2", "Karrose", 3, 3, "Ready"));
            Cat3List.Add(new MotorVm("Categorie 2", "Moto", 4, 4, "Processed"));

        }

        private void FillLists()
        {
            CategoryList.Add("Categorie 1");
            CategoryList.Add("Categorie 2");
            CategoryList.Add("Categorie 3");
            CategoryList.Add("Categorie 4");

            TypeList.Add("Karroserie");
            TypeList.Add("Motor");

            PriorityList.Add(1);
            PriorityList.Add(2);
            PriorityList.Add(3);

            StatusList.Add("Ready");
            StatusList.Add("Waiting");
            StatusList.Add("Processing");
        }

        private bool AddCanExec()
        {
            //if (SelectedCategory != null && SelectedCategory.Length > 0 && Descr.Length > 0 && SelectedType != null && SelectedType.Length > 0 && SelectedPrio > 0 && Amount > 0 && SelectedStatus != null) return true;
            //return false;
            return true;
        }

        private void AddExec()
        {
            MotorVm motor = new MotorVm();
            KarrosierieVm kar = new KarrosierieVm();

            if(SelectedType!=null && SelectedType.Equals("Motor"))
            {
                 motor = new MotorVm(SelectedType, Descr, SelectedPrio, Amount, SelectedStatus);
                kar = null;
            }
            else
            {
                kar = new KarrosierieVm(SelectedType, Descr, SelectedPrio, Amount, SelectedStatus);
                motor = null;
            }

            if (SelectedCategory == "Categorie 1")
            {
                if (motor == null)
                {
                    Cat1List.Add(kar);
                    
                }
                else
                {
                    Cat1List.Add(motor);
                }
            }
            else if (SelectedCategory == "Categorie 2")
            {
                if (motor == null)
                {
                    Cat2List.Add(kar);

                }
                else
                {
                    Cat2List.Add(motor);
                }
            }
            else if( SelectedCategory == "Categorie 3")
            {
                if (motor == null)
                {
                    Cat3List.Add(kar);

                }
                else
                {
                    Cat3List.Add(motor);
                }
            }
            else
            {
                if (motor == null)
                {
                    Cat4List.Add(kar);

                }
                else
                {
                    Cat4List.Add(motor);
                }
            }

        }
    }
}