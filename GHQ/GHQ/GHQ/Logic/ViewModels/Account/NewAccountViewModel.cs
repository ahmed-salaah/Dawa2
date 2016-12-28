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
		private NewUSer _User;
		public NewUSer User
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

		private ObservableCollection<LookupData> _GenderList;
		public ObservableCollection<LookupData> GenderList
		{
			get
			{
				return _GenderList;
			}
			set
			{
				Set(() => GenderList, ref _GenderList, value);
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

				GenderList =new ObservableCollection<LookupData>( await lookupService.GetGenderAsync());

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

		#region Media Command

        private RelayCommand _OnOpenGalleryCommand;
		public RelayCommand OnOpenGalleryCommand
		{
			get
			{
				if (_OnOpenGalleryCommand == null)
				{
					_OnOpenGalleryCommand = new RelayCommand(openGallery);
				}
				return _OnOpenGalleryCommand;
			}
		}
		private async void openGallery()
		{
			try
			{
				
				var mediaPicker = DependencyService.Get<IMediaPicker>();
				navigationService.IsExternalAppOpen = true;
				var mediaFile = await mediaPicker.SelectPhotoAsync();
				navigationService.IsExternalAppOpen = false;
				if (mediaFile != null)
				{
					User.Image = mediaFile;
					IsLoading = true;
					var imageBytes = mediaFile.data;
				}

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
