using Xamarin.Forms;

namespace GHQ.UI.Pages
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            NavigationPage.SetBackButtonTitle(this, "");
        }
    }
}
