using GHQ.Logic.Models.Account.Data;
using GHQ.Resources.Strings;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GHQ.Logic.Models.Data.Registration
{
    public class RegistrationData : BaseModel
    {
        public VisibilitiesAndRequiredFeilds VisibilitiesAndRequiredFeilds { get; set; }

        #region Step 1 

        #region Names

        /////////////////////////////////////////////////////////FirstName English/////////////////////////////////////////////////////////

        string _FirstName_English;
        public string FirstName_English
        {
            get
            {
                return _FirstName_English;
            }
            set
            {
                Set(() => FirstName_English, ref _FirstName_English, value);
            }
        }


        /////////////////////////////////////////////////////////FirstName Arabice/////////////////////////////////////////////////////////

        string _FirstName_Arabic;
        public string FirstName_Arabic
        {
            get
            {
                return _FirstName_Arabic;
            }
            set
            {
                Set(() => FirstName_Arabic, ref _FirstName_Arabic, value);
            }
        }


        /////////////////////////////////////////////////////////SecondName English/////////////////////////////////////////////////////////

        string _SecondName_English;
        public string SecondName_English
        {
            get
            {
                return _SecondName_English;
            }
            set
            {
                Set(() => SecondName_English, ref _SecondName_English, value);
            }
        }


        /////////////////////////////////////////////////////////SecondName Arabic/////////////////////////////////////////////////////////

        string _SecondName_Arabic;
        public string SecondName_Arabic
        {
            get
            {
                return _SecondName_Arabic;
            }
            set
            {
                Set(() => SecondName_Arabic, ref _SecondName_Arabic, value);
            }
        }


        /////////////////////////////////////////////////////////ThirdName English/////////////////////////////////////////////////////////

        string _ThirdName_English;
        public string ThirdName_English
        {
            get
            {
                return _ThirdName_English;
            }
            set
            {
                Set(() => ThirdName_English, ref _ThirdName_English, value);
            }
        }


        /////////////////////////////////////////////////////////ThirdName Arabic/////////////////////////////////////////////////////////

        string _ThirdName_Arabic;
        public string ThirdName_Arabic
        {
            get
            {
                return _ThirdName_Arabic;
            }
            set
            {
                Set(() => ThirdName_Arabic, ref _ThirdName_Arabic, value);
            }
        }


        /////////////////////////////////////////////////////////FourthName English/////////////////////////////////////////////////////////

        string _FourthName_English;
        public string FourthName_English
        {
            get
            {
                return _FourthName_English;
            }
            set
            {
                Set(() => FourthName_English, ref _FourthName_English, value);
            }
        }


        /////////////////////////////////////////////////////////FourthName English/////////////////////////////////////////////////////////

        string _FourthName_Arabic;
        public string FourthName_Arabic
        {
            get
            {
                return _FourthName_Arabic;
            }
            set
            {
                Set(() => FourthName_Arabic, ref _FourthName_Arabic, value);
            }
        }


        /////////////////////////////////////////////////////////FifthName English/////////////////////////////////////////////////////////

        string _FifthName_English;
        public string FifthName_English
        {
            get
            {
                return _FifthName_English;
            }
            set
            {
                Set(() => FifthName_English, ref _FifthName_English, value);
            }
        }


        /////////////////////////////////////////////////////////FifthName Arabic/////////////////////////////////////////////////////////

        string _FifthName_Arabic;
        public string FifthName_Arabic
        {
            get
            {
                return _FifthName_Arabic;
            }
            set
            {
                Set(() => FifthName_Arabic, ref _FifthName_Arabic, value);
            }
        }


        #endregion

        #region Identity

        public string EmiratesId { get; set; }

        /////////////////////////////////////////////////////////DateOfBirth/////////////////////////////////////////////////////////
        DateTime _DateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                Set(() => DateOfBirth, ref _DateOfBirth, value);
            }
        }


        /////////////////////////////////////////////////////////TribeID/////////////////////////////////////////////////////////

        LookupData _SelectedTribe;
        public LookupData SelecteTribe
        {
            get
            {
                return _SelectedTribe;
            }
            set
            {
                Set(() => SelecteTribe, ref _SelectedTribe, value);
                TribeID = SelecteTribe.Id;
            }
        }

        public string TribeID { get; set; }

        /////////////////////////////////////////////////////////Gender/////////////////////////////////////////////////////////

        LookupData _SelectedGender;
        public LookupData SelectedGender
        {
            get
            {
                return _SelectedGender;
            }
            set
            {
                Set(() => SelectedGender, ref _SelectedGender, value);
                Gender = SelectedGender.Id;
            }
        }

        public string Gender { get; set; }


        /////////////////////////////////////////////////////////PlaceOfBirth/////////////////////////////////////////////////////////

        public string PlaceOfBirth { get; set; }


        ///////////////////////////////////////////////////////// MaritalStatus/////////////////////////////////////////////////////////

        LookupData _SelectedMaritalStatus;
        public LookupData SelectedMaritalStatus
        {
            get
            {
                return _SelectedMaritalStatus;
            }
            set
            {
                Set(() => SelectedMaritalStatus, ref _SelectedMaritalStatus, value);
                MaritalStatus = SelectedMaritalStatus.Id;
                RaisePropertyChanged("WifeTabVisible");
            }
        }
        public string MaritalStatus { get; set; }


        ///////////////////////////////////////////////////////// PreviousNationality/////////////////////////////////////////////////////////
        LookupData _SelectedPreviousNationality;
        public LookupData SelectedPreviousNationality
        {
            get
            {
                return _SelectedPreviousNationality;
            }
            set
            {
                Set(() => SelectedPreviousNationality, ref _SelectedPreviousNationality, value);
            }
        }

        public string PreviousNationality { get; set; }


        ///////////////////////////////////////////////////////// NationalityGain/////////////////////////////////////////////////////////

        LookupData _SelectedNationalityGain;
        public LookupData SelectedNationalityGain
        {
            get
            {
                return _SelectedNationalityGain;
            }
            set
            {
                Set(() => SelectedNationalityGain, ref _SelectedNationalityGain, value);
               NationalityGain = SelectedNationalityGain.Id;
            }
        }
        public string NationalityGain { get; set; }


        ///////////////////////////////////////////////////////// NationalityGain/////////////////////////////////////////////////////////


        public DateTime NationalityGainDate { get; set; }


        #endregion

        #region Passport

        ///////////////////////////////////////////////////////// PassportNumber/////////////////////////////////////////////////////////

        public string PassportNumber { get; set; }


        ///////////////////////////////////////////////////////// PassportIssueDate/////////////////////////////////////////////////////////
        public DateTime PassportIssueDate { get; set; }


        ///////////////////////////////////////////////////////// PassportExpiryDate/////////////////////////////////////////////////////////

        public DateTime PassportExpiryDate { get; set; }


        ///////////////////////////////////////////////////////// PassportType/////////////////////////////////////////////////////////
        LookupData _SelectedPassportType;
        public LookupData SelectedPassportType
        {
            get
            {
                return _SelectedPassportType;
            }
            set
            {
                Set(() => SelectedPassportType, ref _SelectedPassportType, value);
                PassportType = SelectedPassportType.Id;
            }
        }
        public string PassportType { get; set; }


        ///////////////////////////////////////////////////////// PassportExpiryDate/////////////////////////////////////////////////////////

        LookupData _SelectedPassportIssuePlace;
        public LookupData SelectedPassportIssuePlace
        {
            get
            {
                return _SelectedPassportIssuePlace;
            }
            set
            {
                Set(() => SelectedPassportIssuePlace, ref _SelectedPassportIssuePlace, value);
                PassportIssuePlace = SelectedPassportIssuePlace.Id;
            }
        }
        public string PassportIssuePlace { get; set; }


        #endregion

        #region General Info

        ///////////////////////////////////////////////////////// WorkStatusID/////////////////////////////////////////////////////////

        public string WorkStatusID { get; set; }

        ///////////////////////////////////////////////////////// EthparaNumber/////////////////////////////////////////////////////////

        public int EthparaNumber { get; set; }


        ///////////////////////////////////////////////////////// UniqueNumber/////////////////////////////////////////////////////////

        public int UniqueNumber { get; set; }

        ///////////////////////////////////////////////////////// EmiratesIDExpiryDate/////////////////////////////////////////////////////////
        public DateTime EmiratesIDExpiryDate { get; set; }

        ///////////////////////////////////////////////////////// EmiratesIDCardNumber/////////////////////////////////////////////////////////

        public string EmiratesIDCardNumber { get; set; }

        ///////////////////////////////////////////////////////// EmiratesIDCardNumber/////////////////////////////////////////////////////////
        public int FamilybooknumberorNationalitynumber { get; set; }

        ///////////////////////////////////////////////////////// CityNumber/////////////////////////////////////////////////////////
        public int CityNumber { get; set; }

        ///////////////////////////////////////////////////////// FamilyBookNumber/////////////////////////////////////////////////////////

        public int FamilyBookNumber { get; set; }


        ///////////////////////////////////////////////////////// OriginalCity/////////////////////////////////////////////////////////
        LookupData _SelectedOriginalCity;
        public LookupData SelectedOriginalCity
        {
            get
            {
                return _SelectedOriginalCity;
            }
            set
            {
                Set(() => SelectedOriginalCity, ref _SelectedOriginalCity, value);
               OriginalCity = SelectedOriginalCity.Id;
            }
        }

        public string OriginalCity { get; set; }


        #endregion

        #endregion

        #region Step2 Work

        public List<Work> Work { get; set; }

        #endregion

        #region Step3 Address

        public List<Address> Addresses { get; set; }

        #endregion

        #region Step 4 and 5 Relatives

        public Relative[] Relatives { get; set; }

        ObservableCollection<Relative> _OtherRelatives;
        public ObservableCollection<Relative> OtherRelatives
        {
            get
            {
                return _OtherRelatives;
            }
            set
            {
                Set(() => OtherRelatives, ref _OtherRelatives, value);
                RaisePropertyChanged("OtherRelativesWithoutDeleted");
            }
        }

        public ObservableCollection<Relative> OtherRelativesWithoutDeleted
        {
            get
            {
                var wifes = new ObservableCollection<Relative>(OtherRelatives.Where(a => a.IsDeleted == false || a.IsDeleted == null));
                return wifes;
            }
        }

        ObservableCollection<Relative> _WifeHusbandRelatives;
        public ObservableCollection<Relative> WifeHusbandRelatives
        {
            get
            {
                return _WifeHusbandRelatives;
            }
            set
            {
                Set(() => WifeHusbandRelatives, ref _WifeHusbandRelatives, value);
                RaisePropertyChanged("WifeHusbandRelativesWithoutDeleted");
            }
        }

        public ObservableCollection<Relative> WifeHusbandRelativesWithoutDeleted
        {
            get
            {
                var wifes = new ObservableCollection<Relative>(WifeHusbandRelatives.Where(a => a.IsDeleted == false || a.IsDeleted == null));
                return wifes;
            }
        }

        public void UpdateRelatives()
        {
            RaisePropertyChanged("OtherRelativesWithoutDeleted");
        }

        public void UpdateWifes()
        {
            RaisePropertyChanged("WifeHusbandRelativesWithoutDeleted");
        }

        #endregion

        #region Step6 AcademicQualifications

        public List<Academicqualification> AcademicQualifications { get; set; }

        #endregion

        #region Step7 RegistrationAttachments

        public Registrationattachment[] RegistrationAttachments { get; set; }


        #endregion

        public object OnlySon { get; set; }
        public object WorkForMilitaryBefore { get; set; }

        public object RegistrationStatus { get; set; }

        public object CreatedDate { get; set; }
        public object Status { get; set; }
        public object Passcode { get; set; }
        public string SubmittionDate { get; set; }

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (VisibilitiesAndRequiredFeilds.E_FirstName_IsRequired && string.IsNullOrEmpty(FirstName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFirstName), PropertyName = "FirstName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(FirstName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFirstName), PropertyName = "FirstName_English" });
            }

            if (VisibilitiesAndRequiredFeilds.E_SecondName_IsRequired && string.IsNullOrEmpty(SecondName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishSecondName), PropertyName = "SecondName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(SecondName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishSecondName), PropertyName = "SecondName_English" });
            }

            if (VisibilitiesAndRequiredFeilds.E_ThirdName_IsRequired && string.IsNullOrEmpty(ThirdName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishThirdName), PropertyName = "ThirdName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(ThirdName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishThirdName), PropertyName = "ThirdName_English" });
            }

            if (VisibilitiesAndRequiredFeilds.E_FourthName_IsRequired && string.IsNullOrEmpty(FourthName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFourthName), PropertyName = "FourthName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(FourthName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFourthName), PropertyName = "FourthName_English" });
            }

            if (VisibilitiesAndRequiredFeilds.E_FifthName_IsRequired && string.IsNullOrEmpty(FifthName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFifthName), PropertyName = "FifthName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(FifthName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFifthName), PropertyName = "FifthName_English" });
            }
            if (VisibilitiesAndRequiredFeilds.EmiratesIDExpiryDate_IsRequired && EmiratesIDExpiryDate == DateTime.MinValue)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_EmiratesIDExpiryDate), PropertyName = "EmiratesIDExpiryDate" });
            }
            if (VisibilitiesAndRequiredFeilds.PassportIssueDate_IsRequired && PassportIssueDate == DateTime.MinValue)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_PassportIssuanceDate), PropertyName = "PassportIssueDate" });
            }
            if (VisibilitiesAndRequiredFeilds.PassportExpiryDate_IsVisible && PassportExpiryDate == DateTime.MinValue)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_PassportExpiryDate), PropertyName = "PassportExpiryDate" });
            }
            if (VisibilitiesAndRequiredFeilds.PassportExpiryDate_IsVisible && VisibilitiesAndRequiredFeilds.PassportIssueDate_IsRequired && PassportIssueDate >= PassportExpiryDate)
            {
                errors.Add(new ValidatedModel { Error = AppResources.ServiceRegistration_PassportIssuanceGreaterThanExpiry, PropertyName = "PassportExpiryDate" });
            }

            if (VisibilitiesAndRequiredFeilds.PlaceOfBirth_IsRequired && string.IsNullOrEmpty(PlaceOfBirth))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_PlaceOfBirth), PropertyName = "PlaceOfBirth" });
            }
            else if (Validations.Validation.ValidateHasSpecialCharchters(PlaceOfBirth))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_PlaceOfBirth), PropertyName = "PlaceOfBirth" });
            }
            if (VisibilitiesAndRequiredFeilds.PassportNumber_IsRequired && string.IsNullOrEmpty(PassportNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Passport), PropertyName = "PlaceOfBirth" });
            }
            if (VisibilitiesAndRequiredFeilds.PassportIssuanceLocation_IsRequired && string.IsNullOrEmpty(PassportIssuePlace))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_PassportIssuancePlace), PropertyName = "PassportIssuePlace" });
            }

            if (VisibilitiesAndRequiredFeilds.EmiratesIDCardNumber_IsRequired && string.IsNullOrEmpty(EmiratesIDCardNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EmiratesIDCardNumber), PropertyName = "EmiratesIDCardNumber" });
            }
            if (VisibilitiesAndRequiredFeilds.EthparaNumber_IsRequired && EthparaNumber == -1)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EthparaNumber), PropertyName = "EthparaNumber" });
            }
            if (VisibilitiesAndRequiredFeilds.FamilybooknumberorNationalitynumber_IsRequired && FamilyBookNumber == -1)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_FamilybooknumberorNationalitynumber), PropertyName = "FamilyBookNumber" });
            }
            if (VisibilitiesAndRequiredFeilds.CityNumber_IsRequired && CityNumber == -1)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_CityNumber), PropertyName = "CityNumber" });
            }
            return errors;
        }

    }

    public class Relative : BaseModel
    {
        string _FirstName_English;
        public string FirstName_English
        {
            get
            {
                return _FirstName_English;
            }
            set
            {
                Set(() => FirstName_English, ref _FirstName_English, value);
            }
        }

        string _FirstName_Arabic;
        public string FirstName_Arabic
        {
            get
            {
                return _FirstName_Arabic;
            }
            set
            {
                Set(() => FirstName_Arabic, ref _FirstName_Arabic, value);
            }
        }


        string _SecondName_English;
        public string SecondName_English
        {
            get
            {
                return _SecondName_English;
            }
            set
            {
                Set(() => SecondName_English, ref _SecondName_English, value);
            }
        }

        string _SecondName_Arabic;
        public string SecondName_Arabic
        {
            get
            {
                return _SecondName_Arabic;
            }
            set
            {
                Set(() => SecondName_Arabic, ref _SecondName_Arabic, value);
            }
        }

        string _ThirdName_English;
        public string ThirdName_English
        {
            get
            {
                return _ThirdName_English;
            }
            set
            {
                Set(() => ThirdName_English, ref _ThirdName_English, value);
            }
        }

        string _ThirdName_Arabic;
        public string ThirdName_Arabic
        {
            get
            {
                return _ThirdName_Arabic;
            }
            set
            {
                Set(() => ThirdName_Arabic, ref _ThirdName_Arabic, value);
            }
        }

        string _FourthName_English;
        public string FourthName_English
        {
            get
            {
                return _FourthName_English;
            }
            set
            {
                Set(() => FourthName_English, ref _FourthName_English, value);
            }
        }

        string _FourthName_Arabic;
        public string FourthName_Arabic
        {
            get
            {
                return _FourthName_Arabic;
            }
            set
            {
                Set(() => FourthName_Arabic, ref _FourthName_Arabic, value);
            }
        }

        string _FifthName_English;
        public string FifthName_English
        {
            get
            {
                return _FifthName_English;
            }
            set
            {
                Set(() => FifthName_English, ref _FifthName_English, value);
            }
        }

        string _FifthName_Arabic;
        public string FifthName_Arabic
        {
            get
            {
                return _FifthName_Arabic;
            }
            set
            {
                Set(() => FifthName_Arabic, ref _FifthName_Arabic, value);
            }
        }


        LookupData _SelectedTribe;
        public LookupData SelectedTribe
        {
            get
            {
                return _SelectedTribe;
            }
            set
            {
                Set(() => SelectedTribe, ref _SelectedTribe, value);
            }
        }

        public string TribeID { get; set; }

        LookupData _SelectedRelativetype;
        public LookupData SelectedRelativetype
        {
            get
            {
                return _SelectedRelativetype;
            }
            set
            {
                Set(() => SelectedRelativetype, ref _SelectedRelativetype, value);
            }
        }
        public string Relativetype { get; set; }

        LookupData _SelectedNationality;
        public LookupData SelectedNationality
        {
            get
            {
                return _SelectedNationality;
            }
            set
            {
                Set(() => SelectedNationality, ref _SelectedNationality, value);
            }
        }
        public string Nationality { get; set; }

        LookupData _SelectedResidencePlaceID;
        public LookupData SelectedResidencePlaceID
        {
            get
            {
                return _SelectedResidencePlaceID;
            }
            set
            {
                Set(() => SelectedResidencePlaceID, ref _SelectedResidencePlaceID, value);
            }
        }
        public string ResidencePlaceID { get; set; }
        public string BirthPlace { get; set; }
        public string WorkPlace { get; set; }
        public string JobName { get; set; }
        public int AgeOfRelative { get; set; }

        LookupData _SelectedStatusOfRelative;
        public LookupData SelectedStatusOfRelative
        {
            get
            {
                return _SelectedStatusOfRelative;
            }
            set
            {
                Set(() => SelectedStatusOfRelative, ref _SelectedStatusOfRelative, value);
            }
        }
        public string StatusOfRelative { get; set; }
        public bool? IsBrother { get; set; }
        public bool? IsAlive { get; set; }

        public bool IsBrotherValue { get; set; }
        public bool IsAliveValue { get; set; }
        public object HalfBrotherReltiveType { get; set; }
        public string Source { get; set; }
        public string GHQID { get; set; }
        public bool? IsDeleted { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FirstName_Arabic, SecondName_Arabic, FifthName_Arabic);
        }
        public override IEnumerable<ValidatedModel> Validate()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidatedModel> Validate(VisibilitiesAndRequiredFeilds VisibilitiesAndRequiredFeilds)
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (VisibilitiesAndRequiredFeilds.E_FirstName_Relative_IsRequired && string.IsNullOrEmpty(FirstName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFirstName), PropertyName = "FirstName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(FirstName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFirstName), PropertyName = "FirstName_English" });
            }
            if (VisibilitiesAndRequiredFeilds.A_FirstName_Relative_IsRequired && string.IsNullOrEmpty(FirstName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicFirstName), PropertyName = "FirstName_Arabic" });
            }
            else if (!Validations.Validation.ValidateArabicName(FirstName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicFirstName), PropertyName = "FirstName_Arabic" });
            }

            if (VisibilitiesAndRequiredFeilds.E_SecondName_Relative_IsRequired && string.IsNullOrEmpty(SecondName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishSecondName), PropertyName = "SecondName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(SecondName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishSecondName), PropertyName = "SecondName_English" });
            }
            if (VisibilitiesAndRequiredFeilds.A_SecondName_Relative_IsRequired && string.IsNullOrEmpty(SecondName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicSecondName), PropertyName = "SecondName_Arabic" });
            }
            else if (!Validations.Validation.ValidateArabicName(SecondName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicSecondName), PropertyName = "SecondName_Arabic" });
            }


            if (VisibilitiesAndRequiredFeilds.E_ThirdName_Relative_IsRequired && string.IsNullOrEmpty(ThirdName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishThirdName), PropertyName = "ThirdName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(ThirdName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishThirdName), PropertyName = "ThirdName_English" });
            }
            if (VisibilitiesAndRequiredFeilds.A_ThirdName_Relative_IsRequired && string.IsNullOrEmpty(ThirdName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicThirdName), PropertyName = "ThirdName_Arabic" });
            }
            else if (!Validations.Validation.ValidateArabicName(ThirdName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicThirdName), PropertyName = "ThirdName_Arabic" });
            }


            if (VisibilitiesAndRequiredFeilds.E_FourthName_Relative_IsRequired && string.IsNullOrEmpty(FourthName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFourthName), PropertyName = "FourthName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(FourthName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFourthName), PropertyName = "FourthName_English" });
            }
            if (VisibilitiesAndRequiredFeilds.A_FourthName_Relative_IsRequired && string.IsNullOrEmpty(FourthName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicFourthName), PropertyName = "FourthName_Arabic" });
            }
            else if (!Validations.Validation.ValidateArabicName(FourthName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicFourthName), PropertyName = "FourthName_Arabic" });
            }

            if (VisibilitiesAndRequiredFeilds.E_FifthName_Relative_IsRequired && string.IsNullOrEmpty(FifthName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFifthName), PropertyName = "FifthName_English" });
            }
            else if (!Validations.Validation.ValidateEnglishName(FifthName_English))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.EnglishFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_EnglishFifthName), PropertyName = "FifthName_English" });
            }
            if (VisibilitiesAndRequiredFeilds.A_FifthName_Relative_IsRequired && string.IsNullOrEmpty(FifthName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicFifthName), PropertyName = "FifthName_Arabic" });
            }
            else if (!Validations.Validation.ValidateArabicName(FifthName_Arabic))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicFifthName), PropertyName = "FifthName_Arabic" });
            }
            if (string.IsNullOrEmpty(Nationality))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Nationality), PropertyName = "Nationality" });
            }
            if (string.IsNullOrEmpty(WorkPlace))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkPlace), PropertyName = "WorkPlace" });
            }
            if (string.IsNullOrEmpty(JobName))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_JobName), PropertyName = "JobName" });
            }
            if (string.IsNullOrEmpty(TribeID))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_TribeName), PropertyName = "TribeID" });
            }

            if (string.IsNullOrEmpty(BirthPlace))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_BirthPlace), PropertyName = "BirthPlace" });
            }
            if (VisibilitiesAndRequiredFeilds.AgeOfRelative_IsRequired && AgeOfRelative <= 0)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Age), PropertyName = "FifthName_Arabic" });
            }

            return errors;
        }

    }

    public class Academicqualification : BaseModel
    {
        LookupData _SelectedAcademicQualification;
        public LookupData SelectedAcademicQualification
        {
            get
            {
                return _SelectedAcademicQualification;
            }
            set
            {
                Set(() => SelectedAcademicQualification, ref _SelectedAcademicQualification, value);
            }
        }
        public string AcademicQualificationID { get; set; }

        LookupData _SelectedAcademicCountry;
        public LookupData SelectedAcademicCountry
        {
            get
            {
                return _SelectedAcademicCountry;
            }
            set
            {
                Set(() => SelectedAcademicCountry, ref _SelectedAcademicCountry, value);
            }
        }
        public string AcademicCountryID { get; set; }

        LookupData _SelectedEducationInstitute;
        public LookupData SelectedEducationInstitute
        {
            get
            {
                return _SelectedEducationInstitute;
            }
            set
            {
                Set(() => SelectedEducationInstitute, ref _SelectedEducationInstitute, value);
            }
        }
        public string EducationInstituteID { get; set; }

        LookupData _SelectedMainSpecialization;
        public LookupData SelectedMainSpecialization
        {
            get
            {
                return _SelectedMainSpecialization;
            }
            set
            {
                Set(() => SelectedMainSpecialization, ref _SelectedMainSpecialization, value);
            }
        }
        public string MainSpecializationID { get; set; }


        LookupData _SelectedSubSpecialization;
        public LookupData SelectedSubSpecialization
        {
            get
            {
                return _SelectedSubSpecialization;
            }
            set
            {
                Set(() => SelectedSubSpecialization, ref _SelectedSubSpecialization, value);
            }
        }
        public string SubSpecializationID { get; set; }


        LookupData _SelectedJobLevel;
        public LookupData SelectedJobLevel
        {
            get
            {
                return _SelectedJobLevel;
            }
            set
            {
                Set(() => SelectedJobLevel, ref _SelectedJobLevel, value);
            }
        }
        public string JobLevel { get; set; }
        public DateTime GraduationDate { get; set; }
        public string Grade { get; set; }
        public string GPA { get; set; }
        public string Notes { get; set; }
        public bool? ISEducationFinished { get; set; }

        bool _ISEducationFinishedValue;
        public bool ISEducationFinishedValue
        {
            get
            {
                return _ISEducationFinishedValue;
            }
            set
            {
                Set(() => ISEducationFinishedValue, ref _ISEducationFinishedValue, value);
            }
        }
        public bool IsDeleted { get; set; }

        public override IEnumerable<ValidatedModel> Validate()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidatedModel> Validate(VisibilitiesAndRequiredFeilds VisibilitiesAndRequiredFeilds, bool IsGPA)
        {
            int GPANumber = 0;
            int.TryParse(GPA, out GPANumber);
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (VisibilitiesAndRequiredFeilds.SelectEducationInstitute_IsRequired && string.IsNullOrEmpty(EducationInstituteID))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_EducationJob), PropertyName = "EducationInstituteID" });
            }

            if (VisibilitiesAndRequiredFeilds.GraduationDate_IsRequired && GraduationDate == DateTime.MinValue)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_GraduationDate), PropertyName = "GraduationDate" });
            }


            if (IsGPA)
            {
                if (VisibilitiesAndRequiredFeilds.GPA_IsRequired && string.IsNullOrEmpty(GPA))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_GPA), PropertyName = "GPA" });
                }
                if (!(GPANumber > 0 && GPANumber < 5))
                {
                    errors.Add(new ValidatedModel { Error = AppResources.ServiceRegistration_GPA_Validation, PropertyName = "GPA" });
                }
            }
            else
            {
                if (!(GPANumber > 0 && GPANumber < 101))
                {
                    errors.Add(new ValidatedModel { Error = AppResources.ServiceRegistration_Entry_PlaceHolder_Percentage, PropertyName = "GPA" });
                }
                if (VisibilitiesAndRequiredFeilds.GPA_IsRequired && string.IsNullOrEmpty(GPA))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Percentage), PropertyName = "GPA" });
                }
                if (VisibilitiesAndRequiredFeilds.Grade_IsRequired && string.IsNullOrEmpty(Grade))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Grade), PropertyName = "Grade" });
                }
            }

            if (VisibilitiesAndRequiredFeilds.Notes_IsRequired && string.IsNullOrEmpty(Notes))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Notes), PropertyName = "Notes" });
            }


            return errors;
        }
    }

    public class Address : BaseModel
    {

        LookupData _SelectedCity;
        public LookupData SelectedCity
        {
            get
            {
                return _SelectedCity;
            }
            set
            {
                Set(() => SelectedCity, ref _SelectedCity, value);
            }
        }

        public string CityID { get; set; }

        LookupData _SelectedRegion;
        public LookupData SelectedRegion
        {
            get
            {
                return _SelectedRegion;
            }
            set
            {
                Set(() => SelectedRegion, ref _SelectedRegion, value);
            }
        }
        public string RegionID { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string BldgName { get; set; }
        public string BldgNumber { get; set; }
        public string FloorNumber { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string HomePhone1 { get; set; }
        public string HomePhone2 { get; set; }
        public string GuardianNumber { get; set; }
        public string EmailCandidate { get; set; }
        public string POBox { get; set; }
        public string AddressText { get; set; }

        public override IEnumerable<ValidatedModel> Validate()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidatedModel> Validate(VisibilitiesAndRequiredFeilds VisibilitiesAndRequiredFeilds)
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (VisibilitiesAndRequiredFeilds.StreetName_IsRequired && string.IsNullOrEmpty(StreetName))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_StreetName), PropertyName = "StreetName" });
            }
            else if (Validations.Validation.ValidateHasSpecialCharchters(StreetName))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_StreetName), PropertyName = "StreetName" });
            }
            if (VisibilitiesAndRequiredFeilds.StreetNumber_IsRequired && string.IsNullOrEmpty(StreetNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_StreetNumber), PropertyName = "StreetNumber" });
            }
            else if (Validations.Validation.ValidateHasSpecialCharchters(StreetNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_StreetNumber), PropertyName = "StreetNumber" });
            }
            if (VisibilitiesAndRequiredFeilds.BldgName_IsRequired && string.IsNullOrEmpty(BldgName))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_BldgName), PropertyName = "BldgName" });
            }
            else if (Validations.Validation.ValidateHasSpecialCharchters(BldgName))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_BldgName), PropertyName = "BldgName" });
            }
            if (VisibilitiesAndRequiredFeilds.BldgNumber_IsRequired && string.IsNullOrEmpty(BldgNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_BldgNumber), PropertyName = "BldgNumber" });
            }
            else if (Validations.Validation.ValidateHasSpecialCharchters(BldgNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_BldgNumber), PropertyName = "BldgNumber" });
            }
            if (VisibilitiesAndRequiredFeilds.HomePhone1_IsRequired && string.IsNullOrEmpty(HomePhone1))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_HomePhone1), PropertyName = "HomePhone1" });
            }
            if (VisibilitiesAndRequiredFeilds.HomePhone2_IsRequired && string.IsNullOrEmpty(HomePhone2))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_HomePhone2), PropertyName = "HomePhone2" });
            }
            if (VisibilitiesAndRequiredFeilds.FloorNumber_IsRequired && string.IsNullOrEmpty(FloorNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_FloorNumber), PropertyName = "FloorNumber" });
            }
            else if (Validations.Validation.ValidateHasSpecialCharchters(FloorNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_FloorNumber), PropertyName = "FloorNumber" });
            }
            if (VisibilitiesAndRequiredFeilds.Mobile1_IsRequired && string.IsNullOrEmpty(Mobile1))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Mobile1), PropertyName = "Mobile1" });
            }
            if (VisibilitiesAndRequiredFeilds.Mobile2_IsRequired && string.IsNullOrEmpty(Mobile2))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Mobile2), PropertyName = "Mobile2" });
            }
            if (VisibilitiesAndRequiredFeilds.GuardianNumber_IsRequired && string.IsNullOrEmpty(GuardianNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_GuardianNumber), PropertyName = "GuardianNumber" });
            }

            if (VisibilitiesAndRequiredFeilds.Emailcandidate_IsRequired && string.IsNullOrEmpty(EmailCandidate))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Emailcandidate), PropertyName = "EmailCandidate" });
            }
            else
            {
                bool isEmailValid = Validations.Validation.ValidateMail(EmailCandidate);
                if (!isEmailValid)
                {
                    errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_Email, PropertyName = "EmailCandidate" });
                }
            }


            if (VisibilitiesAndRequiredFeilds.POBox_IsRequired && string.IsNullOrEmpty(POBox))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_POBox), PropertyName = "POBox" });
            }
            else if (Validations.Validation.ValidateHasSpecialCharchters(POBox))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_POBox), PropertyName = "POBox" });
            }


            if (VisibilitiesAndRequiredFeilds.AddressText_IsRequired && (AddressText == null || string.IsNullOrEmpty(AddressText.Trim())))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_AddressText), PropertyName = "AddressText" });
            }
            return errors;
        }
    }

    public class Work : BaseModel
    {

        ///////////////////////////////////////////////////////// SelectedWorkOrgType/////////////////////////////////////////////////////////

        LookupData _SelectedWorkOrgType;
        public LookupData SelectedWorkOrgType
        {
            get
            {
                return _SelectedWorkOrgType;
            }
            set
            {
                Set(() => SelectedWorkOrgType, ref _SelectedWorkOrgType, value);
            }
        }
        public string WorkOrgTypeID { get; set; }

        ///////////////////////////////////////////////////////// WorkOrganization/////////////////////////////////////////////////////////

        public string WorkOrganization { get; set; }

        ///////////////////////////////////////////////////////// WorkOrgCity/////////////////////////////////////////////////////////

        LookupData _SelectedWorkOrgCity;
        public LookupData SelectedWorkOrgCity
        {
            get
            {
                return _SelectedWorkOrgCity;
            }
            set
            {
                Set(() => SelectedWorkOrgCity, ref _SelectedWorkOrgCity, value);
            }
        }

        public string WorkOrgCityID { get; set; }

        ///////////////////////////////////////////////////////// WorkPosition/////////////////////////////////////////////////////////

        public string WorkPosition { get; set; }


        ///////////////////////////////////////////////////////// WorkJobName/////////////////////////////////////////////////////////

        public string WorkJobName { get; set; }

        ///////////////////////////////////////////////////////// WorkPhone1/////////////////////////////////////////////////////////

        public string WorkPhone1 { get; set; }

        ///////////////////////////////////////////////////////// WorkPhone2/////////////////////////////////////////////////////////

        public string WorkPhone2 { get; set; }


        ///////////////////////////////////////////////////////// WorkFax/////////////////////////////////////////////////////////

        public string WorkFax { get; set; }


        ///////////////////////////////////////////////////////// Salary/////////////////////////////////////////////////////////

        public string Salary { get; set; }

        ///////////////////////////////////////////////////////// EducationInstituteID/////////////////////////////////////////////////////////
        LookupData _SelectedEducationInstitute;
        public LookupData SelectedEducationInstitute
        {
            get
            {
                return _SelectedEducationInstitute;
            }
            set
            {
                Set(() => SelectedEducationInstitute, ref _SelectedEducationInstitute, value);
            }
        }
        public string EducationInstituteID { get; set; }

        ///////////////////////////////////////////////////////// MilitaryEntityID/////////////////////////////////////////////////////////
        LookupData _SelectedMilitaryEntity;
        public LookupData SelectedMilitaryEntity
        {
            get
            {
                return _SelectedMilitaryEntity;
            }
            set
            {
                Set(() => SelectedMilitaryEntity, ref _SelectedMilitaryEntity, value);
            }
        }
        public string MilitaryEntityID { get; set; }

        public override IEnumerable<ValidatedModel> Validate()
        {
            return null;
        }

        public IEnumerable<ValidatedModel> Validate(bool isWorking, VisibilitiesAndRequiredFeilds VisibilitiesAndRequiredFeilds, bool isPrivate, bool isMilitary)
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (isWorking && !isMilitary)
            {
                if (VisibilitiesAndRequiredFeilds.WorkOrganizationType_IsRequired && string.IsNullOrEmpty(WorkOrgTypeID))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_WorkOrganizationType), PropertyName = "WorkOrgTypeID" });
                }
                if (VisibilitiesAndRequiredFeilds.WorkOrganization_IsVisible && string.IsNullOrEmpty(WorkOrganization))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkOrganization), PropertyName = "WorkOrganization" });
                }
                else if (Validations.Validation.ValidateHasSpecialCharchters(WorkOrganization))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkOrganization), PropertyName = "WorkOrganization" });
                }
                if (VisibilitiesAndRequiredFeilds.WorkPosition_IsRequired && string.IsNullOrEmpty(WorkPosition))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkPosition), PropertyName = "WorkPosition" });
                }
                else if (Validations.Validation.ValidateHasSpecialCharchters(WorkPosition))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkPosition), PropertyName = "WorkPosition" });
                }
                if (VisibilitiesAndRequiredFeilds.WorkJobName_IsRequired && string.IsNullOrEmpty(WorkJobName))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkJobName), PropertyName = "WorkJobName" });
                }
                else if (Validations.Validation.ValidateHasSpecialCharchters(WorkJobName))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkJobName), PropertyName = "WorkJobName" });
                }
                if (VisibilitiesAndRequiredFeilds.WorkPhone1_IsRequired && string.IsNullOrEmpty(WorkPhone1))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkPhone1), PropertyName = "WorkPhone1" });
                }
                if (VisibilitiesAndRequiredFeilds.WorkPhone2_IsRequired && string.IsNullOrEmpty(WorkPhone2))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkPhone2), PropertyName = "WorkPhone2" });
                }
                if (VisibilitiesAndRequiredFeilds.WorkFax_IsRequired && string.IsNullOrEmpty(WorkFax))
                {
                    errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_WorkFax), PropertyName = "WorkFax" });
                }

                if (isPrivate)
                {
                    if (VisibilitiesAndRequiredFeilds.Salary_IsRequired && string.IsNullOrEmpty(Salary))
                    {
                        errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Salary), PropertyName = "WorkFax" });
                    }
                }

            }
            return errors;
        }
    }

    public class Registrationattachment
    {
        public object RegistrationID { get; set; }
        public string ServiceAttachmentID { get; set; }
        public string FileID { get; set; }
        public string FileName { get; set; }
        public object CreationDate { get; set; }
        public object CreatedBy { get; set; }
        public object LastModificationDate { get; set; }
        public object LastModifiedBy { get; set; }
        public string AttachmentCode { get; set; }
        public string URL { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class VisibilitiesAndRequiredFeilds : BaseModel
    {

        #region Step 1 

        #region Names

        /////////////////////////////////////////////////////////FirstName English/////////////////////////////////////////////////////////


        public bool E_FirstName_IsRequired { get; set; } = false;
        public bool E_FirstName_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FirstName Arabice/////////////////////////////////////////////////////////

        public bool A_FirstName_IsRequired { get; set; } = false;
        public bool A_FirstName_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////SecondName English/////////////////////////////////////////////////////////

        public bool E_SecondName_IsRequired { get; set; } = false;
        public bool E_SecondName_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////SecondName Arabic/////////////////////////////////////////////////////////

        public bool A_SecondName_IsRequired { get; set; } = false;
        public bool A_SecondName_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////ThirdName English/////////////////////////////////////////////////////////


        public bool E_ThirdName_IsRequired { get; set; } = false;
        public bool E_ThirdName_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////ThirdName Arabic/////////////////////////////////////////////////////////


        public bool A_ThirdName_IsRequired { get; set; } = false;
        public bool A_ThirdName_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FourthName English/////////////////////////////////////////////////////////

        public bool E_FourthName_IsRequired { get; set; } = false;
        public bool E_FourthName_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FourthName English/////////////////////////////////////////////////////////

        public bool A_FourthName_IsRequired { get; set; } = false;
        public bool A_FourthName_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FifthName English/////////////////////////////////////////////////////////

        public bool E_FifthName_IsRequired { get; set; } = false;
        public bool E_FifthName_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FifthName Arabic/////////////////////////////////////////////////////////

        public bool A_FifthName_IsRequired { get; set; } = false;
        public bool A_FifthName_IsVisible { get; set; } = false;

        #endregion

        #region Identity

        public string EmiratesId { get; set; }

        /////////////////////////////////////////////////////////DateOfBirth/////////////////////////////////////////////////////////
        public bool DateOfBirth_IsRequired { get; set; } = false;
        public bool DateOfBirth_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////TribeID/////////////////////////////////////////////////////////

        public bool TribeID_IsRequired { get; set; } = false;
        public bool TribeID_IsVisible { get; set; } = false;
        /////////////////////////////////////////////////////////Gender/////////////////////////////////////////////////////////


        public bool Gender_IsRequired { get; set; } = false;
        public bool Gender_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////PlaceOfBirth/////////////////////////////////////////////////////////

        public bool PlaceOfBirth_IsRequired { get; set; } = false;
        public bool PlaceOfBirth_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// MaritalStatus/////////////////////////////////////////////////////////

        public bool MaritalStatus_IsRequired { get; set; } = false;
        public bool MaritalStatus_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// PreviousNationality/////////////////////////////////////////////////////////

        public bool PreviousNationality_IsRequired { get; set; } = false;
        public bool PreviousNationality_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// NationalityGain/////////////////////////////////////////////////////////


        public bool GainedNationality_IsRequired { get; set; } = false;
        public bool GainedNationality_IsVisible { get; set; } = false;


        ///////////////////////////////////////////////////////// NationalityGain/////////////////////////////////////////////////////////


        public bool NationalityGainDate_IsRequired { get; set; } = false;
        public bool NationalityGainDate_IsVisible { get; set; } = false;

        #endregion

        #region Passport

        ///////////////////////////////////////////////////////// PassportNumber/////////////////////////////////////////////////////////

        public bool PassportNumber_IsRequired { get; set; } = false;
        public bool PassportNumber_IsVisible { get; set; } = false;


        ///////////////////////////////////////////////////////// PassportIssueDate/////////////////////////////////////////////////////////
        public bool PassportIssueDate_IsRequired { get; set; } = false;
        public bool PassportIssueDate_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// PassportExpiryDate/////////////////////////////////////////////////////////

        public bool PassportExpiryDate_IsRequired { get; set; } = false;
        public bool PassportExpiryDate_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// PassportType/////////////////////////////////////////////////////////

        public bool PassportType_IsRequired { get; set; } = false;
        public bool PassportType_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// PassportExpiryDate/////////////////////////////////////////////////////////

        public bool PassportIssuanceLocation_IsRequired { get; set; } = false;
        public bool PassportIssuanceLocation_IsVisible { get; set; } = false;

        #endregion

        #region General Info

        ///////////////////////////////////////////////////////// EthparaNumber/////////////////////////////////////////////////////////

        public bool EthparaNumber_IsRequired { get; set; } = false;
        public bool EthparaNumber_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// UniqueNumber/////////////////////////////////////////////////////////

        public bool UniqueNumber_IsRequired { get; set; } = false;
        public bool UniqueNumber_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// EmiratesIDExpiryDate/////////////////////////////////////////////////////////
        public bool EmiratesIDExpiryDate_IsRequired { get; set; } = false;
        public bool EmiratesIDExpiryDate_IsVisible { get; set; } = false;


        ///////////////////////////////////////////////////////// EmiratesIDCardNumber/////////////////////////////////////////////////////////

        public bool EmiratesIDCardNumber_IsRequired { get; set; } = false;
        public bool EmiratesIDCardNumber_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// EmiratesIDCardNumber/////////////////////////////////////////////////////////
        public bool FamilybooknumberorNationalitynumber_IsRequired { get; set; } = false;
        public bool FamilybooknumberorNationalitynumber_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// CityNumber/////////////////////////////////////////////////////////
        public bool CityNumber_IsRequired { get; set; } = false;
        public bool CityNumber_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// FamilyBookNumber/////////////////////////////////////////////////////////

        public bool FamilyNumber_IsRequired { get; set; } = false;
        public bool FamilyNumber_IsVisible { get; set; } = false;


        ///////////////////////////////////////////////////////// OriginalCity/////////////////////////////////////////////////////////

        public bool OriginalCity_IsRequired { get; set; } = false;
        public bool OriginalCity_IsVisible { get; set; } = false;

        #endregion

        #endregion

        #region Step 2 Works

        ///////////////////////////////////////////////////////// SelectedWorkOrgType/////////////////////////////////////////////////////////
        public bool WorkOrganizationType_IsRequired { get; set; } = false;
        public bool WorkOrganizationType_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// WorkOrganization/////////////////////////////////////////////////////////

        public bool WorkOrganization_IsRequired { get; set; } = false;
        public bool WorkOrganization_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// WorkOrgCity/////////////////////////////////////////////////////////

        public bool WorkOrganizationCity_IsRequired { get; set; } = false;
        public bool WorkOrganizationCity_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// WorkPosition/////////////////////////////////////////////////////////

        public bool WorkPosition_IsRequired { get; set; } = false;
        public bool WorkPosition_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// WorkJobName/////////////////////////////////////////////////////////

        public bool WorkJobName_IsRequired { get; set; } = false;
        public bool WorkJobName_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// WorkPhone1/////////////////////////////////////////////////////////

        public bool WorkPhone1_IsRequired { get; set; } = false;
        public bool WorkPhone1_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// WorkPhone2/////////////////////////////////////////////////////////

        public bool WorkPhone2_IsRequired { get; set; } = false;
        public bool WorkPhone2_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// WorkFax/////////////////////////////////////////////////////////

        public bool WorkFax_IsRequired { get; set; } = false;
        public bool WorkFax_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// MilitaryID/////////////////////////////////////////////////////////

        public bool Salary_IsRequired { get; set; } = false;
        public bool Salary_IsVisible { get; set; } = false;


        #endregion

        #region Step 3 Address

        ///////////////////////////////////////////////////////// CityName/////////////////////////////////////////////////////////
        public bool CityName_IsRequired { get; set; } = false;
        public bool CityName_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// RegionName/////////////////////////////////////////////////////////
        public bool RegionName_IsRequired { get; set; } = false;
        public bool RegionName_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// StreetName/////////////////////////////////////////////////////////
        public bool StreetName_IsRequired { get; set; } = false;
        public bool StreetName_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// StreetNumber/////////////////////////////////////////////////////////
        public bool StreetNumber_IsRequired { get; set; } = false;
        public bool StreetNumber_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// BldgNumber/////////////////////////////////////////////////////////
        public bool BldgNumber_IsRequired { get; set; } = false;
        public bool BldgNumber_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// BldgName/////////////////////////////////////////////////////////
        public bool BldgName_IsRequired { get; set; } = false;
        public bool BldgName_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// GuardianNumber/////////////////////////////////////////////////////////
        public bool GuardianNumber_IsRequired { get; set; } = false;
        public bool GuardianNumber_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// GuardianNumber/////////////////////////////////////////////////////////
        public bool AddressText_IsRequired { get; set; } = false;
        public bool AddressText_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// FloorNumber/////////////////////////////////////////////////////////
        public bool FloorNumber_IsRequired { get; set; } = false;
        public bool FloorNumber_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// Mobile1/////////////////////////////////////////////////////////
        public bool Mobile1_IsRequired { get; set; } = false;
        public bool Mobile1_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// 2/////////////////////////////////////////////////////////
        public bool Mobile2_IsRequired { get; set; } = false;
        public bool Mobile2_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// HomePhone1/////////////////////////////////////////////////////////
        public bool HomePhone1_IsRequired { get; set; } = false;
        public bool HomePhone1_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// HomePhone2/////////////////////////////////////////////////////////
        public bool HomePhone2_IsRequired { get; set; } = false;
        public bool HomePhone2_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// Emailcandidate/////////////////////////////////////////////////////////
        public bool Emailcandidate_IsRequired { get; set; } = false;
        public bool Emailcandidate_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// POBox/////////////////////////////////////////////////////////
        public bool POBox_IsRequired { get; set; } = false;
        public bool POBox_IsVisible { get; set; } = false;

        #endregion

        #region Step 4 Relatives

        #region Names

        /////////////////////////////////////////////////////////FirstName English/////////////////////////////////////////////////////////


        public bool E_FirstName_Relative_IsRequired { get; set; } = false;
        public bool E_FirstName_Relative_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FirstName Arabice/////////////////////////////////////////////////////////

        public bool A_FirstName_Relative_IsRequired { get; set; } = false;
        public bool A_FirstName_Relative_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////SecondName English/////////////////////////////////////////////////////////

        public bool E_SecondName_Relative_IsRequired { get; set; } = false;
        public bool E_SecondName_Relative_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////SecondName Arabic/////////////////////////////////////////////////////////

        public bool A_SecondName_Relative_IsRequired { get; set; } = false;
        public bool A_SecondName_Relative_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////ThirdName English/////////////////////////////////////////////////////////


        public bool E_ThirdName_Relative_IsRequired { get; set; } = false;
        public bool E_ThirdName_Relative_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////ThirdName Arabic/////////////////////////////////////////////////////////


        public bool A_ThirdName_Relative_IsRequired { get; set; } = false;
        public bool A_ThirdName_Relative_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FourthName English/////////////////////////////////////////////////////////

        public bool E_FourthName_Relative_IsRequired { get; set; } = false;
        public bool E_FourthName_Relative_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FourthName English/////////////////////////////////////////////////////////

        public bool A_FourthName_Relative_IsRequired { get; set; } = false;
        public bool A_FourthName_Relative_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FifthName English/////////////////////////////////////////////////////////

        public bool E_FifthName_Relative_IsRequired { get; set; } = false;
        public bool E_FifthName_Relative_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FifthName Arabic/////////////////////////////////////////////////////////

        public bool A_FifthName_Relative_IsRequired { get; set; } = false;
        public bool A_FifthName_Relative_IsVisible { get; set; } = false;

        #endregion

        public bool AgeOfRelative_IsRequired { get; set; } = false;
        public bool AgeOfRelative_IsVisible { get; set; } = false;


        public bool StatusofRelative_IsRequired { get; set; } = false;
        public bool StatusofRelative_IsVisible { get; set; } = false;


        #endregion

        #region Step 5 Wifes

        #region Names

        /////////////////////////////////////////////////////////FirstName English/////////////////////////////////////////////////////////


        public bool E_FirstName_Wife_IsRequired { get; set; } = false;
        public bool E_FirstName_Wife_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FirstName Arabice/////////////////////////////////////////////////////////

        public bool A_FirstName_Wife_IsRequired { get; set; } = false;
        public bool A_FirstName_Wife_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////SecondName English/////////////////////////////////////////////////////////

        public bool E_SecondName_Wife_IsRequired { get; set; } = false;
        public bool E_SecondName_Wife_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////SecondName Arabic/////////////////////////////////////////////////////////

        public bool A_SecondName_Wife_IsRequired { get; set; } = false;
        public bool A_SecondName_Wife_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////ThirdName English/////////////////////////////////////////////////////////


        public bool E_ThirdName_Wife_IsRequired { get; set; } = false;
        public bool E_ThirdName_Wife_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////ThirdName Arabic/////////////////////////////////////////////////////////


        public bool A_ThirdName_Wife_IsRequired { get; set; } = false;
        public bool A_ThirdName_Wife_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FourthName English/////////////////////////////////////////////////////////

        public bool E_FourthName_Wife_IsRequired { get; set; } = false;
        public bool E_FourthName_Wife_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FourthName English/////////////////////////////////////////////////////////

        public bool A_FourthName_Wife_IsRequired { get; set; } = false;
        public bool A_FourthName_Wife_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FifthName English/////////////////////////////////////////////////////////

        public bool E_FifthName_Wife_IsRequired { get; set; } = false;
        public bool E_FifthName_Wife_IsVisible { get; set; } = false;

        /////////////////////////////////////////////////////////FifthName Arabic/////////////////////////////////////////////////////////

        public bool A_FifthName_Wife_IsRequired { get; set; } = false;
        public bool A_FifthName_Wife_IsVisible { get; set; } = false;

        #endregion


        #endregion

        #region Step 6 Academic Education

        ///////////////////////////////////////////////////////// SelectAcademicQualificationname/////////////////////////////////////////////////////////
        public bool SelectAcademicQualificationname_IsRequired { get; set; } = false;
        public bool SelectAcademicQualificationname_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// SelectAcademicCountry/////////////////////////////////////////////////////////
        public bool SelectAcademicCountry_IsRequired { get; set; } = false;
        public bool SelectAcademicCountry_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// SelectEducationInstitute/////////////////////////////////////////////////////////
        public bool SelectEducationInstitute_IsRequired { get; set; } = false;
        public bool SelectEducationInstitute_IsVisible { get; set; } = false;


        ///////////////////////////////////////////////////////// SelectMainSpecialization/////////////////////////////////////////////////////////
        public bool SelectMainSpecialization_IsRequired { get; set; } = false;
        public bool SelectMainSpecialization_IsVisible { get; set; } = false;
        ///////////////////////////////////////////////////////// SelectMainSpecialization/////////////////////////////////////////////////////////
        public bool SelectSubSpecialization_IsRequired { get; set; } = false;
        public bool SelectSubSpecialization_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// GraduationDate/////////////////////////////////////////////////////////
        public bool GraduationDate_IsRequired { get; set; } = false;
        public bool GraduationDate_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// Grade/////////////////////////////////////////////////////////
        public bool Grade_IsRequired { get; set; } = false;
        public bool Grade_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// GPA/////////////////////////////////////////////////////////
        public bool GPA_IsRequired { get; set; } = false;
        public bool GPA_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// SelectJobLevel/////////////////////////////////////////////////////////
        public bool SelectJobLevel_IsRequired { get; set; } = false;
        public bool SelectJobLevel_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// EducationFinished/////////////////////////////////////////////////////////
        public bool EducationFinished_IsRequired { get; set; } = false;
        public bool EducationFinished_IsVisible { get; set; } = false;

        ///////////////////////////////////////////////////////// Notes/////////////////////////////////////////////////////////
        public bool Notes_IsRequired { get; set; } = false;
        public bool Notes_IsVisible { get; set; } = false;


        #endregion

        public override IEnumerable<ValidatedModel> Validate()
        {
            throw new NotImplementedException();
        }
    }

}
