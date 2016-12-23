using Models;
using System.Collections.Generic;

namespace GHQ.Logic.Models.Data.Account
{
    public class LoginData : BaseModel
    {
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

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (string.IsNullOrEmpty(EmiratesID))
            {
                errors.Add(new ValidatedModel { Error = "لا يمكن أن تكون فارغة المحمول", PropertyName = "Mobile" });
            }
            if (string.IsNullOrEmpty(UnifiedNumber))
            {
                errors.Add(new ValidatedModel { Error = "كلمة لا يمكن أن يكون الخالي", PropertyName = "Password" });
            }
            return errors;
        }
    }
}
