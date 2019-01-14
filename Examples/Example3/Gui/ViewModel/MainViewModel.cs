using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;

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

        static Random rand = new Random();
        static Random rand1 = new Random();

        private RelayCommand startGenerateCmd;

        public RelayCommand StartGenerateCmd
        {
            get { return startGenerateCmd; }
            set { startGenerateCmd = value; RaisePropertyChanged(); }
        }


        private RelayCommand detailCmd;

        public RelayCommand DetailCmd
        {
            get { return detailCmd; }
            set { detailCmd = value; RaisePropertyChanged(); }
        }

        private RelayCommand clearCmd;

        public RelayCommand ClearCmd
        {
            get { return clearCmd; }
            set { clearCmd = value; RaisePropertyChanged(); }
        }



        private ObservableCollection<ItemVm> listOfWaitingItems;

        public ObservableCollection<ItemVm> ListOfWaitingItems
        {
            get { return listOfWaitingItems; }
            set { listOfWaitingItems = value; }
        }

        private ObservableCollection<ItemVm> listOfReadyItems;

        public ObservableCollection<ItemVm> ListOfReadyItems
        {
            get { return listOfReadyItems; }
            set { listOfReadyItems = value; }
        }

        private ItemVm selectedItem;

        public ItemVm SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged(); }
        }

        private ItemVm showDetailView;

        public ItemVm ShowDetailView
        {
            get { return showDetailView; }
            set { showDetailView = value; RaisePropertyChanged(); }
        }


        private DispatcherTimer dispachTimer = new DispatcherTimer();

        private DispatcherTimer dispachTimer2 = new DispatcherTimer();

        private DispatcherTimer dispachTimer3 = new DispatcherTimer();

        private ItemVm[] listOfCargos;

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                listOfCargos = new ItemVm[5];
                listOfCargos = FillListWithDemoCargos(); // aud dieser Liste kann nun zufällig alle 5 Sekunden etwas ausgewählt werden
                ListOfWaitingItems = new ObservableCollection<ItemVm>();
                ListOfReadyItems = new ObservableCollection<ItemVm>();
                
                StartGenerateCmd = new RelayCommand(StartGenerateExec, StartCanEexec);
                ClearCmd = new RelayCommand(ClearExec, ClearCanExec);
                DetailCmd = new RelayCommand(ShowDetailExec, ShowDetailCanExec);
                
                dispachTimer.Interval = new TimeSpan(0, 0, 0, 5, 0);
                dispachTimer.Tick += SendItemToWaitingList;

                dispachTimer2.Interval = new TimeSpan(0, 0, 0, 1, 0);
                dispachTimer2.Tick += CalcualteRemainingtime;

                //dispachTimer3.Interval = new TimeSpan(0, 0, 0, 0, 1);
                //dispachTimer3.Tick += CheckIfReady;


            }
        }

        private void CheckIfReady(object sender, EventArgs e)
        {
            lock (ListOfWaitingItems)
            {
                foreach (var item in ListOfWaitingItems)
                {
                    if (item.RemainingTime == 0 && !ListOfReadyItems.Contains(item)) ListOfReadyItems.Add(item);
                }
            }
        }

        private void CalcualteRemainingtime(object sender, EventArgs e)
        {
            lock (ListOfWaitingItems)
            {
                List<ItemVm> tmp = new List<ItemVm>();
                foreach (var item in ListOfWaitingItems)
                {
                    if (item.RemainingTime > 0)
                    {
                        item.RemainingTime = item.RemainingTime - 1;
                    }
                    else if (item.RemainingTime == 0)
                    {
                        if (ListOfReadyItems.Contains(item))
                            { }
                        else{ ListOfReadyItems.Add(item); };
                        tmp.Add(item);

                    }
                }
                RemoveReadyItems(tmp);
            }
        }

        private void RemoveReadyItems(List<ItemVm> tmp)
        {
            foreach (var item in tmp)
            {
                ListOfWaitingItems.Remove(item);
            }
        }

        private void SendItemToWaitingList(object sender, EventArgs e)
        {
            lock (ListOfWaitingItems)
            {
                ItemVm tmp = listOfCargos[rand1.Next(0, 5)];
                ListOfWaitingItems.Add(tmp);
            }
        }

        private ItemVm[] FillListWithDemoCargos()
        {
            
            
            CargoItemVm c1 = new CargoItemVm("Window", 10, 200);
            CargoItemVm c2 = new CargoItemVm("Timber", 20, 300);
            CargoItemVm c3 = new CargoItemVm("Bricks", 10, 2000);
            CargoItemVm c4 = new CargoItemVm("Doors", 10, 100);
            CargoItemVm c5 = new CargoItemVm("Stones", 50, 2000);

            ItemVm item1 = new ItemVm("Vienna", rand.Next(1, 6));
            item1.ListOfCargos.Add(c1);
          

            ItemVm item2 = new ItemVm("Berlin", rand.Next(1, 6));
            item2.ListOfCargos.Add(c1);
            item2.ListOfCargos.Add(c2);

            ItemVm item3 = new ItemVm("Bratislava", rand.Next(1, 6));
            item3.ListOfCargos.Add(c1);
            item3.ListOfCargos.Add(c2);
            item3.ListOfCargos.Add(c3);

            ItemVm item4 = new ItemVm("Prag", rand.Next(1, 6));
            item4.ListOfCargos.Add(c1);
            item4.ListOfCargos.Add(c2);
            item4.ListOfCargos.Add(c3);
            item4.ListOfCargos.Add(c4);

            ItemVm item5 = new ItemVm("Warschau", rand.Next(1, 6));
            item5.ListOfCargos.Add(c1);
            item5.ListOfCargos.Add(c2);
            item5.ListOfCargos.Add(c3);
            item5.ListOfCargos.Add(c4);
            item5.ListOfCargos.Add(c5);

            ItemVm[] tmp = new ItemVm[5];
            tmp[0]=item1;
            tmp[1] = item2;
            tmp[2] = item3;
            tmp[3] = item4;
            tmp[4] = item5;
            return tmp;
        }

        private bool ShowDetailCanExec()
        {
            if (SelectedItem != null) return true;
            return false;
        }

        private void ShowDetailExec()
        {
            ShowDetailView = SelectedItem;
        }

        private bool ClearCanExec()
        {
            return true;
        }

        private void ClearExec()
        {
           // to Do
        }

        private bool StartCanEexec()
        {
            return true;
        }

        private void StartGenerateExec()
        {
            dispachTimer.Start();
            dispachTimer2.Start();
            //dispachTimer3.Start();
        }
    }
}