using System.Threading;
using System.Web.Mvc;
using MvcState.Infrastructure;

namespace MvcState.Controllers
{
    public class SessionLifecycleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(bool store = false, bool abandon = false)
        {
            if (store)
            {
                SessionStateHelper.Set(SessionStateKey.Name, "Name");
            }

            if (abandon)
            {
                Session.Abandon();
            }

            return RedirectToAction("Index");
        }
    }
}