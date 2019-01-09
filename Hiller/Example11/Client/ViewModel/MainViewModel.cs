using Client.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Client.ViewModel
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
        public Com client;
        public bool isConnected = false;

        private string tag;

        public string Tag
        {
            get { return tag; }
            set { tag = value; RaisePropertyChanged(); }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; RaisePropertyChanged(); }
        }

        private string person;

        public string Person
        {
            get { return person; }
            set { person = value; RaisePropertyChanged(); }
        }

        private string column;

        public string Column
        {
            get { return column; }
            set { column = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<string> ColumnList { get; set; }
        public RelayCommand ConnectBtnClicked { get; set; }
        public RelayCommand AddBtnClicked { get; set; }


        public MainViewModel()
        {
            Tag = "";
            Person = "";
            ColumnList = new ObservableCollection<string>(){"IQ", "Estimate", "Implement", "Testing", "Deploy" };
            ConnectBtnClicked = new RelayCommand(ConnectClicked, CanExecConnect);
            AddBtnClicked = new RelayCommand(AddClicked, CanExecAdd);
        }

        private bool CanExecAdd()
        {
            if (Tag.Length > 0 && Time != null && Person.Length > 0 && Column != null) return true;
            else return false;
        }

        private void AddClicked()
        {
            string tmp = Time.ToShortDateString();
            string msg = Tag + ";" + tmp + ";" + Person + ";" + Column;
            client.Send(msg);
        }

        private bool CanExecConnect()
        {
            return !isConnected;
        }

        private void ConnectClicked()
        {
            isConnected = true;
            client = new Com("127.0.0.1", 10100);
        }
    }
}