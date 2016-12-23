using Models;
using System.Collections.Generic;
using System;
using Xamarin.Forms.Maps;

namespace GHQ.Logic.Models.Data.Map
{
	public class MapData : BaseModel
	{
		private string _Title;
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				Set(() => Title, ref _Title, value);
			}
		}

		private Position _Location;
		public Position Location
		{
			get
			{
				return _Location;
			}
			set
			{
				Set(() => Location, ref _Location, value);
			}
		}
		private string _Description;
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				Set(() => Description, ref _Description, value);
			}
		}


	

		public override IEnumerable<ValidatedModel> Validate()
		{
			List<ValidatedModel> errors = new List<ValidatedModel>();
			return errors;
		}
	}
}
