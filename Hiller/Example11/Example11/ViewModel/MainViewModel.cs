using Example11.Com;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Example11.ViewModel
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
        public Server server;
        public bool isconnected = false;

        public ObservableCollection<Task> IQTasks { get; set; }
        public ObservableCollection<Task> EstimateTasks { get; set; }
        public ObservableCollection<Task> ImplementTasks { get; set; }
        public ObservableCollection<Task> TestingTasks { get; set; }
        public ObservableCollection<Task> DeployTasks { get; set; }

        private Task selectedTask;

        public Task SelectedTask
        {
            get { return selectedTask; }
            set { selectedTask = value; RaisePropertyChanged(); }
        }

        public RelayCommand ConnectBtnClicked { get; set; }
        public RelayCommand<Task> ContinueBtnClicked { get; set; }


        public MainViewModel()
        {
            IQTasks = new ObservableCollection<Task>();
            EstimateTasks = new ObservableCollection<Task>();
            ImplementTasks = new ObservableCollection<Task>();
            TestingTasks = new ObservableCollection<Task>();
            DeployTasks = new ObservableCollection<Task>();
            ConnectBtnClicked = new RelayCommand(ConnectClicked, CanExecConnect);
            ContinueBtnClicked = new RelayCommand<Task>(ContinueClicked);
        }

        private void ContinueClicked(Task task)
        {
            foreach (var item in IQTasks)
            {
                if (task.Equals(item))
                {
                    EstimateTasks.Add(task);
                    IQTasks.Remove(item);
                    return;
                }
            }
            foreach (var item in EstimateTasks)
            {
                if (task.Equals(item))
                {
                    ImplementTasks.Add(task);
                    EstimateTasks.Remove(item);
                    return;
                }
            }
            foreach (var item in ImplementTasks)
            {
                if (task.Equals(item))
                {
                    TestingTasks.Add(task);
                    ImplementTasks.Remove(item);
                    return;
                }
            }
            foreach (var item in TestingTasks)
            {
                if (task.Equals(item))
                {
                    DeployTasks.Add(task);
                    TestingTasks.Remove(item);
                    return;
                }
            }
            foreach (var item in DeployTasks)
            {
                if (task.Equals(item))
                {
                    DeployTasks.Remove(item);
                    return;
                }
            }
        }

        private bool CanExecConnect()
        {
            return !isconnected;
        }

        private void ConnectClicked()
        {
            isconnected = true;
            server = new Server("127.0.0.1", 10100, NewMessageReceived);
        }

        private void NewMessageReceived(string msg)
        {
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] tmp = msg.Split(';');
                    Task t = new Task(tmp[0], tmp[1], tmp[2], tmp[3]);
                    switch (tmp[3])
                    {
                        case "IQ": IQTasks.Add(t);
                            return;
                        case "Estimate": EstimateTasks.Add(t);
                            return;
                        case "Implement": ImplementTasks.Add(t);
                            return;
                        case "Testing": TestingTasks.Add(t);
                            return;
                        case "Deploy": DeployTasks.Add(t);
                            return;
                    }

                });
        }
    }
}