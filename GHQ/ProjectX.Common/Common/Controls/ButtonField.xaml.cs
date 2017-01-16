using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Controls
{
    public partial class ButtonField : ContentView
    {
        public ButtonField()
        {
            InitializeComponent();
        }

        #region Height p


        public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create<ButtonField, int>(p => p.ItemHeight, 50);
        public int ItemHeight
        {
            get { return (int)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        #endregion

        #region IsEnabled p


        public static readonly BindableProperty EnabledProperty = BindableProperty.Create<ButtonField, bool>(p => p.IsEnabled, true);
        public bool IsEnabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        #endregion

        #region Title p


        public static readonly BindableProperty TitleProperty = BindableProperty.Create<ButtonField, string>(p => p.Title, default(string));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion

        #region TextColor p

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create<ButtonField, string>(p => p.TextColor, default(string));
        public string TextColor
        {
            get { return (string)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        #endregion

        #region BGColor p

        public static readonly BindableProperty BGColorProperty = BindableProperty.Create<ButtonField, Xamarin.Forms.Color>(p => p.BGColor, Color.Red);



        public Xamarin.Forms.Color BGColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BGColorProperty); }
            set { SetValue(BGColorProperty, value); }
        }

        #endregion

        #region RightImage p


        public static readonly BindableProperty RightImageProperty = BindableProperty.Create<ButtonField, ImageSource>(p => p.RightImage, null);
        public ImageSource RightImage
        {
            get { return (ImageSource)GetValue(RightImageProperty); }
            set { SetValue(RightImageProperty, value); }
        }

        #endregion

        #region LeftImage p


        public static readonly BindableProperty LeftImageProperty = BindableProperty.Create<ButtonField, ImageSource>(p => p.LeftImage, null);

        public ImageSource LeftImage
        {
            get { return (ImageSource)GetValue(LeftImageProperty); }
            set { SetValue(LeftImageProperty, value); }
        }


        #endregion

        #region Command

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<ButtonField, ICommand>(p => p.Command, default(ICommand));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion

        #region Command Parameter

        public static readonly BindableProperty CommandParamterProperty = BindableProperty.Create<ButtonField, object>(p => p.CommandParamter, default(object));

        public object CommandParamter
        {
            get { return (object)GetValue(CommandParamterProperty); }
            set { SetValue(CommandParamterProperty, value); }
        }

        #endregion

        private void Button_OnClicked(object sender, EventArgs e)
        {
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
