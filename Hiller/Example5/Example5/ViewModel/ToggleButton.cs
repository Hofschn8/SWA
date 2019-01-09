using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example5.ViewModel
{
    public class ToggleButton : ViewModelBase
    {
        public int Id { get; set; }
        public string ToggleString { get; set; }
        private bool isOn;

        public bool IsOn
        {
            get { return isOn; }
            set { isOn = value; RaisePropertyChanged(); }
        }


        public ToggleButton(int id)
        {
            Id = id;
            ToggleString = "Toggle";
            IsOn = true;
        }
    }
}
