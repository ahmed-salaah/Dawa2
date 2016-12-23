using Models;
using System.Collections.Generic;
using System;

namespace GHQ.Logic.Models.Data.Notification
{
    public class NotificationData : BaseModel
    {
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
                DateString = _Date.ToString("yyyy MMMMM dd");
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
        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                Set(() => Description, ref _Description, value);
            }
        }


        private string _Image;
        public string Image
        {
            get
            {
                return _Image = "http://www.iconsfind.com/wp-content/uploads/2015/10/20151012_561bac6b7f711.png";
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
