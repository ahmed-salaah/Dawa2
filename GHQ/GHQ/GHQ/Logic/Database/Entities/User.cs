using SQLite;
using System;

namespace GHQ.Logic.Database.Entities
{
    public class User
    {
        public User()
        {

        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string FirstName { get; set; }

        public string MiddleName { get; set; }
		public string FamilyName { get; set; }

		public string UserName { get; set; }
		public string Password { get; set; }


		public TimeSpan BreakfastTime { get; set; }

        public TimeSpan LaunchTime { get; set; }

        public TimeSpan DinnerTime { get; set; }

        public string UserImage { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }

    }
}
