using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example6.ViewModel
{
    public class Person : ViewModelBase
    {



        Action<Person> update;
        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname { get; set; }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; RaisePropertyChanged(); update(this); }
        }

        private int idNumber;

        public int IDNumber
        {
            get { return idNumber; }
            set { idNumber = value; RaisePropertyChanged(); update(this); }
        }


        private string idtype;

        public string IDType
        {
            get { return idtype; }
            set { idtype = value; RaisePropertyChanged(); update(this); }
        }

        public int Rating { get; set; }

        public Person(string v1, string v2, int v3, int v4, string v5, int v6, Action<Person> UpdateName)
        {
            update = UpdateName;
            Firstname = v1;
            Lastname = v2;
            Age = v3;
            IDNumber = v4;
            IDType = v5;
            Rating = v6;
        }

        public string ToString()
        {
            string tmp = Firstname + "|" + Lastname + "|" + Age + "|" + IDNumber + "|" + IDType;
            return tmp;
        }

    }
}
