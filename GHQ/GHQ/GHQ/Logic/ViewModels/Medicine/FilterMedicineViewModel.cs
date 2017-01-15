
using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Lookup;

using Logic.Models.Data;
using Models;
using Service.Dialog;
using Service.Exception;

using Service.Naviagtion;


namespace GHQ.Logic.ViewModels.Account
{
    public class FilterMedicineViewModel : BaseViewModel
    {
        public FilterMedicineViewModel(IAccountService _accountService, IMedicineService _medicineService, INavigationService _naviagtionService, IDialogService _dialogService, IExceptionService _exceptionService)
        {
            accountService = _accountService;
            navigationService = _naviagtionService;
            medicineService = _medicineService;
            exceptionService = _exceptionService;
            dialogService = _dialogService;
        }

        #region Private Members

        IAccountService accountService;
        INavigationService navigationService;
        IMedicineService medicineService;
        IExceptionService exceptionService;
        IDialogService dialogService;
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
                
                if (navigationService.IsExternalAppOpen)
                    return;
               
                
                    Medicine = new Medicine();
                    
             
        
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

        
       

   


        #region OnFilter Command

        private RelayCommand _OnFilterCommand;
        public RelayCommand OnFilterCommand
        {
            get
            {
                if (_OnFilterCommand == null)
                {
                    _OnFilterCommand = new RelayCommand(OnFilter);
                }
                return _OnFilterCommand;
            }
        }
        private async void OnFilter()
        {
            try
            {
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
