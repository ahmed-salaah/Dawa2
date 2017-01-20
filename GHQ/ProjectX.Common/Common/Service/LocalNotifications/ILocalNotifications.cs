using Enums;
using System;

namespace Service.ILocalNotifications
{
    public interface ILocalNotifications
    {
        void ShowNotification(string title, string body, DateTime startDate, DateTime endDate, string soundPath, ReminderRepeatOptions reminderRepeatOptions);
    }
}
