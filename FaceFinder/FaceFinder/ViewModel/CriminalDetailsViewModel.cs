using FaceFinder.Model;
using FaceFinder.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceFinder.ViewModel
{
    public class CriminalDetailsViewModel : BaseViewModel
    {
        public PersonWanted Criminal { get; set; }
        public CriminalDetailsViewModel(PersonWanted person)
        {
            Criminal = person;
        }
         public string PhotoUrl {
            get {
                    return Criminal.PhotoUrl;
                }
        }
        public string Name
        {
            get { return Criminal.Name; }
        }
        public string NickName { get { return Criminal.NickName; } }
        public string Age { get { return Criminal.Age.ToString(); } }
        public string WantedReasons { get { return Criminal.WantedReasons; } }



    }
}
