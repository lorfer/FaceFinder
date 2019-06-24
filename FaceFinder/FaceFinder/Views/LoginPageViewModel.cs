using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace FaceFinder.Views
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DisplayNameCommand { get; private set; }

        private string _username;
        private string _passworld;

        private bool _isBusy;

       

        public LoginPageViewModel()
        {

            DisplayNameCommand = new Command(ValidationCommand, CanExecuteValue);

        }

         private bool CanExecuteValue()
        {
            return !IsBusy;
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    ((Command)DisplayNameCommand).ChangeCanExecute();
                }
                    
                }
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
            
            await Task.Delay(3000);
            if (_username.Contains("name@mail.com") && _passworld.Contains("admin123"))
            {
                // await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                 Application.Current.MainPage.Navigation.InsertPageBefore(new HomePage(), new ModelView.LoginPage());
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor revisA \n tu nombre de usuario o contraseña", "Ok");
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
