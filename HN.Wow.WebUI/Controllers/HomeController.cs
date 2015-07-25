using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HN.Wow.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HN.MenuManagement.HNMenuItemManager mgr;
            HN.MenuManagement.HNMenuMock injector =
                new HN.MenuManagement.HNMenuMock();
            mgr = new HN.MenuManagement.HNMenuItemManager(injector);

            mgr.Load();

            return View(mgr);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}