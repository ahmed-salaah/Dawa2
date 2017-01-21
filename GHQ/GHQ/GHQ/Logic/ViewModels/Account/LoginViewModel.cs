using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.UI.Pages.Account;
using GHQ.UI.Pages.Filter;
using GHQ.UI.Pages.Home;
using GHQ.Logic.Models.Data;
using Models;
using Service.Localization;
using Service.Naviagtion;
using Xamarin.Forms;
using System.Threading.Tasks;
using GHQLogic.Models.Data;
using System.Linq;
using Service.Dialog;
using GHQ.Resources.Strings;

namespace GHQ.Logic.ViewModels.Account
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigationService _navigationService, IAccountService _accountService, IDialogService _dialogService)
        {
            navigationService = _navigationService;
            accountService = _accountService;
			dialogService = _dialogService;
        }

        #region Private Members

        INavigationService navigationService;
        IAccountService accountService;
		IDialogService dialogService;
        #endregion

        #region Properties
		private LoginUser _User;
		public LoginUser User
		{
			get
			{
				return _User;
			}
			set
			{
				Set(() => User, ref _User, value);
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
                DependencyService.Get<ILocalize>().SetLocale(new System.Globalization.CultureInfo("ar-EG"));
				User = new LoginUser();
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
				ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(User.Validate());
				if (ValidationErrors.Any())
				{
					await dialogService.DisplayAlert("", ErrorMessagesString);
				}
				else
				{
					NewUser userLogged = await accountService.Login(User.UserName, User.Password);
 					if (userLogged != null)
					{
						navigationService.NavigateToPage(typeof(HomePage));

					}
					else
					{
						await dialogService.DisplayAlert("", AppResources.Login_WrongUserNameOrPassword);

					}
				}
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

		#region FacebookLogin Command
		private RelayCommand _OnFacebookLoginCommand;
		public RelayCommand OnFacebookLoginCommand
		{
			get
			{
				if (_OnFacebookLoginCommand == null)
				{
					_OnFacebookLoginCommand = new RelayCommand(OnFacebook);
				}
				return _OnFacebookLoginCommand;
			}
		}

		private async void OnFacebook()
		{
			try
			{
				IsLoading = true;
				IsPageEnabled = false;

            App.PostSuccessFacebookAction =  token =>
				{
				//you can use this token to authenticate to the server here
				//call your FacebookLoginService.LoginToServer(token)
				//I'll just navigate to a screen that displays the token

					navigationService.NavigateToPage(typeof(HomePage));


				};
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
                //ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(LoginData.Validate());

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
		#region forgotPassword Command
        private RelayCommand _OnforgotPasswordCommand;
		public RelayCommand OnforgotPasswordCommand
		{
			get
			{
				if (_OnforgotPasswordCommand == null)
				{
					_OnforgotPasswordCommand = new RelayCommand(OnforgotPassword);
				}
				return _OnforgotPasswordCommand;
			}
		}

		private async void OnforgotPassword()
		{
			try
			{
				IsLoading = true;
				IsPageEnabled = false;
				//ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(LoginData.Validate());

				//navigationService.NavigateToPage(typeof(FilterPage));
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