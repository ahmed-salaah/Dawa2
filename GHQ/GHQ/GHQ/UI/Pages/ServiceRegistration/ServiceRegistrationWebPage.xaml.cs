using GHQ.Logic.Constant;
using Xamarin.Forms;

namespace GHQ.UI.Pages.ServiceRegistration
{
    public partial class ServiceRegistrationWebPage : ContentPage
    {
        public ServiceRegistrationWebPage()
        {
            InitializeComponent();
        }
        private void WvLogin_Navigating(object sender, WebNavigatingEventArgs e)
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            wvLogin.Source = ServiceConstant.BaseUrl;
        }
    }
}
