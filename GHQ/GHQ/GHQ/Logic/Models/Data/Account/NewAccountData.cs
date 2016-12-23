using GHQ.Resources.Strings;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GHQ.Logic.Models.Account.Data
{
    public class NewAccountData : BaseModel
    {
        public NewAccountData()
        {
            NewAccountStep1 = new NewAccountDataStep1();
            NewAccountStep2 = new NewAccountDataStep2();
            NewAccountStep3 = new NewAccountDataStep3();
            NewAccountStep4 = new NewAccountDataStep4();
        }

        private NewAccountDataStep1 _NewAccountStep1;
        public NewAccountDataStep1 NewAccountStep1
        {
            get
            {
                return _NewAccountStep1;
            }
            set
            {
                Set(() => NewAccountStep1, ref _NewAccountStep1, value);
            }
        }

        private NewAccountDataStep2 _NewAccountStep2;
        public NewAccountDataStep2 NewAccountStep2
        {
            get
            {
                return _NewAccountStep2;
            }
            set
            {
                Set(() => NewAccountStep2, ref _NewAccountStep2, value);
            }
        }

        private NewAccountDataStep3 _NewAccountStep3;
        public NewAccountDataStep3 NewAccountStep3
        {
            get
            {
                return _NewAccountStep3;
            }
            set
            {
                Set(() => NewAccountStep3, ref _NewAccountStep3, value);
            }
        }

        private NewAccountDataStep4 _NewAccountStep4;
        public NewAccountDataStep4 NewAccountStep4
        {
            get
            {
                return _NewAccountStep4;
            }
            set
            {
                Set(() => NewAccountStep4, ref _NewAccountStep4, value);
            }
        }

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors_ServiceRegistrationStep1 = NewAccountStep1.Validate().ToList();
            List<ValidatedModel> errors_ServiceRegistrationStep2 = NewAccountStep2.Validate().ToList();
            List<ValidatedModel> errors_ServiceRegistrationStep3 = NewAccountStep3.Validate().ToList();
            List<ValidatedModel> errors_ServiceRegistrationStep4 = NewAccountStep4.Validate().ToList();
            var errors_Total = errors_ServiceRegistrationStep1.Concat(errors_ServiceRegistrationStep2).Concat(errors_ServiceRegistrationStep3).Concat(errors_ServiceRegistrationStep4);
            return errors_Total;
        }
    }

    public class NewAccountDataStep1 : BaseModel
    {
        private string _EmiratesID;
        public string EmiratesID
        {
            get
            {
                return _EmiratesID;
            }
            set
            {
                Set(() => EmiratesID, ref _EmiratesID, value);
            }
        }

        private string _UnifiedNumber;
        public string UnifiedNumber
        {
            get
            {
                return _UnifiedNumber;
            }
            set
            {
                Set(() => UnifiedNumber, ref _UnifiedNumber, value);
            }
        }

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (string.IsNullOrEmpty(EmiratesID))
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_EmiratesID_Empty, PropertyName = "EmiratesID" });
            }
            else if (!Validations.Validation.ValidateEmiratesId(EmiratesID))
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_EmiratesID_Invalid, PropertyName = "EmiratesID" });
            }
            if (string.IsNullOrEmpty(UnifiedNumber))
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_UnifiedNumber_Empty, PropertyName = "UnifiedNumber" });
            }
            else if (Validations.Validation.ValidateHasSpecialCharchters(UnifiedNumber))
            {
                errors.Add(new ValidatedModel { Error = string.Format("{0} {1}", AppResources.FeildIsInvalid, AppResources.NewAccount_Entry_PlaceHolder_IdentityNumber), PropertyName = "UnifiedNumber" });
            }
            return errors;
        }
    }

    public class NewAccountDataStep2 : BaseModel
    {
        private string _MobileNumberConfirmationCode;
        public string MobileNumberConfirmationCode
        {
            get
            {
                return _MobileNumberConfirmationCode;
            }
            set
            {
                Set(() => MobileNumberConfirmationCode, ref _MobileNumberConfirmationCode, value);
            }
        }

        private bool _MobileNumberIsConfirmed;
        public bool MobileNumberIsConfirmed
        {
            get
            {
                return _MobileNumberIsConfirmed;
            }
            set
            {
                Set(() => MobileNumberIsConfirmed, ref _MobileNumberIsConfirmed, value);
            }
        }

        private bool _HasEmailValidation;
        public bool HasEmailValidation
        {
            get
            {
                return _HasEmailValidation;
            }
            set
            {
                Set(() => HasEmailValidation, ref _HasEmailValidation, value);
            }
        }

        private ObservableCollection<UserMobileData> _UserMobileList;
        public ObservableCollection<UserMobileData> UserMobileList
        {
            get
            {
                return _UserMobileList;
            }
            set
            {
                Set(() => UserMobileList, ref _UserMobileList, value);
            }
        }

        private UserMobileData _SelectedUserMobile;
        public UserMobileData SelectedUserMobile
        {
            get
            {
                return _SelectedUserMobile;
            }
            set
            {
                Set(() => SelectedUserMobile, ref _SelectedUserMobile, value);
            }
        }


        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (SelectedUserMobile?.MobileID == "-1")
            {
                errors.Add(new ValidatedModel { Error = AppResources.NewAccount_Messages_MobileNotExists, PropertyName = "MobileNumber" });
            }
            else
            {
                if (string.IsNullOrEmpty(SelectedUserMobile?.MobileNumber) || SelectedUserMobile?.MobileID == "-2")
                {
                    errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_MobileNumber_Empty, PropertyName = "MobileNumber" });
                }
                if (string.IsNullOrEmpty(MobileNumberConfirmationCode))
                {
                    errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_MobileNumberConfirmation_Empty, PropertyName = "MobileNumberConfirmationCode" });
                }
                else if (MobileNumberConfirmationCode.Length != 6)
                {
                    errors.Add(new ValidatedModel { Error = AppResources.NewAccount_Messages_CodeIsInvalid, PropertyName = "MobileNumberConfirmationCode" });
                }
            }

            return errors;
        }
    }

    public class NewAccountDataStep3 : BaseModel
    {
        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                Set(() => Email, ref _Email, value);
            }
        }

        private string _EmailConfirmatiionCode;
        public string EmailConfirmatiionCode
        {
            get
            {
                return _EmailConfirmatiionCode;
            }
            set
            {
                Set(() => EmailConfirmatiionCode, ref _EmailConfirmatiionCode, value);
            }
        }

        private bool _EmailIsConfirmed;
        public bool EmailIsConfirmed
        {
            get
            {
                return _EmailIsConfirmed;
            }
            set
            {
                Set(() => EmailIsConfirmed, ref _EmailIsConfirmed, value);
            }
        }
        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            bool isEmailValid = Validations.Validation.ValidateMail(Email);
            if (string.IsNullOrEmpty(Email))
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_Email_Empty, PropertyName = "Email" });
            }
            else if (!isEmailValid)
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_Email, PropertyName = "Email" });
            }
            if (string.IsNullOrEmpty(EmailConfirmatiionCode))
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_EmailConfirmation_Empty, PropertyName = "EmailConfirmatiionCode" });
            }
            else if (EmailConfirmatiionCode.Length != 6)
            {
                errors.Add(new ValidatedModel { Error = AppResources.NewAccount_Messages_CodeIsInvalid, PropertyName = "EmailConfirmatiionCode" });
            }
            return errors;
        }
    }

    public class NewAccountDataStep4 : BaseModel
    {
        private bool _MOIIsDown;
        public bool MOIIsDown
        {
            get
            {
                return _MOIIsDown;
            }
            set
            {
                Set(() => MOIIsDown, ref _MOIIsDown, value);
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                Set(() => FirstName, ref _FirstName, value);
            }
        }

        private string _SecondName;
        public string SecondName
        {
            get
            {
                return _SecondName;
            }
            set
            {
                Set(() => SecondName, ref _SecondName, value);
            }
        }

        private string _ThirdName;
        public string ThirdName
        {
            get
            {
                return _ThirdName;
            }
            set
            {
                Set(() => ThirdName, ref _ThirdName, value);
            }
        }

        private string _FourthName;
        public string FourthName
        {
            get
            {
                return _FourthName;
            }
            set
            {
                Set(() => FourthName, ref _FourthName, value);
            }
        }

        public bool CanEditFourthName
        {
            get
            {
                return MOIIsDown && String.IsNullOrEmpty(FourthName);
            }
        }

        private string _FifthName;
        public string FifthName
        {
            get
            {
                return _FifthName;
            }
            set
            {
                Set(() => FifthName, ref _FifthName, value);
            }
        }

        public bool CanEditFifthName
        {
            get
            {
                return MOIIsDown && String.IsNullOrEmpty(FifthName);
            }
        }

        private string _Gender;
        public string Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                Set(() => Gender, ref _Gender, value);
            }
        }

        private LookupData _SelectedGender;
        public LookupData SelectedGender
        {
            get
            {
                return _SelectedGender;
            }
            set
            {
                Set(() => SelectedGender, ref _SelectedGender, value);
            }
        }

        private string _Nationality;
        public string Nationality
        {
            get
            {
                return _Nationality;
            }
            set
            {
                Set(() => Nationality, ref _Nationality, value);
            }
        }

        private LookupData _SelectedNationality;
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

        private DateTime _DOB;
        public DateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                Set(() => DOB, ref _DOB, value);
            }
        }

        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                Set(() => Password, ref _Password, value);
            }
        }

        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _ConfirmPassword;
            }
            set
            {
                Set(() => ConfirmPassword, ref _ConfirmPassword, value);
            }
        }

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_FirstName_Empty, PropertyName = "FirstName" });
            }
            else if (!Validations.Validation.ValidateArabicName(FirstName))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicFirstName), PropertyName = "FirstName" });
            }

            if (string.IsNullOrEmpty(SecondName))
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_SecondName_Empty, PropertyName = "SecondName" });
            }
            else if (!Validations.Validation.ValidateArabicName(SecondName))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicSecondName), PropertyName = "SecondName" });
            }


            if (string.IsNullOrEmpty(ThirdName))
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_ThirdName_Empty, PropertyName = "ThirdName" });
            }
            else if (!Validations.Validation.ValidateArabicName(ThirdName))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicThirdName), PropertyName = "ThirdName" });
            }

            if (!string.IsNullOrEmpty(FourthName) && !Validations.Validation.ValidateArabicName(FourthName))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicFourthName), PropertyName = "Fourth" });
            }

            if (!string.IsNullOrEmpty(FifthName) && !Validations.Validation.ValidateArabicName(FifthName))
            {
                errors.Add(new ValidatedModel { Error = string.Format(AppResources.ArabicFeildIsInvalid, AppResources.ServiceRegistration_Entry_PlaceHolder_ArabicFifthName), PropertyName = "FifthName" });
            }

            if (SelectedGender == null || SelectedGender.Id == "-1")
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_Gender_Empty, PropertyName = "SelectedGender" });
            }

            if (SelectedNationality == null || SelectedNationality.Id == "-1")
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_Nationality_Empty, PropertyName = "SelectedNationality" });
            }
            if (string.IsNullOrEmpty(Password))
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_Password_Empty, PropertyName = "Password" });
            }
            if (string.IsNullOrEmpty(ConfirmPassword) && Password == ConfirmPassword)
            {
                errors.Add(new ValidatedModel { Error = AppResources.Error_Validation_PasswordConfirmation_MisMatch, PropertyName = "ConfirmPassword" });
            }

            return errors;
        }
    }
}
