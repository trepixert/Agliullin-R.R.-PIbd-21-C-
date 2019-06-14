using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryWeb.Controllers {
    public class DetailController : Controller {
        private IDetailService service = Globals.DetailService;

        // GET: Ingredients
        public ActionResult Index() {
            return View(service.GetList());
        }


        // GET: Ingredients/Create
        public ActionResult Create() {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePost() {
            service.AddElem(new DetailBindingModel {
                DetailName = Request["DetailName"]
            });
            return RedirectToAction("Index");
        }


        // GET: Ingredients/Edit/5
        public ActionResult Edit(int id) {
            var viewModel = service.GetElement(id);
            var bindingModel = new DetailBindingModel {
                ID = id,
                DetailName = viewModel.DetailName
            };
            return View(bindingModel);
        }


        [HttpPost]
        public ActionResult EditPost() {
            service.UpdElem(new DetailBindingModel {
                ID = int.Parse(Request["ID"]),
                DetailName = Request["DetailName"]
            });
            return RedirectToAction("Index");
        }


        // GET: Ingredients/Delete/5
        public ActionResult Delete(int id) {
            service.DelElem(id);
            return RedirectToAction("Index");
        }
    }
}