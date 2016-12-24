using Models;
using System.Collections.Generic;

namespace Logic.Models.Data
{
    public class Medicine : BaseModel
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

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                Set(() => Name, ref _Name, value);
            }
        }

        private string _DoctorName;
        public string DoctorName
        {
            get
            {
                return _DoctorName;
            }
            set
            {
                Set(() => DoctorName, ref _DoctorName, value);
            }
        }

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

        private string _Note;
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                Set(() => Note, ref _Note, value);
            }
        }

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
           
            return errors;
        }
    }
}
