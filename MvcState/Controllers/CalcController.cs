using System.Collections.Generic;
using System.Web.Mvc;
using MvcState.Infrastructure;

namespace MvcState.Controllers
{
    public class CalcController : Controller
    {
        public ActionResult Index()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("Counter", AppStateHelper.Get(AppStateKey.Counter).ToString());
            return View("~/Views/Shared/Many.cshtml", data);
        }

        // System.Web.HttpApplicationState implements NameObjectCollectionBase  contains ArrayList _entriesArray; Get: return (NameObjectEntry)_entriesArray[index].Value;
        // http://www.dotnetframework.org/default.aspx/4@0/4@0/DEVDIV_TFS/Dev10/Releases/RTMRel/ndp/fx/src/CompMod/System/Collections/Specialized/NameObjectCollectionBase@cs/1305376/NameObjectCollectionBase@cs
        public ActionResult Increment()
        {
            // Shakespear: To box or not to box? ArrayList in HttpApplicationState.
            int value = (int)AppStateHelper.Get(AppStateKey.Counter);
            AppStateHelper.Set(AppStateKey.Counter, ++value);
            return RedirectToAction("Index");
        }
    }
}
