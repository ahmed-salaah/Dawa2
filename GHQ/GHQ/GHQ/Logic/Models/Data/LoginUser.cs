using System;
using System.Collections.Generic;
using Models;

namespace GHQ.Logic.Models.Data
{
	public class LoginUser: BaseModel
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

		public override IEnumerable<ValidatedModel> Validate()
		{
			throw new NotImplementedException();
		}
	}
}
