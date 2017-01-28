using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Models;
using Xamarin.Forms;

namespace Controls
{
	public partial class PickerButtonField : ContentView
	{
		public PickerButtonField()
		{
			InitializeComponent();
		}

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == "SelectedLookupValue")
			{
				if (SelectedLookupValue != null)
					Title = SelectedLookupValue.ValueAr;
				else
					Title = Placeholder;
			}
		}

		#region ItemHeight p


		public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create<PickerButtonField, int>(p => p.ItemHeight, 50);
		public int ItemHeight
		{
			get { return (int)GetValue(ItemHeightProperty); }
			set { SetValue(ItemHeightProperty, value); }
		}

		#endregion

		#region IsEnabled p


		public static readonly BindableProperty EnabledProperty = BindableProperty.Create<PickerButtonField, bool>(p => p.IsEnabled, true);
		public bool IsEnabled
		{
			get { return (bool)GetValue(EnabledProperty); }
			set { SetValue(EnabledProperty, value); }
		}

		#endregion

		#region Title p


		public static readonly BindableProperty TitleProperty = BindableProperty.Create<PickerButtonField, string>(p => p.Title, default(string));
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		#endregion

		#region Placeholder p

		public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create<PickerButtonField, string>(p => p.Placeholder, default(string));
		public string Placeholder
		{
			get { return (string)GetValue(PlaceholderProperty); }
			set { SetValue(PlaceholderProperty, value); }
		}

		#endregion
		#region LookupValues p


		public static readonly BindableProperty LookupValuesProperty = BindableProperty.Create<PickerButtonField, ObservableCollection<LookupData>>(p => p.LookupValues, default(ObservableCollection<LookupData>));
		public ObservableCollection<LookupData> LookupValues
		{
			get { return (ObservableCollection<LookupData>)GetValue(LookupValuesProperty); }
			set { SetValue(LookupValuesProperty, value); }
		}

		#endregion
		#region SelectedLookupValue p


		public static readonly BindableProperty SelectedLookupValueProperty = BindableProperty.Create<PickerButtonField, LookupData>(p => p.SelectedLookupValue, default(LookupData));
		public LookupData SelectedLookupValue
		{
			get { return (LookupData)GetValue(SelectedLookupValueProperty); }
			set { SetValue(SelectedLookupValueProperty, value); }
		}

		#endregion

		#region SelectedLookupValueIndex p


		public static readonly BindableProperty SelectedLookupValueIndexProperty = BindableProperty.Create<PickerButtonField, int>(p => p.SelectedLookupValueIndex, default(int));
		public int SelectedLookupValueIndex
		{
			get { return (int)GetValue(SelectedLookupValueIndexProperty); }
			set
			{
				SetValue(SelectedLookupValueIndexProperty, value);
				if (value == -1)
				{
					return;
					SelectedLookupValue = LookupValues.FirstOrDefault();
				}

				else
					SelectedLookupValue = LookupValues[value];
			}
		}

		#endregion


		#region TextColor p

		public static readonly BindableProperty TextColorProperty = BindableProperty.Create<PickerButtonField, Xamarin.Forms.Color>(p => p.TextColor, Color.Black);
		public Xamarin.Forms.Color TextColor
		{
			get { return (Xamarin.Forms.Color)GetValue(TextColorProperty); }
			set { SetValue(TextColorProperty, value); }
		}

		#endregion

		#region TextAlignment p

		public static readonly BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create<TimePickerButtonField, TextAlignment>(p => p.HorizontalTextAlignment, TextAlignment.Center);

		public TextAlignment HorizontalTextAlignment
		{
			get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
			set { SetValue(HorizontalTextAlignmentProperty, value); }
		}

		#endregion

		#region BGColor p

		public static readonly BindableProperty BGColorProperty = BindableProperty.Create<PickerButtonField, Xamarin.Forms.Color>(p => p.BGColor, Color.Blue);

		public Xamarin.Forms.Color BGColor
		{
			get { return (Xamarin.Forms.Color)GetValue(BGColorProperty); }
			set { SetValue(BGColorProperty, value); }
		}

		#endregion

		#region RightImage p


		public static readonly BindableProperty RightImageProperty = BindableProperty.Create<PickerButtonField, ImageSource>(p => p.RightImage, null);
		public ImageSource RightImage
		{
			get { return (ImageSource)GetValue(RightImageProperty); }
			set { SetValue(RightImageProperty, value); }
		}

		#endregion

		#region LeftImage p


		public static readonly BindableProperty LeftImageProperty = BindableProperty.Create<PickerButtonField, ImageSource>(p => p.LeftImage, null);

		public ImageSource LeftImage
		{
			get { return (ImageSource)GetValue(LeftImageProperty); }
			set { SetValue(LeftImageProperty, value); }
		}


		#endregion

		#region Command

		public static readonly BindableProperty CommandProperty = BindableProperty.Create<PickerButtonField, ICommand>(p => p.Command, default(ICommand));

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		#endregion

		#region Command Parameter

		public static readonly BindableProperty CommandParamterProperty = BindableProperty.Create<PickerButtonField, object>(p => p.CommandParamter, default(object));

		public object CommandParamter
		{
			get { return (object)GetValue(CommandParamterProperty); }
			set { SetValue(CommandParamterProperty, value); }
		}

		#endregion

		private void Button_OnClicked(object sender, EventArgs e)
		{
			
			Device.BeginInvokeOnMainThread(() =>
		{
			Picker.Unfocus();
			Picker.Focus();
		});
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
