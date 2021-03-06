﻿using System.Web.Mvc;
using MvcState.Infrastructure;

namespace MvcState.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult Index()
        {
            return View("../Session/Index");
        }

        [HttpPost]
        public ActionResult ProcessFirstForm(string name)
        {
            SessionStateHelper.Set(SessionStateKey.Name, name);
            return View("../Session/SecondForm", (object)name);
        }

        [HttpPost]
        public ActionResult CompleteForm(string country)
        {
            ViewBag.Name = SessionStateHelper.Get(SessionStateKey.Name);
            ViewBag.Country = country;
            return View("../Session/CompleteForm");
        }

        private void Debug(string name, object value)
        {
            System.Diagnostics.Debug.WriteLine(name, value);
        }
    }
}