
using Logic.Models.Data;
using System.Collections.Generic;

namespace GHQ.Logic.Translators
{
    public static class MedicineTranslator
    {
        public static Medicine EntityToModel(Database.Entities.Medicine entity)
        {
            Medicine m = new Medicine()
            {
                Id = entity.Id,
                DiseaseName = entity.DiseaseName,
                DoctorName = entity.DoctorName,
                EndDate = entity.EndDate,
                ImagePath = entity.ImagePath,
                IsMissed = entity.IsMissed,
                Name = entity.Name,
                NextDate = entity.NextDate,
                Note = entity.Note,
                StartDate = entity.StartDate,
                VoiceNotePath = entity.VoiceNotePath,
            };

            return m;
        }

        public static List<Medicine> EntitiesToModels(List<Database.Entities.Medicine> entities)
        {
            List<Medicine> medicinList = new List<Medicine>();
            foreach (var item in entities)
            {
                medicinList.Add(EntityToModel(item));
            }
            return medicinList;
        }

        public static Database.Entities.Medicine ModelToEntity(Medicine entity)
        {
            Database.Entities.Medicine m = new Database.Entities.Medicine()
            {
                Id = entity.Id,
                DiseaseName = entity.DiseaseName,
                DoctorName = entity.DoctorName,
                EndDate = entity.EndDate,
                ImagePath = entity.ImagePath,
                IsMissed = entity.IsMissed,
                Name = entity.Name,
                NextDate = entity.NextDate,
                Note = entity.Note,
                StartDate = entity.StartDate,
                VoiceNotePath = entity.VoiceNotePath,
                ReminderOption_Id = entity.Reminder.SelectedReminderOption.Id,
                ReminderDate = entity.Reminder.Date,
                ReminderTime = entity.Reminder.Time,
            };

            return m;
        }

        public static List<Database.Entities.Medicine> ModelToEntity(List<Medicine> entities)
        {
            List<Database.Entities.Medicine> medicinList = new List<Database.Entities.Medicine>();
            foreach (var item in entities)
            {
                medicinList.Add(ModelToEntity(item));
            }
            return medicinList;
        }

    }
}
