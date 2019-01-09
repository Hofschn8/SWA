using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2_Server.Model
{
    public class User
    {
        public string Name { get; set; }
        public ObservableCollection<string> Messages { get; set; }

        public User(string name)
        {
            this.Name = name;
            Messages = new ObservableCollection<string>();
        }

    }
}
