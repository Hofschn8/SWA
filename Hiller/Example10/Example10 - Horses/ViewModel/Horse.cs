using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example10___Horses.ViewModel
{
    public class Horse
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Horse(string n, int s)
        {
            Name = n;
            Speed = s;
        }
    }
}
