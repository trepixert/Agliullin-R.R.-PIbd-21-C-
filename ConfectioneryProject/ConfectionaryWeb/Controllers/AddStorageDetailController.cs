using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryWeb.Controllers {
    public class AddStorageDetailController : Controller {
        private IDetailService detailService = Globals.DetailService;
        private IStorageService storageService = Globals.StorageService;
        private IMainService mainService = Globals.MainService;

        public ActionResult Index()
        {
            var details = new SelectList(detailService.GetList(), "ID", "DetailName");
            ViewBag.Details = details;

            var storages = new SelectList(storageService.GetList(), "ID", "StorageName");
            ViewBag.Storages = storages;
            return View();
        }

        [HttpPost]
        public ActionResult AddDetailPost()
        {
            mainService.PutDetailOnStorage(new StorageDetailBindingModel
            {
                DetailID = int.Parse(Request["DetailID"]),
                StorageID = int.Parse(Request["StorageID"]),
                Count = int.Parse(Request["Count"])
            });
            return RedirectToAction("Index", "Home");
        }
    }
}