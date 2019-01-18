using Einheit4_Server.Communication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Einheit4_Server.ViewModel
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
        private Server serverConnection;
        public ObservableCollection<ClientVm> Clients { get; set; }
        private ClientVm selectedClient;

        public ClientVm SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            if (IsInDesignMode)
            {

            }
            else
            {
                Clients = new ObservableCollection<ClientVm>();
                serverConnection = new Server(UpdateGui);
            }
        }

        private void UpdateGui(string message)
        {
            string[] splitMessage = message.Split('|');
            string clientid = splitMessage[0];
            bool isInList = false;
            ClientVm client = new ClientVm();

            foreach (var item in Clients)
            {
                if (item.ClientID.Equals(clientid))
                {
                    client = item;
                    isInList = true;
                }
            }

            if (isInList==false)
            {
                client = new ClientVm()
                {
                    ClientID = clientid,
                    Submissions = new ObservableCollection<SubmissionVm>()
                };
            }

            SubmissionVm subVm = new SubmissionVm()
            {
                Students = new ObservableCollection<StudentVm>()
            };
            for(int i=1;i<splitMessage.Length;i+=2)
            {
                
                subVm.Students.Add(new StudentVm()
                {
                    Lastname = splitMessage[i],
                    Semester = Convert.ToInt32(splitMessage[(i+1)])
                });
            }
            
            App.Current.Dispatcher.Invoke(() =>
            {
                client.Submissions.Add(subVm);
                if (!isInList)
                {
                    Clients.Add(client);
                    RaisePropertyChanged("client");
                }
            });


        }
    }
}