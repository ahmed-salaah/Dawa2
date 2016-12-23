using Exceptions;
using GalaSoft.MvvmLight.Command;
using GHQ.Resources.Strings;
using Models;
using Service.Dialog;
using Service.Exception;
using Service.Naviagtion;
using GHQ.Logic.Service.ServiceRegistration;
using GHQ.Logic.Models.Data.Registration;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using Service.Reflection;
using System.Collections.ObjectModel;
using GHQ.Logic.Service.Account;
using System.Threading.Tasks;
using System.Linq;
using GHQ.Logic.Service.Lookup;
using System;
using Service.Media;
using GHQ.UI.Pages.Master;

namespace GHQ.Logic.ViewModels.ServiceRegistration
{
    public class ServiceRegistrationViewModel : BaseViewModel
    {
        public ServiceRegistrationViewModel(INavigationService _navigationService, IServiceRegistrationService _serviceRegistrationService, ILookupService _lookupService,
            IDialogService _dialogService, IExceptionService _excpetionService, IAccountService _accountService)
        {
            serviceRegistrationService = _serviceRegistrationService;
            navigationService = _navigationService;
            dialogService = _dialogService;
            excpetionService = _excpetionService;
            accountService = _accountService;
            lookupService = _lookupService;
        }

        #region Private Members

        INavigationService navigationService;
        IServiceRegistrationService serviceRegistrationService;
        IDialogService dialogService;
        IExceptionService excpetionService;
        IAccountService accountService;
        ILookupService lookupService;
        #endregion

        #region Properties

        private RegistrationData _RegistrationData;
        public RegistrationData RegistrationData
        {
            get
            {
                return _RegistrationData;
            }
            set
            {
                Set(() => RegistrationData, ref _RegistrationData, value);
            }
        }

        private List<BREData> _BREList;
        public List<BREData> BREList
        {
            get
            {
                return _BREList;
            }
            set
            {
                Set(() => BREList, ref _BREList, value);
            }
        }

        #region Personal Information

        private ObservableCollection<LookupData> _WorkStateList;
        public ObservableCollection<LookupData> WorkStateList
        {
            get
            {
                return _WorkStateList;
            }
            set
            {
                Set(() => WorkStateList, ref _WorkStateList, value);
            }
        }

        private LookupData _SelectedWorkStateListItem;
        public LookupData SelectedWorkStateListItem
        {
            get
            {
                return _SelectedWorkStateListItem;
            }
            set
            {
                Set(() => SelectedWorkStateListItem, ref _SelectedWorkStateListItem, value);
                if (SelectedWorkStateListItem.Id == "Working") //Employee
                {
                    IsStudent = false;
                    IsMilitary = false;
                    IsWorking = true;
                }
                else if (SelectedWorkStateListItem.Id == "NotWorking") //No Job
                {
                    IsStudent = false;
                    IsMilitary = false;
                    IsWorking = false;
                }
                else if (SelectedWorkStateListItem.Id == "Student") //No Job
                {
                    IsStudent = true;
                    IsMilitary = false;
                    IsWorking = false;
                }
                else
                {
                    IsStudent = false;
                    IsMilitary = false;
                    IsWorking = false;
                }

                RaisePropertyChanged("WorkTabVisible");
            }
        }

        public bool WorkTabVisible
        {
            get
            {
                return SelectedWorkStateListItem?.Id != "NotWorking";
            }
        }

        private ObservableCollection<LookupData> _MaritalStatusList;
        public ObservableCollection<LookupData> MaritalStatusList
        {
            get
            {
                return _MaritalStatusList;
            }
            set
            {
                Set(() => MaritalStatusList, ref _MaritalStatusList, value);
            }
        }

        private int _SelectedMaritalStatusListIndex;
        public int SelectedMaritalStatusListIndex
        {
            get
            {
                return _SelectedMaritalStatusListIndex;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                Set(() => SelectedMaritalStatusListIndex, ref _SelectedMaritalStatusListIndex, value);
                RegistrationData.SelectedMaritalStatus = MaritalStatusList[value];
                RegistrationData.MaritalStatus = RegistrationData.SelectedMaritalStatus.Id;
                RaisePropertyChanged("WifeTabVisible");
            }
        }

        public bool WifeTabVisible
        {
            get
            {
                return RegistrationData?.SelectedMaritalStatus?.Id != "1";
            }
        }

        private ObservableCollection<LookupData> _TribeList;
        public ObservableCollection<LookupData> TribeList
        {
            get
            {
                return _TribeList;
            }
            set
            {
                Set(() => TribeList, ref _TribeList, value);
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

        private ObservableCollection<LookupData> _NationalityGainList;
        public ObservableCollection<LookupData> NationalityGainList
        {
            get
            {
                return _NationalityGainList;
            }
            set
            {
                Set(() => NationalityGainList, ref _NationalityGainList, value);
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


        private ObservableCollection<LookupData> _EmiratesList;
        public ObservableCollection<LookupData> EmiratesList
        {
            get
            {
                return _EmiratesList;
            }
            set
            {
                Set(() => EmiratesList, ref _EmiratesList, value);
            }
        }

       

        private ObservableCollection<LookupData> _NationalityPreviousList;
        public ObservableCollection<LookupData> NationalityPreviousList
        {
            get
            {
                return _NationalityPreviousList;
            }
            set
            {
                Set(() => NationalityPreviousList, ref _NationalityPreviousList, value);
            }
        }

        private int _SelectedNationalityPreviousListIndex;
        public int SelectedNationalityPreviousListIndex
        {
            get
            {
                return _SelectedNationalityPreviousListIndex;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                Set(() => SelectedNationalityPreviousListIndex, ref _SelectedNationalityPreviousListIndex, value);

                RegistrationData.SelectedPreviousNationality = NationalityPreviousList[value];
                RegistrationData.PreviousNationality = RegistrationData.SelectedPreviousNationality.Id;
            }
        }



        #endregion

        #region Work

        private Work _AddedWork;
        public Work AddedWork
        {
            get
            {
                return _AddedWork;
            }
            set
            {
                Set(() => AddedWork, ref _AddedWork, value);
            }
        }

        private bool _IsWorking;
        public bool IsWorking
        {
            get
            {
                return _IsWorking;
            }
            set
            {
                Set(() => IsWorking, ref _IsWorking, value);
            }
        }

        private bool _IsPrivate;
        public bool IsPrivate
        {
            get
            {
                return _IsPrivate;
            }
            set
            {
                Set(() => IsPrivate, ref _IsPrivate, value);
            }
        }

        private bool _IsMilitary;
        public bool IsMilitary
        {
            get
            {
                return _IsMilitary;
            }
            set
            {
                Set(() => IsMilitary, ref _IsMilitary, value);
            }
        }

        private bool _IsStudent;
        public bool IsStudent
        {
            get
            {
                return _IsStudent;
            }
            set
            {
                Set(() => IsStudent, ref _IsStudent, value);
            }
        }

        private ObservableCollection<LookupData> _WorkOrgTypeList;
        public ObservableCollection<LookupData> WorkOrgTypeList
        {
            get
            {
                return _WorkOrgTypeList;
            }
            set
            {
                Set(() => WorkOrgTypeList, ref _WorkOrgTypeList, value);
            }
        }

        private int _SelectedWorkOrgTypeListIndex;
        public int SelectedWorkOrgTypeListIndex
        {
            get
            {
                return _SelectedWorkOrgTypeListIndex;
            }
            set
            {
                Set(() => SelectedWorkOrgTypeListIndex, ref _SelectedWorkOrgTypeListIndex, value);
                if (value >= 0)
                {
                    AddedWork.SelectedWorkOrgType = WorkOrgTypeList[value];
                    AddedWork.WorkOrgTypeID = AddedWork.SelectedWorkOrgType.Id;
                    if (AddedWork.WorkOrgTypeID == "2") //Private
                    {
                        IsPrivate = true;
                        IsMilitary = false;
                    }
                    else if (AddedWork.WorkOrgTypeID == "3") //Military
                    {
                        IsPrivate = false;
                        IsMilitary = true;
                    }
                    else
                    {
                        IsPrivate = false;
                        IsMilitary = false;
                    }
                }
            }
        }


        private ObservableCollection<LookupData> _WorkOrgCityList;
        public ObservableCollection<LookupData> WorkOrgCityList
        {
            get
            {
                return _WorkOrgCityList;
            }
            set
            {
                Set(() => WorkOrgCityList, ref _WorkOrgCityList, value);
            }
        }

        private int _SelectedWorkOrgCityListIndex;
        public int SelectedWorkOrgCityListIndex
        {
            get
            {
                return _SelectedWorkOrgCityListIndex;
            }
            set
            {
                Set(() => SelectedWorkOrgCityListIndex, ref _SelectedWorkOrgCityListIndex, value);
                if (value >= 0)
                {
                    AddedWork.SelectedWorkOrgCity = WorkOrgCityList[value];
                    AddedWork.WorkOrgCityID = AddedWork.SelectedWorkOrgCity.Id;
                }
            }
        }


        private ObservableCollection<LookupData> _EducationTypeList;
        public ObservableCollection<LookupData> EducationTypeList
        {
            get
            {
                return _EducationTypeList;
            }
            set
            {
                Set(() => EducationTypeList, ref _EducationTypeList, value);
            }
        }

        private int _SelectedEducationTypeListIndex;
        public int SelectedEducationTypeListIndex
        {
            get
            {
                return _SelectedEducationTypeListIndex;
            }
            set
            {
                Set(() => SelectedEducationTypeListIndex, ref _SelectedEducationTypeListIndex, value);
                if (value >= 0)
                {
                    AddedWork.SelectedEducationInstitute = EducationTypeList[value];
                    AddedWork.EducationInstituteID = AddedWork.SelectedEducationInstitute.Id;
                }
            }
        }

        private ObservableCollection<LookupData> _MilitartTypeList;
        public ObservableCollection<LookupData> MilitartTypeList
        {
            get
            {
                return _MilitartTypeList;
            }
            set
            {
                Set(() => MilitartTypeList, ref _MilitartTypeList, value);
            }
        }

        private int _SelectedMilitartTypeListIndex;
        public int SelectedMilitartTypeListIndex
        {
            get
            {
                return _SelectedMilitartTypeListIndex;
            }
            set
            {
                Set(() => SelectedMilitartTypeListIndex, ref _SelectedMilitartTypeListIndex, value);
                if (value >= 0)
                {
                    AddedWork.SelectedMilitaryEntity = MilitartTypeList[value];
                    AddedWork.MilitaryEntityID = AddedWork.SelectedMilitaryEntity.Id;
                }
            }
        }


        #endregion

        #region Address

        private Address _AddedAddress;
        public Address AddedAddress
        {
            get
            {
                return _AddedAddress;
            }
            set
            {
                Set(() => AddedAddress, ref _AddedAddress, value);
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
                    AddedAddress.SelectedCity = CitiesList[value];
                    AddedAddress.CityID = AddedAddress.SelectedCity.Id;
                    RegionList = new ObservableCollection<LookupData>(AllRegionList.Where(a => a.LookupValueParentID == AddedAddress.SelectedCity.Id));
                    AddedAddress.SelectedRegion = RegionList.FirstOrDefault();
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
                    AddedAddress.SelectedRegion = RegionList[value];
                    AddedAddress.RegionID = AddedAddress.SelectedRegion.Id;
                }
            }
        }

        #endregion

        #region Relative

        private Relative _AddedRelative;
        public Relative AddedRelative
        {
            get
            {
                return _AddedRelative;
            }
            set
            {
                Set(() => AddedRelative, ref _AddedRelative, value);

            }
        }

        private bool _AddedRelativeAddMode;
        public bool AddedRelativeAddMode
        {
            get
            {
                return _AddedRelativeAddMode;
            }
            set
            {
                Set(() => AddedRelativeAddMode, ref _AddedRelativeAddMode, value);

            }
        }

        private int _SelectedRelativeListIndex;
        public int SelectedRelativeListIndex
        {
            get
            {
                return _SelectedRelativeListIndex;
            }
            set
            {
                Set(() => SelectedRelativeListIndex, ref _SelectedRelativeListIndex, value);
                if (value + 1 == RegistrationData.OtherRelatives.Count() || value <= 0)
                {
                    AddedRelativeAddMode = true;
                }
                else
                {
                    AddedRelativeAddMode = false;
                }
                if (value > 0)
                {

                    if (RegistrationData.OtherRelatives.Count - 1 == value) //Last One
                    {
                        AddedRelative = new Relative();
                    }
                    else
                    {
                        AddedRelative = RegistrationData.OtherRelatives[value];
                    }

                }
                else
                {
                    AddedRelative = new Relative();
                }

                UpdateEditRelative(AddedRelative);
            }
        }


        private bool _IsBrother;
        public bool IsBrother
        {
            get
            {
                return _IsBrother;
            }
            set
            {
                Set(() => IsBrother, ref _IsBrother, value);
            }
        }

        private ObservableCollection<LookupData> _RelativeTribeList;
        public ObservableCollection<LookupData> RelativeTribeList
        {
            get
            {
                return _RelativeTribeList;
            }
            set
            {
                Set(() => RelativeTribeList, ref _RelativeTribeList, value);
            }
        }

        private int _SelectedRelativeTribeListIndex;
        public int SelectedRelativeTribeListIndex
        {
            get
            {
                return _SelectedRelativeTribeListIndex;
            }
            set
            {
                Set(() => SelectedRelativeTribeListIndex, ref _SelectedRelativeTribeListIndex, value);
                if (value >= 0)
                {
                    AddedRelative.SelectedTribe = RelativeTribeList[value];
                    AddedRelative.TribeID = AddedRelative.SelectedTribe.Id;
                }
            }
        }



        private ObservableCollection<LookupData> _RelativeTypesList;
        public ObservableCollection<LookupData> RelativeTypesList
        {
            get
            {
                return _RelativeTypesList;
            }
            set
            {
                Set(() => RelativeTypesList, ref _RelativeTypesList, value);
            }
        }

        private int _SelectedRelativeTypesListIndex;
        public int SelectedRelativeTypesListIndex
        {
            get
            {
                return _SelectedRelativeTypesListIndex;
            }
            set
            {
                Set(() => SelectedRelativeTypesListIndex, ref _SelectedRelativeTypesListIndex, value);
                if (value > 0)
                {

                    AddedRelative.SelectedRelativetype = RelativeTypesList[value];
                    AddedRelative.Relativetype = AddedRelative.SelectedRelativetype.Id;
                    if (AddedRelative.Relativetype == "3") //Sister or Brother
                    {
                        IsBrother = true;
                    }
                    else
                    {
                        IsBrother = false;
                    }

                    if (string.IsNullOrEmpty(AddedRelative.GHQID)) //Means  it not new relative
                    {

                        if (AddedRelative.Relativetype == "3") //Sister or Brother
                        {
                            AddedRelative.FirstName_Arabic = "";
                            AddedRelative.FirstName_English = "";
                            AddedRelative.SecondName_Arabic = RegistrationData.SecondName_Arabic;
                            AddedRelative.SecondName_English = RegistrationData.SecondName_English;
                            AddedRelative.ThirdName_Arabic = RegistrationData.ThirdName_Arabic;
                            AddedRelative.ThirdName_English = RegistrationData.ThirdName_English;
                            AddedRelative.FourthName_Arabic = RegistrationData.FourthName_Arabic;
                            AddedRelative.FourthName_English = RegistrationData.FourthName_English;
                            AddedRelative.FifthName_Arabic = RegistrationData.FifthName_Arabic;
                            AddedRelative.FifthName_English = RegistrationData.FifthName_English;
                        }
                        else if (AddedRelative.Relativetype == "5") //Son or Daughter
                        {
                            AddedRelative.FirstName_Arabic = "";
                            AddedRelative.FirstName_English = "";
                            AddedRelative.SecondName_Arabic = RegistrationData.FirstName_Arabic;
                            AddedRelative.SecondName_English = RegistrationData.FirstName_English;
                            AddedRelative.ThirdName_Arabic = RegistrationData.SecondName_Arabic;
                            AddedRelative.ThirdName_English = RegistrationData.SecondName_English;
                            AddedRelative.FourthName_Arabic = RegistrationData.ThirdName_Arabic;
                            AddedRelative.FourthName_English = RegistrationData.ThirdName_English;
                            AddedRelative.FifthName_Arabic = RegistrationData.FourthName_Arabic;
                            AddedRelative.FifthName_English = RegistrationData.FourthName_English;
                        }
                        else if (AddedRelative.Relativetype == "1") //Father
                        {
                            AddedRelative.FirstName_Arabic = RegistrationData.SecondName_Arabic;
                            AddedRelative.FirstName_English = RegistrationData.SecondName_English;
                            AddedRelative.SecondName_Arabic = RegistrationData.ThirdName_Arabic;
                            AddedRelative.SecondName_English = RegistrationData.ThirdName_English;
                            AddedRelative.ThirdName_Arabic = RegistrationData.FourthName_Arabic;
                            AddedRelative.ThirdName_English = RegistrationData.FourthName_English;
                            AddedRelative.FourthName_Arabic = RegistrationData.FifthName_Arabic;
                            AddedRelative.FourthName_English = RegistrationData.FifthName_English;
                            AddedRelative.FifthName_Arabic = "";
                            AddedRelative.FifthName_English = "";
                        }
                        else
                        {
                            AddedRelative.FirstName_Arabic = "";
                            AddedRelative.FirstName_English = "";
                            AddedRelative.SecondName_Arabic = "";
                            AddedRelative.SecondName_English = "";
                            AddedRelative.ThirdName_Arabic = "";
                            AddedRelative.ThirdName_English = "";
                            AddedRelative.FourthName_Arabic = "";
                            AddedRelative.FourthName_English = "";
                            AddedRelative.FifthName_Arabic = "";
                            AddedRelative.FifthName_English = "";
                        }
                    }
                }
            }
        }


        private ObservableCollection<LookupData> _RelativeNationalityList;
        public ObservableCollection<LookupData> RelativeNationalityList
        {
            get
            {
                return _RelativeNationalityList;
            }
            set
            {
                Set(() => RelativeNationalityList, ref _RelativeNationalityList, value);
            }
        }

        private int _SelectedRelativeNationalityListIndex;
        public int SelectedRelativeNationalityListIndex
        {
            get
            {
                return _SelectedRelativeNationalityListIndex;
            }
            set
            {
                Set(() => SelectedRelativeNationalityListIndex, ref _SelectedRelativeNationalityListIndex, value);
                if (value >= 0)
                {
                    AddedRelative.SelectedNationality = RelativeNationalityList[value];
                    AddedRelative.Nationality = AddedRelative.SelectedNationality.Id;
                }
            }
        }


        private ObservableCollection<LookupData> _RelativeStatusList;
        public ObservableCollection<LookupData> RelativeStatusList
        {
            get
            {
                return _RelativeStatusList;
            }
            set
            {
                Set(() => RelativeStatusList, ref _RelativeStatusList, value);
            }
        }

        private int _SelectedRelativeStatusListIndex;
        public int SelectedRelativeStatusListIndex
        {
            get
            {
                return _SelectedRelativeStatusListIndex;
            }
            set
            {
                Set(() => SelectedRelativeStatusListIndex, ref _SelectedRelativeStatusListIndex, value);
                if (value >= 0)
                {
                    AddedRelative.SelectedStatusOfRelative = RelativeStatusList[value];
                    AddedRelative.StatusOfRelative = AddedRelative.SelectedStatusOfRelative.Id;
                }
            }
        }

        private ObservableCollection<LookupData> _RelativeEmairtesList;
        public ObservableCollection<LookupData> RelativeEmairtesList
        {
            get
            {
                return _RelativeEmairtesList;
            }
            set
            {
                Set(() => RelativeEmairtesList, ref _RelativeEmairtesList, value);
            }
        }

        private int _SelectedRelativeEmairtesListIndex;
        public int SelectedRelativeEmairtesListIndex
        {
            get
            {
                return _SelectedRelativeEmairtesListIndex;
            }
            set
            {
                Set(() => SelectedRelativeEmairtesListIndex, ref _SelectedRelativeEmairtesListIndex, value);
                if (value >= 0)
                {
                    AddedRelative.SelectedResidencePlaceID = RelativeEmairtesList[value];
                    AddedRelative.ResidencePlaceID = AddedRelative.SelectedResidencePlaceID.Id;
                }
            }
        }

        #endregion

        #region Wife

        private Relative _AddedWife;
        public Relative AddedWife
        {
            get
            {
                return _AddedWife;
            }
            set
            {
                Set(() => AddedWife, ref _AddedWife, value);

            }
        }

        private int _SelectedWifeListIndex;
        public int SelectedWifeListIndex
        {
            get
            {
                return _SelectedWifeListIndex;
            }
            set
            {
                Set(() => SelectedWifeListIndex, ref _SelectedWifeListIndex, value);

                if (value + 1 == RegistrationData.WifeHusbandRelatives.Count() || value <= 0)
                {
                    AddedWifeAddMode = true;
                }
                else
                {
                    AddedWifeAddMode = false;
                }

                if (value > 0)
                {

                    if (RegistrationData.WifeHusbandRelatives.Count - 1 == value) //Last One
                    {
                        AddedWife = new Relative();
                    }
                    else
                    {
                        AddedWife = RegistrationData.WifeHusbandRelatives[value];
                    }

                }
                else
                {
                    AddedWife = new Relative();
                }
                UpdateEditWife(AddedWife);
            }
        }

        private bool _AddedWifeAddMode;
        public bool AddedWifeAddMode
        {
            get
            {
                return _AddedWifeAddMode;
            }
            set
            {
                Set(() => AddedWifeAddMode, ref _AddedWifeAddMode, value);

            }
        }


        private ObservableCollection<LookupData> _WifeTribeList;
        public ObservableCollection<LookupData> WifeTribeList
        {
            get
            {
                return _WifeTribeList;
            }
            set
            {
                Set(() => WifeTribeList, ref _WifeTribeList, value);
            }
        }

        private int _SelectedWifeTribeListIndex;
        public int SelectedWifeTribeListIndex
        {
            get
            {
                return _SelectedWifeTribeListIndex;
            }
            set
            {
                Set(() => SelectedWifeTribeListIndex, ref _SelectedWifeTribeListIndex, value);
                if (value >= 0)
                {
                    AddedWife.SelectedTribe = WifeTribeList[value];
                    AddedWife.TribeID = AddedWife.SelectedTribe.Id;
                }
            }
        }



        private ObservableCollection<LookupData> _WifeTypesList;
        public ObservableCollection<LookupData> WifeTypesList
        {
            get
            {
                return _WifeTypesList;
            }
            set
            {
                Set(() => WifeTypesList, ref _WifeTypesList, value);
            }
        }

        private int _SelectedWifeTypesListIndex;
        public int SelectedWifeTypesListIndex
        {
            get
            {
                return _SelectedWifeTypesListIndex;
            }
            set
            {
                Set(() => SelectedWifeTypesListIndex, ref _SelectedWifeTypesListIndex, value);
                if (value >= 0)
                {
                    if (value == 1) //Sister or Brother
                    {
                        IsBrother = true;
                    }
                    else
                    {
                        IsBrother = false;
                    }
                    AddedWife.SelectedRelativetype = WifeTypesList[value];
                    AddedWife.Relativetype = AddedWife.SelectedRelativetype.Id;

                }
            }
        }


        private ObservableCollection<LookupData> _WifeNationalityList;
        public ObservableCollection<LookupData> WifeNationalityList
        {
            get
            {
                return _WifeNationalityList;
            }
            set
            {
                Set(() => WifeNationalityList, ref _WifeNationalityList, value);
            }
        }

        private int _SelectedWifeNationalityListIndex;
        public int SelectedWifeNationalityListIndex
        {
            get
            {
                return _SelectedWifeNationalityListIndex;
            }
            set
            {
                Set(() => SelectedWifeNationalityListIndex, ref _SelectedWifeNationalityListIndex, value);
                if (value >= 0)
                {
                    AddedWife.SelectedNationality = WifeNationalityList[value];
                    AddedWife.Nationality = AddedWife.SelectedNationality.Id;
                }
            }
        }


        private ObservableCollection<LookupData> _WifeStatusList;
        public ObservableCollection<LookupData> WifeStatusList
        {
            get
            {
                return _WifeStatusList;
            }
            set
            {
                Set(() => WifeStatusList, ref _WifeStatusList, value);
            }
        }

        private int _SelectedWifeStatusListIndex;
        public int SelectedWifeStatusListIndex
        {
            get
            {
                return _SelectedWifeStatusListIndex;
            }
            set
            {
                Set(() => SelectedWifeStatusListIndex, ref _SelectedWifeStatusListIndex, value);
                if (value >= 0)
                {
                    AddedWife.SelectedStatusOfRelative = WifeStatusList[value];
                    AddedWife.StatusOfRelative = AddedWife.SelectedStatusOfRelative.Id;
                }
            }
        }

        private ObservableCollection<LookupData> _WifeEmairtesList;
        public ObservableCollection<LookupData> WifeEmairtesList
        {
            get
            {
                return _WifeEmairtesList;
            }
            set
            {
                Set(() => WifeEmairtesList, ref _WifeEmairtesList, value);
            }
        }

        private int _SelectedWifeEmairtesListIndex;
        public int SelectedWifeEmairtesListIndex
        {
            get
            {
                return _SelectedWifeEmairtesListIndex;
            }
            set
            {
                Set(() => SelectedWifeEmairtesListIndex, ref _SelectedWifeEmairtesListIndex, value);
                if (value >= 0)
                {
                    AddedWife.SelectedResidencePlaceID = WifeEmairtesList[value];
                    AddedWife.ResidencePlaceID = AddedWife.SelectedResidencePlaceID.Id;
                }
            }
        }

        #endregion

        #region Academic Qualification

        private Academicqualification _AddedAcademicqualification;
        public Academicqualification AddedAcademicqualification
        {
            get
            {
                return _AddedAcademicqualification;
            }
            set
            {
                Set(() => AddedAcademicqualification, ref _AddedAcademicqualification, value);
            }
        }


        private ObservableCollection<LookupData> _AcademicQualificationList;
        public ObservableCollection<LookupData> AcademicQualificationList
        {
            get
            {
                return _AcademicQualificationList;
            }
            set
            {
                Set(() => AcademicQualificationList, ref _AcademicQualificationList, value);
            }
        }

        private int _SelectedAcademicQualificationListIndex;
        public int SelectedAcademicQualificationListIndex
        {
            get
            {
                return _SelectedAcademicQualificationListIndex;
            }
            set
            {
                Set(() => SelectedAcademicQualificationListIndex, ref _SelectedAcademicQualificationListIndex, value);
                if (value > 0)
                {
                    if (value == 1)
                    {
                        HasAcademicQualfication = false;
                        return;
                    }
                    else
                    {
                        HasAcademicQualfication = true;
                    }
                    AddedAcademicqualification.SelectedAcademicQualification = AcademicQualificationList[value];
                    AddedAcademicqualification.AcademicQualificationID = AddedAcademicqualification.SelectedAcademicQualification.Id;
                    if (value >= 2 && value <= 10)
                    {
                        IsPreparatory = true;
                        IsSecondary = false;
                        IsHigh = false;
                    }
                    else if (value >= 11 && value <= 13)
                    {
                        IsPreparatory = false;
                        IsSecondary = true;
                        IsHigh = false;
                        PopulateHighSchoolList();
                    }
                    else
                    {
                        IsPreparatory = false;
                        IsSecondary = false;
                        IsHigh = true;
                    }
                }

            }
        }

        private bool _HasAcademicQualfication = true;
        public bool HasAcademicQualfication
        {
            get
            {
                return _HasAcademicQualfication;
            }
            set
            {
                Set(() => HasAcademicQualfication, ref _HasAcademicQualfication, value);
            }
        }


        private bool _IsPreparatory;
        public bool IsPreparatory
        {
            get
            {
                return _IsPreparatory;
            }
            set
            {
                Set(() => IsPreparatory, ref _IsPreparatory, value);
                RaisePropertyChanged("IsGradeVisible");
            }
        }

        private bool _IsSecondary;
        public bool IsSecondary
        {
            get
            {
                return _IsSecondary;
            }
            set
            {
                Set(() => IsSecondary, ref _IsSecondary, value);
                RaisePropertyChanged("IsGradeVisible");
            }
        }

        private bool _IsHigh;
        public bool IsHigh
        {
            get
            {
                return _IsHigh;
            }
            set
            {
                Set(() => IsHigh, ref _IsHigh, value);
                RaisePropertyChanged("IsGradeVisible");
            }
        }


        public bool IsGradeVisible
        {
            get
            {
                return IsSecondary || IsPreparatory;
            }
        }

        private ObservableCollection<LookupData> _AcademicCountryList;
        public ObservableCollection<LookupData> AcademicCountryList
        {
            get
            {
                return _AcademicCountryList;
            }
            set
            {
                Set(() => AcademicCountryList, ref _AcademicCountryList, value);
            }
        }

        private int _SelectedAcademicCountryListIndex;
        public int SelectedAcademicCountryListIndex
        {
            get
            {
                return _SelectedAcademicCountryListIndex;
            }
            set
            {
                Set(() => SelectedAcademicCountryListIndex, ref _SelectedAcademicCountryListIndex, value);
                if (value >= 0)
                {
                    AddedAcademicqualification.SelectedAcademicCountry = AcademicCountryList[value];
                    AddedAcademicqualification.AcademicCountryID = AddedAcademicqualification.SelectedAcademicCountry.Id;
                }
            }
        }



        private ObservableCollection<LookupData> _EducationInstitutesList;
        public ObservableCollection<LookupData> EducationInstitutesList
        {
            get
            {
                return _EducationInstitutesList;
            }
            set
            {
                Set(() => EducationInstitutesList, ref _EducationInstitutesList, value);
            }
        }

        private int _SelectedEducationInstitutesListIndex;
        public int SelectedEducationInstitutesIndex
        {
            get
            {
                return _SelectedEducationInstitutesListIndex;
            }
            set
            {
                Set(() => SelectedEducationInstitutesIndex, ref _SelectedEducationInstitutesListIndex, value);
                if (value >= 0)
                {
                    AddedAcademicqualification.SelectedEducationInstitute = EducationInstitutesList[value];
                    AddedAcademicqualification.EducationInstituteID = AddedAcademicqualification.SelectedEducationInstitute.Id;
                }
            }
        }


        private ObservableCollection<LookupData> _MajorSpecialtyList;
        public ObservableCollection<LookupData> MajorSpecialtyList
        {
            get
            {
                return _MajorSpecialtyList;
            }
            set
            {
                Set(() => MajorSpecialtyList, ref _MajorSpecialtyList, value);
            }
        }

        private int _SelectedMajorSpecialtyListIndex;
        public int SelectedMajorSpecialtyListIndex
        {
            get
            {
                return _SelectedMajorSpecialtyListIndex;
            }
            set
            {
                Set(() => SelectedMajorSpecialtyListIndex, ref _SelectedMajorSpecialtyListIndex, value);
                if (value > 0)
                {
                    AddedAcademicqualification.SelectedMainSpecialization = MajorSpecialtyList[value];
                    AddedAcademicqualification.MainSpecializationID = AddedAcademicqualification.SelectedMainSpecialization.Id;
                    PopulateSubSpecialtyList(AddedAcademicqualification.MainSpecializationID);
                }
            }
        }


        private ObservableCollection<LookupData> _SecondarySpecialtyList;
        public ObservableCollection<LookupData> SecondarySpecialtyList
        {
            get
            {
                return _SecondarySpecialtyList;
            }
            set
            {
                Set(() => SecondarySpecialtyList, ref _SecondarySpecialtyList, value);
            }
        }

        private int _SelectedSecondarySpecialtyListIndex;
        public int SelectedSecondarySpecialtyListIndex
        {
            get
            {
                return _SelectedSecondarySpecialtyListIndex;
            }
            set
            {
                Set(() => SelectedSecondarySpecialtyListIndex, ref _SelectedSecondarySpecialtyListIndex, value);
                if (value > 0)
                {
                    AddedAcademicqualification.SelectedSubSpecialization = SecondarySpecialtyList[value];
                    AddedAcademicqualification.SubSpecializationID = AddedAcademicqualification.SelectedSubSpecialization.Id;
                }
            }
        }


        private ObservableCollection<LookupData> _WorkEntityList;
        public ObservableCollection<LookupData> WorkEntityList
        {
            get
            {
                return _WorkEntityList;
            }
            set
            {
                Set(() => WorkEntityList, ref _WorkEntityList, value);
            }
        }

        private int _SelectedWorkEntityListIndex;
        public int SelectedWorkEntityListIndex
        {
            get
            {
                return _SelectedWorkEntityListIndex;
            }
            set
            {
                Set(() => SelectedWorkEntityListIndex, ref _SelectedWorkEntityListIndex, value);
                if (value >= 0)
                {
                    AddedAcademicqualification.SelectedJobLevel = WorkEntityList[value];
                    AddedAcademicqualification.JobLevel = AddedAcademicqualification.SelectedJobLevel.Id;
                }
            }
        }

        #endregion

        #region Registration attachment

        private ServiceAttachementData _AddedRegistrationattachment;
        public ServiceAttachementData AddedRegistrationattachment
        {
            get
            {
                return _AddedRegistrationattachment;
            }
            set
            {
                Set(() => AddedRegistrationattachment, ref _AddedRegistrationattachment, value);
                //UpdateEditAcademicQualification(value);
            }
        }

        private ObservableCollection<ServiceAttachementData> _ServiceAttachementData;
        public ObservableCollection<ServiceAttachementData> ServiceAttachementData
        {
            get
            {
                return _ServiceAttachementData;
            }
            set
            {
                Set(() => ServiceAttachementData, ref _ServiceAttachementData, value);
            }
        }



        #endregion

        #endregion

        #region Private Methods

        #region BRE

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetTypeInfo().GetDeclaredProperty(propName);
        }

        private void UpdateBuisnessRuleValidation()
        {
            RegistrationData.VisibilitiesAndRequiredFeilds = new VisibilitiesAndRequiredFeilds();
            foreach (var item in BREList)
            {
                object isRequried = GetPropValue(RegistrationData.VisibilitiesAndRequiredFeilds, item.ControlName + "_IsRequired");
                if (isRequried != null)
                {
                    bool isRequriedValue = bool.Parse(item.IsRequired.ToString());
                    DependencyService.Get<IReflection>().SetProperty(RegistrationData.VisibilitiesAndRequiredFeilds, item.ControlName + "_IsRequired", isRequriedValue);
                }
                object isVisible = GetPropValue(RegistrationData.VisibilitiesAndRequiredFeilds, item.ControlName + "_IsVisible");
                if (isVisible != null)
                {
                    bool isVisibleValue = bool.Parse(item.IsVisibleForMobile.ToString());
                    DependencyService.Get<IReflection>().SetProperty(RegistrationData.VisibilitiesAndRequiredFeilds, item.ControlName + "_IsVisible", isVisibleValue);
                }
            }
        }

        #endregion

        #region Personal Information

        public async Task LoadPersonalInformationData()
        {
            ClearValidationErrors();
            IsLoading = true;
            await PopulateCommonLookups();
            await PopulateGenders();
            await PopulateNationality();
            await PopulateMaritalStatus();
            await PopulatePassportIssuanceLocation();
            await PopulateTibes();
            await PopulatePassportTypes();
            await PopulateAreaAndRegions();
            UpdateEditPersonalInformation();
            IsLoading = false;
        }

        private void UpdateEditPersonalInformation()
        {
            if (string.IsNullOrEmpty(RegistrationData.WorkStatusID))
            {
                SelectedWorkStateListItem = WorkStateList.FirstOrDefault();
            }
            else
            {
                SelectedWorkStateListItem = WorkStateList.FirstOrDefault(a => a.Id == RegistrationData.WorkStatusID);
            }


            if (string.IsNullOrEmpty(RegistrationData.Gender))
            {
                RegistrationData.SelectedGender = GenderList.FirstOrDefault();
            }
            else
            {
                RegistrationData.SelectedGender = GenderList.FirstOrDefault(a => a.Id == RegistrationData.Gender);
            }

            if (string.IsNullOrEmpty(RegistrationData.NationalityGain))
            {
                RegistrationData.SelectedNationalityGain = NationalityGainList.FirstOrDefault();
            }
            else
            {
                RegistrationData.SelectedNationalityGain = NationalityGainList.FirstOrDefault(a => a.Id == RegistrationData.NationalityGain);
            }

            if (string.IsNullOrEmpty(RegistrationData.PreviousNationality))
            {
                RegistrationData.SelectedPreviousNationality = NationalityPreviousList.FirstOrDefault();
            }
            else
            {
                RegistrationData.SelectedPreviousNationality = NationalityPreviousList.FirstOrDefault(a => a.Id == RegistrationData.PreviousNationality);
            }


            if (string.IsNullOrEmpty(RegistrationData.TribeID))
            {
                RegistrationData.SelecteTribe = TribeList.FirstOrDefault();
            }
            else
            {
                RegistrationData.SelecteTribe = TribeList.FirstOrDefault(a => a.Id == RegistrationData.TribeID);
            }


            if (string.IsNullOrEmpty(RegistrationData.MaritalStatus))
            {
                RegistrationData.SelectedMaritalStatus = MaritalStatusList.FirstOrDefault();
            }
            else
            {
                RegistrationData.SelectedMaritalStatus = MaritalStatusList.FirstOrDefault(a => a.Id == RegistrationData.MaritalStatus);
            }


            if (string.IsNullOrEmpty(RegistrationData.PassportType))
            {
                RegistrationData.SelectedPassportType = PassportTypeList.FirstOrDefault();
            }
            else
            {
                RegistrationData.SelectedPassportType = PassportTypeList.FirstOrDefault(a => a.Id == RegistrationData.PassportType);
            }

            if (string.IsNullOrEmpty(RegistrationData.PassportIssuePlace))
            {
                RegistrationData.SelectedPassportIssuePlace = PassportIssuanceLocationList.FirstOrDefault();
            }
            else
            {
                RegistrationData.SelectedPassportIssuePlace = PassportIssuanceLocationList.FirstOrDefault(a => a.Id == RegistrationData.PassportIssuePlace);
            }


            if (string.IsNullOrEmpty(RegistrationData.OriginalCity))
            {
                RegistrationData.SelectedOriginalCity = EmiratesList.FirstOrDefault();
            }
            else
            {
                RegistrationData.SelectedOriginalCity = EmiratesList.FirstOrDefault(a => a.Id == RegistrationData.OriginalCity);
            }
        }

        async Task PopulateCommonLookups()
        {
            try
            {
                if (WorkStateList == null)
                {
                    WorkStateList = new ObservableCollection<LookupData>(await lookupService.GetWorkTypesAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateGenders()
        {
            try
            {
                if (GenderList == null)
                {
                    GenderList = new ObservableCollection<LookupData>(await lookupService.GetGenderAsync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateNationality()
        {

            try
            {
                if (NationalityGainList == null)
                {
                    var nationalities = await lookupService.GetNationalityAsync();
                    NationalityGainList = new ObservableCollection<LookupData>(nationalities);
                    NationalityPreviousList = new ObservableCollection<LookupData>(nationalities);
                    RelativeNationalityList = new ObservableCollection<LookupData>(nationalities);
                    WifeNationalityList = new ObservableCollection<LookupData>(nationalities);
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateMaritalStatus()
        {
            try
            {
                if (MaritalStatusList == null)
                {
                    MaritalStatusList = new ObservableCollection<LookupData>(await lookupService.GetMaritalStatusAsync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateTibes()
        {
            try
            {
                if (TribeList == null)
                {
                    var tribes = await lookupService.GetTribeAsync();
                    TribeList = new ObservableCollection<LookupData>(tribes);
                    RelativeTribeList = new ObservableCollection<LookupData>(tribes);
                    WifeTribeList = new ObservableCollection<LookupData>(tribes);
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

        async Task PopulateAreaAndRegions()
        {
            try
            {
                if (CitiesList == null)
                {
                    var emirates = await lookupService.GetEmiratesAync();
                    EmiratesList = new ObservableCollection<LookupData>(emirates);
                    RelativeEmairtesList = new ObservableCollection<LookupData>(emirates);
                    WifeEmairtesList = new ObservableCollection<LookupData>(emirates);
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateWorkDetails()
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

        #endregion

        #region Address

        public async Task LoadAddressData()
        {
            ClearValidationErrors();
            IsLoading = true;
            await PopulateAddressAreaAndRegions();
            AddedAddress = RegistrationData.Addresses?.Count() > 0 ? RegistrationData.Addresses.FirstOrDefault() : new Address();
            UpdateEditAddress(AddedAddress);
            IsLoading = false;
        }

        private void UpdateEditAddress(Address value)
        {
            if (string.IsNullOrEmpty(value.CityID))
            {
                AddedAddress.SelectedCity = CitiesList.FirstOrDefault();
            }
            else
            {
                AddedAddress.SelectedCity = CitiesList.FirstOrDefault(a => a.Id == value.CityID);
            }
            AddedAddress.CityID = AddedAddress.SelectedCity.Id;

            RegionList = new ObservableCollection<LookupData>(AllRegionList.Where(a => a.LookupValueParentID == AddedAddress.SelectedCity.Id));

            if (string.IsNullOrEmpty(value.RegionID))
            {
                AddedAddress.SelectedRegion = RegionList.FirstOrDefault();
            }
            else
            {
                AddedAddress.SelectedRegion = RegionList.FirstOrDefault(a => a.Id == value.RegionID);
            }
            AddedAddress.RegionID = AddedAddress.SelectedCity.Id;
        }

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

        #endregion

        #region Work

        public async Task LoadWorkData()
        {
            ClearValidationErrors();
            IsLoading = true;
            await PopulateWorkOrgTypes();
            await PopulateWorkOrgCity();
            await PopulateMilitartTypes();
            await PopulatEducationType();
            AddedWork = RegistrationData?.Work?.Count() > 0 ? RegistrationData?.Work.FirstOrDefault() : new Work();
            UpdateEditWork(AddedWork);
            IsLoading = false;
        }

        private void UpdateEditWork(Work value)
        {
            if (string.IsNullOrEmpty(value.WorkOrgCityID))
            {
                AddedWork.SelectedWorkOrgCity = WorkOrgCityList.FirstOrDefault();

            }
            else
            {
                AddedWork.SelectedWorkOrgCity = WorkOrgCityList.FirstOrDefault(a => a.Id == value.WorkOrgCityID);
            }
            AddedWork.WorkOrgCityID = AddedWork.SelectedWorkOrgCity.Id;

            if (string.IsNullOrEmpty(value.WorkOrgTypeID))
            {
                AddedWork.SelectedWorkOrgType = WorkOrgTypeList.FirstOrDefault();
            }
            else
            {
                AddedWork.SelectedWorkOrgType = WorkOrgTypeList.FirstOrDefault(a => a.Id == value.WorkOrgTypeID);
            }
            AddedWork.WorkOrgTypeID = AddedWork.SelectedWorkOrgType.Id;

            if (string.IsNullOrEmpty(value.EducationInstituteID))
            {
                AddedWork.SelectedEducationInstitute = EducationTypeList.FirstOrDefault();
            }
            else
            {
                AddedWork.SelectedEducationInstitute = EducationTypeList.FirstOrDefault(a => a.Id == value.EducationInstituteID);
            }

            AddedWork.EducationInstituteID = AddedWork.SelectedEducationInstitute.Id;

            if (string.IsNullOrEmpty(value.MilitaryEntityID))
            {
                AddedWork.SelectedMilitaryEntity = MilitartTypeList.FirstOrDefault();
            }
            else
            {
                AddedWork.SelectedMilitaryEntity = MilitartTypeList.FirstOrDefault(a => a.Id == value.MilitaryEntityID);
            }
            AddedWork.MilitaryEntityID = AddedWork.SelectedMilitaryEntity.Id;
        }

        async Task PopulateWorkOrgTypes()
        {
            try
            {
                if (WorkOrgTypeList == null)
                {
                    WorkOrgTypeList = new ObservableCollection<LookupData>(await lookupService.GetWorkEntityTypeAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateWorkOrgCity()
        {
            try
            {
                if (WorkOrgCityList == null)
                {
                    WorkOrgCityList = new ObservableCollection<LookupData>(await lookupService.GetEmiratesAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateMilitartTypes()
        {
            try
            {
                if (MilitartTypeList == null)
                {
                    MilitartTypeList = new ObservableCollection<LookupData>(await lookupService.GetMilitaryTypes());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulatEducationType()
        {
            try
            {
                if (EducationTypeList == null)
                {
                    EducationTypeList = new ObservableCollection<LookupData>(await lookupService.GetEducationInstitutesAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Relatives

        public async Task LoadRelativesData()
        {
            ClearValidationErrors();
            IsLoading = true;
            await PopulateRelativeTypes();
            await PopulateRelativeStatus();
            AddedRelative = RegistrationData.OtherRelatives?.Count() > 0 ? RegistrationData.OtherRelatives.FirstOrDefault() : new Relative();
            UpdateEditRelative(AddedRelative);
            IsLoading = false;
        }

        private void UpdateEditRelative(Relative value)
        {
            if (value == null)
                return;
            AddedRelative.IsAliveValue = value.IsAlive.HasValue ? value.IsAlive.Value : false;
            AddedRelative.IsBrotherValue = value.IsBrother.HasValue ? value.IsBrother.Value : false;
            if (string.IsNullOrEmpty(value.TribeID))
            {
                AddedRelative.SelectedTribe = RelativeTribeList.FirstOrDefault();
            }
            else
            {
                AddedRelative.SelectedTribe = RelativeTribeList.FirstOrDefault(a => a.Id == value.TribeID);
            }

            if (string.IsNullOrEmpty(value.Relativetype))
            {
                AddedRelative.SelectedRelativetype = RelativeTypesList.FirstOrDefault();
            }
            else
            {
                AddedRelative.SelectedRelativetype = RelativeTypesList.FirstOrDefault(a => a.Id == value.Relativetype);
            }

            if (string.IsNullOrEmpty(value.StatusOfRelative))
            {
                AddedRelative.SelectedStatusOfRelative = RelativeStatusList.FirstOrDefault();
            }
            else
            {
                AddedRelative.SelectedStatusOfRelative = RelativeStatusList.FirstOrDefault(a => a.Id == value.StatusOfRelative);
            }


            if (string.IsNullOrEmpty(value.ResidencePlaceID))
            {
                AddedRelative.SelectedResidencePlaceID = RelativeEmairtesList.FirstOrDefault();
            }
            else
            {
                AddedRelative.SelectedResidencePlaceID = RelativeEmairtesList.FirstOrDefault(a => a.Id == value.ResidencePlaceID);
            }

            if (string.IsNullOrEmpty(value.Nationality))
            {
                AddedRelative.SelectedNationality = RelativeNationalityList.FirstOrDefault();
            }
            else
            {
                AddedRelative.SelectedNationality = RelativeNationalityList.FirstOrDefault(a => a.Id == value.Nationality);
            }
            //RegistrationData.UpdateRelatives();
        }

        async Task PopulateRelativeTypes()
        {
            try
            {
                if (RelativeTypesList == null)
                {
                    var types = await lookupService.GetRelativesTypesAync();
                    var wifeType = types.FirstOrDefault(a => a.Id == "4");
                    types.Remove(wifeType);
                    RelativeTypesList = new ObservableCollection<LookupData>(types);
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateRelativeStatus()
        {
            try
            {
                if (RelativeStatusList == null)
                {
                    RelativeStatusList = new ObservableCollection<LookupData>(await lookupService.GetRelativesStatusAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Wife

        public async Task LoadWifesData()
        {
            ClearValidationErrors();
            IsLoading = true;
            await PopulateWifeTypes();
            await PopulateWifeStatus();
            AddedWife = RegistrationData.WifeHusbandRelatives?.Count() > 0 ? RegistrationData.WifeHusbandRelatives.FirstOrDefault() : new Relative();
            UpdateEditWife(AddedWife);
            IsLoading = false;
        }

        private void UpdateEditWife(Relative value)
        {
            if (value == null)
                return;
            AddedWife.IsAliveValue = value.IsAlive.HasValue ? value.IsAlive.Value : false;
            AddedWife.SelectedRelativetype = WifeTypesList == null ? null : WifeTypesList.FirstOrDefault();
            if (string.IsNullOrEmpty(value.TribeID))
            {
                AddedWife.SelectedTribe = WifeTribeList.FirstOrDefault();
            }
            else
            {
                AddedWife.SelectedTribe = WifeTribeList.FirstOrDefault(a => a.Id == value.TribeID);
            }

            if (string.IsNullOrEmpty(value.StatusOfRelative))
            {
                AddedWife.SelectedStatusOfRelative = WifeStatusList.FirstOrDefault();
            }
            else
            {
                AddedWife.SelectedStatusOfRelative = WifeStatusList.FirstOrDefault(a => a.Id == value.StatusOfRelative);
            }


            if (string.IsNullOrEmpty(value.ResidencePlaceID))
            {
                AddedWife.SelectedResidencePlaceID = WifeEmairtesList.FirstOrDefault();
            }
            else
            {
                AddedWife.SelectedResidencePlaceID = WifeEmairtesList.FirstOrDefault(a => a.Id == value.ResidencePlaceID);
            }

            if (string.IsNullOrEmpty(value.Nationality))
            {
                AddedWife.SelectedNationality = WifeNationalityList.FirstOrDefault();
            }
            else
            {
                AddedWife.SelectedNationality = WifeNationalityList.FirstOrDefault(a => a.Id == value.Nationality);
            }
            // RegistrationData.UpdateWifes();
        }

        async Task PopulateWifeTypes()
        {
            try
            {
                if (WifeTypesList == null)
                {
                    var allTypes = await lookupService.GetRelativesTypesAync();
                    WifeTypesList = new ObservableCollection<LookupData>(allTypes.Where(a => a.Id == "4"));
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateWifeStatus()
        {
            try
            {
                if (WifeStatusList == null)
                {
                    WifeStatusList = new ObservableCollection<LookupData>(await lookupService.GetRelativesStatusAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Academic Qualification

        public async Task LoadAcademicQualificationData()
        {
            ClearValidationErrors();
            IsLoading = true;
            await PopulateAcademicQualification();
            await PopulateAcademicCountryList();
            await PopulateEducationInstitutesList();
            await PopulateMajorSpecialtyList();
            await PopulateWorkEntityList();
            AddedAcademicqualification = RegistrationData.AcademicQualifications?.Count() > 0 ? RegistrationData.AcademicQualifications.FirstOrDefault() : new Academicqualification();
            UpdateEditAcademicQualification(AddedAcademicqualification);
            IsLoading = false;
        }

        private void UpdateEditAcademicQualification(Academicqualification value)
        {
            AddedAcademicqualification.ISEducationFinishedValue = value.ISEducationFinished.HasValue ? value.ISEducationFinished.Value : false;
            if (string.IsNullOrEmpty(value.AcademicCountryID))
            {
                AddedAcademicqualification.SelectedAcademicCountry = AcademicCountryList.FirstOrDefault();
            }
            else
            {
                AddedAcademicqualification.SelectedAcademicCountry = AcademicCountryList.FirstOrDefault(a => a.Id == value.AcademicCountryID);
            }
            AddedAcademicqualification.AcademicCountryID = AddedAcademicqualification.SelectedAcademicCountry.Id;
            if (string.IsNullOrEmpty(value.AcademicQualificationID))
            {
                AddedAcademicqualification.SelectedAcademicQualification = AcademicQualificationList.FirstOrDefault();
            }
            else
            {
                AddedAcademicqualification.SelectedAcademicQualification = AcademicQualificationList.FirstOrDefault(a => a.Id == value.AcademicQualificationID);
            }
            AddedAcademicqualification.AcademicQualificationID = AddedAcademicqualification.SelectedAcademicQualification.Id;

            if (string.IsNullOrEmpty(value.EducationInstituteID))
            {
                AddedAcademicqualification.SelectedEducationInstitute = EducationInstitutesList.FirstOrDefault();
            }
            else
            {
                AddedAcademicqualification.SelectedEducationInstitute = EducationInstitutesList.FirstOrDefault(a => a.Id == value.EducationInstituteID);
            }
            AddedAcademicqualification.EducationInstituteID = AddedAcademicqualification?.SelectedEducationInstitute?.Id;

            if (string.IsNullOrEmpty(value.MainSpecializationID))
            {
                AddedAcademicqualification.SelectedMainSpecialization = MajorSpecialtyList.FirstOrDefault();
            }
            else
            {
                AddedAcademicqualification.SelectedMainSpecialization = MajorSpecialtyList.FirstOrDefault(a => a.Id == value.MainSpecializationID);
            }
            AddedAcademicqualification.MainSpecializationID = AddedAcademicqualification.SelectedMainSpecialization.Id;
            //if (string.IsNullOrEmpty(value.JobLevel))
            //{
            //    AddedAcademicqualification.SelectedJobLevel = WorkEntityList.FirstOrDefault();
            //}
            //else
            //{
            //    AddedAcademicqualification.SelectedJobLevel = WorkEntityList.FirstOrDefault(a => a.Id == value.JobLevel);
            //}

        }

        async Task PopulateAcademicQualification()
        {
            try
            {
                if (AcademicQualificationList == null)
                {
                    AcademicQualificationList = new ObservableCollection<LookupData>(await lookupService.GetAcademicQualificationAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateEducationInstitutesList()
        {
            try
            {
                if (EducationInstitutesList == null)
                {
                    EducationInstitutesList = new ObservableCollection<LookupData>(await lookupService.GetEducationInstitutesAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateAcademicCountryList()
        {
            try
            {
                if (AcademicCountryList == null)
                {
                    AcademicCountryList = new ObservableCollection<LookupData>(await lookupService.GetCountriesnAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateMajorSpecialtyList()
        {
            try
            {
                if (MajorSpecialtyList == null)
                {
                    MajorSpecialtyList = new ObservableCollection<LookupData>(await lookupService.GetMajorSpecialtyAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateHighSchoolList()
        {
            try
            {
                SecondarySpecialtyList = new ObservableCollection<LookupData>(await lookupService.GetHighShcoolAync());
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateSubSpecialtyList(string major)
        {
            try
            {
                var sub = await lookupService.GetSecondarySpecialtyAync(major);
                SecondarySpecialtyList = new ObservableCollection<LookupData>(sub);
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        async Task PopulateWorkEntityList()
        {
            try
            {
                if (WorkEntityList == null)
                {
                    WorkEntityList = new ObservableCollection<LookupData>(await lookupService.GetWorkEntityAync());
                }
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Attachments

        public async Task LoadAttachmentsData()
        {
            ClearValidationErrors();
            IsLoading = true;
            ServiceAttachementData = new ObservableCollection<Models.Data.Registration.ServiceAttachementData>(await serviceRegistrationService.GetServiceAttachement());
            if (ServiceAttachementData != null)
            {
                foreach (var item in ServiceAttachementData)
                {
                    var attchament = RegistrationData.RegistrationAttachments.Where(a => a.ServiceAttachmentID == item.ServiceAttachmentID);
                    item.Attachment = attchament.FirstOrDefault();
                }
            }

            IsLoading = false;
        }

        #endregion

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
                //In case of Image picker opened
                if (Locator.Default.NavigationService.IsExternalAppOpen)
                {
                    return;
                }
                ClearValidationErrors();
                IsLoading = true;
                IsPageEnabled = false;

                BREList = await serviceRegistrationService.GetBRConfiguration();
                RegistrationData = await serviceRegistrationService.GetCandidateInfoByEmiratesId(accountService.AccessToken);

                if (RegistrationData != null)
                {
                    var tempRelative = new Relative() { FirstName_Arabic = "إضافة بيانات الأقارب" };
                    var tempWife = new Relative() { FirstName_Arabic = "إضافة بيانات  الزوج / الزوجة " };
                    RegistrationData.OtherRelatives = new ObservableCollection<Relative>(RegistrationData.Relatives.Where(a => a.Relativetype != "4").ToList());
                    RegistrationData.OtherRelatives.Insert(0, new Relative() { FirstName_Arabic = AppResources.NewAccount_Combo_Placeholder, GHQID = "-1" });
                    if (RegistrationData.OtherRelatives.Any())
                    {
                        int lastRelativeIndex = RegistrationData.OtherRelatives.Count;
                        RegistrationData.OtherRelatives.Insert(lastRelativeIndex, tempRelative);
                    }
                    else
                    {
                        RegistrationData.OtherRelatives.Add(tempRelative);
                    }

                    RegistrationData.WifeHusbandRelatives = new ObservableCollection<Relative>(RegistrationData.Relatives.Where(a => a.Relativetype == "4").ToList());
                    RegistrationData.WifeHusbandRelatives.Insert(0, new Relative() { FirstName_Arabic = AppResources.NewAccount_Combo_Placeholder, GHQID = "-1" });
                    if (RegistrationData.WifeHusbandRelatives.Any())
                    {
                        int lastRelativeIndex = RegistrationData.WifeHusbandRelatives.Count;
                        RegistrationData.WifeHusbandRelatives.Insert(lastRelativeIndex, tempWife);
                    }
                    else
                    {
                        RegistrationData.WifeHusbandRelatives.Add(tempWife);
                    }

                    UpdateBuisnessRuleValidation();

                    await LoadPersonalInformationData();
                }

                IsPageEnabled = true;
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

        #region First Step

        #region OnNextFirstStepCommand

        private RelayCommand _OnStep1SaveCommand;
        public RelayCommand OnStep1SaveCommand
        {
            get
            {
                if (_OnStep1SaveCommand == null)
                {
                    _OnStep1SaveCommand = new RelayCommand(OnStep1Save);
                }
                return _OnStep1SaveCommand;
            }
        }
        private async void OnStep1Save()
        {
            try
            {
                if (IsLoading)
                {
                    return;
                }
                IsLoading = true;
                IsPageEnabled = false;
                ClearValidationErrors();


                ValidationErrors = new ObservableCollection<ValidatedModel>(RegistrationData.Validate());

                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    var result = await serviceRegistrationService.UpdateCandidateData(RegistrationData, SelectedWorkStateListItem?.Id, accountService.AccessToken);
                    IsLoading = false;
                    if (result)
                    {
                        await dialogService.DisplayAlert("", AppResources.ServiceRegistration_AccountSaved);
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

        #region Second Step

        #region OnStep2SaveCommand

        private RelayCommand _OnStep2SaveCommand;
        public RelayCommand OnStep2SaveCommand
        {
            get
            {
                if (_OnStep2SaveCommand == null)
                {
                    _OnStep2SaveCommand = new RelayCommand(OnStep2Save);
                }
                return _OnStep2SaveCommand;
            }
        }
        private async void OnStep2Save()
        {
            try
            {
                if (IsLoading)
                {
                    return;
                }
                IsLoading = true;
                IsPageEnabled = false;
                ClearValidationErrors();
                ValidationErrors = new ObservableCollection<ValidatedModel>(AddedWork.Validate(SelectedWorkStateListItem.Id == "Working", RegistrationData.VisibilitiesAndRequiredFeilds, IsPrivate, IsMilitary));

                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    var result = await serviceRegistrationService.UpdateWorkData(AddedWork, RegistrationData?.SelectedMaritalStatus?.Id, SelectedWorkStateListItem?.Id, accountService.AccessToken);
                    IsLoading = false;
                    if (result)
                    {
                        if (RegistrationData.Work.Any())
                        {
                            RegistrationData.Work[0] = AddedWork;
                        }
                        else
                        {
                            RegistrationData.Work = new List<Work>();
                            RegistrationData.Work.Add(AddedWork);
                        }
                        await dialogService.DisplayAlert("", AppResources.ServiceRegistration_AccountSaved);
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

        #region Third Step

        #region OnStep3SaveCommand

        private RelayCommand _OnStep3SaveCommand;
        public RelayCommand OnStep3SaveCommand
        {
            get
            {
                if (_OnStep3SaveCommand == null)
                {
                    _OnStep3SaveCommand = new RelayCommand(OnStep3Save);
                }
                return _OnStep3SaveCommand;
            }
        }
        private async void OnStep3Save()
        {
            try
            {
                if (IsLoading)
                {
                    return;
                }
                IsLoading = true;
                IsPageEnabled = false;
                ClearValidationErrors();
                ValidationErrors = new ObservableCollection<ValidatedModel>(AddedAddress.Validate(RegistrationData.VisibilitiesAndRequiredFeilds));

                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    var result = await serviceRegistrationService.UpdateAddress(AddedAddress, RegistrationData?.SelectedMaritalStatus?.Id, SelectedWorkStateListItem?.Id, accountService.AccessToken);
                    IsLoading = false;
                    if (result)
                    {
                        if (RegistrationData.Addresses.Any())
                        {
                            RegistrationData.Addresses[0] = AddedAddress;
                        }
                        else
                        {
                            RegistrationData.Addresses = new List<Address>();
                            RegistrationData.Addresses.Add(AddedAddress);
                        }
                        await dialogService.DisplayAlert("", AppResources.ServiceRegistration_AccountSaved);
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

        #region Fourth Step

        #region OnAddNewRelativeCommand

        private RelayCommand _OnAddNewRelativeCommand;
        public RelayCommand OnAddNewRelativeCommand
        {
            get
            {
                if (_OnAddNewRelativeCommand == null)
                {
                    _OnAddNewRelativeCommand = new RelayCommand(OnAddNewRelative);
                }
                return _OnAddNewRelativeCommand;
            }
        }
        private async void OnAddNewRelative()
        {
            ValidationErrors = new ObservableCollection<ValidatedModel>(AddedRelative.Validate(RegistrationData.VisibilitiesAndRequiredFeilds));

            if (ValidationErrors.Any())
            {
                await dialogService.DisplayAlert("", ErrorMessagesString);
            }
            else if (!ValidationErrors.Any())
            {
                if (string.IsNullOrEmpty(AddedRelative.GHQID))
                {

                    AddedRelative.GHQID = "Local";
                    var lastRelativeIndex = RegistrationData.OtherRelatives.Count;
                    RegistrationData.OtherRelatives.RemoveAt(--lastRelativeIndex);
                    RegistrationData.OtherRelatives.Add(AddedRelative);
                    RegistrationData.OtherRelatives.Add(new Relative() { FirstName_Arabic = "إضافة بيانات الأقارب" });
                    AddedRelative = new Relative();
                    RegistrationData.UpdateRelatives();

                }
                else
                {
                    int removedRelativeIndex = RegistrationData.OtherRelatives.IndexOf(AddedRelative);
                    RegistrationData.OtherRelatives[removedRelativeIndex] = AddedRelative;
                    AddedRelative = new Relative();
                }
            }
        }

        #endregion

        #region OnDeleteRelativeCommand

        private RelayCommand _OnDeleteRelativeCommand;
        public RelayCommand OnDeleteRelativeCommand
        {
            get
            {
                if (_OnDeleteRelativeCommand == null)
                {
                    _OnDeleteRelativeCommand = new RelayCommand(OnDeleteRelative);
                }
                return _OnDeleteRelativeCommand;
            }
        }
        private async void OnDeleteRelative()
        {
            var status = await dialogService.DisplayActionSheet(AppResources.ServiceRegistration_DeleteRelativeMessage_Title, null, null, AppResources.Yes, AppResources.No);
            if (status == AppResources.Yes)
            {
                int removedRelativeIndex = RegistrationData.OtherRelatives.IndexOf(AddedRelative);
                AddedRelative.IsDeleted = true;
                RegistrationData.OtherRelatives[removedRelativeIndex] = AddedRelative;
                RegistrationData.UpdateRelatives();
                AddedRelative = new Relative();
            }
        }

        #endregion

        #region OnStep4SaveCommand

        private RelayCommand _OnStep4SaveCommand;
        public RelayCommand OnStep4SaveCommand
        {
            get
            {
                if (_OnStep4SaveCommand == null)
                {
                    _OnStep4SaveCommand = new RelayCommand(OnStep4Save);
                }
                return _OnStep4SaveCommand;
            }
        }
        private async void OnStep4Save()
        {
            try
            {
                if (IsLoading || RegistrationData.OtherRelatives.Count <= 0)
                {
                    return;
                }
                IsLoading = true;
                IsPageEnabled = false;
                ClearValidationErrors();
                var toSavedList = RegistrationData.OtherRelatives.ToList().GetRange(1, RegistrationData.OtherRelatives.Count - 2);
                var fatherMother = toSavedList.Where(a => a.Relativetype == "1" || a.Relativetype == "2");
                if (fatherMother.Count() >= 2)
                {
                    bool onlySon = false;
                    if (toSavedList.Count() == 2)
                    {
                        var status = await dialogService.DisplayActionSheet(AppResources.ServiceRegistration_OnlySon, null, null, AppResources.Yes, AppResources.No);
                        if (status == AppResources.Yes)
                        {

                            onlySon = true;
                        }
                        else
                        {
                            await dialogService.DisplayAlert("", AppResources.ServiceRegistration_HaveOtherSon);
                        }

                    }
                    var result = await serviceRegistrationService.UpdateRelative(toSavedList, RegistrationData?.SelectedMaritalStatus?.Id, SelectedWorkStateListItem?.Id, onlySon, accountService.AccessToken);
                    IsLoading = false;
                    if (result)
                    {
                        await dialogService.DisplayAlert("", AppResources.ServiceRegistration_AccountSaved);
                    }
                    else
                    {
                        await dialogService.DisplayAlert(AppResources.Error, AppResources.Error_NoDataFound);
                    }
                }
                else
                {
                    var hasFather = toSavedList.Where(a => a.Relativetype == "1");
                    if (hasFather == null)
                    {
                        await dialogService.DisplayAlert(AppResources.Error, AppResources.ServiceRegistration_FatherMandatory);
                    }
                    else
                    {
                        await dialogService.DisplayAlert(AppResources.Error, AppResources.ServiceRegistration_MotherMandatory);
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

        #region Fifth Step

        #region OnAddNewWifeCommand

        private RelayCommand _OnAddNewWifeCommand;
        public RelayCommand OnAddNewWifeCommand
        {
            get
            {
                if (_OnAddNewWifeCommand == null)
                {
                    _OnAddNewWifeCommand = new RelayCommand(OnAddNewWife);
                }
                return _OnAddNewWifeCommand;
            }
        }
        private async void OnAddNewWife()
        {
            ValidationErrors = new ObservableCollection<ValidatedModel>(AddedWife.Validate(RegistrationData.VisibilitiesAndRequiredFeilds));

            if (ValidationErrors.Any())
            {
                await dialogService.DisplayAlert("", ErrorMessagesString);
            }
            else if (!ValidationErrors.Any())
            {
                if (string.IsNullOrEmpty(AddedWife.GHQID))
                {

                    AddedWife.GHQID = "Local";
                    AddedWife.Relativetype = "4";
                    var lastRelativeIndex = RegistrationData.WifeHusbandRelatives.Count;
                    RegistrationData.WifeHusbandRelatives.RemoveAt(--lastRelativeIndex);
                    RegistrationData.WifeHusbandRelatives.Add(AddedWife);
                    RegistrationData.WifeHusbandRelatives.Add(new Relative() { FirstName_Arabic = "إضافة بيانات  الزوج / الزوجة " });
                    AddedWife = new Relative();
                    RegistrationData.UpdateWifes();

                }
                else
                {
                    int removedRelativeIndex = RegistrationData.WifeHusbandRelatives.IndexOf(AddedWife);
                    RegistrationData.WifeHusbandRelatives[removedRelativeIndex] = AddedWife;
                    AddedWife = new Relative();
                }
            }
        }

        #endregion

        #region OnDeleteWifeCommand

        private RelayCommand _OnDeleteWifeCommand;
        public RelayCommand OnDeleteWifeCommand
        {
            get
            {
                if (_OnDeleteWifeCommand == null)
                {
                    _OnDeleteWifeCommand = new RelayCommand(OnDeleteWife);
                }
                return _OnDeleteWifeCommand;
            }
        }
        private async void OnDeleteWife()
        {
            var status = await dialogService.DisplayActionSheet(AppResources.ServiceRegistration_DeleteRelativeMessage_Title, null, null, AppResources.Yes, AppResources.No);
            if (status == AppResources.Yes)
            {
                int removedRelativeIndex = RegistrationData.WifeHusbandRelatives.IndexOf(AddedWife);
                AddedWife.IsDeleted = true;
                RegistrationData.WifeHusbandRelatives[removedRelativeIndex] = AddedWife;
                RegistrationData.UpdateWifes();
                AddedWife = new Relative();
            }

        }

        #endregion

        #region OnStep5SaveCommand

        private RelayCommand _OnStep5SaveCommand;
        public RelayCommand OnStep5SaveCommand
        {
            get
            {
                if (_OnStep5SaveCommand == null)
                {
                    _OnStep5SaveCommand = new RelayCommand(OnStep5Save);
                }
                return _OnStep5SaveCommand;
            }
        }
        private async void OnStep5Save()
        {
            try
            {
                if (IsLoading || RegistrationData.WifeHusbandRelatives.Count <= 0)
                {
                    return;
                }
                IsLoading = true;
                IsPageEnabled = false;
                ClearValidationErrors();
                var toSavedList = RegistrationData.WifeHusbandRelatives.ToList().GetRange(1, RegistrationData.WifeHusbandRelatives.Count - 2);

                var result = await serviceRegistrationService.UpdateRelative(toSavedList, RegistrationData?.SelectedMaritalStatus?.Id, SelectedWorkStateListItem?.Id, false, accountService.AccessToken);
                IsLoading = false;
                if (result)
                {
                    await dialogService.DisplayAlert("", AppResources.ServiceRegistration_AccountSaved);
                }
                else
                {
                    await dialogService.DisplayAlert(AppResources.Error, AppResources.Error_NoDataFound);
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

        #region Sixth Step

        #region OnStep6SaveCommand

        private RelayCommand _OnStep6SaveCommand;
        public RelayCommand OnStep6SaveCommand
        {
            get
            {
                if (_OnStep6SaveCommand == null)
                {
                    _OnStep6SaveCommand = new RelayCommand(OnStep6Save);
                }
                return _OnStep6SaveCommand;
            }
        }
        private async void OnStep6Save()
        {
            try
            {
                ValidationErrors = new ObservableCollection<ValidatedModel>(AddedAcademicqualification.Validate(RegistrationData.VisibilitiesAndRequiredFeilds, IsHigh));

                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    if (IsLoading)
                    {
                        return;
                    }
                    IsLoading = true;
                    IsPageEnabled = false;
                    ClearValidationErrors();
                    var result = await serviceRegistrationService.UpdateAcademicQualificationsData(AddedAcademicqualification, RegistrationData?.SelectedMaritalStatus?.Id, SelectedWorkStateListItem?.Id, accountService.AccessToken);
                    IsLoading = false;
                    if (result)
                    {
                        if (RegistrationData.AcademicQualifications.Any())
                        {
                            RegistrationData.AcademicQualifications[0] = AddedAcademicqualification;
                        }
                        else
                        {
                            RegistrationData.AcademicQualifications = new List<Academicqualification>();
                            RegistrationData.AcademicQualifications.Add(AddedAcademicqualification);
                        }

                        await dialogService.DisplayAlert("", AppResources.ServiceRegistration_AccountSaved);
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

        #region Seventh Step

        #region OnUpdateImageCommand

        private RelayCommand<ServiceAttachementData> _OnUpdateImageCommand;
        public RelayCommand<ServiceAttachementData> OnUpdateImageCommand
        {
            get
            {
                if (_OnUpdateImageCommand == null)
                {
                    _OnUpdateImageCommand = new RelayCommand<ServiceAttachementData>(OnUpdateImage);
                }
                return _OnUpdateImageCommand;
            }
        }
        private async void OnUpdateImage(ServiceAttachementData attachment)
        {
            try
            {
                IsLoading = true;
                int updatedIndex = ServiceAttachementData.IndexOf(attachment);

                if (attachment.Attachment == null) //Add
                {
                    var mediaPicker = DependencyService.Get<IMediaPicker>();
                    navigationService.IsExternalAppOpen = true;
                    var mediaFile = await mediaPicker.SelectPhotoAsync();
                    navigationService.IsExternalAppOpen = false;
                    if (mediaFile != null)
                    {
                        IsLoading = true;
                        var imageBytes = mediaFile.data;
                        var status = await serviceRegistrationService.UploadAttachment(imageBytes, mediaFile.Extension, attachment.AttachmentCode, accountService.AccessToken);
                        attachment.Attachment = new Registrationattachment();
                        attachment.Attachment.FileName = mediaFile.Extension;
                        ServiceAttachementData[updatedIndex] = attachment;
                    }

                }
                else //Update
                {
                    string value = await dialogService.DisplayActionSheet(AppResources.ServiceRegistration_ActionSheet_UploadImage_Title, AppResources.ServiceRegistration_ActionSheet_UploadImage_Cancel, null,
                        AppResources.ServiceRegistration_ActionSheet_UploadImage_Update, AppResources.ServiceRegistration_ActionSheet_UploadImage_Delete);
                    if (value == AppResources.ServiceRegistration_ActionSheet_UploadImage_Update)
                    {
                        var mediaPicker = DependencyService.Get<IMediaPicker>();
                        navigationService.IsExternalAppOpen = true;
                        var mediaFile = await mediaPicker.SelectPhotoAsync();
                        navigationService.IsExternalAppOpen = false;
                        if (mediaFile != null)
                        {
                            IsLoading = true;
                            var imageBytes = mediaFile.data;
                            var status = await serviceRegistrationService.UploadAttachment(imageBytes, mediaFile.Extension, attachment.AttachmentCode, accountService.AccessToken);
                            attachment.Attachment = new Registrationattachment();
                            attachment.Attachment.FileName = mediaFile.Extension;
                            ServiceAttachementData[updatedIndex] = attachment;
                        }
                    }
                    else if (value == AppResources.ServiceRegistration_ActionSheet_UploadImage_Delete)
                    {
                        var status = await serviceRegistrationService.DeleteFile(attachment.Attachment.FileID);
                        attachment.Attachment = new Registrationattachment();
                        attachment.Attachment.IsDeleted = true;
                        ServiceAttachementData[updatedIndex] = attachment;
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
            catch (AttachmentSizeException ex)
            {
                await excpetionService.LogExceptionAndDisplayAlert(ex, AppResources.Error_ApplicationTitle, ex.Message);
            }
            catch (System.Exception ex)
            {
                await excpetionService.LogException(ex);
            }
            finally
            {
                IsLoading = false;
                IsPageEnabled = true;
                AddedRegistrationattachment = null;
            }
        }

        #endregion

        #region OnStep7SaveCommand

        private RelayCommand _OnStep7SaveCommand;
        public RelayCommand OnStep7SaveCommand
        {
            get
            {
                if (_OnStep7SaveCommand == null)
                {
                    _OnStep7SaveCommand = new RelayCommand(OnStep7Save);
                }
                return _OnStep7SaveCommand;
            }
        }
        private async void OnStep7Save()
        {
            try
            {
                if (IsLoading)
                {
                    return;
                }
                IsLoading = true;
                IsPageEnabled = false;
                ClearValidationErrors();
                var result = await serviceRegistrationService.UpdateAttachments(ServiceAttachementData.ToList(), RegistrationData?.SelectedMaritalStatus?.Id, SelectedWorkStateListItem?.Id, accountService.AccessToken);
                IsLoading = false;
                if (result)
                {
                    await dialogService.DisplayAlert("", AppResources.ServiceRegistration_AccountSaved);
                }
                else
                {
                    await dialogService.DisplayAlert(AppResources.Error, AppResources.Error_NoDataFound);
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

        #region OnFinishCommand

        private RelayCommand _OnFinishCommand;
        public RelayCommand OnFinishCommand
        {
            get
            {
                if (_OnFinishCommand == null)
                {
                    _OnFinishCommand = new RelayCommand(OnFinish);
                }
                return _OnFinishCommand;
            }
        }
        private async void OnFinish()
        {
            try
            {
                IsLoading = true;
                IsPageEnabled = false;
                ClearValidationErrors();
                var result = await serviceRegistrationService.Submit(ServiceAttachementData.ToList(), RegistrationData?.SelectedMaritalStatus?.Id, SelectedWorkStateListItem?.Id, accountService.AccessToken);
                if (result)
                {
                    navigationService.SetAppCurrentPage(typeof(MainPage));
                }
                else
                {
                    await dialogService.DisplayAlert(AppResources.Error, AppResources.Error_NoDataFound);
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

        #endregion
    }
}
