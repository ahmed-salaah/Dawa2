using GalaSoft.MvvmLight.Ioc;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Inquiry;
using GHQ.Logic.Service.Lookup;
using GHQ.Logic.Service.Map;
using GHQ.Logic.Service.News;
using GHQ.Logic.Service.Notification;
using GHQ.Logic.Service.PhotoGallery;
using GHQ.Logic.Service.ServiceRegistration;
using GHQ.Logic.ViewModels.Account;
using GHQ.Logic.ViewModels.ContactUs;
using GHQ.Logic.ViewModels.Inquiry;
using GHQ.Logic.ViewModels.Map;
using GHQ.Logic.ViewModels.News;
using GHQ.Logic.ViewModels.Notification;
using GHQ.Logic.ViewModels.PhotoGallery;
using GHQ.Logic.ViewModels.ServiceRegistration;
using GHQ.Resources.Strings;
using Microsoft.Practices.ServiceLocation;
using Service.Dialog;
using Service.Exception;
using Service.Internet;
using Service.Naviagtion;
using Service.Network;
using Service.SideMenu;

namespace GHQ.Logic
{
    public class Locator
    {
        public static Locator Default { set; get; }

        public Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            RegisterService();
            RegisterViewModels();
            Default = this;
            InternetService.NoInternetMessage = AppResources.Error_NoInternet;
        }

        #region Methods

        private void RegisterService()
        {
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<INetworkService, NetworkService>();
            SimpleIoc.Default.Register<IAccountService, AccountService>();
            SimpleIoc.Default.Register<INewsService, NewsService>();
            SimpleIoc.Default.Register<IPhotoGalleryService, PhotoGalleryService>();
            SimpleIoc.Default.Register<IServiceRegistrationService, ServiceRegistrationService>();
            SimpleIoc.Default.Register<IInquiryService, InquiryService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IExceptionService, ExceptionService>();
            SimpleIoc.Default.Register<IInternetService, InternetService>();
            SimpleIoc.Default.Register<ILookupService, LookupService>();
            SimpleIoc.Default.Register<IMapService, MapService>();
            SimpleIoc.Default.Register<INotificationService, NotificationService>();
            SimpleIoc.Default.Register<ISideMenuService, SideMenuService>();
        }

        private void RegisterViewModels()
        {
            SimpleIoc.Default.Register<ServiceRegistrationViewModel>();
            SimpleIoc.Default.Register<ServiceRegistrationHomeViewModel>();
            SimpleIoc.Default.Register<UpdateContactViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<ForgetPasswordViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<NewsViewModel>();
            SimpleIoc.Default.Register<NewsDetailsViewModel>();
            SimpleIoc.Default.Register<InquiryViewModel>();
            SimpleIoc.Default.Register<PhotoGalleryViewModel>();
            SimpleIoc.Default.Register<NewAccountViewModel>();
            SimpleIoc.Default.Register<PhotoAlbumViewMiodel>();
            SimpleIoc.Default.Register<PhotoGalleryViewModel>();
            SimpleIoc.Default.Register<PhotoDetailsViewModel>();
            SimpleIoc.Default.Register<MapViewModel>();
            SimpleIoc.Default.Register<ContactUsViewModel>();
            SimpleIoc.Default.Register<NotificationViewModel>();
        }

        #endregion

        #region Services Properties

        public IDialogService DialogService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDialogService>();
            }
        }
        public IInternetService InternetService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IInternetService>();
            }
        }

        public INavigationService NavigationService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        public INotificationService NotificationService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<INotificationService>();
            }
        }

        public IAccountService AccountService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IAccountService>();
            }
        }

        public ISideMenuService SideMenuService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ISideMenuService>();
            }
        }

        #endregion


        #region View Model Properties

        #region Home

        public HomeViewModel HomeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        #endregion

        #region Account

        public LoginViewModel LoginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public NewAccountViewModel NewAccountViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NewAccountViewModel>();
            }
        }

        public ForgetPasswordViewModel ForgetPasswordViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ForgetPasswordViewModel>();
            }
        }

        #endregion

        #region Registration


        public UpdateContactViewModel UpdateContactViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UpdateContactViewModel>();
            }
        }


        public ServiceRegistrationHomeViewModel ServiceRegistrationHomeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ServiceRegistrationHomeViewModel>();
            }
        }

        public ServiceRegistrationViewModel ServiceRegistrationViewModel
        {
            get
            {
                //Workaround: to fix crash on second time, it must be enhanced
                return new ServiceRegistrationViewModel(ServiceLocator.Current.GetInstance<INavigationService>(), ServiceLocator.Current.GetInstance<IServiceRegistrationService>(),
                    ServiceLocator.Current.GetInstance<ILookupService>(), ServiceLocator.Current.GetInstance<IDialogService>(), ServiceLocator.Current.GetInstance<IExceptionService>(), ServiceLocator.Current.GetInstance<IAccountService>());
                //return ServiceLocator.Current.GetInstance<ServiceRegistrationViewModel>();
            }
        }

        #endregion

        #region News

        public NewsViewModel NewsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NewsViewModel>();
            }
        }

        #endregion

        #region NewsDetails

        public NewsDetailsViewModel NewsDetailsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NewsDetailsViewModel>();
            }
        }

        #endregion

        #region Inquiry

        public InquiryViewModel InquiryViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InquiryViewModel>();
            }
        }

        #endregion

        #region PhotoGallery

        public PhotoAlbumViewMiodel PhotoAlbumViewMiodel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PhotoAlbumViewMiodel>();
            }
        }
        public PhotoGalleryViewModel PhotoGalleryViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PhotoGalleryViewModel>();
            }
        }

        public PhotoDetailsViewModel PhotoDetailsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PhotoDetailsViewModel>();
            }
        }

        #endregion

        #region Map

        public MapViewModel MapViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MapViewModel>();
            }
        }
        #endregion

        #region ContactUs

        public ContactUsViewModel ContactUsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ContactUsViewModel>();
            }
        }
        #endregion

        #region News

        public NotificationViewModel NotificationViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NotificationViewModel>();
            }
        }

        #endregion

        #endregion
    }
}
