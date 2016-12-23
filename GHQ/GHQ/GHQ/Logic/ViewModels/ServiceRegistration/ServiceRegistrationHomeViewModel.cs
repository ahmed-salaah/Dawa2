using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Models.Account.Data;
using GHQ.Logic.Models.Data.News;
using GHQ.Logic.Models.Data.Notification;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.News;
using GHQ.Logic.Service.Notification;
using GHQ.Logic.Service.ServiceRegistration;
using GHQ.UI.Pages.News;
using GHQ.UI.Pages.Notification;
using GHQ.UI.Pages.ServiceRegistration;
using Models;
using Service.Naviagtion;
using System.Collections.ObjectModel;
using System.Linq;

namespace GHQ.Logic.ViewModels.ServiceRegistration
{
    public class ServiceRegistrationHomeViewModel : BaseViewModel
    {
        public ServiceRegistrationHomeViewModel(IAccountService _accountService, INewsService _newsService, INotificationService _notificationService, INavigationService _naviagtionService, IServiceRegistrationService _serviceRegistrationService)
        {
            accountService = _accountService;
            naviagtionService = _naviagtionService;
            newsService = _newsService;
            notificationService = _notificationService;
            serviceRegistrationService = _serviceRegistrationService;
        }

        #region Private Members

        IAccountService accountService;
        INavigationService naviagtionService;
        INewsService newsService;
        INotificationService notificationService;
        IServiceRegistrationService serviceRegistrationService;
        #endregion

        #region Properties

        private UserData _UserData;
        public UserData UserData
        {
            get { return _UserData; }
            set
            {
                Set(() => UserData, ref _UserData, value);
            }
        }

        private ObservableCollection<NotificationData> _Notifications;
        public ObservableCollection<NotificationData> Notifications
        {
            get { return _Notifications; }
            set
            {
                Set(() => Notifications, ref _Notifications, value);
            }
        }

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

        private NotificationData _SelectedNotification;
        public NotificationData SelectedNotification
        {
            get { return _SelectedNotification; }
            set
            {
                Set(() => SelectedNotification, ref _SelectedNotification, value);
            }
        }

        private bool _ShowNotifications;
        public bool ShowNotifications
        {
            get { return _ShowNotifications; }
            set
            {
                Set(() => ShowNotifications, ref _ShowNotifications, value);
            }
        }


        private bool _CanUpdateContactList;
        public bool CanUpdateContactList
        {
            get { return _CanUpdateContactList; }
            set
            {
                Set(() => CanUpdateContactList, ref _CanUpdateContactList, value);
            }
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
                CanUpdateContactList = await serviceRegistrationService.GetIsRegistered(accountService.AccessToken);
                //CanUpdateContactList = true;
                UserData = new UserData { IsRegistrationSubmitted = true }; //Hide by default
                var notificationResponse = await notificationService.GetNotificationsAsync();
                if (notificationResponse != null)
                {
                    Notifications = new ObservableCollection<NotificationData>(notificationResponse.GetRange(0, 2));
                    if (Notifications.Any())
                    {
                        ShowNotifications = true;
                    }
                }

                var newsResponse = await newsService.GetNewsAsync();
                if (newsResponse != null)
                {
                    News = new ObservableCollection<NewsData>(newsResponse.GetRange(0, 2));
                }

                UserData = await accountService.GetUserByEmiratesId(accountService.AccessToken);
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
        private void OnHomeNavigation(string pageName)
        {
            try
            {
                if (pageName == "ServiceRegistration")
                {
                    naviagtionService.NavigateToPage(typeof(ServiceRegistrationPage));
                }
                else if (pageName == "Notifications")
                {
                    naviagtionService.NavigateToPage(typeof(NotificationsPage));
                }
                else if (pageName == "News")
                {
                    naviagtionService.NavigateToPage(typeof(NewsPage));
                }
                else if (pageName == "UpdateContact")
                {
                    naviagtionService.NavigateToPage(typeof(UpdateContactPage));
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
            newsService.SelectedNew = SelectedNews;
            naviagtionService.NavigateToPage(typeof(NewsDetailsPage));
        }

        #endregion

        #region NotoficationSelectedCommand

        private RelayCommand<NotificationData> _OnNotoficationSelectedCommand;
        public RelayCommand<NotificationData> OnNotoficationSelectedCommand
        {
            get
            {
                if (_OnNotoficationSelectedCommand == null)
                {
                    _OnNotoficationSelectedCommand = new RelayCommand<NotificationData>(OnNotoficationSelected);
                }
                return _OnNotoficationSelectedCommand;
            }
        }

        private void OnNotoficationSelected(NotificationData notification)
        {
            notificationService.SelectedNotification = SelectedNotification;
            naviagtionService.NavigateToPage(typeof(NewsDetailsPage));
        }

        #endregion



        #endregion
    }
}
