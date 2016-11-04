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
            AppStateHelper.Set(AppStateKeys.Counter, 0);
        }
    }
}
