using System.Web.Mvc;
using System.Collections.Generic;
using MvcState.Infrastructure;

namespace MvcState.Controllers
{
    public class LockController : AsyncController
    {
        public ActionResult Index()
        {
            IDictionary<AppStateKey, object> data = AppStateHelper.Get(AppStateKey.LastRequestTime, AppStateKey.LastRequestUrl);
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var pair in data)
            {
                result.Add(AppStateHelper.GetKey(pair.Key), pair.Value.ToString());
            }

            return View("~/Views/Shared/Many.cshtml", (object)result);
        }

        public ActionResult Increment()
        {
            int value = (int)AppStateHelper.Get(AppStateKey.Counter);
            AppStateHelper.Set(AppStateKey.Counter, ++value);
            AppStateHelper.Set(new Dictionary<AppStateKey, object>()
            {
                { AppStateKey.LastRequestTime, HttpContext.Timestamp },
                { AppStateKey.LastRequestUrl, Request.RawUrl }
            });

            return RedirectToAction("Index");
        }

        public ActionResult Violate()
        {
            int value = (int)AppStateHelper.Get(AppStateKey.Counter);
            AppStateHelper.Set(AppStateKey.Counter, ++value);
            AppStateHelper.Set(AppStateKey.LastRequestTime, "Violate lock on debugging. Try to update an item from locked field set.");
            return RedirectToAction("Index");
        }
    }
}
