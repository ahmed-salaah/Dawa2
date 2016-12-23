using GHQ.Logic;
using Xamarin.Forms;

namespace GHQ
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Logic.Locator locator = new Logic.Locator();
            bool IsLogIn = true;
            if (IsLogIn)
            {
                MainPage = new GHQ.UI.Pages.Master.MainPage();

            }
            else
            {
                MainPage = new NavigationPage(new UI.Pages.Account.LoginPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            try
            {
                // Handle when your app sleeps
                if (!Locator.Default.NavigationService.IsExternalAppOpen)
                {
                    if (Locator.Default.AccountService != null)
                        Locator.Default.AccountService.AccessToken = "";
                }
            }
            catch (System.Exception)
            {
            }

        }

        protected async override void OnResume()
        {
            //try
            //{
            //    // Handle when your app resumes
            //    if (!Locator.Default.NavigationService.IsExternalAppOpen)
            //    {
            //         Locator.Default.NavigationService.SetAppCurrentPage(typeof(MainPage));
            //    }
            //}
            //catch (System.Exception)
            //{

            //}
        }
    }
}
