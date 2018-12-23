using _GUI.Enums;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GUI.ViewModel
{
   public  class BluePrintVm : ViewModelBase
    {



        public Types Typ
        {
            get { return typ; }
            set { typ = value; RaisePropertyChanged(); }
        }

        private Types  typ;
        private string components;
        private string time;
        private int amount;
        private string completionTime;
        private int rating;


        public string Components
        {
            get { return components; }
            set { components = value; RaisePropertyChanged(); }
        }


        public string Time
        {
            get { return time; }
            set { time = value; RaisePropertyChanged(); }
        }


        public int Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged(); }
        }


        public string CompletionTime
        {
            get { return completionTime; }
            set { completionTime = value; RaisePropertyChanged(); }
        }


        public int Rating
        {
            get { return rating; }
            set { rating = value; RaisePropertyChanged(); }
        }

        public BluePrintVm(Types typ, string components, int amount, string completionTime)
        {
            this.typ = typ;
            this.components = components;
            this.time = time;
            this.amount = amount;
            this.completionTime = completionTime;
            
        }
       



    }
}
