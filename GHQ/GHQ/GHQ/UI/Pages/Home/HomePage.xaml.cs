using GHQ.Logic;
using GHQ.Logic.Constant;
using GHQ.Logic.ViewModels.Account;
using GHQ.UI.Pages.Notification;
using Service;
using System;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Home
{
    public partial class HomePage : ContentPage
    {
		void Handle_Tapped(object sender, System.EventArgs e)
		{
			HomeViewModel.OnHomeNavigationCommand.Execute("News");
		}

		readonly HomeViewModel HomeViewModel = Locator.Default.HomeViewModel;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = HomeViewModel;

            Action action = () =>
            {
                Locator.Default.NavigationService.NavigateToPage(typeof(NotificationsPage));
            };
            if (Locator.Default.AccountService.IsLogin && !Constant.UseServiceRegisterationAsWebView)
            {
                ToolbarItems.Add(
            new ToolbarItem("", "notification.png", action, ToolbarItemOrder.Primary));
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HomeViewModel.OnIntializeCommand.Execute(null);
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            HomeViewModel.OnNewsSelectedCommand.Execute(HomeViewModel.SelectedNews);
        }

        protected override bool OnBackButtonPressed()
        {
            //WorkAround
            //https://forums.xamarin.com/discussion/83864/java-lang-illegalstateexception-activity-has-been-destroyed-when-using-admob
            if (Device.OS == TargetPlatform.Android)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //var result = await this.DisplayAlert("Warning", "Sure to close the app?", "Yes", "No");
                    //if (result)
                    DependencyService.Get<IAndroidMethods>().CloseApp();
                });
            }

            return true;
        }

    }
}
