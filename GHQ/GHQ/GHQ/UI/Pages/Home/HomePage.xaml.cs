using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;
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
			NavigationPage.SetHasNavigationBar(this, false);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HomeViewModel.OnIntializeCommand.Execute(null);
        }

    }
}
