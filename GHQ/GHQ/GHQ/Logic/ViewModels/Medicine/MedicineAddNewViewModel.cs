﻿using Enums;
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
using Service.ILocalNotifications;
using Service.Media;
using Service.Naviagtion;
using Service.Recorder;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        #endregion

        #region Private Methods

        void LoadReminderOptions(int? id)
        {
            ReminderOptions = new ObservableCollection<RadioButtonGroupItem>();
            ReminderOptions.Add(new RadioButtonGroupItem() { Id = (int)ReminderRepeatOptions.Daily, Value = AppResources.MedicineAddNew_DailyReminder });
            ReminderOptions.Add(new RadioButtonGroupItem() { Id = (int)ReminderRepeatOptions.Weekly, Value = AppResources.MedicineAddNew_WeeklyReminder });
            ReminderOptions.Add(new RadioButtonGroupItem() { Id = (int)ReminderRepeatOptions.Monthly, Value = AppResources.MedicineAddNew_MonthlyReminder });
            ReminderOptions.Add(new RadioButtonGroupItem() { Id = (int)ReminderRepeatOptions.EventBased, Value = AppResources.MedicineAddNew_EventReminder });

            if (id == null)
            {
                var option = ReminderOptions.FirstOrDefault();
                option.IsSelected = true;
            }
            else
            {
                var option = ReminderOptions.FirstOrDefault(a => a.Id == id);
                option.IsSelected = true;
            }

        }

        private async Task<bool> AddMedicin()
        {
            try
            {
                ValidationErrors = new ObservableCollection<ValidatedModel>(Medicine.Validate());
                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                    return false;
                }
                else
                {
                    Medicine = await medicineService.AddEditMedicine(Medicine);
                    var localNotifications = DependencyService.Get<ILocalNotifications>();
                    localNotifications.ShowNotification(string.Format("Reminder for {0}", Medicine.Name), Medicine.Name, Medicine.Reminder.Date, Medicine.VoiceNotePath, (ReminderRepeatOptions)Medicine.Reminder.SelectedReminderOption.Id);
                    return true;
                }

            }
            catch (System.Exception ex)
            {
                return false;
            }
            finally
            {
            }
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
                Medicine = null;
                   IsRecording = false;
                if (navigationService.IsExternalAppOpen)
                {
                    navigationService.IsExternalAppOpen = false;
                    return;
                }

                if (medicineService.SelectedMedicine == null)
                {
                    LoadReminderOptions(null);
                    Medicine = new Medicine();
                    Medicine.Reminder.SelectedReminderOption = ReminderOptions.FirstOrDefault();
                    AddMode = true;
                }
                else
                {
                    Medicine = medicineService.SelectedMedicine;
                    LoadReminderOptions(Medicine.Reminder.ReminderOptionId);
                    AddMode = false;

                    Medicine.Reminder.SelectedReminderOption = ReminderOptions.FirstOrDefault(a => a.Id == Medicine.Reminder.ReminderOptionId);

                    if (!string.IsNullOrEmpty(Medicine.ImagePath))
                    {
                        Medicine.ImageSource = ImageSource.FromFile(Medicine.ImagePath);
                    }
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
                DependencyService.Get<IRecorderService>().Play(Medicine.VoiceNotePath);
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
                bool isAdded = await AddMedicin();
                if (isAdded)
                {
                    navigationService.GoBack();
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
                bool isAdded = await AddMedicin();
                if (isAdded)
                {
                    Medicine = new Medicine();
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


        #endregion
    }
}
