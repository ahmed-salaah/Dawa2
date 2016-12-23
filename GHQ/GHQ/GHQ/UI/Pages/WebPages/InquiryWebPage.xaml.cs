using Xamarin.Forms;

namespace GHQ.UI.Pages.WepPages
{
    public partial class InquiryWebPage : ContentPage
    {
        public InquiryWebPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            webPage.Source = "https://www.uaensr.ae/Pages/%D8%A7%D8%AA%D8%B5%D9%84-%D8%A8%D9%86%D8%A7.aspx";
        }
    }
}
