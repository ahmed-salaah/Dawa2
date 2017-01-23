using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Lookup;
using GHQ.Resources.Strings;
using GHQ.UI.Pages.Medicine;
using Logic.Models.Data;
using Models;
using Service.Localization;
using Service.Naviagtion;
using System;
using Xamarin.Forms;
using GHQ.UI.Pages.Filter;
using Plugin.Settings;
using GHQ.UI.Pages.Account;

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


        private Medicine _Medicine;
        public Medicine Medicine
        {
            get { return _Medicine; }
            set
            {
                Set(() => Medicine, ref _Medicine, value);
            }
        }

        private string _NextReminder;
        public string NextReminder
        {
            get { return _NextReminder; }
            set
            {
                Set(() => NextReminder, ref _NextReminder, value);
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
                DependencyService.Get<ILocalize>().SetLocale(new System.Globalization.CultureInfo("ar-EG"));

                int userId = CrossSettings.Current.GetValueOrDefault<int>(Constant.Constant.UserIDKey);
                var user = accountService.GetUser(userId);
                if (user == null)
                {
                    naviagtionService.NavigateToPage(typeof(LoginPage));
                }

                Medicine = await medicineService.GetNextMedicine();
                var diffHour = DateTime.Now.Hour - Medicine.NextDate.Hour;
                var diffMin = DateTime.Now.Minute - Medicine.NextDate.Minute;
                NextReminder = string.Format(AppResources.Home_NextReminderDate, diffHour, diffMin);
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
                    naviagtionService.NavigateToPage(typeof(FilterPage));
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
