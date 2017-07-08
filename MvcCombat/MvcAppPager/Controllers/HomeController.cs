using MvcAppPager.Filter;
using MvcAppPager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppPager.Controllers
{
    public class HomeController : Controller
    {
        List<Order> list = new List<Order>()
        {
            new Order{ID=1,OrderNo="2016050501",WayFee=20,EMS="C0111"},
            new Order{ID=2,OrderNo="2016050502",WayFee=21,EMS="C0112"},
            new Order{ID=3,OrderNo="2016050503",WayFee=22,EMS="C0113"},
            new Order{ID=4,OrderNo="2016050504",WayFee=23,EMS="C0114"},
            new Order{ID=5,OrderNo="2016050505",WayFee=24,EMS="C0115"},
            new Order{ID=6,OrderNo="2016050506",WayFee=25,EMS="C0116"},
            new Order{ID=7,OrderNo="2016050507",WayFee=26,EMS="C0117"}
        };
        private const int PageSize = 2;
        private int counts;
        public ActionResult Index(int pageIndex=0)
        {
            counts = list.Count;
            list = list.Skip(PageSize * pageIndex).Take(PageSize).ToList();
            PageOfList<Order> orderList = new PageOfList<Order>(list, pageIndex, PageSize, counts);

            return View(orderList);
        }
        [MyActionFilterAttribute]
        public ActionResult FilterMethod()
        {
            return Content(string.Format("Action 中的方法:{0}<br/>", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ff")));
        }
        public ActionResult OnAuthorizationMthod()
        {
            return View();
        }

        [TestHandleErrorAttribute]
        public ActionResult GetErr()
        {
            int a = 0;
            int b = 1 / a;
            return View();
        }
	}
}