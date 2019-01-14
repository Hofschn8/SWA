using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.ViewModel
{
    public class MessageVm : ViewModelBase
    {
        private string msg;
        private DateTime datum;


        public string Msg
        {
            get { return msg; }
            set { msg = value; RaisePropertyChanged(); }
        }



        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; RaisePropertyChanged(); }
        }

        public MessageVm(string msg, DateTime datum)
        {
            this.msg = msg;
            this.datum = datum;
        }



    }
}
