using GHQ.UWP.Services;
using Service.Localization;
using System.Globalization;
using System.Resources;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]

namespace GHQ.UWP.Services
{
    public class Localize : ILocalize
    {
        public void SetLocale(CultureInfo ci)
        {
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            return new CultureInfo("ar-EG");
        }

        public ResourceManager GetResourceManager()
        {
            return null;
        }

    }
}

