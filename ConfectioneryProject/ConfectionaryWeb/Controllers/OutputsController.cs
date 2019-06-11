using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryWeb.Controllers {
    public class OutputsController : Controller {
        public IOutputService service = Globals.OutputService;
        public ActionResult Index()
        {
            return View(service.GetList());
        }

        public ActionResult Delete(int id)
        {
            service.DelElem(id);
            return RedirectToAction("Index");
        }
    }
}