﻿using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Text;


namespace FaceFinder.Views
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DisplayNameCommand { get; private set; }

        private string _username="";
        private string _passworld="";
        private bool _isrunning;

        public BaseViewModel()
        {
            DisplayNameCommand = new Command(ValidationCommand, CanExecuteValue);
        }

        public bool IsRunning
        {
            get { return _isrunning; }
            set {
                 if (_isrunning != value)
                 {
                    _isrunning = value;
                    ((Command)DisplayNameCommand).ChangeCanExecute();
                    }
                }
        }
        
         private bool CanExecuteValue()
        {
            return !_isrunning;
        }
       

        public string Passworld
        {
            get
            {
                return _passworld;
            }
            set {
                _passworld = value;
                OnPropertyChanged(nameof(Passworld));
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

       
        async void ValidationCommand()
        {
           
            if (_username.Contains("name@mail.com") && _passworld.Contains("admin123"))
            {  
                 _isrunning = true;
                await Task.Delay(3000);
                _isrunning = false;
                //await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
               // await Application.Current.MainPage.Navigation.PopAsync();
               
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor revisa tu nombre de usuario o contraseña", "Ok");

            }


        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
