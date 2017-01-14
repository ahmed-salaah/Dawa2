using Exceptions;
using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Lookup;
using GHQ.Resources.Strings;
using Logic.Models.Data;
using Models;
using Service.Dialog;
using Service.Exception;
using Service.FileHelper;
using Service.Media;
using Service.Naviagtion;
using Service.Recorder;
using System;
using System.IO;
using Xamarin.Forms;

namespace GHQ.Logic.ViewModels.Account
{
    public class MedicineAddNewViewModel : BaseViewModel
    {
        public MedicineAddNewViewModel(IAccountService _accountService, IMedicineService _medicineService, INavigationService _naviagtionService, IDialogService _dialogService, IExceptionService _exceptionService)
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

        private bool _AddMode;
        public bool AddMode
        {
            get { return _AddMode; }
            set
            {
                Set(() => AddMode, ref _AddMode, value);
            }
        }


        private bool _IsRecording;
        public bool IsRecording
        {
            get { return _IsRecording; }
            set
            {
                Set(() => IsRecording, ref _IsRecording, value);
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
                Medicine = new Medicine();
                // AddMode = false;
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
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
                MediaFile mediaFile = await mediaPicker.SelectPhotoAsync();
                navigationService.IsExternalAppOpen = false;
                if (mediaFile != null)
                {
                    IsLoading = true;
                    var imageBytes = mediaFile.data;
                    Medicine.ImageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                    Medicine.ImagePath = await DependencyService.Get<IFileHelper>().SaveByteArrayToDisk(Guid.NewGuid().ToString() + Medicine.Name, imageBytes, "Medicine");
                }

            }
            catch (InternetException ex)
            {
                await exceptionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
            }
            catch (System.Exception ex)
            {
                await exceptionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_GeneralTitle, ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }

        #endregion

        #region RecordVoiceNote Command

        private RelayCommand _OnRecordVoiceNoteCommand;
        public RelayCommand OnRecordVoiceNoteCommand
        {
            get
            {
                if (_OnRecordVoiceNoteCommand == null)
                {
                    _OnRecordVoiceNoteCommand = new RelayCommand(RecordVoiceNote);
                }
                return _OnRecordVoiceNoteCommand;
            }
        }
        private async void RecordVoiceNote()
        {
            try
            {
                if (!IsRecording)
                {
                    DependencyService.Get<IRecorderService>().Record();
                }
                else
                {
                    byte[] file = await DependencyService.Get<IRecorderService>().Stop();
                    Medicine.VoiceNotePath = await DependencyService.Get<IFileHelper>().SaveByteArrayToDisk(Guid.NewGuid().ToString() + Medicine.Name, file, "VoiceNotes");
                    DependencyService.Get<IRecorderService>().Play();
                }

                IsRecording = !IsRecording;
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

        #region OnSave Command

        private RelayCommand _OnSaveCommand;
        public RelayCommand OnSaveCommand
        {
            get
            {
                if (_OnSaveCommand == null)
                {
                    _OnSaveCommand = new RelayCommand(OnSave);
                }
                return _OnSaveCommand;
            }
        }


        private async void OnSave()
        {
            try
            {
                var m = Medicine;
                Medicine = await medicineService.AddMedicine(Medicine);
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
