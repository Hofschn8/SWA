using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einheit4_Server.ViewModel
{
    public class ClientVm : ViewModelBase
    {
        public string ClientID { get; set; }

        public ObservableCollection<SubmissionVm> Submissions { get; set; }


    }
}
