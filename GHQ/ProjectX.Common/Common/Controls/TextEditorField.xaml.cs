using Xamarin.Forms;

namespace Controls
{
    public partial class TextEditorField : ContentView
    {
        public TextEditorField()
        {
            InitializeComponent();
        }

        #region ShowHeader p


        public static readonly BindableProperty ShowHeaderProperty = BindableProperty.Create<TextEditorField, bool>(p => p.ShowHeader, true);
        public bool ShowHeader
        {
            get { return (bool)GetValue(ShowHeaderProperty); }
            set { SetValue(ShowHeaderProperty, value); }
        }

        #endregion

        #region Placeholder p


        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create<TextEditorField, string>(p => p.Placeholder, default(string));
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        #endregion

        #region AllowSpecialCharchters p

        public static readonly BindableProperty AllowSpecialCharchtersProperty = BindableProperty.Create<TextEditorField, bool>(p => p.AllowSpecialCharchters, default(bool));
        public bool AllowSpecialCharchters
        {
            get { return (bool)GetValue(AllowSpecialCharchtersProperty); }
            set { SetValue(AllowSpecialCharchtersProperty, value); }
        }

        #endregion

        #region ShowValidation p

        public static readonly BindableProperty ShowValidationProperty = BindableProperty.Create<TextEditorField, bool>(p => p.ShowValidation, default(bool));
        public bool ShowValidation
        {
            get { return (bool)GetValue(ShowValidationProperty); }
            set { SetValue(ShowValidationProperty, value); }
        }

        #endregion

        #region ValidationMessage p

        public static readonly BindableProperty ValidationMessageProperty = BindableProperty.Create<TextEditorField, string>(p => p.ValidationMessage, default(string));
        public string ValidationMessage
        {
            get { return (string)GetValue(ValidationMessageProperty); }
            set { SetValue(ValidationMessageProperty, value); }
        }

        #endregion

        #region IsRequired p


        public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create<TextEditorField, bool>(p => p.IsRequired, default(bool));
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        #endregion

        #region MaxLength p


        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create<TextEditorField, int>(p => p.MaxLength, default(int));
        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        #endregion

        #region Title p

        public static readonly BindableProperty TitleProperty = BindableProperty.Create<TextEditorField, string>(p => p.Title, default(string));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion

        #region Keyboard p

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create<TextEditorField, Keyboard>(p => p.Keyboard, default(Keyboard));
        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        #endregion

        #region IsPassword p


        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create<TextEditorField, bool>(p => p.IsPassword, default(bool));
        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        #endregion

        #region IsEnabled p


        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create<TextEditorField, bool>(p => p.IsEnabled, true);
        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        #endregion

    }
}
