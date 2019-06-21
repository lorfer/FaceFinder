using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace FaceFinder.ViewsModel
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //Propeties Binding whith the View Mode

        private string _username;
        private string _passworld;

        public string Passworld
        {
            get { return _passworld; }
            set { _passworld = value; }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                }

            }
        }
        private bool _IsEnabled;

        public bool IsEnabled
        {
            get { return !_IsEnabled; }
            set {
                if (_IsEnabled != value)
                {
                    OnPropertyChanged("IsNotBusy");
                }
            }
        }



        public ICommand DisplayNameCommand { get; private set; }

        public LoginPageViewModel()
        {

            DisplayNameCommand = new Command(ValidationCommand);

        }

         async void ValidationCommand()
        {
            if (_username.Contains("name@mail.com") || _passworld.Contains("admin123"))
            {
                await Task.Delay(3000);
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                
            }
            else
            {
                
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
