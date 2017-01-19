using System;
using GHQ.Logic.Constant;
using GHQ.Logic.Service.Account;
using GHQ.UI.Pages.Home;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace GHQ
{
    public partial class App : Application
    {
		private static ISettings AppSettings
		{
			get { return CrossSettings.Current; }
		}

        public App()
        {
            InitializeComponent();
			if (AppSettings.Contains(Constant.UserIDKey))
			{
				
				Logic.Locator locator = new Logic.Locator();
				MainPage = new NavigationPage(new HomePage())
				{
					BarBackgroundColor = Color.FromHex("#C7e4e4"),
					BarTextColor = Color.FromHex("#333333"),
				};
				var accountService = DependencyService.Get<IAccountService>();
				accountService.GetLoggedInUser(AppSettings.GetValueOrDefault<int>(Constant.UserIDKey));
			}
			else
			{
				Logic.Locator locator = new Logic.Locator();
				MainPage = new NavigationPage(new UI.Pages.Account.LoginPage())
				{
					BarBackgroundColor = Color.FromHex("#C7e4e4"),
					BarTextColor = Color.FromHex("#333333"),
				};
			}

        

            //MainPage = new NavigationPage(new UI.Pages.Home.HomePage())
            //{
            //    BarBackgroundColor = Color.FromHex("#C7e4e4"),
            //    BarTextColor = Color.FromHex("#333333"),
            //};

        }
        public static Action<string> PostSuccessFacebookAction { get; set; }

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
