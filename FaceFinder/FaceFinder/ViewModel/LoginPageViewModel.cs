using FaceFinder.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FaceFinder.ViewModel
{
    class LoginPageViewModel:BaseViewModel
    {

        private string _username = "";
        private string _passworld = "";
 
        public LoginPageViewModel()
        {
            DisplayNameCommand = new Command(ValidationCommand, CanExecuteValue);
        }

        public string Passworld
        {
            get
            {
                return _passworld;
            }
            set
            {
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

        public HomePage Homep { get; private set; }

        async void ValidationCommand()
        {

            if (_username.Contains("name@mail.com") && _passworld.Contains("admin123"))
            {
                IsRunning = true;
                await Task.Delay(3000);
                IsRunning = false;
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                
                
               
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor revisa tu nombre de usuario o contraseña", "Ok");

            }


        }
        private bool CanExecuteValue()
        {
            return !IsBusy;
        }




    }
}
