using System;
using Xamarin.Forms;

namespace GHQ
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Logic.Locator locator = new Logic.Locator();
            MainPage = new NavigationPage(new UI.Pages.Account.LoginPage()){
            	BarBackgroundColor = Color.FromHex("#C7e4e4"),
            	BarTextColor = Color.FromHex("#333333"),
            };

            //MainPage = new NavigationPage(new UI.Pages.Medicine.MedicineAddNew())
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
