using Models;
using System.Collections.Generic;

namespace GHQ.Logic.Models.Account.Data
{
    public class UserMobileData : BaseModel
    {
        private string _MobileID;
        public string MobileID
        {
            get
            {
                return _MobileID;
            }
            set
            {
                Set(() => MobileID, ref _MobileID, value);
            }
        }

        private string _MobileNumber;
        public string MobileNumber
        {
            get
            {
                return _MobileNumber;
            }
            set
            {
                Set(() => MobileNumber, ref _MobileNumber, value);
            }
        }

      //  public int MobileNumberClicks { get; set; }


        public override string ToString()
        {
            return MobileNumber;
        }
        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (string.IsNullOrEmpty(MobileNumber))
            {
                errors.Add(new ValidatedModel { Error = "لا يمكن أن تكون فارغة المحمول", PropertyName = "Mobile" });
            }
            if (string.IsNullOrEmpty(MobileID))
            {
                errors.Add(new ValidatedModel { Error = "كلمة لا يمكن أن يكون الخالي", PropertyName = "Password" });
            }
            return errors;
        }
    }
}
