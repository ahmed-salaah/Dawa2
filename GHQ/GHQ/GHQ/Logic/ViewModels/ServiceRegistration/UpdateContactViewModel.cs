using Exceptions;
using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Models.Account.Data;
using GHQ.Logic.Models.Data.Registration;
using GHQ.Logic.Service.Account;
using GHQ.Logic.Service.Lookup;
using GHQ.Logic.Service.ServiceRegistration;
using GHQ.Resources.Strings;
using GHQ.UI.Pages.Master;
using Models;
using Service.Dialog;
using Service.Exception;
using Service.Naviagtion;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GHQ.Logic.ViewModels.ServiceRegistration
{
    public class UpdateContactViewModel : BaseViewModel
    {
        public UpdateContactViewModel(IAccountService _accountService, IDialogService _dialogService, ILookupService _lookupService,
            INavigationService _naviagtionService, IServiceRegistrationService _serviceRegistrationService, IExceptionService _excpetionService)
        {
            accountService = _accountService;
            navigationService = _naviagtionService;
            dialogService = _dialogService;
            lookupService = _lookupService;
            serviceRegistrationService = _serviceRegistrationService;
            excpetionService = _excpetionService;
        }

        #region Private Members

        IAccountService accountService;
        INavigationService navigationService;
        IDialogService dialogService;
        ILookupService lookupService;
        IServiceRegistrationService serviceRegistrationService;
        IExceptionService excpetionService;
        #endregion

        #region Properties

        private UpdateContactData _UserData;
        public UpdateContactData UserData
        {
            get { return _UserData; }
            set
            {
                Set(() => UserData, ref _UserData, value);
            }
        }

        private ObservableCollection<LookupData> _PassportTypeList;
        public ObservableCollection<LookupData> PassportTypeList
        {
            get
            {
                return _PassportTypeList;
            }
            set
            {
                Set(() => PassportTypeList, ref _PassportTypeList, value);
            }
        }

        private int _SelectedPassportTypeListIndex;
        public int SelectedPassportTypeListIndex
        {
            get
            {
                return _SelectedPassportTypeListIndex;
            }
            set
            {
                Set(() => SelectedPassportTypeListIndex, ref _SelectedPassportTypeListIndex, value);
                if (value >= 0)
                {
                    UserData.SelectedPassportType = PassportTypeList[value];
                    UserData.PassportType = UserData.SelectedPassportType.Id;
                }
            }
        }

        private ObservableCollection<LookupData> _PassportIssuanceLocationList;
        public ObservableCollection<LookupData> PassportIssuanceLocationList
        {
            get
            {
                return _PassportIssuanceLocationList;
            }
            set
            {
                Set(() => PassportIssuanceLocationList, ref _PassportIssuanceLocationList, value);
            }
        }

        private int _SelectedPassportIssuanceLocationListIndex;
        public int SelectedPassportIssuanceLocationListIndex
        {
            get
            {
                return _SelectedPassportIssuanceLocationListIndex;
            }
            set
            {
                Set(() => SelectedPassportIssuanceLocationListIndex, ref _SelectedPassportIssuanceLocationListIndex, value);
                if (value >= 0)
                {
                    UserData.SelectedPassportIssuePlace = PassportIssuanceLocationList[value];
                    UserData.PassportIssuePlace = UserData.SelectedPassportIssuePlace.Id;
                }
            }
        }

        private ObservableCollection<LookupData> _CitiesList;
        public ObservableCollection<LookupData> CitiesList
        {
            get
            {
                return _CitiesList;
            }
            set
            {
                Set(() => CitiesList, ref _CitiesList, value);
            }
        }

        private int _SelectedCitiesListIndex;
        public int SelectedCitiesListIndex
        {
            get
            {
                return _SelectedCitiesListIndex;
            }
            set
            {
                Set(() => SelectedCitiesListIndex, ref _SelectedCitiesListIndex, value);
                if (value >= 0)
                {
                    UserData.SelectedCity = CitiesList[value];
                    UserData.CityID = UserData.SelectedCity.Id;
                    RegionList = new ObservableCollection<LookupData>(AllRegionList.Where(a => a.LookupValueParentID == UserData.SelectedCity.Id));
                    UserData.SelectedRegion = RegionList.FirstOrDefault();
                }
            }
        }

        private ObservableCollection<LookupData> _AllRegionList;
        public ObservableCollection<LookupData> AllRegionList
        {
            get
            {
                return _AllRegionList;
            }
            set
            {
                Set(() => AllRegionList, ref _AllRegionList, value);
            }
        }

        private ObservableCollection<LookupData> _RegionList;
        public ObservableCollection<LookupData> RegionList
        {
            get
            {
                return _RegionList;
            }
            set
            {
                Set(() => RegionList, ref _RegionList, value);
            }
        }

        private int _SelectedRegionListIndex;
        public int SelectedRegionListIndex
        {
            get
            {
                return _SelectedRegionListIndex;
            }
            set
            {
                Set(() => SelectedRegionListIndex, ref _SelectedRegionListIndex, value);
                if (value >= 0)
                {
                    UserData.SelectedRegion = RegionList[value];
                    UserData.RegionID = UserData.SelectedRegion.Id;
                }
            }
        }

        #endregion

        #region Private Methods

        async Task PopulateAddressAreaAndRegions()
        {
            try
            {
                if (CitiesList == null)
                {
                    var emirates = await lookupService.GetEmiratesAync();
                    var areas = await lookupService.GetAreaAync();
                    CitiesList = new ObservableCollection<LookupData>(emirates);
                    AllRegionList = new ObservableCollection<LookupData>(areas);
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        async Task PopulatePassportIssuanceLocation()
        {
            try
            {
                if (PassportIssuanceLocationList == null)
                {
                    PassportIssuanceLocationList = new ObservableCollection<LookupData>(await lookupService.GetPassportIssuanceLocationsync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        async Task PopulatePassportTypes()
        {
            try
            {
                if (PassportTypeList == null)
                {
                    PassportTypeList = new ObservableCollection<LookupData>(await lookupService.GetPassportTypeAsync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
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
                await PopulatePassportTypes();
                await PopulatePassportIssuanceLocation();
                await PopulateAddressAreaAndRegions();
                UserData = await serviceRegistrationService.FillUpdateRequestData(accountService.AccessToken);
                if (string.IsNullOrEmpty(UserData.PassportType))
                {
                    UserData.SelectedPassportType = PassportTypeList.FirstOrDefault();
                }
                else
                {
                    UserData.SelectedPassportType = PassportTypeList.FirstOrDefault(a => a.Id == UserData.PassportType);
                }
                UserData.PassportType = UserData.SelectedPassportType.Id;
                if (string.IsNullOrEmpty(UserData.PassportIssuePlace))
                {
                    UserData.SelectedPassportIssuePlace = PassportIssuanceLocationList.FirstOrDefault();
                }
                else
                {
                    UserData.SelectedPassportIssuePlace = PassportIssuanceLocationList.FirstOrDefault(a => a.Id == UserData.PassportIssuePlace);
                }
                UserData.PassportIssuePlace = UserData.SelectedPassportIssuePlace.Id;
                if (string.IsNullOrEmpty(UserData.CityID))
                {
                    UserData.SelectedCity = CitiesList.FirstOrDefault();
                }
                else
                {
                    UserData.SelectedCity = CitiesList.FirstOrDefault(a => a.Id == UserData.CityID);
                }
                UserData.CityID = UserData.SelectedCity.Id;

                RegionList = new ObservableCollection<LookupData>(AllRegionList.Where(a => a.LookupValueParentID == UserData.SelectedCity.Id));

                if (string.IsNullOrEmpty(UserData.RegionID))
                {
                    UserData.SelectedRegion = RegionList.FirstOrDefault();
                }
                else
                {
                    UserData.SelectedRegion = RegionList.FirstOrDefault(a => a.Id == UserData.RegionID);
                }
                UserData.RegionID = UserData.SelectedCity.Id;

            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                IsPageEnabled = true;
            }
        }

        #endregion

        #region OnUpdateContactCommand

        private RelayCommand _OnOnUpdateContactCommand;
        public RelayCommand OnOnUpdateContactCommand
        {
            get
            {
                if (_OnOnUpdateContactCommand == null)
                {
                    _OnOnUpdateContactCommand = new RelayCommand(OnOnUpdateContact);
                }
                return _OnOnUpdateContactCommand;
            }
        }

        private async void OnOnUpdateContact()
        {
            try
            {


                IsLoading = true;
                IsPageEnabled = false;
                ClearValidationErrors();
                ValidationErrors = new ObservableCollection<ValidatedModel>(UserData.Validate());

                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    var result = await serviceRegistrationService.AddUpdateRequest(UserData, accountService.AccessToken);
                    if (result)
                    {
                        navigationService.SetAppCurrentPage(typeof(MainPage));
                    }
                    else
                    {
                        await dialogService.DisplayAlert(AppResources.Error, AppResources.Error_NoDataFound);
                    }
                }
            }
            catch (BackendException ex)
            {
                await excpetionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_BackendTitle, ex.Message);
            }
            catch (ApplicationError ex)
            {
                await excpetionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_ApplicationTitle, ex.Message);
            }
            catch (System.Exception ex)
            {
                await excpetionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_GeneralTitle, ex.Message);
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
