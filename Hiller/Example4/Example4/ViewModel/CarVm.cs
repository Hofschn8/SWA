using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4.ViewModel
{
    public class CarVm
    {


        public string ProdId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public CarVm(string prodId, string name, double price, string type)
        {
            ProdId = prodId;
            Name = name;
            Price = price;
            Type = type;
        }

    }
}
