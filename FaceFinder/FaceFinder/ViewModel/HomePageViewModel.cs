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
    //    private string _CriminalSelect = "Select a Criminal";
        private PersonWanted criminalSelected;
        public ObservableCollection<PersonWanted> PersonWanteds { get; private set; }
        public ICommand ViewDetailsCommand { get; set; }
        


        public HomePageViewModel()
        {
            GetCriminals();
            PersonWanteds = new ObservableCollection<PersonWanted>();
            ViewDetailsCommand = new Command<PersonWanted>(GetDetailsACriminal);
        }


        public PersonWanted CriminalSelected
        {
            get { return criminalSelected; }
            set {

                criminalSelected = value;
                if (criminalSelected == null)
                {
                    return;
                }
                    ViewDetailsCommand.Execute(criminalSelected);
                    CriminalSelected = null;
                
            }
        }

        //Method For move the the other page
       void GetDetailsACriminal(PersonWanted obj)
        {
           Application.Current.MainPage.Navigation.PushAsync(new CriminalDetailsPage(obj));
        }
       //Method For loader a criminals
        async void GetCriminals()
        {
            //IsBusy = true;
           await Task.Delay(3000);
            var losPillos = GetPersonWanteds();

            foreach (var item in losPillos)
            {
                PersonWanteds.Add(item);
            }
           // IsBusy = false;
        }
        //This method Create a list of Person wanted
        public ObservableCollection<PersonWanted> GetPersonWanteds()
        {
            return new ObservableCollection<PersonWanted>{

                new PersonWanted
                {
                    PhotoUrl = "logo.png",
                    Name= "Fernando Garcia",
                    NickName = "El Chapo",
                    Age = 23,
                    WantedReasons = "Es un Picapollero"
                },

                new PersonWanted
                {
                    PhotoUrl = "logo.png",
                    Name= "Angel Garcia",
                    NickName = "El ticher",
                    Age = 26,
                    WantedReasons = "Enseña como robarle a la NASA"
                }
             
            };
        }





    }
}
