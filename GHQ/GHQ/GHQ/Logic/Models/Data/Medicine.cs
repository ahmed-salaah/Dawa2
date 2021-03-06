﻿using GHQ.Resources.Strings;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace Logic.Models.Data
{
    public class Medicine : BaseModel
    {
        public Medicine()
        {
            Reminder = new Reminder();
        }
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

        public string StartDateFormated { get { return StartDate.ToString("yyyy MMMMM dd"); } }


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

        public string EndDateFormated { get { return EndDate.ToString("yyyy MMMMM dd"); } }

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

        private string _ImagePath;
        public string ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {
                Set(() => ImagePath, ref _ImagePath, value);
            }
        }

        private string _VoiceNotePath;
        public string VoiceNotePath
        {
            get
            {
                return _VoiceNotePath;
            }
            set
            {
                Set(() => VoiceNotePath, ref _VoiceNotePath, value);
                RaisePropertyChanged("HasRecording");
            }
        }

        public bool HasRecording
        {
            get
            {
                if (string.IsNullOrEmpty(VoiceNotePath))
                {
                    return false;
                }
                else
                {
                    return true;
                }
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

        private Reminder _Reminder;
        public Reminder Reminder
        {
            get
            {
                return _Reminder;
            }
            set
            {
                Set(() => Reminder, ref _Reminder, value);
            }
        }


        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();
            if (string.IsNullOrEmpty(Name))
            {
                errors.Add(new ValidatedModel() { Error = string.Format(AppResources.MedicineAddNew_Validation_PleaseEnter, AppResources.MedicineAddNew_Entry_MedicineName), PropertyName = "Name" });
            }
            if (StartDate == default(DateTime))
            {
                errors.Add(new ValidatedModel() { Error = string.Format(AppResources.MedicineAddNew_Validation_PleaseEnter, AppResources.MedicineAddNew_StartDate), PropertyName = "StartDate" });
            }
            if (EndDate == default(DateTime))
            {
                errors.Add(new ValidatedModel() { Error = string.Format(AppResources.MedicineAddNew_Validation_PleaseEnter, AppResources.MedicineAddNew_EndDate), PropertyName = "EndDate" });
            }
            //if (Reminder.Date == default(DateTime))
            //{
            //    errors.Add(new ValidatedModel() { Error = string.Format(AppResources.MedicineAddNew_Validation_PleaseEnter, AppResources.MedicineAddNew_Day), PropertyName = "Date" });
            //}
            //if (Reminder.Time == default(TimeSpan))
            //{
            //    errors.Add(new ValidatedModel() { Error = string.Format(AppResources.MedicineAddNew_Validation_PleaseEnter, AppResources.MedicineAddNew_Time), PropertyName = "Time" });
            //}
            return errors;
        }
    }

    public class Reminder : BaseModel
    {
        private RadioButtonGroupItem _SelectedReminderOption;
        public RadioButtonGroupItem SelectedReminderOption
        {
            get { return _SelectedReminderOption; }
            set
            {
                Set(() => SelectedReminderOption, ref _SelectedReminderOption, value);
                ReminderOptionId = value == null ? 0 : value.Id;
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
            }
        }


        private TimeSpan _Time;
        public TimeSpan Time
        {
            get
            {
                return _Time;
            }
            set
            {
                Set(() => Time, ref _Time, value);
                RaisePropertyChanged("FormatedTime");
            }
        }
        public string FormatedTime
        {
            get
            {
                return Time.ToString(@"hh\:mm");
            }
        }

        public int ReminderOptionId { get; set; }

        public override IEnumerable<ValidatedModel> Validate()
        {
            List<ValidatedModel> errors = new List<ValidatedModel>();


            return errors;
        }
    }
}
