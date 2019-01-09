using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example8.ViewModel
{
    public class Cargo
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Weight { get; set; }


        public Cargo(string n, int a, double w)
        {
            Name = n;
            Amount = a;
            Weight = w;
        }

    }
}
