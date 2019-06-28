using FaceFinder.Model;
using FaceFinder.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FaceFinder.ViewModel
{
    class HomePageViewModel:BaseViewModel
    {
        //This Variable send a other Page the OBj
        private INavigation navigation;
        private string _CriminalSelect = "Select a Criminal";
        private PersonWanted _personWanted;
        public ObservableCollection<PersonWanted> PersonWanteds { get; private set; }

        public PersonWanted PersonWanted
        {
            get { return _personWanted; }
            set {
                if (_personWanted == null)
                {
                    return;
                }
                ViewDetailsCommand.Execute(nameof(PersonWanted));
                _personWanted = null;
                
            }
        }



        public ICommand ViewDetailsCommand { get; private set ; }
        public IObservable<PersonWanted> criminals;

        public HomePageViewModel(PersonWanted criminal)
        {
            ViewDetailsCommand = new Command<PersonWanted>(GetDetailsACriminal);
            PersonWanteds = new ObservableCollection<PersonWanted>();
        }

        //Method For move the the other page
        void GetDetailsACriminal(PersonWanted criminal)
        {
            navigation.PushAsync(new CriminalDetailsPage(criminal));
        }

        public string CriminalSelectd
        {
            get { return _CriminalSelect; }
            set {
                if (_CriminalSelect != value)
                {
                    _CriminalSelect = value;
                    OnPropertyChanged(nameof(CriminalSelectd));
                }
            }
        }


       async void GetCriminal()
        {
            IsBusy = true;
            await Task.Delay(3000);
            var losPillos = GetPersonWanteds();

            foreach (var item in losPillos)
            {
                PersonWanteds.Add(item);
            }
            IsBusy = false;
        }
        //This method Create a list of Person wanted
       public ObservableCollection<PersonWanted> GetPersonWanteds()
        {
            return new ObservableCollection<PersonWanted>{

                new PersonWanted
                {
                    Name= "Fernando Garcia",
                    NickName = "El Chapo",
                    Age = 23,
                    WantedReasons = "Es un Picapollero"
                },

                new PersonWanted
                {
                    Name= "Angel Garcia",
                    NickName = "El ticher",
                    Age = 26,
                    WantedReasons = "Enseña como robarle a la NASA"
                }
            };
        }





    }
}
