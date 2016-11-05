using System.Web.Mvc;
using System.Web.SessionState;
using MvcState.Infrastructure;

namespace MvcState.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class SessionSyncController : Controller
    {
        public ActionResult Index()
        {
            //var x = SessionStateHelper.Get(SessionStateKey.Name);
            return View();
        }

        [OutputCache(NoStore= true, Duration = 0)]
        public string GetMessage(int id)
        {
            return string.Format("Message: {0}", id);
        }
    }
}