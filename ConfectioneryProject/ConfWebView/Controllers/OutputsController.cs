using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfWebView.Controllers {
    public class OutputsController : Controller {
        public IOutputService service = Globals.OutputService;

        public ActionResult Index() {
            return View(service.getList());
        }

        public ActionResult Delete(int id) {
            service.delElem(id);
            return RedirectToAction("Index");
        }
    }
}