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
        //Propeties Binding whith the View Mode

        private string _username;
        private string _passworld;
        public LoginPageViewModel()
        {

            DisplayNameCommand = new Command(ValidationCommand);

        }

        public string Passworld
        {
            set {
                _passworld = value;
            }
        }

        public string Username
        {
            set
            {
                    _username = value;
            }
        }

        async void ValidationCommand()
        {
            if (_username.Contains("name@mail.com") && _passworld.Contains("admin123"))
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
