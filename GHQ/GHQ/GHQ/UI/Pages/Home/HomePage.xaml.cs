using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;
using GHQ.UI.Pages.Account;
using System;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Home
{
    public partial class HomePage : BasePage
    {
        readonly HomeViewModel HomeViewModel = Locator.Default.HomeViewModel;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = HomeViewModel;
            NavigationPage.SetHasNavigationBar(this, true);
            Action action = () =>
            {
                Locator.Default.NavigationService.NavigateToPage(typeof(NewAccountStep1Page));
            };
            ToolbarItems.Add(
            new ToolbarItem("", "profile_ico.png", action, ToolbarItemOrder.Primary));

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HomeViewModel.OnIntializeCommand.Execute(null);
        }

    }
}
