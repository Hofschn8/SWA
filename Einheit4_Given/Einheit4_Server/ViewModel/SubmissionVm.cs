using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einheit4_Server.ViewModel
{
    public class SubmissionVm
    {
        public ObservableCollection<StudentVm> Students { get; set; }

        public SubmissionVm()
        {
            if (Students == null)
            {
                Students = new ObservableCollection<StudentVm>();
            }
        }
    }
}
