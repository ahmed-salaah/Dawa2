using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Lookup;
using Logic.Models.Data;
using Models;
using Service.Naviagtion;


namespace GHQ.Logic.ViewModels.Account
{
    public class MedicineAddNewViewModel : BaseViewModel
    {
        public MedicineAddNewViewModel(IAccountService _accountService, IMedicineService _medicineService, INavigationService _naviagtionService)
        {
            accountService = _accountService;
            naviagtionService = _naviagtionService;
            medicineService = _medicineService;
        }

        #region Private Members

        IAccountService accountService;
        INavigationService naviagtionService;
        IMedicineService medicineService;
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
