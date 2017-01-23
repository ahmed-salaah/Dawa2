using Dawaa.iOS;
using MonoTouch.FacebookConnect;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Dawaa;
using System;
using System.Linq;
using GHQ;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookLoginButtonRendererIos))]
namespace Dawaa.iOS
{
    public class FacebookLoginButtonRendererIos : ViewRenderer<FacebookLoginButton, FBLoginView>
    {
		 	protected override void OnElementChanged(ElementChangedEventArgs<FacebookLoginButton> e)
		{
			base.OnElementChanged(e);

			var element = e.NewElement;

			var session = FBSession.ActiveSession;
			//if (element != null)
			//{
			//	element.LoggedIn = session != null && session.IsOpen;
			//}




			var control = new FBLoginView(element.ReadPermissions);

			SetNativeControl(control);
			control.ShowingLoggedInUser += (s, ea) =>
			{
				var session2 = FBSession.ActiveSession;

				var accessToken = (session2 != null && session2.IsOpen) ? session2.AccessTokenData.AccessToken : null;
				App.PostSuccessFacebookAction(accessToken);

			};

			//control.ShowingLoggedOutUser += (s, ea) => { element.SendShowingLoggedOutUser(); };

			if (element.PublishPermissions != null)
				control.PublishPermissions = element.PublishPermissions;
			if (element.ReadPermissions != null)
				control.ReadPermissions = element.ReadPermissions;

			MessagingCenter.Subscribe(this, "Login", (s) =>
			{
				Login();
			}, element);

			MessagingCenter.Subscribe(this, "Logout", (s) =>
			{
				Logout();
			}, element);
		}

		void Login()
		{
			var session = FBSession.ActiveSession;
			if (session != null && session.IsOpen)
				return;

			var button = Control.Subviews.Select(x => x as UIButton).FirstOrDefault(x => x != null);
			if (button == null)
				throw new Exception("cannot find FB login button");
			button.SendActionForControlEvents(UIControlEvent.TouchUpInside);
		}

		void Logout()
		{
			var session = FBSession.ActiveSession;
			if (session == null)
				return;

			session.CloseAndClearTokenInformation();
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == FacebookLoginButton.ReadPermissionsProperty.PropertyName)
				Control.ReadPermissions = Element.ReadPermissions;
			else if (e.PropertyName == FacebookLoginButton.PublishPermissionsProperty.PropertyName)
				Control.PublishPermissions = Element.PublishPermissions;
		}
    }
}