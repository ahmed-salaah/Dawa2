using Enums;
using System;

namespace Service.ILocalNotifications
{
    public interface ILocalNotifications
    {
        void ShowNotification(int medicinId, string title, string body, DateTime startDate, DateTime endDate, string soundPath, ReminderRepeatOptions reminderRepeatOptions);
    }
}
