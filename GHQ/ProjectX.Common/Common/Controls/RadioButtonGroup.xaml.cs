using Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Command;

namespace Controls
{
    public partial class RadioButtonGroup : ContentView
    {
        public RadioButtonGroup()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Items")
            {
                DrawItems();
            }
        }

        void DrawItems()
        {
            mainGrid.Children.Clear();
            mainGrid.ColumnSpacing = ColumnSpacing;
            for (int i = 0; i < Items.Count; i++)
            {
                var column = i % 2;
                var row = (int)Math.Floor(i / 2f);
                ToogleButtonField t = new ToogleButtonField();
                t.IsEnabled = IsEnabled;
                t.Title = Items[i].Value;
                t.TextColor = TextColor;
                t.BGColor = BGColor;
                t.ToogledBGColor = ToogledBGColor;
                t.IsToogled = Items[i].IsSelected;
                t.ItemHeight = ItemHeight;
                t.RightImage = RightImage;
                t.LeftImage = LeftImage;
                t.Command = OnItemClickedCommand;
                t.CommandParamter = i;
                t.ShowImageOnToogleOnly = true;
                if (!string.IsNullOrEmpty(t.Title))
                    mainGrid.Children.Add(t, row, column);
            }
        }

        #region Items p


        public static readonly BindableProperty ItemsProperty = BindableProperty.Create<RadioButtonGroup, ObservableCollection<RadioButtonGroupItem>>(p => p.Items, null);
        public ObservableCollection<RadioButtonGroupItem> Items
        {
            get { return (ObservableCollection<RadioButtonGroupItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        #endregion

        #region SelectedItem p


        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create<RadioButtonGroup, RadioButtonGroupItem>(p => p.SelectedItem, null);
        public RadioButtonGroupItem SelectedItem
        {
            get { return (RadioButtonGroupItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        #endregion

        #region Height p


        public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create<RadioButtonGroup, int>(p => p.ItemHeight, 50);
        public int ItemHeight
        {
            get { return (int)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        #endregion

        #region ColumnSpacing p


        public static readonly BindableProperty ColumnSpacingProperty = BindableProperty.Create<RadioButtonGroup, int>(p => p.ColumnSpacing, 0);
        public int ColumnSpacing
        {
            get { return (int)GetValue(ColumnSpacingProperty); }
            set { SetValue(ColumnSpacingProperty, value); }
        }

        #endregion

        #region IsEnabled p


        public static readonly BindableProperty EnabledProperty = BindableProperty.Create<RadioButtonGroup, bool>(p => p.IsEnabled, true);
        public bool IsEnabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        #endregion

        #region ShowImageOnToogleOnly p


        public static readonly BindableProperty ShowImageOnToogleOnlyProperty = BindableProperty.Create<RadioButtonGroup, bool>(p => p.ShowImageOnToogleOnly, false);
        public bool ShowImageOnToogleOnly
        {
            get { return (bool)GetValue(ShowImageOnToogleOnlyProperty); }
            set { SetValue(ShowImageOnToogleOnlyProperty, value); }
        }

        #endregion

        #region TextColor p

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create<RadioButtonGroup, Xamarin.Forms.Color>(p => p.TextColor, Color.White);
        public Xamarin.Forms.Color TextColor
        {
            get { return (Xamarin.Forms.Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        #endregion

        #region BGColor p

        public static readonly BindableProperty BGColorProperty = BindableProperty.Create<RadioButtonGroup, Xamarin.Forms.Color>(p => p.BGColor, Color.Red);

        public Xamarin.Forms.Color BGColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BGColorProperty); }
            set { SetValue(BGColorProperty, value); }
        }

        #endregion

        #region ToogledBGColor p

        public static readonly BindableProperty ToogledBGColorProperty = BindableProperty.Create<RadioButtonGroup, Xamarin.Forms.Color>(p => p.ToogledBGColor, Color.Red);

        public Xamarin.Forms.Color ToogledBGColor
        {
            get { return (Xamarin.Forms.Color)GetValue(ToogledBGColorProperty); }
            set { SetValue(ToogledBGColorProperty, value); }
        }

        #endregion

        #region RightImage p


        public static readonly BindableProperty RightImageProperty = BindableProperty.Create<RadioButtonGroup, ImageSource>(p => p.RightImage, null);
        public ImageSource RightImage
        {
            get { return (ImageSource)GetValue(RightImageProperty); }
            set { SetValue(RightImageProperty, value); }
        }

        #endregion

        #region LeftImage p


        public static readonly BindableProperty LeftImageProperty = BindableProperty.Create<RadioButtonGroup, ImageSource>(p => p.LeftImage, null);

        public ImageSource LeftImage
        {
            get { return (ImageSource)GetValue(LeftImageProperty); }
            set { SetValue(LeftImageProperty, value); }
        }


        #endregion

        #region OnItemClicked Command

        private RelayCommand<int> _OnItemClickedCommand;
        public RelayCommand<int> OnItemClickedCommand
        {
            get
            {
                if (_OnItemClickedCommand == null)
                {
                    _OnItemClickedCommand = new RelayCommand<int>(ItemClicked);
                }
                return _OnItemClickedCommand;
            }
        }
        private async void ItemClicked(int index)
        {
            try
            {
                foreach (var item in Items)
                {
                    item.IsSelected = false;
                }
                Items[index].IsSelected = !Items[index].IsSelected;
                SelectedItem = Items[index];
                DrawItems();
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }
        }

        #endregion

    }
}
