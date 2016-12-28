using System;
using System.Collections.Generic;
using Models;

namespace GHQLogic.Models.Data
{
	public class NewUSer : BaseModel
	{

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

		private DateTime _BreakFastTime;
		public DateTime BreakFastTime
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

		private DateTime _LaunchTime;
		public DateTime LaunchTime
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

		private DateTime _DinnerTime;
		public DateTime DinnerTime
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
		public override IEnumerable<ValidatedModel> Validate()
		{
			throw new NotImplementedException();
		}
	}
}
