using GalaSoft.MvvmLight;
using System;

namespace Gui.ViewModel
{
    public class EntryVm : ViewModelBase
    {

        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; RaisePropertyChanged(); }
        }

        private string status;

        public string Status  // On, Off
        {
            get { return status; }
            set { status = value; RaisePropertyChanged(); }
        }

        private string aktion;  // Sended, Received;

        public string Aktion
        {
            get { return aktion; }
            set { aktion = value; RaisePropertyChanged(); }
        }

        private string button;

        public string Button
        {
            get { return button; }
            set { button = value; RaisePropertyChanged(); }
        }

        public EntryVm(DateTime datum, string status, string aktion, string button)
        {
            Datum = datum;
            Status = status;
            Aktion = aktion;
            Button = button;
        }
    }
}