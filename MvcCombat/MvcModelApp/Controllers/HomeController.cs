using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModelApp.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tb_User model)
        {
            if (ModelState.IsValid)
            {
                db.tb_User.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public JsonResult NotExitesUserName()
        {
            string userName = Request.Params["UserName"];
             var user = db.tb_User.Where(x => x.UserName.Equals(userName)).FirstOrDefault();
            JsonResult jsonRes =user== null ? Json(true, JsonRequestBehavior.AllowGet) : Json(false, JsonRequestBehavior.AllowGet);
            return jsonRes;
        }
        public ActionResult Index()
        {
            var sql = "select * from tb_User";
            var model = db.Database.SqlQuery<tb_User>(sql);
            return View(model);
        }
	}
}