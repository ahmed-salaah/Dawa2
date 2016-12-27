using GHQ.Logic;
using GHQ.UI.Pages.Home;
using System;
using Xamarin.Forms;

namespace GHQ.UI.Pages
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            NavigationPage.SetBackButtonTitle(this, "");
            Action action = () =>
            {
                Locator.Default.NavigationService.NavigateToPage(typeof(HomePage));
            };

            ToolbarItems.Add( new ToolbarItem("", "profile_ico.png", action, ToolbarItemOrder.Primary));

        }
    }
}
