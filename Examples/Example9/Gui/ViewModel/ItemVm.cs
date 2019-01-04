using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.ViewModel
{
    public abstract class ItemVm : ViewModelBase
    {
        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; RaisePropertyChanged(); }
        }

        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; RaisePropertyChanged(); }
        }


        private int prio;

        public int Prio
        {
            get { return prio; }
            set { prio = value; RaisePropertyChanged(); }
        }

        private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged(); }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; RaisePropertyChanged(); }
        }

       
    }
}
