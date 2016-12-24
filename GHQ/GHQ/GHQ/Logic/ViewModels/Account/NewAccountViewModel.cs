using Exceptions;
using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.Resources.Strings;
using Models;
using Service.Dialog;
using Service.Exception;
using Service.Naviagtion;
using GHQ.Logic.Service.Lookup;

namespace GHQ.Logic.ViewModels.Account
{
    public class NewAccountViewModel : BaseViewModel
    {
        public NewAccountViewModel(INavigationService _navigationService, IAccountService _accountService, ILookupService _lookupService, IDialogService _dialogService, IExceptionService _excpetionService)
        {
            accountService = _accountService;
            navigationService = _navigationService;
            dialogService = _dialogService;
            excpetionService = _excpetionService;
            lookupService = _lookupService;
        }

        #region Private Members

        INavigationService navigationService;
        IAccountService accountService;
        IDialogService dialogService;
        IExceptionService excpetionService;
        ILookupService lookupService;
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
                ClearValidationErrors();


            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
            }
            catch (System.Exception ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, ex.Message);
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
