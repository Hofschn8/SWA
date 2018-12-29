using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.ViewModel
{
   public class ItemVm : ViewModelBase
    {

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; RaisePropertyChanged(); }
        }


        private int deliveryTime;

        public int DeliveryTime
        {
            get { return deliveryTime; }
            set { deliveryTime = value; RaisePropertyChanged(); }
        }

        private int remainingTime;

        public int RemainingTime
        {
            get { return remainingTime; }
            set { remainingTime = value; RaisePropertyChanged(); }
        }


        private ObservableCollection<CargoItemVm> listOfCargos;


        public ObservableCollection<CargoItemVm> ListOfCargos
        {
            get { return listOfCargos; }
            set { listOfCargos = value; }
        }

        public ItemVm(string description, int deliveryTime)
        {
            Description = description;
            DeliveryTime = deliveryTime;
            ListOfCargos = new ObservableCollection<CargoItemVm>();
            RemainingTime = DeliveryTime;
        }








    }
}
