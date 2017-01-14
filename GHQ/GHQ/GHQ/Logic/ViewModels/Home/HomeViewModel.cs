using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Lookup;
using GHQ.UI.Pages.Medicine;
using Models;
using Service.Localization;
using Service.Naviagtion;

using Xamarin.Forms;

namespace GHQ.Logic.ViewModels.Account
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(IAccountService _accountService, INavigationService _naviagtionService, IMedicineService _medicineService)
        {
            accountService = _accountService;
            naviagtionService = _naviagtionService;
            medicineService = _medicineService;
        }

        #region Private Members

        IAccountService accountService;
        INavigationService naviagtionService;
        IMedicineService medicineService;
        #endregion

        #region Properties



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
                if (pageName == "History")
                {
                    naviagtionService.NavigateToPage(typeof(MedicineHistory));
                }
                else if (pageName == "Schedule")
                {
                    naviagtionService.NavigateToPage(typeof(MedicineSchedule));
                }
                else if (pageName == "Add")
                {
                    medicineService.SelectedMedicine = null;
                    naviagtionService.NavigateToPage(typeof(MedicineAddNew));
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

        #endregion
    }
}
