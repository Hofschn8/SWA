using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example11.ViewModel
{
    public class Task : ViewModelBase
    {
        public string Tag { get; set; }
        public DateTime Time { get; set; }
        public string Person { get; set; }
        private string column;



        public string Column
        {
            get { return column; }
            set { column = value; RaisePropertyChanged(); }
        }

        public Task(string tag, string time, string person, string col)
        {
            Tag = tag;
            Person = person;
            Column = col;
            string [] s = time.Split('.');
            Time = new DateTime(int.Parse(s[2]), int.Parse(s[1]), int.Parse(s[0]));
           // Time = tmp;
        }


    }
}
