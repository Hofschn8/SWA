using Einheit4_Client.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace Einheit4_Client.ViewModel
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
        public string ClientId { get; set; }
        public string Lastname { get => _lastname; set { _lastname = value; RaisePropertyChanged(); } }
        public int Semester { get => _semester; set { _semester = value; RaisePropertyChanged(); } }
        public ObservableCollection<StudentVm> Students { get; set; }
        public RelayCommand AddStudentClickedCommand { get; set; }
        public RelayCommand SendClickedCommand { get; set; }
        private Client connection;
        private string _lastname;
        private int _semester;

        public MainViewModel()
        {
            Students = new ObservableCollection<StudentVm>();
            AddStudentClickedCommand = new RelayCommand(() =>
            {

                Students.Add(new StudentVm() { Lastname = this.Lastname, Semester = this.Semester });
                Lastname = "";
                Semester = 0;
            },
            () =>
             {
                 return Lastname != null && Lastname.Length > 0 && Semester != 0;
             });

            SendClickedCommand = new RelayCommand(
                () =>
                {

                    if (connection == null)
                    {
                        connection = new Client();
                    }

                    string message = ClientId;
                    int i = 0;
                    foreach (var item in Students)
                    {
                        
                            message += "|";
                        
                        message += item.Lastname + "|" + item.Semester;
                        i++;
                    }

                    connection.Send(message);
                    Students.Clear();
                },
                () => { return ClientId != null && ClientId.Length > 0 && Students.Count > 0; }
                );
        }
    }
}