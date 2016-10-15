using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartEnergy_Server.Controllers
{
	/// <summary>
    /// A set of endpoints relating to home data.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "SmartEnergy Server";

            return View();
        }
    }
}
