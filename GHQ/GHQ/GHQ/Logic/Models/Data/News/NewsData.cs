using Models;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace GHQ.Logic.Models.Data.News
{
    public class NewsData : BaseModel
    {
        private string _ShortDescription;
        public string ShortDescription
        {
            get
            {
                return _ShortDescription;
            }
            set
            {
                Set(() => ShortDescription, ref _ShortDescription, value);
            }
        }
        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                Set(() => Title, ref _Title, value);
            }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                Set(() => Date, ref _Date, value);
                DateString = _Date.ToString("dd MMMMM yyyy", new CultureInfo("ar-AE"));
            }
        }
        private String _DateString;
        public string DateString
        {
            get
            {
                return _DateString;
            }
            set
            {
                Set(() => DateString, ref _DateString, value);
            }
        }
        private string _EventDescription;
        public string EventDescription
        {
            get
            {
                return _EventDescription;
            }
            set
            {
                Set(() => EventDescription, ref _EventDescription, value);
            }
        }


        private string _Image;
        public string Image
        {
            get
            {
                return _Image = "https://dl.dropboxusercontent.com/u/15405714/Android_icons-assets/144.png";
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
