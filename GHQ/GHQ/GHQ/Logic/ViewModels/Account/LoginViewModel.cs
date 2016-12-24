﻿using GalaSoft.MvvmLight.Command;
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

<<<<<<< HEAD
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

				navigationService.NavigateToPage(typeof(HomePage));
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

		#region SignUP Command
		private RelayCommand _OnSignUpCommand;
		public RelayCommand OnSignUpCommand
		{
			get
			{
				if (_OnSignUpCommand == null)
				{
					_OnSignUpCommand = new RelayCommand(OnSignUp);
				}
				return _OnSignUpCommand;
			}
		}

		private async void OnSignUp()
		{
			try
			{
				IsLoading = true;
				IsPageEnabled = false;
				ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(LoginData.Validate());

				navigationService.NavigateToPage(typeof(NewAccountStep1Page));
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
=======
        #endregion
    }
>>>>>>> 6534f0f0f4f0bc6d748d039739e3355e44fe6425
}
