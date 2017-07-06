using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MvcAjaxApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult ShowEmployeesList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetEmployeesList()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var list = db.Employees.Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    City = x.City
                }).ToList();
                JavaScriptSerializer js=new JavaScriptSerializer();
                string json= js.Serialize(list);
                return  Content(json);
            }
        }
        public ActionResult PartialViewTest()
        {
            return View();
        }

        public ActionResult BaseInfo(string txtName)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var result = db.Employees.Where(x => x.LastName.Equals(txtName)).FirstOrDefault();
                return Content(string.Format("姓名:{0}", result.LastName));
            }
        }

	}
}