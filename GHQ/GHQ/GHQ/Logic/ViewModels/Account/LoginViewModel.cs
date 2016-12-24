using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using Models;
using Service.Localization;
using Service.Naviagtion;
using Xamarin.Forms;

namespace GHQ.Logic.ViewModels.Account
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigationService _navigationService, IAccountService _accountService)
        {
            navigationService = _navigationService;
            accountService = _accountService;
        }

        #region Private Members

        INavigationService navigationService;
        IAccountService accountService;

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
        private void Intialize()
        {
            try
            {
                DependencyService.Get<ILocalize>().SetLocale(new System.Globalization.CultureInfo("ar-EG"));

                //IsLoading = true;
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                IsLoading = false;
            }
        }

        #endregion

        #endregion
    }
}
