using System;
using System.Collections.Generic;
using Models;
using Xamarin.Forms;

namespace GHQLogic.Models.Data
{
	public class NewUSer : BaseModel
	{
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
		private string _UserName;
		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				Set(() => UserName, ref _UserName, value);
			}
		}

		private string _Password;
		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				Set(() => Password, ref _Password, value);
			}
		}

		private string _ConfirmPassword;
		public string ConfirmPassword
		{
			get
			{
				return _ConfirmPassword;
			}
			set
			{
				Set(() => ConfirmPassword, ref _ConfirmPassword, value);
			}
		}
		private string _FirstName;
		public string FirstName
		{
			get
			{
				return _FirstName;
			}
			set
			{
				Set(() => FirstName, ref _FirstName, value);
			}
		}

		private string _MiddleName;
		public string MiddleName
		{
			get
			{
				return _MiddleName;
			}
			set
			{
				Set(() => MiddleName, ref _MiddleName, value);
			}
		}

		private string _LastName;
		public string LastName
		{
			get
			{
				return _LastName;
			}
			set
			{
				Set(() => LastName, ref _LastName, value);
			}
		}
		private string _Gender;
		public string Gender
		{
			get
			{
				return _Gender;
			}
			set
			{
				Set(() => Gender, ref _Gender, value);
			}
		}

		private int _Age;
		public int Age
		{
			get
			{
				return _Age;
			}
			set
			{
				Set(() => Age, ref _Age, value);
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
				Set(() => ImageSource , ref _ImageSource, value);
			}
		}

		private LookupData _SelectedGender;
		public LookupData SelectedGender
		{
			get
			{
				return _SelectedGender;
			}
			set
			{
				Gender = SelectedGender.ValueAr;
				Set(() => SelectedGender, ref _SelectedGender, value);
			}
		}

		private TimeSpan _BreakFastTime;
		public TimeSpan BreakFastTime
		{
			get
			{
				return _BreakFastTime;
			}
			set
			{
				Set(() => BreakFastTime, ref _BreakFastTime, value);
			}
		}

		private TimeSpan _LaunchTime;
		public TimeSpan LaunchTime
		{
			get
			{
				return _LaunchTime;
			}
			set
			{
				Set(() => LaunchTime, ref _LaunchTime, value);
			}
		}

		private TimeSpan _DinnerTime;
		public TimeSpan DinnerTime
		{
			get
			{
				return _DinnerTime;
			}
			set
			{
				Set(() => DinnerTime, ref _DinnerTime, value);
			}
		}

		private MediaFile _Image;
		public MediaFile Image
		{
			get
			{
				return _Image;
			}
			set
			{
				Set(() => Image, ref _Image, value);
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

		public override IEnumerable<ValidatedModel> Validate()
		{
			throw new NotImplementedException();
		}
	}
}
