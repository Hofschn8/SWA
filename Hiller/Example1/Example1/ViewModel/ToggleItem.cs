using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1.ViewModel
{
    public class ToggleItem
    {
        public string Id { get; set; }
        public string State { get; set; }
        public DateTime Timestamp { get; set; }

        public ToggleItem(string id, string state)
        {
            Id = id;
            State = state;
            Timestamp = DateTime.Now;
        }
    }
}
