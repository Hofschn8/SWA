using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;

namespace Gui.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private ViewModelBase currentDetailView;

        public ViewModelBase CurrentDetailView
        {
            get { return currentDetailView; }
            set { currentDetailView = value; RaisePropertyChanged(); }
        }

        private RelayCommand dataCmd;

        public RelayCommand DataCmd
        {
            get { return dataCmd; }
            set { dataCmd = value; RaisePropertyChanged(); }
        }


        private RelayCommand historyCmd;

        public RelayCommand HistoryCmd
        {
            get { return historyCmd; }
            set { historyCmd = value; RaisePropertyChanged(); }
        }



        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                CurrentDetailView = SimpleIoc.Default.GetInstance<DataVm>();
            }
            else
            {
                DataCmd = new RelayCommand(
                    () => { CurrentDetailView = SimpleIoc.Default.GetInstance<DataVm>();},
                    ()=>{ return true; }
                    );

                HistoryCmd = new RelayCommand(
                    () => { CurrentDetailView = SimpleIoc.Default.GetInstance<HistoryVm>(); },
                    () => { return true; }
                    );

            }
        }
    }
}