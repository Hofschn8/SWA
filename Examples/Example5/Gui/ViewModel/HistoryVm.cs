using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.ViewModel
{
   public  class HistoryVm : ViewModelBase
    {


        private RelayCommand clearCmd ;

        public RelayCommand ClearCmd
        {
            get { return clearCmd; }
            set { clearCmd = value; RaisePropertyChanged(); }
        }

        private Messenger myMessenger = SimpleIoc.Default.GetInstance<Messenger>();


        private ObservableCollection<EntryVm> historyList;

        public ObservableCollection<EntryVm> HistoryList
        {
            get { return historyList; }
            set { historyList = value; }
        }

        private char[] seperator = new char[] { ('*') };

        public HistoryVm()
        {
            HistoryList = new ObservableCollection<EntryVm>();
            ClearCmd = new RelayCommand(ClearExec,ClearCanExec);
            myMessenger.Register<string>(this, MessengerReceive);
        }

        private void MessengerReceive(string obj)
        {
            if (obj != null)
            {
                string[] tmp = obj.Split(seperator);
                DateTime t = DateTime.Parse(tmp[2]);
                HistoryList.Add(new EntryVm(t, tmp[1], tmp[3], tmp[0]));
            }
        }

        private bool ClearCanExec()
        {
            //to Do
            return true;
        }

        private void ClearExec()
        {
            HistoryList.Clear();


        }
    }
}
