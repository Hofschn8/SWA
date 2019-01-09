using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Example3.ViewModel
{
    public class CargoItemVm
    {
        
        public string CargoItem { get; set; }
        public double Weight { get; set; }
        public int Amount { get; set; }


        public CargoItemVm(string item, double w, int a)
        {
            CargoItem = item;
            Weight = w;
            Amount = a;
            
        }


    }
}
