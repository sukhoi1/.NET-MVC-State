using System;
using System.Web;

namespace MvcState.Infrastructure
{
    public class SessionStateHelper
    {
        public static object Get(SessionStateKey key)
        {
            return HttpContext.Current.Session[GetKey(key)];
        }

        public static object Set(SessionStateKey key, object value)
        {
            return HttpContext.Current.Session[GetKey(key)] = value;
        }

        public static string GetKey(SessionStateKey key)
        {
            return Enum.GetName(typeof(AppStateKey), key);
        }
    }
}