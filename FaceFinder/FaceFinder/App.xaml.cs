using Xamarin.Forms;



namespace FaceFinder
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        //https://devblogs.microsoft.com/wp-content/uploads/sites/44/2019/03/data-binding@2x1.png
            MainPage = new ModelView.LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
