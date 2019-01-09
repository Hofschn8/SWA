using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_example9.ViewModel
{
    public class ItemVm
    {
        public int Priority { get; set; }
        public int Category { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }

        public ItemVm(int priority, int category, string description, string status)
        {
            Priority = priority;
            Category = category;
            Description = description;
            Status = status;
        }
    }
}
