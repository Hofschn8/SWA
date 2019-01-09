using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace test_example9.ViewModel
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
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        public ObservableCollection<ItemVm> Items { get; set; }
        public MainViewModel()
        {
            Items = new ObservableCollection<ItemVm>();
            Items.Add(new ItemVm(1, 2, "Item1", "ready"));
            Items.Add(new ItemVm(3, 4, "Item2", "processing"));
            Items.Add(new ItemVm(2, 1, "Item3", "waiting"));


        }
    }
}