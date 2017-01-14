using Exceptions;
using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.Resources.Strings;
using Models;
using Service.Dialog;
using Service.Exception;
using Service.Naviagtion;
using GHQ.Logic.Service.Lookup;
using Xamarin.Forms;
using Service.Media;
using GHQLogic.Models.Data;
using System.Collections.ObjectModel;
using System.IO;
using GHQ.Logic.Database.Entities;

namespace GHQ.Logic.ViewModels.Account
{
    public class FilterMedicineViewModel : BaseViewModel
    {
        public FilterMedicineViewModel(INavigationService _navigationService, IAccountService _accountService, ILookupService _lookupService, IDialogService _dialogService, IExceptionService _excpetionService)
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
                ClearValidationErrors();

                

            }
            catch (InternetException ex)
            {
                await excpetionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
            }
            catch (System.Exception ex)
            {
                await excpetionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_GeneralTitle, ex.Message);
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
