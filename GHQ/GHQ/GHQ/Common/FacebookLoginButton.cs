﻿using System;
using Xamarin.Forms;

namespace Dawaa
{
	public class FacebookLoginEventArgs : EventArgs
	{
		public string AccessToken { get; set; }
	}
	public class FacebookLoginButton : View
    {
		public static readonly BindableProperty ReadPermissionsProperty = BindableProperty.Create<FacebookLoginButton, string[]>(p => p.ReadPermissions, null);
		public string[] ReadPermissions { get { return new string[] { "public_profile" }; } set { SetValue(ReadPermissionsProperty, value); } }

		public static readonly BindableProperty PublishPermissionsProperty = BindableProperty.Create<FacebookLoginButton, string[]>(p => p.PublishPermissions, null);
		public string[] PublishPermissions { get { return new string[] { "publish_actions" }; } set { SetValue(PublishPermissionsProperty, value); } }

		public static readonly BindableProperty LoggedInProperty = BindableProperty.Create<FacebookLoginButton, bool>(p => p.LoggedIn, false, BindingMode.OneWayToSource);
		public bool LoggedIn { get { return (bool)GetValue(LoggedInProperty); } internal set { SetValue(LoggedInProperty, value); } }

		public event EventHandler<FacebookLoginEventArgs> ShowingLoggedInUser;
		public event EventHandler ShowingLoggedOutUser;

		internal void SendShowingLoggedInUser(string accessToken)
		{
			LoggedIn = true;
			var eh = ShowingLoggedInUser;
			if (eh != null)
				eh(this, new FacebookLoginEventArgs { AccessToken = accessToken });
		}

		internal void SendShowingLoggedOutUser()
		{
			LoggedIn = false;
			var eh = ShowingLoggedOutUser;
			if (eh != null)
				eh(this, EventArgs.Empty);
		}

		public void Login()
		{
			MessagingCenter.Send(this, "Login");
		}

		public void Logout()
		{
			MessagingCenter.Send(this, "Logout");
		}
    }
}
