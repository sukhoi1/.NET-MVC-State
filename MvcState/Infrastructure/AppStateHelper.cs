using System;
using System.Web;

namespace MvcState.Infrastructure
{
    public class AppStateHelper
    {
        public static object Get(AppStateKeys key)
        {
            return HttpContext.Current.Application[GetKey(key)];
        }

        public static object Set(AppStateKeys key, object value)
        {
            return HttpContext.Current.Application[GetKey(key)] = value;
        }

        private static string GetKey(AppStateKeys key)
        {
            return Enum.GetName(typeof(AppStateKeys), key);
        }
    }
}