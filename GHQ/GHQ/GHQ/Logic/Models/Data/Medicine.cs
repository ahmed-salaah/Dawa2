using Models;
using System.Collections.Generic;

namespace Logic.Models.Data
{
    public class Medicine : BaseModel
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
           
            return errors;
        }
    }
}
