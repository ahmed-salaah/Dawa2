using System;
using GHQ.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WebView), typeof(CustomWebView))]
namespace GHQ.iOS
{
    public class CustomWebView : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
			this.Opaque = false;
			nfloat red = (nfloat)236 / (nfloat)255;
			nfloat green = (nfloat)220 / (nfloat)255;
			nfloat blue = (nfloat)197 / (nfloat)255;
			this.BackgroundColor = new UIKit.UIColor(red, green, blue, 1);
		}
	}

}
