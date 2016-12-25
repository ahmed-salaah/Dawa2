using Xamarin.Forms;

namespace GHQ
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Logic.Locator locator = new Logic.Locator();
            //MainPage = new NavigationPage(new UI.Pages.Account.LoginPage());
            MainPage = new NavigationPage(new UI.Pages.Medicine.MedicineAddNew());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            try
            {
            }
            catch (System.Exception)
            {
            }

        }

        protected async override void OnResume()
        {
        }
    }
}
