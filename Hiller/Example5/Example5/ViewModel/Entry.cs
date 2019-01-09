using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example5.ViewModel
{
    public class Entry
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }

        public Entry(string v, int id)
        {
            Date = DateTime.Now;
            Type = v;
            Id = id;
        }





    }
}
