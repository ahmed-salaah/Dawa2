using GHQ.Logic;
using GHQ.Logic.ViewModels.Account;
using GHQ.UI.Pages.Home;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Account
{
	public partial class LoginPage : BasePage
	{
		readonly LoginViewModel LoginViewModel = Locator.Default.LoginViewModel;
		public LoginPage()
		{
			InitializeComponent();
			BindingContext = LoginViewModel;
			NavigationPage.SetHasNavigationBar(this, false);
			ToolbarItems.Clear();
			App.PostSuccessFacebookAction = token =>
			{
				Navigation.PushAsync(new HomePage());

			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			LoginViewModel.OnIntializeCommand.Execute(null);
		}
	}
}
