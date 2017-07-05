using MvcViewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcViewApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["One"] = "111";
            ViewBag.Two = "222";
            var user = new User { Name = "333" };
            TempData["Four"] = "444";
            return View(user);
        }
	}
}