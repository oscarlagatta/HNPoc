using System.Web.Mvc;
using SamplesData;

namespace HN.Wow.WebUI.Controllers
{
  public class PagerSamplesController : Controller
  {
    public ActionResult Pager01()
    {
      return View();
    }

    public ActionResult Pager02()
    {
      PagerViewModel vm = new PagerViewModel();

      return View(vm);
    }
  }
}