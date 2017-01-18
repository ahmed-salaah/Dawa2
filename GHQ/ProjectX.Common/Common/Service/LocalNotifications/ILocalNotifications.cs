using System;
using System.Globalization;
using System.Resources;

namespace Service.ILocalNotifications
{
   
    
    public interface ILocalNotifications
    {
		void showNotification(string title, string body, DateTime date, string sound);
    }

   
}
