using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Constant;
using GHQ.Logic.Models.Data.News;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.News;
using GHQ.Resources.Strings;
using GHQ.UI.Pages.AboutUs;
using GHQ.UI.Pages.Account;
using GHQ.UI.Pages.ContactUS;
using GHQ.UI.Pages.News;
using GHQ.UI.Pages.PhotoGallery;
using GHQ.UI.Pages.ServiceRegistration;
using Models;
using Service.Localization;
using Service.Naviagtion;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GHQ.Logic.ViewModels.Account
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(IAccountService _accountService, INewsService _newsService, INavigationService _naviagtionService)
        {
            accountService = _accountService;
            naviagtionService = _naviagtionService;
            newsService = _newsService;
        }

        #region Private Members

        IAccountService accountService;
        INavigationService naviagtionService;
        INewsService newsService;

        #endregion

        #region Properties

        private ObservableCollection<NewsData> _News;
        public ObservableCollection<NewsData> News
        {
            get { return _News; }
            set
            {
                Set(() => News, ref _News, value);
            }
        }

        private NewsData _SelectedNews;
        public NewsData SelectedNews
        {
            get { return _SelectedNews; }
            set
            {
                Set(() => SelectedNews, ref _SelectedNews, value);
            }
        }


        public bool IsLogin
        {
            get { return accountService.IsLogin; }

        }

        #endregion

        #region Private Methods

        #endregion

        #region Commands

        #region Intialize Command

        private RelayCommand _OnIntializeCommand;
        public RelayCommand OnIntializeCommand
        {
            get
            {
                if (_OnIntializeCommand == null)
                {
                    _OnIntializeCommand = new RelayCommand(Intialize);
                }
                return _OnIntializeCommand;
            }
        }
        private async void Intialize()
        {
            try
            {
                DependencyService.Get<ILocalize>().SetLocale(new System.Globalization.CultureInfo("ar-EG"));
                RaisePropertyChanged("IsLogin");
                var response = await newsService.GetNewsAsync();
                if (response != null)
                {
                    News = new ObservableCollection<NewsData>(response.GetRange(0, 2));
                }

            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

        #region OnHomeNavigation Command

        private RelayCommand<string> _OnHomeNavigationCommand;
        public RelayCommand<string> OnHomeNavigationCommand
        {
            get
            {
                if (_OnHomeNavigationCommand == null)
                {
                    _OnHomeNavigationCommand = new RelayCommand<string>(OnHomeNavigation);
                }
                return _OnHomeNavigationCommand;
            }
        }
        private async void OnHomeNavigation(string pageName)
        {
            try
            {
                if (pageName == "NewAccount")
                {
                    naviagtionService.NavigateToPage(typeof(NewAccountStep1Page));
                }
                else if (pageName == "Login")
                {
                    bool hasInternet = Locator.Default.InternetService.HasInternetAccess();
                    if (!hasInternet)
                    {
                        await Locator.Default.DialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
                        return;
                    }
                    naviagtionService.NavigateToPage(typeof(IdentityLoginPage));
                }
                else if (pageName == "Lawaa")
                {
                    naviagtionService.NavigateToPage(typeof(WalaaPage));
                }
                else if (pageName == "ContactUs")
                {
                    naviagtionService.NavigateToPage(typeof(ContactUSPage));
                }
                else if (pageName == "News")
                {
                    naviagtionService.NavigateToPage(typeof(NewsPage));
                }
                else if (pageName == "About")
                {
                    naviagtionService.NavigateToPage(typeof(AboutUSPage));
                }
                else if (pageName == "Media")
                {
                    naviagtionService.NavigateToPage(typeof(AlbumLibraryPage));
                }
                else if (pageName == "ServiceRegisteration")
                {
                    if (Constant.Constant.UseServiceRegisterationAsWebView)
                    {
                        Device.OpenUri(new Uri(ServiceConstant.BaseUrl));
                    }
                    else
                    {
                        naviagtionService.NavigateToPage(typeof(ServiceRegistrationHomePage));
                    }

                }
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

        #region NewsSelectedCommand

        private RelayCommand<NewsData> _OnNewsSelectedCommand;
        public RelayCommand<NewsData> OnNewsSelectedCommand
        {
            get
            {
                if (_OnNewsSelectedCommand == null)
                {
                    _OnNewsSelectedCommand = new RelayCommand<NewsData>(OpenNewstDetailsPage);
                }
                return _OnNewsSelectedCommand;
            }
        }

        private void OpenNewstDetailsPage(NewsData news)
        {
            newsService.SelectedNew = news;

            naviagtionService.NavigateToPage(typeof(NewsDetailsPage));
        }

        #endregion

        #endregion
    }
}
