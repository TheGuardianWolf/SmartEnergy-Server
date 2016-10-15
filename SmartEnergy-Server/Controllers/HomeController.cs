using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartEnergy_Server.Controllers
{
	/// <summary>
    /// Controller for the home page of the server.
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
