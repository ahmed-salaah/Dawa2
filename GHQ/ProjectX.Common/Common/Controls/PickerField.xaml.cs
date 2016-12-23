using Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Controls
{
    public partial class PickerField : ContentView
    {
        public PickerField()
        {
            InitializeComponent();
        }

        #region Placeholder p


        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create<InputField, string>(p => p.Placeholder, default(string));
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        #endregion

        #region ShowValidation p

        public static readonly BindableProperty ShowValidationProperty = BindableProperty.Create<InputField, bool>(p => p.ShowValidation, default(bool));
        public bool ShowValidation
        {
            get { return (bool)GetValue(ShowValidationProperty); }
            set { SetValue(ShowValidationProperty, value); }
        }

        #endregion

        #region ValidationMessage p

        public static readonly BindableProperty ValidationMessageProperty = BindableProperty.Create<InputField, string>(p => p.ValidationMessage, default(string));
        public string ValidationMessage
        {
            get { return (string)GetValue(ValidationMessageProperty); }
            set { SetValue(ValidationMessageProperty, value); }
        }

        #endregion

        #region IsRequired p


        public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create<InputField, bool>(p => p.IsRequired, default(bool));
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        #endregion

        #region LookupValues p


        public static readonly BindableProperty LookupValuesProperty = BindableProperty.Create<PickerField, ObservableCollection<LookupData>>(p => p.LookupValues, default(ObservableCollection<LookupData>));
        public ObservableCollection<LookupData> LookupValues
        {
            get { return (ObservableCollection<LookupData>)GetValue(LookupValuesProperty); }
            set { SetValue(LookupValuesProperty, value); }
        }

        #endregion

        #region SelectedLookupValue p


        public static readonly BindableProperty SelectedLookupValueProperty = BindableProperty.Create<PickerField, LookupData>(p => p.SelectedLookupValue, default(LookupData));
        public LookupData SelectedLookupValue
        {
            get { return (LookupData)GetValue(SelectedLookupValueProperty); }
            set { SetValue(SelectedLookupValueProperty, value); }
        }

        #endregion

        #region SelectedLookupValueIndex p


        public static readonly BindableProperty SelectedLookupValueIndexProperty = BindableProperty.Create<PickerField, int>(p => p.SelectedLookupValueIndex, default(int));
        public int SelectedLookupValueIndex
        {
            get { return (int)GetValue(SelectedLookupValueIndexProperty); }
            set
            {
                SetValue(SelectedLookupValueIndexProperty, value);
                SelectedLookupValue = LookupValues[value];
            }
        }

        #endregion

        #region Title p

        public static readonly BindableProperty TitleProperty = BindableProperty.Create<InputField, string>(p => p.Title, default(string));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion

        #region IsEnabled p


        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create<InputField, bool>(p => p.IsEnabled, true);
        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        #endregion

    }
}
