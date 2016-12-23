using Models;
using System.Collections.Generic;

namespace GHQ.Logic.Models.Data.Account
{
    public class ForgetPasswordData : BaseModel
    {
        private string _ConfirmationCode;
        public string ConfirmationCode
        {
            get
            {
                return _ConfirmationCode;
            }
            set
            {
                Set(() => ConfirmationCode, ref _ConfirmationCode, value);
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
            if (string.IsNullOrEmpty(Password))
            {
                errors.Add(new ValidatedModel { Error = "لا يمكن أن تكون فارغة المحمول", PropertyName = "Mobile" });
            }
            if (string.IsNullOrEmpty(ConfirmationCode))
            {
                errors.Add(new ValidatedModel { Error = "كلمة لا يمكن أن يكون الخالي", PropertyName = "Password" });
            }
            return errors;
        }
    }
}
