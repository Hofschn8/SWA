using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public string Name { get; set; }
        public string ProductId { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public Product(string name, string productId, double price, string type)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Type = type;
        }



    }
}
