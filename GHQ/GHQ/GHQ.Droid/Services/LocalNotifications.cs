using Xamarin.Forms;
using GHQ.Droid.Services;
using System;
using Service.ILocalNotifications;
using Enums;
using Android.Content;
using Android.App;
using Android.OS;
using GHQ.Droid.Receivers;

[assembly: Dependency(typeof(LocalNotifications))]

namespace GHQ.Droid.Services
{
    public class LocalNotifications : ILocalNotifications
    {
        public static long ConvertHoursToMilliseconds(double hours)
        {
            return long.Parse(TimeSpan.FromHours(hours).TotalMilliseconds.ToString());
        }

        public void ShowNotification(int medicinId, string title, string body, DateTime startDate, DateTime endDate, string soundPath, ReminderRepeatOptions reminderRepeatOptions)
        {
            Intent alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));
            alarmIntent.PutExtra("medicinId", medicinId.ToString());
            alarmIntent.PutExtra("message", body);
            alarmIntent.PutExtra("title", title);
            alarmIntent.PutExtra("soundPath", soundPath);
            alarmIntent.PutExtra("endDate", endDate.ToString());
            alarmIntent.PutExtra("reminderOptionId", ((int)reminderRepeatOptions).ToString());

            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);

            long repeatEvery = 0;
            switch (reminderRepeatOptions)
            {
                case ReminderRepeatOptions.Daily:
                    repeatEvery = ConvertHoursToMilliseconds(24);
                    break;
                case ReminderRepeatOptions.EventBased:
                    repeatEvery = ConvertHoursToMilliseconds(24);
                    break;
                case ReminderRepeatOptions.Weekly:
                    repeatEvery = ConvertHoursToMilliseconds(24 * 7);
                    break;
                case ReminderRepeatOptions.Monthly:
                    repeatEvery = ConvertHoursToMilliseconds(24 * 7 * 30);
                    break;
                case ReminderRepeatOptions.Yearly:
                    repeatEvery = ConvertHoursToMilliseconds(24 * 7 * 30 * 12);
                    break;
                default:
                    break;
            }

            var fireAt = startDate.Subtract(DateTime.Now);
            long afterlng = -1;
            var afterInMin = fireAt.TotalMinutes;
            if (afterInMin > 0)
            {
                var milliSeconds = (int)fireAt.TotalMilliseconds;
                afterlng = long.Parse(milliSeconds.ToString());
            }

            alarmManager.SetRepeating(AlarmType.RtcWakeup, afterlng, repeatEvery, pendingIntent);
        }
    }
}