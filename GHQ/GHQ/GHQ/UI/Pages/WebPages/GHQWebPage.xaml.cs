using GHQ.Logic.Constant;
using Xamarin.Forms;

namespace GHQ.UI.Pages.WepPages
{
    public partial class GHQWebPage : ContentPage
    {
        public GHQWebPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            webPage.Source = ServiceConstant.BaseUrl;
        }
    }
}
