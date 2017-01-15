using System.Collections.Generic;

namespace Models
{
    public class RadioButtonGroupItem : BaseModel
    {
        private int _Id;
        public int Id
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

        private string _Value;
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                Set(() => Value, ref _Value, value);
            }
        }

        private bool _IsSelected;
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                Set(() => IsSelected, ref _IsSelected, value);
            }
        }

        public override string ToString()
        {
            return Value;
        }
        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            return errors;
        }
    }
}
