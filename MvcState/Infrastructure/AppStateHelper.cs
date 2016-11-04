using System;
using System.Collections.Generic;
using System.Web;

namespace MvcState.Infrastructure
{
    public class AppStateHelper
    {
        private static HttpApplicationState AppState = HttpContext.Current.Application;

        public static object Get(AppStateKey key)
        {
            return HttpContext.Current.Application[GetKey(key)];
        }

        public static object Set(AppStateKey key, object value)
        {
            return HttpContext.Current.Application[GetKey(key)] = value;
        }

        public static IDictionary<AppStateKey, object> Get(params AppStateKey[] keys)
        {
            Dictionary<AppStateKey, object> data = new Dictionary<AppStateKey, object>();
            AppState.Lock();
            foreach (var key in keys)
            {
                data.Add(key, Get(key));
            }

            AppState.UnLock();
            return data;
        }

        public static void Set(IDictionary<AppStateKey, object> data)
        {
            AppState.Lock();
            foreach (var pair in data)
            {
                Set(pair.Key, pair.Value);
            }

            AppState.UnLock();
        }

        public static string GetKey(AppStateKey key)
        {
            return Enum.GetName(typeof(AppStateKey), key);
        }
    }
}