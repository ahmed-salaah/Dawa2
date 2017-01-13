using GalaSoft.MvvmLight.Ioc;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Lookup;
using GHQ.Logic.ViewModels.Account;
using GHQ.Logic.ViewModels.ContactUs;
using GHQ.Resources.Strings;
using Microsoft.Practices.ServiceLocation;
using Service.Database;
using Service.DatabaseService;
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
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IExceptionService, ExceptionService>();
            SimpleIoc.Default.Register<IInternetService, InternetService>();
            SimpleIoc.Default.Register<IDatabaseService, DatabaseService>();
            SimpleIoc.Default.Register<ILookupService, LookupService>();
            SimpleIoc.Default.Register<IMedicineService, MedicineService>();
        }

        private void RegisterViewModels()
        {
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<ForgetPasswordViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<NewAccountViewModel>();
            SimpleIoc.Default.Register<ContactUsViewModel>();
            SimpleIoc.Default.Register<MedicineHistoryViewModel>();
            SimpleIoc.Default.Register<MedicineScheduleViewModel>();
            SimpleIoc.Default.Register<MedicineAddNewViewModel>();


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

        public MedicineHistoryViewModel MedicineHistoryViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MedicineHistoryViewModel>();
            }
        }

        public MedicineScheduleViewModel MedicineScheduleViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MedicineScheduleViewModel>();
            }
        }


        public MedicineAddNewViewModel MedicineAddNewViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MedicineAddNewViewModel>();
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



        #endregion

    }
}
