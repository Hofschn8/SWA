using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example7.ViewModel
{
    public class Blueprint
    {



        public string Description { get; set; }
        public string Components { get; set; }
        public int Amount { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Completiontime { get; set; }
        public double Rating { get; set; }

        public Blueprint(string description, int amount, DateTime time)
        {
            Description = description;
            Amount = amount;
            Starttime = DateTime.Now;
            Completiontime = time;
            Rating = Completiontime.Hour - Starttime.Hour;
        }


    }
}
