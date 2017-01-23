
using Logic.Models.Data;
using System.Collections.Generic;
using GHQ.Logic.Database.Entities;
using GHQLogic.Models.Data;

namespace GHQ.Logic.Translators
{
    public static class UserTranslator
    {
        public static NewUser EntityToModel(Database.Entities.User entity)
        {
            NewUser m = new NewUser()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.FamilyName,
                UserName = entity.UserName,
                Password = entity.Password,
                ImagePath = entity.UserImage,
                BreakFastTime = entity.BreakfastTime,
                LaunchTime = entity.LaunchTime,
                DinnerTime = entity.DinnerTime,
                Age = entity.Age.ToString(),
                Gender = entity.Gender
            };

            return m;
        }

        public static List<NewUser> EntitiesToModels(List<Database.Entities.User> entities)
        {
            List<NewUser> userList = new List<NewUser>();
            foreach (var item in entities)
            {
                userList.Add(EntityToModel(item));
            }
            return userList;
        }

        public static Database.Entities.User ModelToEntity(NewUser entity)
        {
            Database.Entities.User m = new Database.Entities.User()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                FamilyName = entity.LastName,
                UserName = entity.UserName,
                Password = entity.Password,
                UserImage = entity.ImagePath,
                BreakfastTime = entity.BreakFastTime,
                LaunchTime = entity.LaunchTime,
                DinnerTime = entity.DinnerTime,
                Age = string.IsNullOrEmpty(entity.Age) ? 0 : int.Parse(entity.Age),
                Gender = entity.SelectedGender?.Id
            };

            return m;
        }

        public static List<Database.Entities.User> ModelToEntity(List<NewUser> entities)
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
