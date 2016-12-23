using GHQ.Logic.Constant;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Service.Localization
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci = null;
        ResourceManager rm = null;


        public TranslateExtension()
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            if (rm == null)
            {
                var assembly = typeof(TranslateExtension).GetTypeInfo().Assembly;
                rm = new ResourceManager(Constant.ResourceId, assembly);

            }

            var translation = rm.GetString(Text, ci);
            if (translation == null)
            {
                translation = Text;
                //#if DEBUG
                //                throw new ArgumentException(
                //                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                //                    "Text");
                //#else
                //				translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
                //#endif
            }
            return translation;
        }
    }

}
