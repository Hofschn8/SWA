using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example8.ViewModel
{
    public class Ship
    {
        public int Id { get; set; }
        public List<Cargo> Cargos { get; set; }

        public Ship(int id)
        {
            Id = id;
            Cargos = new List<Cargo>();
        }

    }
}
