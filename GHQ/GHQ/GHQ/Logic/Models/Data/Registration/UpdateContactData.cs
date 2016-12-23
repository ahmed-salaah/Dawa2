using GHQ.Logic.Models.Account.Data;
using GHQ.Resources.Strings;
using Models;
using System;
using System.Collections.Generic;

namespace GHQ.Logic.Models.Data.Registration
{
    public class UpdateContactData : BaseModel
    {
        public string EmiratesID { get; set; }
        public DateTime EmiratesIDExpiryDate { get; set; }
        public string EmiratesIDCardNumber { get; set; }
        public string CityID { get; set; }
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
        public string PassportNumber { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public DateTime PassportExpiryDate { get; set; }
        public string PassportType { get; set; }

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
            }
        }

        public string PassportIssuePlace { get; set; }

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
            }
        }

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

        public bool? IsDeleted { get; set; }

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (EmiratesIDExpiryDate == DateTime.MinValue)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_EmiratesIDExpiryDate), PropertyName = "EmiratesIDExpiryDate" });
            }
            if (string.IsNullOrEmpty(PassportNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Passport), PropertyName = "PlaceOfBirth" });
            }
            if (PassportIssueDate == DateTime.MinValue)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_PassportIssuanceDate), PropertyName = "PassportIssueDate" });
            }
            if (PassportExpiryDate == DateTime.MinValue)
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_PassportExpiryDate), PropertyName = "PassportExpiryDate" });
            }
            if (PassportIssueDate >= PassportExpiryDate)
            {
                errors.Add(new ValidatedModel { Error = AppResources.ServiceRegistration_PassportIssuanceGreaterThanExpiry, PropertyName = "PassportExpiryDate" });
            }
            if (string.IsNullOrEmpty(PassportIssuePlace))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Picker_PassportIssuancePlace), PropertyName = "PassportIssuePlace" });
            }
            if (string.IsNullOrEmpty(StreetName))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_StreetName), PropertyName = "StreetName" });
            }
            if (string.IsNullOrEmpty(StreetNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_StreetNumber), PropertyName = "StreetNumber" });
            }
            if (string.IsNullOrEmpty(BldgName))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_BldgName), PropertyName = "BldgName" });
            }
            if (string.IsNullOrEmpty(BldgNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_BldgNumber), PropertyName = "BldgNumber" });
            }
            if (string.IsNullOrEmpty(HomePhone1))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_HomePhone1), PropertyName = "HomePhone1" });
            }
            if (string.IsNullOrEmpty(HomePhone2))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_HomePhone2), PropertyName = "HomePhone2" });
            }
            if (string.IsNullOrEmpty(FloorNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_FloorNumber), PropertyName = "FloorNumber" });
            }
            if (string.IsNullOrEmpty(Mobile1))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Mobile1), PropertyName = "Mobile1" });
            }
            if (string.IsNullOrEmpty(Mobile2))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_Mobile2), PropertyName = "Mobile2" });
            }
            if (string.IsNullOrEmpty(GuardianNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_GuardianNumber), PropertyName = "GuardianNumber" });
            }


            if (string.IsNullOrEmpty(EmailCandidate))
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
            if (string.IsNullOrEmpty(POBox))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_POBox), PropertyName = "POBox" });
            }
            if (string.IsNullOrEmpty(AddressText.Trim()))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsManadtory, AppResources.ServiceRegistration_Entry_PlaceHolder_AddressText), PropertyName = "AddressText" });
            }
            return errors;
        }
    }

}
