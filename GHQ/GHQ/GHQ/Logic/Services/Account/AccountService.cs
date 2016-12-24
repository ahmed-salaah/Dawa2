using Exceptions;
using Service.Dialog;
using Service.Internet;
using Service.Naviagtion;
using Service.Network;


namespace GHQ.Logic.Service.Account
{
    public class AccountService : IAccountService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        INavigationService navigationService;
        IDialogService dialogService;
        #endregion

        public AccountService(INetworkService _networkService, IInternetService _internetService, INavigationService _navigationService, IDialogService _dialogService)
        {
            networkService = _networkService;
            internetService = _internetService;
            navigationService = _navigationService;
            dialogService = _dialogService;
        }

        public void HandleUnAuthorizedException(UnAuthorizedException ex)
        {

        }


    }
}
