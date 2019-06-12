using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryWeb.Controllers {
    public class StorageController : Controller {
        private IStorageService service = Globals.StorageService;

        public ActionResult List()
        {
            return View(service.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            service.AddElem(new StorageBindingModel
            {
                StorageName = Request["StorageName"]
            });
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = service.GetElement(id);
            var bindingModel = new StorageBindingModel
            {
                ID = id,
                StorageName = viewModel.StorageName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            service.UpdElem(new StorageBindingModel
            { 
                ID = int.Parse(Request["StorageId"]),
                StorageName = Request["StorageName"]
            });
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            service.DelElem(id);
            return RedirectToAction("List");
        }
    }
}