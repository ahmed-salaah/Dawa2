﻿using Exceptions;
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
using System.Threading.Tasks;
using GHQ.Logic.Database.Entities;
using Service.FileHelper;
using System;
using GHQ.UI.Pages.Home;
using System.Linq;

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

                GenderList = new ObservableCollection<LookupData>(await lookupService.GetGenderAsync());
				User = new NewUSer();
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

		 #region Intialize SignUP

        private RelayCommand _OnCreateAccountCommand;
		public RelayCommand OnCreateAccountCommand
		{
			get
			{
				if (_OnCreateAccountCommand == null)
				{
					_OnCreateAccountCommand = new RelayCommand(CreateAccount);
				}
				return _OnCreateAccountCommand;
			}
		}
		private async void CreateAccount()
		{
			try
			{
				
				ValidationErrors = new ObservableCollection<ValidatedModel>(User.Validate());
				if (ValidationErrors.Any())
				{
					await dialogService.DisplayAlert("", ErrorMessagesString);
				}
				else
				{
					Task<NewUSer> userLogged = accountService.AddEditUser(User);
					navigationService.NavigateToPage(typeof(HomePage));
				}
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

		#region OnOpenGalleryCommand Command

		private RelayCommand _OnOpenGalleryCommand;
        public RelayCommand OnOpenGalleryCommand
        {
            get
            {
                if (_OnOpenGalleryCommand == null)
                {
                    _OnOpenGalleryCommand = new RelayCommand(OpenGallery);
                }
                return _OnOpenGalleryCommand;
            }
        }
        private async void OpenGallery()
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
                    User.ImageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));
					User.ImagePath = await DependencyService.Get<IFileHelper>().SaveImageToDisk(Guid.NewGuid().ToString() + User.UserName + ".jpg", imageBytes, "Medicine");
                }

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
