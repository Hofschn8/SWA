using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.ViewModel
{
   public  class CargoItemVm : ViewModelBase
    {
        private string item;


        private int amount;

        private float weight;


        public string Item
        {
            get { return item; }
            set { item = value; RaisePropertyChanged(); }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged(); }
        }


        public float Weight
        {
            get { return weight; }
            set { weight = value; RaisePropertyChanged(); }
        }


        public CargoItemVm(string item, int amount, float weight)
        {
            this.Item = item;
            this.Amount = amount;
            this.Weight = weight;
        }


    }
}
