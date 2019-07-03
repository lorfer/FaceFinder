using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Text;


namespace FaceFinder.Views
{
  public  class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation navegacion;
        public ICommand DisplayNameCommand { get;  set; }
        
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set {
                 if (_IsBusy != value)
                 {
                    _IsBusy = value;
                    ((Command)DisplayNameCommand).ChangeCanExecute();
                    }
                }
        }

        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    OnPropertyChanged(nameof(IsRunning));
                }
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
