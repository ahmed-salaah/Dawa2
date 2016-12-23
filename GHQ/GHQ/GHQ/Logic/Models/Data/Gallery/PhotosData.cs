using System.Collections.Generic;
using Models;

namespace GHQ.Logic.Models.Data.PhotosData
{
    public class PhotosData : BaseModel
    {
        private string _Image;
        public string Image
        {
            get
            {
                return _Image;
            }
            set
            {
                Set(() => Image, ref _Image, value);
            }
        }

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            return errors;
        }

    }
}
