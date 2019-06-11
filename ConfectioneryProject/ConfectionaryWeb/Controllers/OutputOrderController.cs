using System;
using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectionaryWeb.Controllers {
    public class OutputOrderController : Controller {
        private IOutputService outputService = Globals.OutputService;
        private IMainService mainService = Globals.MainService;
        private ICustomerService customerService = Globals.CustomerService;


        // GET: PizzaOrder
        public ActionResult Index()
        {
            return View(mainService.GetList());
        }

        public ActionResult Create()
        {
            var outputs = new SelectList(outputService.GetList(), "ID", "OutputName");
            var customers = new SelectList(customerService.GetList(), "ID", "CustomerFIO");
            ViewBag.Outputs = outputs;
            ViewBag.Customers = customers;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var customerId = int.Parse(Request["CustomerId"]);
            var outputId = int.Parse(Request["OutputID"]);
            var count = int.Parse(Request["Count"]);
            var totalCost = CalcSum(outputId, count);

            mainService.CreateOrder(new OrderBindingModel()
            {
                CustomerID = customerId,
                OutputID = outputId,
                Count = count,
                Sum = totalCost

            });
            return RedirectToAction("Index");
        }

        private Decimal CalcSum(int outputId, int count)
        {
            OutputViewModel output = outputService.GetElement(outputId);
            return count * output.Price;
        }

        public ActionResult SetStatus(int id, string status)
        {
            try
            {
                switch (status)
                {
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
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }
            

            return RedirectToAction("Index");
        }
    }
}