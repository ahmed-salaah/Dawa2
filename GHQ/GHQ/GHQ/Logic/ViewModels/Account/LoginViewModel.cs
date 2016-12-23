using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Models.Data.Account;
using GHQ.Logic.Service.Account;
using GHQ.UI.Pages.Master;
using Models;
using Service.Naviagtion;

namespace GHQ.Logic.ViewModels.Account
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigationService _navigationService, IAccountService _accountService)
        {
            navigationService = _navigationService;
            accountService = _accountService;
            LoginData = new LoginData();
        }

        #region Private Members

        INavigationService navigationService;
        IAccountService accountService;

        #endregion

        #region Properties

        private LoginData _LoginData;
        public LoginData LoginData
        {
            get
            {
                return _LoginData;
            }
            set
            {
                Set(() => LoginData, ref _LoginData, value);
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
        private void Intialize()
        {
            try
            {
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

        #region Login Command

        private RelayCommand _OnLoginCommand;
        public RelayCommand OnLoginCommand
        {
            get
            {
                if (_OnLoginCommand == null)
                {
                    _OnLoginCommand = new RelayCommand(OnLogin);
                }
                return _OnLoginCommand;
            }
        }
        private async void OnLogin()
        {
            try
            {
                IsLoading = true;
                IsPageEnabled = false;
                ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(LoginData.Validate());

                navigationService.SetAppCurrentPage(typeof(MainPage));
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                IsLoading = false;
                IsPageEnabled = true;
            }
        }


        #endregion

        #endregion
    }
}
