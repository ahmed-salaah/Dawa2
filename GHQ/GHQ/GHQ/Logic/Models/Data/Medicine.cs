using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

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

        private bool _IsMissed;
        public bool IsMissed
        {
            get
            {
                return _IsMissed;
            }
            set
            {
                Set(() => IsMissed, ref _IsMissed, value);
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

        private string _DiseaseName;
        public string DiseaseName
        {
            get
            {
                return _DiseaseName;
            }
            set
            {
                Set(() => DiseaseName, ref _DiseaseName, value);
            }
        }


        private DateTime _StartDate;
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                Set(() => StartDate, ref _StartDate, value);
            }
        }

        private DateTime _EndDate;
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                Set(() => EndDate, ref _EndDate, value);
            }
        }


        private DateTime _NextDate;
        public DateTime NextDate
        {
            get
            {
                return _NextDate;
            }
            set
            {
                Set(() => NextDate, ref _NextDate, value);
            }
        }

        public string NextDateFormated
        {
            get
            {
                var day = NextDate.DayOfWeek;
                var date = NextDate.ToString("dd MMMMM yyyy", new CultureInfo("ar-AE"));
                var time = NextDate.TimeOfDay;
                var period = "عصر ";
                var formatedDate = string.Format("{0} - {1} - {2} {3}", day, date, time, period);
                return formatedDate;
            }
        }

        private ImageSource _ImageSource = ImageSource.FromResource("profile_photo.png");
        public ImageSource ImageSource
        {
            get
            {
                return _ImageSource;
            }
            set
            {
                Set(() => ImageSource, ref _ImageSource, value);
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
