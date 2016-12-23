using Xamarin.Forms;

namespace Controls
{
    public partial class InputField : ContentView
    {
        public InputField()
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

        #region AllowSpecialCharchters p

        public static readonly BindableProperty AllowSpecialCharchtersProperty = BindableProperty.Create<InputField, bool>(p => p.AllowSpecialCharchters, default(bool));
        public bool AllowSpecialCharchters
        {
            get { return (bool)GetValue(AllowSpecialCharchtersProperty); }
            set { SetValue(AllowSpecialCharchtersProperty, value); }
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

        #region MaxLength p


        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create<InputField, int>(p => p.MaxLength, default(int));
        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
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

        #region Keyboard p

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create<InputField, Keyboard>(p => p.Keyboard, default(Keyboard));
        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        #endregion

        #region IsPassword p


        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create<InputField, bool>(p => p.IsPassword, default(bool));
        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
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
