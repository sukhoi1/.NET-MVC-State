using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using MvcState.Infrastructure;

namespace MvcState
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AppStateHelper.Set(AppStateKey.Counter, 0);
            AppStateHelper.Set(new Dictionary<AppStateKey, object>()
            {
                { AppStateKey.LastRequestTime, "Default value is a string, not a timestamp. This is a very flexible solution with low performance side effect." },
                { AppStateKey.LastRequestUrl, 0 }
            });
        }
    }
}
