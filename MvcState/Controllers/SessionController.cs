using System.Web.Mvc;

namespace MvcState.Controllers
{
    public class ViewBagController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessFirstForm(string name)
        {
            Debug("Name: {0}", (object)name);
            return View("SecondForm", (object)name);
        }

        [HttpPost]
        public ActionResult CompleteForm(string country)
        {
            Debug("Country: {0}", (object)country);
            ViewBag.Name = "<Unknown>";
            ViewBag.Country = country;
            return View();
        }

        private void Debug(string name, object value)
        {
            System.Diagnostics.Debug.WriteLine(name, value);
        }
    }
}