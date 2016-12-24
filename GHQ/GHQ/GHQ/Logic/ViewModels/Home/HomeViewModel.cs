using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using Models;
using Service.Localization;
using Service.Naviagtion;

using Xamarin.Forms;

namespace GHQ.Logic.ViewModels.Account
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(IAccountService _accountService, INavigationService _naviagtionService)
        {
            accountService = _accountService;
            naviagtionService = _naviagtionService;
        }

        #region Private Members

        IAccountService accountService;
        INavigationService naviagtionService;

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

        #endregion
    }
}
