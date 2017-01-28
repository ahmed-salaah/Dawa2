using System;
using GHQ.Logic.Constant;
using GHQ.UI.Pages.Home;
using Plugin.Settings;
using Xamarin.Forms;

namespace GHQ
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Logic.Locator locator = new Logic.Locator();

            int userId = CrossSettings.Current.GetValueOrDefault<int>(Constant.UserIDKey);
            if (Device.OS == TargetPlatform.Windows)
            {
                MainPage = new NavigationPage(new HomePage())
                {
                    BarBackgroundColor = Color.FromHex("#C7e4e4"),
                    BarTextColor = Color.FromHex("#333333"),
                };
            }
            else
            {
                if (CrossSettings.Current.Contains(Constant.UserIDKey) && userId > 0)
                {
                    MainPage = new NavigationPage(new HomePage())
                    {
                        BarBackgroundColor = Color.FromHex("#C7e4e4"),
                        BarTextColor = Color.FromHex("#333333"),
                    };
                }
                else
                {
                    MainPage = new NavigationPage(new UI.Pages.Account.LoginPage())
                    {
                        BarBackgroundColor = Color.FromHex("#C7e4e4"),
                        BarTextColor = Color.FromHex("#333333"),
                    };
                }
            }
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
