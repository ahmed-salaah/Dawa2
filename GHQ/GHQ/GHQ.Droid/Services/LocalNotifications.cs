using Xamarin.Forms;
using GHQ.Droid.Services;
using System;
using Service.ILocalNotifications;

[assembly: Dependency(typeof(LocalNotifications))]

namespace GHQ.Droid.Services
{
    public class LocalNotifications : ILocalNotifications
    {

        public void ShowNotification(string title, string body, DateTime date, string sound)
        {
        }
    }
}