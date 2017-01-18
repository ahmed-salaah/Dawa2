using System;
using System.Collections.Generic;
using GHQ.Resources.Strings;
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
			List<ValidatedModel> errors = new List<ValidatedModel>();
			if (string.IsNullOrEmpty(UserName))
			{
				errors.Add(new ValidatedModel() { Error = string.Format(AppResources.MedicineAddNew_Validation_PleaseEnter, AppResources.login_userName), PropertyName = "UserName" });
			}

			if (string.IsNullOrEmpty(Password))
			{
				errors.Add(new ValidatedModel() { Error = string.Format(AppResources.MedicineAddNew_Validation_PleaseEnter, AppResources.login_password), PropertyName = "Password" });
			}
			return errors;
		}
	}
}
