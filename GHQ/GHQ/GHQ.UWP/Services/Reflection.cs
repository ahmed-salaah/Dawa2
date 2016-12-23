using System;
using Service.Reflection;
using Xamarin.Forms;
using System.Reflection;

[assembly: Dependency(typeof(GHQ.UWP.Services.Reflection))]

namespace GHQ.UWP.Services
{
    public class Reflection : IReflection
    {
        public void SetProperty(object instance, string propertyName, object newValue)
        {
            Type type = instance.GetType();

            PropertyInfo prop = type.GetProperty(propertyName);

            if (prop != null)
                prop.SetValue(instance, newValue, null);
        }
    }
}
