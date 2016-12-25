using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Models
{
    public class BaseViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        public BaseViewModel()
        {

        }
        private bool _IsPageEnabled;
        public bool IsPageEnabled
        {
            get
            {
                return _IsPageEnabled;
            }
            set
            {
                Set(() => IsPageEnabled, ref _IsPageEnabled, value);
            }
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get
            {
                return _IsLoading;
            }
            set
            {
                Set(() => IsLoading, ref _IsLoading, value);
            }
        }

        private ObservableCollection<ValidatedModel> _ValidationErrors;
        public ObservableCollection<ValidatedModel> ValidationErrors
        {
            get
            {
                return _ValidationErrors;
            }
            set
            {
                Set(() => ValidationErrors, ref _ValidationErrors, value);
                RaisePropertyChanged("HasErrors");
            }
        }

        public string ErrorMessagesString
        {
            get
            {
                string errors = "";
                if (ValidationErrors == null)
                    return errors;
                foreach (var item in ValidationErrors)
                {
                    errors += string.Format("{0}", item.Error) + Environment.NewLine;
                }
                return errors;
            }
        }

        public bool HasErrors
        {
            get
            {
                return ValidationErrors != null ? ValidationErrors.Any() : false;
            }
        }

        protected void ClearValidationErrors()
        {
            ValidationErrors = new ObservableCollection<ValidatedModel>();
        }
    }
}
