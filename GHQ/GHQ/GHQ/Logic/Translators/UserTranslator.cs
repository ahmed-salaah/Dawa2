
using Logic.Models.Data;
using System.Collections.Generic;
using GHQ.Logic.Database.Entities;

namespace GHQ.Logic.Translators
{
    public static class UserTranslator
    {
		public static User EntityToModel(Database.Entities.User entity)
        {
			User m = new User()
            {
                Id = entity.Id,
				FirstName = entity.FirstName,
				MiddleName = entity.MiddleName,
				FamilyName = entity.FamilyName,
				UserName = entity.UserName,
				Password = entity.Password,
				UserImage = entity.UserImage,
				BreakfastTime = entity.BreakfastTime,
				LaunchTime = entity.LaunchTime,
				DinnerTime = entity.DinnerTime,
				Age = entity.Age,
				Gender = entity.Gender
            };

            return m;
        }

        public static List<User> EntitiesToModels(List<Database.Entities.User> entities)
        {
            List<User> userList = new List<User>();
            foreach (var item in entities)
            {
                userList.Add(EntityToModel(item));
            }
            return userList;
        }

        public static Database.Entities.User ModelToEntity(User entity)
        {
			Database.Entities.User m = new Database.Entities.User()
            {
                 Id = entity.Id,
				FirstName = entity.FirstName,
				MiddleName = entity.MiddleName,
				FamilyName = entity.FamilyName,
				UserName = entity.UserName,
				Password = entity.Password,
				UserImage = entity.UserImage,
				BreakfastTime = entity.BreakfastTime,
				LaunchTime = entity.LaunchTime,
				DinnerTime = entity.DinnerTime,
				Age = entity.Age,
				Gender = entity.Gender
            };

            return m;
        }

        public static List<Database.Entities.User> ModelToEntity(List<User> entities)
        {
            List<Database.Entities.User> userList = new List<Database.Entities.User>();
            foreach (var item in entities)
            {
                userList.Add(ModelToEntity(item));
            }
            return userList;
        }

    }
}
