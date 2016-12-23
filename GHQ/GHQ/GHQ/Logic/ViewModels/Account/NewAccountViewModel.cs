using Exceptions;
using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Models.Account.Data;
using GHQ.Logic.Service.Account;
using GHQ.Resources.Strings;
using GHQ.UI.Pages.Home;
using GHQ.UI.Pages.Account;
using Models;
using Service.Dialog;
using Service.Exception;
using Service.Naviagtion;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GHQ.Logic.Service.Lookup;

namespace GHQ.Logic.ViewModels.Account
{
    public class NewAccountViewModel : BaseViewModel
    {
        public NewAccountViewModel(INavigationService _navigationService, IAccountService _accountService, ILookupService _lookupService, IDialogService _dialogService, IExceptionService _excpetionService)
        {
            accountService = _accountService;
            navigationService = _navigationService;
            dialogService = _dialogService;
            excpetionService = _excpetionService;
            lookupService = _lookupService;
        }

        #region Private Members

        INavigationService navigationService;
        IAccountService accountService;
        IDialogService dialogService;
        IExceptionService excpetionService;
        ILookupService lookupService;
        #endregion

        #region Properties

        private NewAccountData _NewAccount;
        public NewAccountData NewAccount
        {
            get
            {
                return _NewAccount;
            }
            set
            {
                Set(() => NewAccount, ref _NewAccount, value);
            }
        }

        private int _SelectedUserMobileIndex;
        public int SelectedUserMobileIndex
        {
            get
            {
                return _SelectedUserMobileIndex;
            }
            set
            {
                if (_SelectedUserMobileIndex == value)
                    return;
                Set(() => SelectedUserMobileIndex, ref _SelectedUserMobileIndex, value);
                if (value > 0)
                {
                    NewAccount.NewAccountStep2.SelectedUserMobile = NewAccount.NewAccountStep2.UserMobileList[value];
                    if (NewAccount.NewAccountStep2.SelectedUserMobile.MobileID == "-1")
                    {
                        dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_MobileNotExists);
                    }
                    //else
                    //{
                    //    NewAccount.NewAccountStep2.SelectedUserMobile.MobileNumberClicks = 0;
                    //}
                }
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

        private int _SelectedGenderListIndex;
        public int SelectedGenderListIndex
        {
            get
            {
                return _SelectedGenderListIndex;
            }
            set
            {
                Set(() => SelectedGenderListIndex, ref _SelectedGenderListIndex, value);
                if (value >= 0)
                {
                    NewAccount.NewAccountStep4.SelectedGender = GenderList[value];
                }
            }
        }



        private ObservableCollection<LookupData> _NationalityList;
        public ObservableCollection<LookupData> NationalityList
        {
            get
            {
                return _NationalityList;
            }
            set
            {
                Set(() => NationalityList, ref _NationalityList, value);
            }
        }

        private int _SelectedNationalityListIndex;
        public int SelectedNationalityListIndex
        {
            get
            {
                return _SelectedNationalityListIndex;
            }
            set
            {
                Set(() => SelectedNationalityListIndex, ref _SelectedNationalityListIndex, value);
                if (value >= 0)
                {
                    NewAccount.NewAccountStep4.SelectedNationality = NationalityList[value];
                }
            }
        }

        #endregion

        #region Private Methods

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
                if (NationalityList == null)
                {
                    NationalityList = new ObservableCollection<LookupData>(await lookupService.GetNationalityAsync());
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
                ClearValidationErrors();
                NewAccount = new NewAccountData();

#if DEBUG
                NewAccount.NewAccountStep1.EmiratesID = "784-1976-1240156-7";
                NewAccount.NewAccountStep1.UnifiedNumber = "2222";
#endif


            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
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

        #region IntializeStep4 Command

        private RelayCommand _OnIntializeStep4Command;
        public RelayCommand OnIntializeStep4Command
        {
            get
            {
                if (_OnIntializeStep4Command == null)
                {
                    _OnIntializeStep4Command = new RelayCommand(IntializeStep4);
                }
                return _OnIntializeStep4Command;
            }
        }
        private async void IntializeStep4()
        {
            try
            {
                await PopulateGenders();
                await PopulateNationality();

                if (string.IsNullOrEmpty(NewAccount.NewAccountStep4.Gender))
                {
                    NewAccount.NewAccountStep4.SelectedGender = GenderList.FirstOrDefault();
                }
                else
                {
                    NewAccount.NewAccountStep4.SelectedGender = GenderList.FirstOrDefault(a => a.Id == NewAccount.NewAccountStep4.Gender);
                }

                NewAccount.NewAccountStep4.SelectedNationality = NationalityList.FirstOrDefault(a => a.Id == NewAccount.NewAccountStep4.Nationality);
            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
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

        private RelayCommand _OnNextFirstStepCommand;
        public RelayCommand OnNextFirstStepCommand
        {
            get
            {
                if (_OnNextFirstStepCommand == null)
                {
                    _OnNextFirstStepCommand = new RelayCommand(OnNextFirstStep);
                }
                return _OnNextFirstStepCommand;
            }
        }
        private async void OnNextFirstStep()
        {
            try
            {
                if (IsLoading)
                    return;

                IsPageEnabled = false;
                ClearValidationErrors();
                ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(NewAccount.NewAccountStep1.Validate());
                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    IsLoading = true;
                    NewAccount = await accountService.GetMOIUserInfoAsync(NewAccount.NewAccountStep1.EmiratesID, NewAccount.NewAccountStep1.UnifiedNumber);
                    NewAccount.NewAccountStep2.SelectedUserMobile = NewAccount.NewAccountStep2.UserMobileList.FirstOrDefault();


                    NewAccount.NewAccountStep2.HasEmailValidation = await accountService.IsEmailRequiredAsync(false);
                    int stepNumber = await accountService.GetStepOfAccountCreationAsync(NewAccount.NewAccountStep1.EmiratesID, NewAccount.NewAccountStep1.UnifiedNumber);
                    switch (stepNumber)
                    {
                        case 1:
                            navigationService.NavigateToPage(typeof(NewAccountStep2Page));
                            break;
                        case 2:
                            navigationService.NavigateToPage(typeof(NewAccountStep2Page));
                            break;
                        case 3:
                            navigationService.NavigateToPage(typeof(NewAccountStep3Page));
                            break;
                        case 4:
                            navigationService.NavigateToPage(typeof(NewAccountStep4Page));
                            break;
                        case -1:
                            dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_UserAlreadyExists);
                            break;
                        case -2:
                            dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_UserNotEligibleToCreateAccount);
                            break;
                        case -3:
                            dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_DataIsInvalid);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
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

        #region OnSendSMSVerfiicationCodeCommand

        private RelayCommand _OnSendSMSVerfiicationCodeCommand;
        public RelayCommand OnSendSMSVerfiicationCodeCommand
        {
            get
            {
                if (_OnSendSMSVerfiicationCodeCommand == null)
                {
                    _OnSendSMSVerfiicationCodeCommand = new RelayCommand(OnSendSMSVerfiicationCode);
                }
                return _OnSendSMSVerfiicationCodeCommand;
            }
        }
        private async void OnSendSMSVerfiicationCode()
        {
            try
            {
                if (IsLoading)
                    return;

                IsPageEnabled = false;
                ClearValidationErrors();
                ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>();
                if (NewAccount.NewAccountStep2.SelectedUserMobile == null || NewAccount.NewAccountStep2.SelectedUserMobile.MobileID == "-1")
                {
                    ValidationErrors.Add(new ValidatedModel { Error = AppResources.NewAccount_Messages_MobileNotValid, PropertyName = "SelectedUserMobile" });
                }
                else if (NewAccount.NewAccountStep2.SelectedUserMobile == null || NewAccount.NewAccountStep2.SelectedUserMobile.MobileID == "-2")
                {
                    return;
                }
                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    IsLoading = true;
                    //NewAccount.NewAccountStep2.SelectedUserMobile.MobileNumberClicks++;
                    //if (NewAccount.NewAccountStep2.SelectedUserMobile.MobileNumberClicks >= Constant.Constant.MaxSendingCode)
                    //{
                    //    await dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_MaxSendingCode); 
                    //}
                    //else
                    //{
                    var result = await accountService.SendVerificationCodeBySMSAsync(NewAccount.NewAccountStep1.EmiratesID, NewAccount.NewAccountStep1.UnifiedNumber, NewAccount.NewAccountStep2.SelectedUserMobile.MobileID);
                    if (result)
                    {
                        await dialogService.DisplayAlert("", AppResources.NewAccount_Messages_SMSSent_Description);
                        ClearValidationErrors();
                    }
                    else
                    {
                        await dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_SMSNotSent);
                    }
                    // }

                }
            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
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

        #region Next Second Step Command

        private RelayCommand _OnNextSecondStepCommand;
        public RelayCommand OnNextSecondStepCommand
        {
            get
            {
                if (_OnNextSecondStepCommand == null)
                {
                    _OnNextSecondStepCommand = new RelayCommand(OnNextSecondStep);
                }
                return _OnNextSecondStepCommand;
            }
        }
        private async void OnNextSecondStep()
        {
            try
            {
                if (IsLoading)
                    return;

                IsPageEnabled = false;
                ClearValidationErrors();
                ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(NewAccount.NewAccountStep2.Validate());
                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    IsLoading = true;
                    NewAccount.NewAccountStep2.MobileNumberIsConfirmed = await accountService.VerifyMyCodeAsync(NewAccount.NewAccountStep1.EmiratesID, NewAccount.NewAccountStep1.UnifiedNumber, NewAccount.NewAccountStep2.SelectedUserMobile.MobileID, NewAccount.NewAccountStep2.MobileNumberConfirmationCode);

                    if (NewAccount.NewAccountStep2.MobileNumberIsConfirmed)
                    {
                        ClearValidationErrors();
                        navigationService.NavigateToPage(typeof(NewAccountStep3Page));
                    }
                    else
                    {
                        await dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_ConfirmationCodeIsNotValid);
                    }
                }
            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
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

        #region Next Third Step Command

        private RelayCommand _OnNextThirdStepCommand;
        public RelayCommand OnNextThirdStepCommand
        {
            get
            {
                if (_OnNextThirdStepCommand == null)
                {
                    _OnNextThirdStepCommand = new RelayCommand(OnNextThirdStep);
                }
                return _OnNextThirdStepCommand;
            }
        }
        private async void OnNextThirdStep()
        {
            try
            {
                if (IsLoading)
                    return;

                IsPageEnabled = false;
                ClearValidationErrors();
                ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(NewAccount.NewAccountStep3.Validate());
                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    IsLoading = true;
                    var result = await accountService.VerifyMyCodeAsync(NewAccount.NewAccountStep1.EmiratesID, NewAccount.NewAccountStep1.UnifiedNumber, NewAccount.NewAccountStep3.Email, NewAccount.NewAccountStep3.EmailConfirmatiionCode);
                    if (result)
                    {
                        ClearValidationErrors();
                        navigationService.NavigateToPage(typeof(NewAccountStep4Page));
                    }
                    else
                    {
                        await dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_ConfirmationCodeIsNotValid);
                    }
                }
            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
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

        #region On Verfiy Email Command

        private RelayCommand _OnVerfiyEmailCommand;
        public RelayCommand OnVerfiyEmailCommand
        {
            get
            {
                if (_OnVerfiyEmailCommand == null)
                {
                    _OnVerfiyEmailCommand = new RelayCommand(OnVerfiyEmail);
                }
                return _OnVerfiyEmailCommand;
            }
        }
        private async void OnVerfiyEmail()
        {
            try
            {
                if (IsLoading)
                    return;

                IsPageEnabled = false;
                ClearValidationErrors();
                bool isEmailValid = Validations.Validation.ValidateMail(NewAccount.NewAccountStep3.Email);
                if (string.IsNullOrEmpty(NewAccount.NewAccountStep3.Email))
                {
                    ValidationErrors.Add(new ValidatedModel() { Error = AppResources.Error_Validation_Email_Empty, PropertyName = "Email" });
                }
                else if (!isEmailValid)
                {
                    ValidationErrors.Add(new ValidatedModel { Error = AppResources.Error_Validation_Email, PropertyName = "Email" });
                }
                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    IsLoading = true;
                    var result = await accountService.SendVerificationCodeByEmailAsync(NewAccount.NewAccountStep1.EmiratesID, NewAccount.NewAccountStep1.UnifiedNumber, NewAccount.NewAccountStep3.Email);
                    if (result)
                    {
                        await dialogService.DisplayAlert("", AppResources.NewAccount_Messages_EmailSent_Description);
                        ClearValidationErrors();
                    }
                }
            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
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

        #region OnSkipThirdStep Command

        private RelayCommand _OnSkipThirdStepCommand;
        public RelayCommand OnSkipThirdStepCommand
        {
            get
            {
                if (_OnSkipThirdStepCommand == null)
                {
                    _OnSkipThirdStepCommand = new RelayCommand(OnSkipThirdStep);
                }
                return _OnSkipThirdStepCommand;
            }
        }
        private async void OnSkipThirdStep()
        {
            try
            {
                navigationService.NavigateToPage(typeof(NewAccountStep4Page));
            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
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

        #region Next Fourth Step Command

        private RelayCommand _OnNextFourthStepCommand;
        public RelayCommand OnNextFourthStepCommand
        {
            get
            {
                if (_OnNextFourthStepCommand == null)
                {
                    _OnNextFourthStepCommand = new RelayCommand(OnNextFourthStep);
                }
                return _OnNextFourthStepCommand;
            }
        }
        private async void OnNextFourthStep()
        {
            try
            {
                if (IsLoading)
                    return;

                IsPageEnabled = false;
                ClearValidationErrors();
                ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(NewAccount.NewAccountStep4.Validate());
                if (ValidationErrors.Any())
                {
                    await dialogService.DisplayAlert("", ErrorMessagesString);
                }
                else if (!ValidationErrors.Any())
                {
                    IsLoading = true;
                    var result = await accountService.AddUserAccountAsync(NewAccount);
                    if (result == 1)
                    {
                        await dialogService.DisplayAlert("", AppResources.NewAccount_Messages_AccountUpdated_Description);
                        ClearValidationErrors();
                        navigationService.NavigateToPage(typeof(HomePage));
                    }
                    else
                    {
                        switch (result)
                        {
                            case -1:
                                dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_UserDataIsNotSimilarToHash_MOI_UP);
                                break;
                            case -2:
                                dialogService.DisplayAlert(AppResources.Error, AppResources.NewAccount_Messages_UserNotEligibleToCreateAccount);
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            catch (InternetException ex)
            {
                await dialogService.DisplayAlert(AppResources.Error_GeneralTitle, AppResources.Error_NoInternet);
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
