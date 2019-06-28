using FaceFinder.Model;
using FaceFinder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriminalDetailsPage : ContentPage
    {
        public CriminalDetailsPage(PersonWanted person)
        {
            
            InitializeComponent();
            BindingContext = new HomePageViewModel(person);
        }
    }
}