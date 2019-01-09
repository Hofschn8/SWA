using Example1.Com;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Example1.ViewModel
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
        bool isConnected = false;
        private string visibility;
        Communication com;

        private SolidColorBrush toggle1Color;
        private SolidColorBrush toggle2Color;
        private SolidColorBrush toggle3Color;
        private SolidColorBrush toggle4Color;

        public SolidColorBrush Toggle4Color
        {
            get { return toggle4Color; }
            set { toggle4Color = value; RaisePropertyChanged(); }
        }

        public SolidColorBrush Toggle3Color
        {
            get { return toggle3Color; }
            set { toggle3Color = value; RaisePropertyChanged(); }
        }

        public SolidColorBrush Toggle2Color
        {
            get { return toggle2Color; }
            set { toggle2Color = value; RaisePropertyChanged(); }
        }

        public SolidColorBrush Toggle1Color
        {
            get { return toggle1Color; }
            set { toggle1Color = value; RaisePropertyChanged(); }
        }


        public string Visibility
        {
            get { return visibility; }
            set { visibility = value; RaisePropertyChanged(); }
        }


        public ObservableCollection<ToggleItem> AllToggles { get; set; }
        public RelayCommand Toggle1ClickedCmd { get; set; }
        public RelayCommand Toggle2ClickedCmd { get; set; }
        public RelayCommand Toggle3ClickedCmd { get; set; }
        public RelayCommand Toggle4ClickedCmd { get; set; }
        public RelayCommand ListenBtnClickedCmd { get; set; }
        public RelayCommand ConnectBtnClickedCmd { get; set; }


        public MainViewModel()
        {
            Visibility = "Visible";
            toggle1Color = new SolidColorBrush(Colors.Red);
            toggle2Color = new SolidColorBrush(Colors.Red);
            toggle3Color = new SolidColorBrush(Colors.Red);
            toggle4Color = new SolidColorBrush(Colors.Red);
            AllToggles = new ObservableCollection<ToggleItem>();
            ConnectBtnClickedCmd = new RelayCommand(ConnectBtnClicked, CanExecConnectBtnClicked);
            ListenBtnClickedCmd = new RelayCommand(ListenBtnClicked, CanExecListenClicked);
            Toggle1ClickedCmd = new RelayCommand(Toggle1BtnClicked, CanExecToggle1);
            Toggle2ClickedCmd = new RelayCommand(Toggle2BtnClicked, CanExecToggle2);
            Toggle3ClickedCmd = new RelayCommand(Toggle3BtnClicked, CanExecToggle3);
            Toggle4ClickedCmd = new RelayCommand(Toggle4BtnClicked, CanExecToggle4);
        }

        private bool CanExecToggle4()
        {
            return isConnected;
        }

        private void Toggle4BtnClicked()
        {
            string tmp = "";
            if (toggle4Color.Color == Colors.Red)
            {
                toggle4Color = new SolidColorBrush(Colors.Green);
                RaisePropertyChanged("toggle4Color");
                AllToggles.Add(new ToggleItem("Toggle 4", "green"));
                tmp = "Toggle 4|green";
            }
            else
            {
                toggle4Color = new SolidColorBrush(Colors.Red);
                RaisePropertyChanged("toggle4Color");
                AllToggles.Add(new ToggleItem("Toggle 4", "red"));
                tmp = "Toggle 4|red";
            }

            com.Send(tmp);
        }

        private bool CanExecToggle3()
            {
                return isConnected;
            }

            private void Toggle3BtnClicked()
            {
                string tmp = "";
                if (toggle3Color.Color == Colors.Red)
                {
                    toggle3Color = new SolidColorBrush(Colors.Green);
                    RaisePropertyChanged("toggle3Color");
                    AllToggles.Add(new ToggleItem("Toggle 3", "green"));
                    tmp = "Toggle 3|green";
                }
                else
                {
                    toggle3Color = new SolidColorBrush(Colors.Red);
                    RaisePropertyChanged("toggle3Color");
                    AllToggles.Add(new ToggleItem("Toggle 3", "red"));
                    tmp = "Toggle 3|red";
                }

                com.Send(tmp);
            }

            private void Toggle2BtnClicked()
            {
                string tmp = "";
                if (toggle2Color.Color == Colors.Red)
                {
                    toggle2Color = new SolidColorBrush(Colors.Green);
                    RaisePropertyChanged("toggle2Color");
                    AllToggles.Add(new ToggleItem("Toggle 2", "green"));
                    tmp = "Toggle 2|green";
                }
                else
                {
                    toggle2Color = new SolidColorBrush(Colors.Red);
                    RaisePropertyChanged("toggle2Color");
                    AllToggles.Add(new ToggleItem("Toggle 2", "red"));
                    tmp = "Toggle 2|red";
                }

                com.Send(tmp);
            }

            private bool CanExecToggle2()
            {
                return isConnected;
            }

            private bool CanExecToggle1()
            {
                return isConnected;
            }

            private void Toggle1BtnClicked()
            {
                string tmp = "";
                if (toggle1Color.Color == Colors.Red)
                {
                    toggle1Color = new SolidColorBrush(Colors.Green);
                    RaisePropertyChanged("toggle1Color");
                    AllToggles.Add(new ToggleItem("Toggle 1", "green"));
                    tmp = "Toggle 1|green";
                }
                else
                {
                    toggle1Color = new SolidColorBrush(Colors.Red);
                    RaisePropertyChanged("toggle1Color");
                    AllToggles.Add(new ToggleItem("Toggle 1", "red"));
                    tmp = "Toggle 1|red";
                }

                com.Send(tmp);
            }

            private void ListenBtnClicked()
            {
                isConnected = true;
                com = new Communication(true, "127.0.0.1", 10100, null);
            }

            private bool CanExecListenClicked()
            {
                return !isConnected;
            }

            private bool CanExecConnectBtnClicked()
            {
                return !isConnected;
            }

            private void ConnectBtnClicked()
            {
                isConnected = true;
                Visibility = "Hidden";
                com = new Communication(false, "127.0.0.1", 10100, NewMessageReceived);
            }

            private void NewMessageReceived(string message)
            {
                App.Current.Dispatcher.Invoke(
                    () =>
                    {
                        string[] tmp = message.Split('|');
                        AllToggles.Add(new ToggleItem(tmp[0], tmp[1]));
                    }
                    );
            }
        }
    
}