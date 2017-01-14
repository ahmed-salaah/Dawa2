using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Controls
{
    public partial class ToogleButtonField : ContentView
    {
        public ToogleButtonField()
        {
            InitializeComponent();
            leftImage.IsVisible = false;
            rightImage.IsVisible = false;
        }

        #region Height p


        public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create<ToogleButtonField, int>(p => p.ItemHeight, 50);
        public int ItemHeight
        {
            get { return (int)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        #endregion

        #region IsEnabled p


        public static readonly BindableProperty EnabledProperty = BindableProperty.Create<ToogleButtonField, bool>(p => p.IsEnabled, true);
        public bool IsEnabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        #endregion

        #region IsToogled p


        public static readonly BindableProperty IsToogledProperty = BindableProperty.Create<ToogleButtonField, bool>(p => p.IsToogled, false);
        public bool IsToogled
        {
            get { return (bool)GetValue(IsToogledProperty); }
            set
            {
                SetValue(IsToogledProperty, value);
                //if (!IsToogled)
                //{
                //    mainGrid.BackgroundColor = ToogledBGColor;
                //    if (ShowImageOnToogleOnly)
                //    {
                //        leftImage.IsVisible = true;
                //        rightImage.IsVisible = true;
                //    }
                //}
                //else
                //{
                //    if (ShowImageOnToogleOnly)
                //    {
                //        leftImage.IsVisible = false;
                //        rightImage.IsVisible = false;
                //    }
                //    mainGrid.BackgroundColor = BGColor;
                //}
            }
        }

        #endregion

        #region ShowImageOnToogleOnly p


        public static readonly BindableProperty ShowImageOnToogleOnlyProperty = BindableProperty.Create<ToogleButtonField, bool>(p => p.ShowImageOnToogleOnly, false);
        public bool ShowImageOnToogleOnly
        {
            get { return (bool)GetValue(ShowImageOnToogleOnlyProperty); }
            set { SetValue(ShowImageOnToogleOnlyProperty, value); }
        }

        #endregion

        #region Title p


        public static readonly BindableProperty TitleProperty = BindableProperty.Create<ToogleButtonField, string>(p => p.Title, default(string));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion

        #region TextColor p

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create<ToogleButtonField, string>(p => p.TextColor, default(string));
        public string TextColor
        {
            get { return (string)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        #endregion

        #region BGColor p

        public static readonly BindableProperty BGColorProperty = BindableProperty.Create<ToogleButtonField, Xamarin.Forms.Color>(p => p.BGColor, Color.Red);

        public Xamarin.Forms.Color BGColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BGColorProperty); }
            set { SetValue(BGColorProperty, value); }
        }

        #endregion

        #region ToogledBGColor p

        public static readonly BindableProperty ToogledBGColorProperty = BindableProperty.Create<ToogleButtonField, Xamarin.Forms.Color>(p => p.ToogledBGColor, Color.Red);

        public Xamarin.Forms.Color ToogledBGColor
        {
            get { return (Xamarin.Forms.Color)GetValue(ToogledBGColorProperty); }
            set { SetValue(ToogledBGColorProperty, value); }
        }

        #endregion

        #region RightImage p


        public static readonly BindableProperty RightImageProperty = BindableProperty.Create<ToogleButtonField, ImageSource>(p => p.RightImage, null);
        public ImageSource RightImage
        {
            get { return (ImageSource)GetValue(RightImageProperty); }
            set { SetValue(RightImageProperty, value); }
        }

        #endregion

        #region LeftImage p


        public static readonly BindableProperty LeftImageProperty = BindableProperty.Create<ToogleButtonField, ImageSource>(p => p.LeftImage, null);

        public ImageSource LeftImage
        {
            get { return (ImageSource)GetValue(LeftImageProperty); }
            set { SetValue(LeftImageProperty, value); }
        }


        //void SetLeftImage
        #endregion

        #region Command

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<ToogleButtonField, ICommand>(p => p.Command, default(ICommand));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion

        #region Command Parameter

        public static readonly BindableProperty CommandParamterProperty = BindableProperty.Create<ToogleButtonField, object>(p => p.CommandParamter, default(object));

        public object CommandParamter
        {
            get { return (object)GetValue(CommandParamterProperty); }
            set { SetValue(CommandParamterProperty, value); }
        }

        #endregion

        private void Button_OnClicked(object sender, EventArgs e)
        {
            IsToogled = !IsToogled;
            if (IsToogled)
            {
                mainGrid.BackgroundColor = ToogledBGColor;
                if (ShowImageOnToogleOnly)
                {
                    leftImage.IsVisible = true;
                    rightImage.IsVisible = true;
                }
            }
            else
            {
                if (ShowImageOnToogleOnly)
                {
                    leftImage.IsVisible = false;
                    rightImage.IsVisible = false;
                }
                mainGrid.BackgroundColor = BGColor;
            }
    
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
