using GHQ.Logic;
using GHQ.Logic.Constant;
using GHQ.UI.Pages.Master;
using Service;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Account
{
    public partial class LogoutPage :BasePage
    {
        public LogoutPage()
        {
            InitializeComponent();
        }

        private void WvLogin_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.Contains("login"))
            {
                Locator.Default.NotificationService.UnRegisterUserDevice(PushToken.DeviceId);
                Locator.Default.AccountService.AccessToken = "";
                Locator.Default.NavigationService.SetAppCurrentPage(typeof(MainPage));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            wvLogin.Source = ServiceConstant.LogoutUrl;
        }
    }
}
