using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.ViewModel
{
    

   public  class ItemVm : ViewModelBase
    {
        public static int number = 1;

        private bool isOn;
       

        public bool IsOn
        {
            get { return isOn; }
            set { isOn = value; RaisePropertyChanged(); }
        }

        private int num;

        public int Num
        {
            get { return num; }
            set { num = value;RaisePropertyChanged(); }
        }



        public ItemVm()
        {
            isOn = false;
            Num = number;
            number++;
        }
    }
}
