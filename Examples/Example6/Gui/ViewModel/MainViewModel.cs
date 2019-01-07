using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Gui.Model;
using System;
using System.Collections.ObjectModel;
using TcpComm;

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

        private ServerClient myServerClient;
        private int port = 10100;
        private string ip = "127.0.0.1";
        private bool isServer = true;
        private bool isOn = false;
        private char[] seperator = new char[] { '@' };


        private RelayCommand actClientCmd;

        public RelayCommand ActClientCmd
        {
            get { return actClientCmd; }
            set { actClientCmd = value; RaisePropertyChanged(); }
        }

        private RelayCommand actServerCmd;

        public RelayCommand ActServerCmd
        {
            get { return actServerCmd; }
            set { actServerCmd = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<PersonVm> personList = new ObservableCollection<PersonVm>();

        public ObservableCollection<PersonVm> PersonList
        {
            get { return personList; }
            set { personList = value; }
        }



        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                
                ActClientCmd = new RelayCommand(ActClientExec, ActClientCanExec);
                ActServerCmd = new RelayCommand(ActServerExec, ActServerCanExec);
                

            }
        }

        private void GenerateDemoData()
        {
            PersonList.Add(new PersonVm("Vorname1", "Nachname1", 18, "A1234", IdType.DrivingLicense, 2,PersonChanged));
            //PersonList.Add(new PersonVm("Vorname2", "Nachname2", 25, "BX 245", IdType.Signature, 3,PersonChanged));
            //PersonList.Add(new PersonVm("Vorname3", "Nachname3", 25, "ZY 245", IdType.IdentyCard, 5,PersonChanged));
        }

        private bool ActServerCanExec()
        {
            if (isOn) return false;
            return true;
        }

        private void ActServerExec()
        {
           isServer = true;
            myServerClient = new ServerClient(isServer, port, ip, GuiUpdater);
            isOn = true;
            GenerateDemoData();


        }

        private bool ActClientCanExec()
        {
            if (isOn) return false;
            return true;
        }

        private void ActClientExec()
        {
            myServerClient = new ServerClient(false, port, ip, GuiUpdater);
            isOn = true;
            isServer = false;
        }


        private void PersonChanged(PersonVm person)
        {
            if (isServer)
            {
                myServerClient.SendToAllClients(person.PersonToString(), null);
            }
            else
            {
                myServerClient.SendToServer(person.PersonToString());
            }
        }

        private void GuiUpdater(string msg, ClientHandler client)
        {
           
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    string[] tmp = msg.Split(seperator);
                    string fn = tmp[0];
                    string ln = tmp[1];
                    string ag = tmp[2];
                    string id = tmp[3];
                    string idType = tmp[4];
                    string rat = tmp[5];
                    bool isNew = true;
                    

                    // Fall Vorname und Nachname sind identisch, dann ist Objekt bereits vorhanden

                    foreach (var item in PersonList)
                    {
                        if(item.Firstname.Equals(fn) && item.Lastname.Equals(ln))
                        {
                            item.Age = int.Parse(ag);
                            item.IdNumber = id;
                            if (idType.Equals("DrivingLicense"))
                            {
                                item.IDType = IdType.DrivingLicense;
                            }
                            else if (idType.Equals("Signature"))
                            {
                                item.IDType = IdType.Signature;
                            }
                            else
                            {
                                item.IDType = IdType.IdentyCard;
                            }
                            item.Rating = int.Parse(rat);
                            isNew = false;
                        }
                    }

                    if (isNew)  // ist es neu und muss hinzugefügt werden
                    {
                        if (idType.Equals("DrivingLicense")) {
                            PersonList.Add(new PersonVm(fn, ln, int.Parse(ag), id, IdType.DrivingLicense, int.Parse(rat), PersonChanged));
                        }
                        else if (idType.Equals("Signature"))
                        {
                            PersonList.Add(new PersonVm(fn, ln, int.Parse(ag), id, IdType.Signature, int.Parse(rat), PersonChanged));
                        }
                        else
                        {
                            PersonList.Add(new PersonVm(fn, ln, int.Parse(ag), id, IdType.IdentyCard, int.Parse(rat), PersonChanged));
                        }

                    }
                }); // Ende App.Current


        } // Ende Gui Updater
    }
}