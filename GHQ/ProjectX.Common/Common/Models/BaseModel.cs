using System.Collections.Generic;

namespace Models
{
    public abstract class BaseModel : BaseViewModel
    {
        public abstract IEnumerable<ValidatedModel> Validate();
    }

}
