using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfWebView.Controllers {
    public class CustomerController : Controller {
        public ICustomerService service = Globals.CustomerService;

        // GET: Customers
        public ActionResult Index() {
            return View(service.GetList());
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost() {
            service.AddElem(new CustomerBindingModel {
                CustomerFIO = Request["CustomerFIO"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id) {
            var viewModel = service.GetElement(id);
            var bindingModel = new CustomerBindingModel {
                ID = id,
                CustomerFIO = viewModel.CustomerFIO
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost() {
            service.UpdElem(new CustomerBindingModel {
                ID = int.Parse(Request["ID"]),
                CustomerFIO = Request["CustomerFIO"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) {
            service.DelElem(id);
            return RedirectToAction("Index");
        }
    }
}