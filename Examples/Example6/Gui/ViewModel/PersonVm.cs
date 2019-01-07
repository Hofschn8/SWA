using GalaSoft.MvvmLight;
using Gui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.ViewModel
{
    public class PersonVm : ViewModelBase 
    {

        private Action<PersonVm> personChanged;

        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; personChanged(this); RaisePropertyChanged(); }
        }

        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value;  personChanged(this); RaisePropertyChanged(); }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value;  personChanged(this); RaisePropertyChanged(); }
        }

        private string idNumber;

        public string IdNumber
        {
            get { return idNumber; }
            set { idNumber = value;  personChanged(this); RaisePropertyChanged(); }
        }

        private IdType idType;

        public IdType IDType
        {
            get { return idType; }
            set { idType = value;  personChanged(this); RaisePropertyChanged(); }
        }

        private int rating;


        public int Rating
        {
            get { return rating; }
            set { rating = value;  personChanged(this); RaisePropertyChanged(); }
        }

        public PersonVm(string firstname, string lastname, int age, string idNumber, IdType iDType, int rating,Action<PersonVm> personChangedInformder)
        {
            personChanged = personChangedInformder;
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            IdNumber = idNumber;
            IDType = iDType;
            Rating = rating;
        }

        public string PersonToString()
        {
            string person = Firstname + "@" + Lastname + "@" + Age + "@" + IdNumber + "@" + IDType.ToString() + "@" + Rating;
            return person;
            
        }

    }
}
