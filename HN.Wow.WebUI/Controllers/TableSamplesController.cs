using System.Web.Mvc;
using SamplesData;

namespace HN.Wow.WebUI.Controllers
{
  public class TableSamplesController : Controller
  {
    //*********************************************************
    // Loading Data
    public ActionResult Table01()
    {
      ProductViewModel1 vm = new ProductViewModel1();

      vm.HandleRequest();

      return View(vm);
    }

    //*********************************************************
    // Sorting
    public ActionResult Table02()
    {
      ProductViewModel2 vm = new ProductViewModel2();

      vm.EventCommand = "sort";
      vm.HandleRequest();

      return View(vm);
    }

    [HttpPost]
    public ActionResult Table02(ProductViewModel2 vm)
    {
      vm.HandleRequest();

      // NOTE: Must clear the model state in order to bind
      //       the @Html helpers to the new model values
      ModelState.Clear();

      return View(vm);
    }

    //*********************************************************
    // Paging using C#
    public ActionResult Table03()
    {
      ProductViewModel3 vm = new ProductViewModel3();

      vm.EventCommand = "page";
      vm.HandleRequest();

      return View(vm);
    }

    [HttpPost]
    public ActionResult Table03(ProductViewModel3 vm)
    {
      vm.HandleRequest();

      // NOTE: Must clear the model state in order to bind
      //       the @Html helpers to the new model values
      ModelState.Clear();

      return View(vm);
    }



    //*********************************************************
    // Server-Side Paging
    public ActionResult Table04()
    {
      ProductViewModel4 vm = new ProductViewModel4();

      vm.EventCommand = "page";
      vm.HandleRequest();

      return View(vm);
    }

    [HttpPost]
    public ActionResult Table04(ProductViewModel4 vm)
    {
      vm.HandleRequest();

      // NOTE: Must clear the model state in order to bind
      //       the @Html helpers to the new model values
      ModelState.Clear();

      return View(vm);
    }

    //*********************************************************
    // Paging and Sorting using C#
    public ActionResult Table05()
    {
      ProductViewModel5 vm = new ProductViewModel5();

      vm.EventCommand = "page";
      vm.HandleRequest();

      return View(vm);
    }

    [HttpPost]
    public ActionResult Table05(ProductViewModel5 vm)
    {
      vm.HandleRequest();

      // NOTE: Must clear the model state in order to bind
      //       the @Html helpers to the new model values
      ModelState.Clear();

      return View(vm);
    }

    //*********************************************************
    // Server-Side Paging and Sorting
    public ActionResult Table06()
    {
      ProductViewModel6 vm = new ProductViewModel6();

      vm.EventCommand = "page";
      vm.HandleRequest();

      return View(vm);
    }

    [HttpPost]
    public ActionResult Table06(ProductViewModel6 vm)
    {
      vm.HandleRequest();

      // NOTE: Must clear the model state in order to bind
      //       the @Html helpers to the new model values
      ModelState.Clear();

      return View(vm);
    }
  }
}