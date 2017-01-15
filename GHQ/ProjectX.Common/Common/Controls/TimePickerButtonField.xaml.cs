using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Controls
{
    public partial class TimePickerButtonField : ContentView
    {
        public TimePickerButtonField()
        {
            InitializeComponent();
        }

        #region ItemHeight p


        public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create<TimePickerButtonField, int>(p => p.ItemHeight, 50);
        public int ItemHeight
        {
            get { return (int)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        #endregion

        #region IsEnabled p


        public static readonly BindableProperty EnabledProperty = BindableProperty.Create<TimePickerButtonField, bool>(p => p.IsEnabled, true);
        public bool IsEnabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        #endregion

        #region Title p


        public static readonly BindableProperty TitleProperty = BindableProperty.Create<TimePickerButtonField, string>(p => p.Title, default(string));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion

        #region Date p

        public static readonly BindableProperty TimeProperty = BindableProperty.Create<TimePickerButtonField, TimeSpan>(p => p.Time, default(TimeSpan));
        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        #endregion

        #region TextColor p

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create<TimePickerButtonField, Xamarin.Forms.Color>(p => p.TextColor, Color.White);
        public Xamarin.Forms.Color TextColor
        {
            get { return (Xamarin.Forms.Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        #endregion

        #region BGColor p

        public static readonly BindableProperty BGColorProperty = BindableProperty.Create<TimePickerButtonField, Xamarin.Forms.Color>(p => p.BGColor, Color.Blue);

        public Xamarin.Forms.Color BGColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BGColorProperty); }
            set { SetValue(BGColorProperty, value); }
        }

        #endregion

        #region RightImage p


        public static readonly BindableProperty RightImageProperty = BindableProperty.Create<TimePickerButtonField, ImageSource>(p => p.RightImage, null);
        public ImageSource RightImage
        {
            get { return (ImageSource)GetValue(RightImageProperty); }
            set { SetValue(RightImageProperty, value); }
        }

        #endregion

        #region LeftImage p


        public static readonly BindableProperty LeftImageProperty = BindableProperty.Create<TimePickerButtonField, ImageSource>(p => p.LeftImage, null);

        public ImageSource LeftImage
        {
            get { return (ImageSource)GetValue(LeftImageProperty); }
            set { SetValue(LeftImageProperty, value); }
        }

        #endregion

        #region Command

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<TimePickerButtonField, ICommand>(p => p.Command, default(ICommand));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion

        #region Command Parameter

        public static readonly BindableProperty CommandParamterProperty = BindableProperty.Create<TimePickerButtonField, object>(p => p.CommandParamter, default(object));

        public object CommandParamter
        {
            get { return (object)GetValue(CommandParamterProperty); }
            set { SetValue(CommandParamterProperty, value); }
        }

        #endregion

        private void Button_OnClicked(object sender, EventArgs e)
        {
            datePicker.Focus();
            if (Command != null)
            {
                if (Command.CanExecute(CommandParamter))
                {
                    Command.Execute(CommandParamter);
                }
            }
        }

    }
}
