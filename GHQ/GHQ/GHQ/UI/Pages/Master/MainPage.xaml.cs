using GHQ.Logic;
using GHQ.Logic.Constant;
using GHQ.Resources.Strings;
using GHQ.UI.Pages.Account;
using GHQ.UI.Pages.Home;
using GHQ.UI.Pages.Inquiry;
using GHQ.UI.Pages.ServiceRegistration;
using GHQ.UI.Pages.WepPages;
using Models;
using System;
using Xamarin.Forms;

namespace GHQ.UI.Pages.Master
{
    public partial class MainPage : MasterDetailPage
    {
        MasterPage masterPage = new MasterPage();

        public MainPage()
        {
            InitializeComponent();

            Master = masterPage;
            masterPage.ListView.ItemSelected += OnItemSelected;
            Detail = new NavigationPage(new HomePage())
            {
                BarBackgroundColor = Color.FromRgb(174, 128, 58),
                BarTextColor = Color.White

            };
            if (Device.OS == TargetPlatform.Windows)
            {
                Master.Icon = "Assets/home-icon.png";
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as SideMenuItem;
            if (item != null)
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                if (page is HomePage)
                {
                    Locator.Default.NavigationService.SetAppCurrentPage(typeof(MainPage));
                }

                else
                {
                    if (page is LogoutPage || page is IdentityLoginPage || page is InquiryWebPage || page is GHQWebPage || page is ServiceRegistrationWebPage)
                    {
                        bool hasInternet = Locator.Default.InternetService.HasInternetAccess();
                        if (!hasInternet)
                        {
                            await Locator.Default.DialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
                            return;
                        }
                        if (page is ServiceRegistrationWebPage)
                        {
                            Device.OpenUri(new Uri(ServiceConstant.BaseUrl));
                            return;
                        }
                        else if (page is GHQWebPage)
                        {
                            Device.OpenUri(new Uri(ServiceConstant.BaseUrl));
                            return;
                        }
                        else if (page is InquiryWebPage)
                        {
                            Device.OpenUri(new Uri(ServiceConstant.InquiryUrl));
                            return;
                        }
                    }
                    Type pageType = page.GetType();
                    Locator.Default.NavigationService.NavigateToPage(pageType);
                }

                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}