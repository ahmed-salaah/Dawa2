using System;
using Xamarin.Forms;

namespace Controls
{
    public partial class DatePickerField : ContentView
    {
        public DatePickerField()
        {
            InitializeComponent();
        }

        #region Placeholder p


        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create<DatePickerField, string>(p => p.Placeholder, default(string));
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        #endregion

        #region ShowValidation p

        public static readonly BindableProperty ShowValidationProperty = BindableProperty.Create<DatePickerField, bool>(p => p.ShowValidation, default(bool));
        public bool ShowValidation
        {
            get { return (bool)GetValue(ShowValidationProperty); }
            set { SetValue(ShowValidationProperty, value); }
        }

        #endregion

        #region ValidationMessage p

        public static readonly BindableProperty ValidationMessageProperty = BindableProperty.Create<DatePickerField, string>(p => p.ValidationMessage, default(string));
        public string ValidationMessage
        {
            get { return (string)GetValue(ValidationMessageProperty); }
            set { SetValue(ValidationMessageProperty, value); }
        }

        #endregion

        #region IsRequired p


        public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create<DatePickerField, bool>(p => p.IsRequired, default(bool));
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        #endregion

        #region Date p

        public static readonly BindableProperty DateProperty = BindableProperty.Create<DatePickerField, DateTime>(p => p.Date, default(DateTime));
        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        #endregion

        #region IsEnabled p


        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create<DatePickerField, bool>(p => p.IsEnabled, true);
        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        #endregion

    }
}
