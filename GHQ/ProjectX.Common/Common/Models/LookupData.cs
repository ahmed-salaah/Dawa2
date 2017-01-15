using System.Collections.Generic;

namespace Models
{
    public class LookupData : BaseModel
    {
        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                Set(() => Id, ref _Id, value);
            }
        }

        private string _ValueEn;
        public string ValueEn
        {
            get
            {
                return _ValueEn;
            }
            set
            {
                Set(() => ValueEn, ref _ValueEn, value);
            }
        }

        private string _ValueAr;
        public string ValueAr
        {
            get
            {
                return _ValueAr;
            }
            set
            {
                Set(() => ValueAr, ref _ValueAr, value);
            }
        }

        private string _LookupValueParentID;
        public string LookupValueParentID
        {
            get
            {
                return _LookupValueParentID;
            }
            set
            {
                Set(() => LookupValueParentID, ref _LookupValueParentID, value);
            }
        }


        public override string ToString()
        {
            return ValueAr;
        }
        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            return errors;
        }
    }
}
