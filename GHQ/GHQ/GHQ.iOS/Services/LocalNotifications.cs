using Xamarin.Forms;
using GHQ.iOS.Services;
using System;
using Service.ILocalNotifications;
using UIKit;
using Enums;
[assembly: Dependency(typeof(LocalNotifications))]

namespace GHQ.iOS.Services
{
	public class LocalNotifications : ILocalNotifications
	{
		public void ShowNotification(string title, string body, DateTime date, string soundPath, ReminderRepeatOptions reminderRepeatOptions)
		{
	
            // create the notification
            var notification = new UILocalNotification();

            // set the fire date (the date time in which it will fire)
            notification.FireDate = (Foundation.NSDate)date;

            // configure the alert

            notification.AlertAction = title;
            notification.AlertBody = body;

            // modify the badge
            notification.ApplicationIconBadgeNumber = 1;

            if (string.IsNullOrEmpty(soundPath))
				notification.SoundName = UILocalNotification.DefaultSoundName;
            else
                // set the sound to be the default sound
                notification.SoundName = soundPath;

			switch (reminderRepeatOptions)
			{
				case ReminderRepeatOptions.Daily:
					notification.RepeatInterval = Foundation.NSCalendarUnit.Day;
					break;
				case ReminderRepeatOptions.Monthly:
					notification.RepeatInterval = Foundation.NSCalendarUnit.Month;
					break;
					
				case ReminderRepeatOptions.Yearly:
					notification.RepeatInterval = Foundation.NSCalendarUnit.Year;
					break;
				case ReminderRepeatOptions.Weekly:
					notification.RepeatInterval = Foundation.NSCalendarUnit.Week;
					break;
				case ReminderRepeatOptions.EventBased:
					notification.RepeatInterval = Foundation.NSCalendarUnit.Day;
					break;
				default:
					break;
			}

            // schedule it
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}