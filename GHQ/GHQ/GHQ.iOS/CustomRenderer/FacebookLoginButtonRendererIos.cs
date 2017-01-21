using Dawaa.iOS;
using GHQ;
using MonoTouch.FacebookConnect;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Dawaa;
using System.Collections.Generic;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookLoginButtonRendererIos))]
namespace Dawaa.iOS
{
    public class FacebookLoginButtonRendererIos : ButtonRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                UIButton button = Control;

                button.TouchUpInside += delegate
                {
                    HandleFacebookLoginClicked();
                };
            }
        }

        private void HandleFacebookLoginClicked()
        {
            if (FBSession.ActiveSession.IsOpen)
            {
                App.PostSuccessFacebookAction(FBSession.ActiveSession.AccessTokenData.AccessToken);
            }
            else
            {
				List<string> permissions = new List<string>();
				permissions.Add("public_profile");


				FBSession.OpenActiveSession(null, true, (session, status, error) =>
				{
					if (error == null)
	                {
						App.PostSuccessFacebookAction(session.AccessTokenData.AccessToken);
	                }
				});
					
				//FBSession.ActiveSession.Open(FBSessionLoginBehavior.UseSystemAccountIfPresent, (aSession, status, error) =>
    //            {
    //                if (error == null)
    //                {
    //                    App.PostSuccessFacebookAction(aSession.AccessTokenData.AccessToken);
    //                }
    //            });
            }

        }
    }
}