using GalaSoft.MvvmLight.Command;
using GHQ.Logic.Models.Data.Account;
using GHQ.Logic.Service.Inquiry;
using Models;

namespace GHQ.Logic.ViewModels.Inquiry
{
    public class InquiryViewModel : BaseViewModel
    {
        public InquiryViewModel(IInquiryService _inquiryService)
        {
            inquiryService = _inquiryService;
        }

        #region Private Members

        IInquiryService inquiryService;

        #endregion

        #region Properties

        private LoginData _LoginData;
        public LoginData LoginData
        {
            get
            {
                return _LoginData;
            }
            set
            {
                Set(() => LoginData, ref _LoginData, value);
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
        private void Intialize()
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

        #region Login Command

        private RelayCommand _OnLoginCommand;
        public RelayCommand OnLoginCommand
        {
            get
            {
                if (_OnLoginCommand == null)
                {
                    _OnLoginCommand = new RelayCommand(OnLogin);
                }
                return _OnLoginCommand;
            }
        }
        private void OnLogin()
        {
            try
            {
                ValidationErrors = new System.Collections.ObjectModel.ObservableCollection<ValidatedModel>(LoginData.Validate());
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
