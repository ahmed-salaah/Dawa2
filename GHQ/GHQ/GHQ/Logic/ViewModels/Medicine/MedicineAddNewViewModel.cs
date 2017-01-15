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
using System.Collections.ObjectModel;
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


        private ObservableCollection<RadioButtonGroupItem> _ReminderOptions;
        public ObservableCollection<RadioButtonGroupItem> ReminderOptions
        {
            get { return _ReminderOptions; }
            set
            {
                Set(() => ReminderOptions, ref _ReminderOptions, value);
            }
        }

        private RadioButtonGroupItem _SelectedReminderOption;
        public RadioButtonGroupItem SelectedReminderOption
        {
            get { return _SelectedReminderOption; }
            set
            {
                Set(() => SelectedReminderOption, ref _SelectedReminderOption, value);
            }
        }

        #endregion

        #region Private Methods

        void LoadReminderOptions()
        {
            ReminderOptions = new ObservableCollection<RadioButtonGroupItem>();
            ReminderOptions.Add(new RadioButtonGroupItem() { Id = 1, Value = AppResources.MedicineAddNew_DailyReminder });
            ReminderOptions.Add(new RadioButtonGroupItem() { Id = 2, Value = AppResources.MedicineAddNew_WeeklyReminder });
            ReminderOptions.Add(new RadioButtonGroupItem() { Id = 3, Value = AppResources.MedicineAddNew_MonthlyReminder });
            ReminderOptions.Add(new RadioButtonGroupItem() { Id = 4, Value = AppResources.MedicineAddNew_EventReminder });
        }
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
                IsRecording = false;
                LoadReminderOptions();
                if (navigationService.IsExternalAppOpen)
                    return;
                if (medicineService.SelectedMedicine == null)
                {
                    Medicine = new Medicine();
                    AddMode = true;
                }
                else
                {
                    Medicine = medicineService.SelectedMedicine;
                    AddMode = false;
                }
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
                    Medicine.ImagePath = await DependencyService.Get<IFileHelper>().SaveImageToDisk(Guid.NewGuid().ToString() + Medicine.Name + ".jpg", imageBytes, "Medicine");
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
                    Medicine.VoiceNotePath = "";
                    DependencyService.Get<IRecorderService>().Record();
                }
                else
                {
                    byte[] file = await DependencyService.Get<IRecorderService>().Stop();
                    Medicine.VoiceNotePath = await DependencyService.Get<IFileHelper>().SaveByteArrayToDisk(Guid.NewGuid().ToString() + Medicine.Name + ".wav", file, "VoiceNotes");
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

        #region PlayVoiceNote Command

        private RelayCommand _OnPlayVoiceNoteCommand;
        public RelayCommand OnPlayVoiceNoteCommand
        {
            get
            {
                if (_OnPlayVoiceNoteCommand == null)
                {
                    _OnPlayVoiceNoteCommand = new RelayCommand(PlayVoiceNote);
                }
                return _OnPlayVoiceNoteCommand;
            }
        }
        private async void PlayVoiceNote()
        {
            try
            {
                DependencyService.Get<IRecorderService>().Play();
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
                Medicine = await medicineService.AddEditMedicine(Medicine);
                navigationService.GoBack();
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

        #region OnSaveAndAdd Command

        private RelayCommand _OnSaveAndAddCommand;
        public RelayCommand OnSaveAndAddCommand
        {
            get
            {
                if (_OnSaveAndAddCommand == null)
                {
                    _OnSaveAndAddCommand = new RelayCommand(OnSaveAndAdd);
                }
                return _OnSaveAndAddCommand;
            }
        }


        private async void OnSaveAndAdd()
        {
            try
            {
                var m = Medicine;
                await medicineService.AddEditMedicine(Medicine);
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


        #endregion
    }
}
