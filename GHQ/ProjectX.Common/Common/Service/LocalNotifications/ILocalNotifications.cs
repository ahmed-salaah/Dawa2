using Enums;
using System;

namespace Service.ILocalNotifications
{
    public interface ILocalNotifications
    {
        void ShowNotification(string title, string body, DateTime date, string soundPath, ReminderRepeatOptions reminderRepeatOptions);
    }
}
