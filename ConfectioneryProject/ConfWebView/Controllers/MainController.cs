using System;
using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfWebView.Controllers {
    public class MainController : Controller {
        private IOutputService outputService = Globals.OutputService;
        private IMainService mainService = Globals.MainService;
        private ICustomerService customerService = Globals.CustomerService;


        // GET: PizzaOrder
        public ActionResult Index() {
            return View(mainService.GetList());
        }

        public ActionResult Create() {
            var outputs = new SelectList(outputService.GetList(), "ID", "OutputName");
            var customers = new SelectList(customerService.GetList(), "Id", "CustomerFIO");
            ViewBag.Outputs = outputs;
            ViewBag.Customers = customers;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost() {
            var customerId = int.Parse(Request["CustomerID"]);
            var outputID = int.Parse(Request["OutputID"]);
            var outputCount = int.Parse(Request["Count"]);
            var totalCost = CalcSum(outputID, outputCount);

            mainService.CreateOrder(new OrderBindingModel {
                CustomerID = customerId,
                OutputID = outputID,
                Count = outputCount,
                Sum = totalCost
            });
            return RedirectToAction("Index");
        }

        private Decimal CalcSum(int outputID, int outputCount) {
            OutputViewModel output = outputService.GetElement(outputID);
            return outputCount * output.Price;
        }

        public ActionResult SetStatus(int id, string status) {
            try {
                switch ( status ) {
                    case "Processing":
                        mainService.TakeOrderInWork(new OrderBindingModel {ID = id});
                        break;
                    case "Ready":
                        mainService.FinishOrder(new OrderBindingModel {ID = id});
                        break;
                    case "Paid":
                        mainService.PayOrder(new OrderBindingModel {ID = id});
                        break;
                }
            }
            catch ( Exception ex ) {
                ModelState.AddModelError("Error", ex.Message);
            }


            return RedirectToAction("Index");
        }
    }
}