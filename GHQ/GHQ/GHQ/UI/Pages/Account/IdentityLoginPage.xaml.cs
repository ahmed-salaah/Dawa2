using GHQ.Logic;
using GHQ.Logic.Constant;
using GHQ.UI.Pages.Master;
using Service;
using System;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Account
{
    public partial class IdentityLoginPage : BasePage
    {
        //LINK:https://github.com/IdentityServer/IdentityServer3.Samples/blob/master/source/Xamarin/Forms/OIDCSample.Client/XamarinFormsOIDCSample.Client/Views/LoginView.xaml
        //LINK:https://github.com/IdentityServer/IdentityServer3.Samples/blob/master/source/Xamarin/Forms/OIDCSample.Client/XamarinFormsOIDCSample.Client/Views/LoginView.xaml.cs
        public IdentityLoginPage()
        {
            InitializeComponent();
        }
        bool LoginStarts = false;
        private void WvLogin_Navigating(object sender, WebNavigatingEventArgs e)
        {
            //https://ghq-identityserver.linkdev.com/core/login?signin=1ba57db4614eda63b37d2d68ea506119
            if (e.Url.Contains("login?signin") && LoginStarts == false)
            {
                LoginStarts = true;
                StartFlow("id_token token", "openid profile email GHQ.Backend");
            }
            else if (e.Url.Contains("https://ghq-xamarin/redirect"))
            {
                wvLogin.IsVisible = false;
                string[] param1 = e.Url.Split('&');
                string[] param2 = param1[1].Split(new string[] { "access_token=" }, StringSplitOptions.None);
                string decodedTokens = param2[1];

                Locator.Default.AccountService.AccessToken = decodedTokens;
                Locator.Default.NotificationService.RegisterUserDevice(PushToken.DeviceId);
                Locator.Default.NavigationService.SetAppCurrentPage(typeof(MainPage));
            }
            else if (e.Url.Contains("login"))
            {
                loading.IsRunning = false;
            }
        }


        public void StartFlow(string responseType, string scope)
        {
            string client_id = "BA4DA27A-C700-4AED-9134-EBC64D6C014B";
            string authorizeUri = ServiceConstant.AuthorizeUrl + string.Format("?client_id={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}&nonce={5}", client_id, "https://GHQ-xamarin/redirect", responseType, scope, Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"));
            authorizeUri = authorizeUri.Replace(" ", "%20");
            wvLogin.Source = authorizeUri;

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            wvLogin.Source = ServiceConstant.LogoutUrl;
            //StartFlow("id_token token", "openid profile email GHQ.Backend");

        }
    }
}
