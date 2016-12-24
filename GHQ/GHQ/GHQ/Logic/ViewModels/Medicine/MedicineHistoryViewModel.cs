using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Lookup;
using Logic.Models.Data;
using Models;
using Service.Localization;
using Service.Naviagtion;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GHQ.Logic.ViewModels.Account
{
    public class MedicineHistoryViewModel : BaseViewModel
    {
        public MedicineHistoryViewModel(IAccountService _accountService, IMedicineService _medicineService, INavigationService _naviagtionService)
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
                MedicineList = new ObservableCollection<Medicine>(await medicineService.GetHistory());
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
