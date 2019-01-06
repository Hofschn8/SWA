using GalaSoft.MvvmLight;
using System;

namespace test_example6.ViewModel
{
    public class PersonVm : ViewModelBase
    {
        private string _firstname;
        private string _lastname;
        private int _age;
        private int _id;
        private string _idType;
        private int _rating;
        private Action<PersonVm> informMain;

        public string Firstname { get => _firstname; set { _firstname = value;
                if (informMain != null) { 
                    informMain(this);
                }
                RaisePropertyChanged();  } }
        public string Lastname { get => _lastname; set {
                _lastname = value;
                if (informMain != null)
                {
                    informMain(this);
                }
                RaisePropertyChanged(); } }
        public int Age { get => _age; set { _age = value;
                if (informMain != null)
                {
                    informMain(this);
                }
                RaisePropertyChanged(); } }
        public int Id { get => _id; set { _id = value;
                if (informMain != null)
                {
                    informMain(this);
                }
                RaisePropertyChanged(); } }
        public string IdType { get => _idType; set { _idType = value;
                if (informMain != null)
                {
                    informMain(this);
                }
                RaisePropertyChanged(); } }
        public int Rating { get => _rating; set { _rating = value;
                RaisePropertyChanged(); } }

        public PersonVm(string firstname, string lastname, int age, int id, string idType, int rating, Action<PersonVm> informMain)
        {

            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            Id = id;
            IdType = idType;
            Rating = rating;
            this.informMain = informMain;
        }
        public PersonVm()
        {

        }
    }
}