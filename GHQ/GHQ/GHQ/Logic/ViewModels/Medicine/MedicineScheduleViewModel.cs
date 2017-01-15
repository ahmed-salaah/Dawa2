using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Lookup;
using GHQ.Resources.Strings;
using GHQ.UI.Pages.Medicine;
using Logic.Models.Data;
using Models;
using Service.Naviagtion;
using System.Collections.ObjectModel;

namespace GHQ.Logic.ViewModels.Account
{
    public class MedicineScheduleViewModel : BaseViewModel
    {
        public MedicineScheduleViewModel(IAccountService _accountService, IMedicineService _medicineService, INavigationService _naviagtionService)
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

        private ObservableCollection<Medicine> _MedicineList;
        public ObservableCollection<Medicine> MedicineList
        {
            get { return _MedicineList; }
            set
            {
                Set(() => MedicineList, ref _MedicineList, value);
            }
        }

        private Medicine _SelectedMedicine;
        public Medicine SelectedMedicine
        {
            get { return _SelectedMedicine; }
            set
            {
                Set(() => SelectedMedicine, ref _SelectedMedicine, value);
                medicineService.SelectedMedicine = value;
                if (value != null)
                    naviagtionService.NavigateToPage(typeof(MedicineAddNew));
            }
        }


        //private bool _IsCurrentModeSelected;
        //public bool IsCurrentModeSelected
        //{
        //    get { return _IsCurrentModeSelected; }
        //    set
        //    {
        //        Set(() => IsCurrentModeSelected, ref _IsCurrentModeSelected, value);

        //    }
        //}

        //private bool _IsAllModeSelected;
        //public bool IsAllModeSelected
        //{
        //    get { return _IsAllModeSelected; }
        //    set
        //    {
        //        Set(() => IsAllModeSelected, ref _IsAllModeSelected, value);
        //    }
        //}

        private ObservableCollection<RadioButtonGroupItem> _ModeOptions;
        public ObservableCollection<RadioButtonGroupItem> ModeOptions
        {
            get { return _ModeOptions; }
            set
            {
                Set(() => ModeOptions, ref _ModeOptions, value);
            }
        }

        private RadioButtonGroupItem _SelectedModeOption;
        public RadioButtonGroupItem SelectedModeOption
        {
            get { return _SelectedModeOption; }
            set
            {
                Set(() => SelectedModeOption, ref _SelectedModeOption, value);
                if (value != null && value.Id == 2)
                {
                    Intialize();
                }
                else
                {
                    AllMedicine();
                }
            }
        }

        #endregion

        #region Private Methods

        void LoadModeOptions()
        {
            ModeOptions = new ObservableCollection<RadioButtonGroupItem>();
            ModeOptions.Add(new RadioButtonGroupItem() { Id = 1, Value = AppResources.PageHeader_MedicineSchedule_AllMedicine });
            ModeOptions.Add(new RadioButtonGroupItem() { Id = 0, Value = "" });
            ModeOptions.Add(new RadioButtonGroupItem() { Id = 2, Value = AppResources.PageHeader_MedicineSchedule_CurrentMedicine, IsSelected = true });

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
                IsLoading = true;
                SelectedMedicine = null;
                LoadModeOptions();
                MedicineList = new ObservableCollection<Medicine>(await medicineService.GetCurrentMedicine());
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

        #region AllMedicine Command

        private RelayCommand _OnAllMedicineCommand;
        public RelayCommand OnAllMedicineCommand
        {
            get
            {
                if (_OnAllMedicineCommand == null)
                {
                    _OnAllMedicineCommand = new RelayCommand(AllMedicine);
                }
                return _OnAllMedicineCommand;
            }
        }
        private async void AllMedicine()
        {
            try
            {
                IsLoading = true;
                MedicineList = new ObservableCollection<Medicine>(await medicineService.GetAllMedicine());
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

        #endregion
    }
}
