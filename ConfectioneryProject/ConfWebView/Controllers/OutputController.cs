using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfWebView.Controllers
{
    public class OutputController : Controller
    {
        private IOutputService service = Globals.OutputService;
        private IDetailService detailService = Globals.DetailService;

        // GET: Pizzas
        public ActionResult Index()
        {
            if (Session["Pizza"] == null)
            {
                var output = new OutputViewModel();
                output.OutputDetail = new List<ConnectionBetweenDetailAndOutputViewModel>();
                Session["Output"] = output;
            }
            return View((OutputViewModel)Session["Output"]);
        }

        public ActionResult AddDetail()
        {
            var details = new SelectList(detailService.getList(), "ID", "DetailName");
            ViewBag.Ingredients = details;
            return View();
        }

        [HttpPost]
        public ActionResult AddDetailPost()
        {
            var output = (OutputViewModel)Session["Output"];
            var detail = new ConnectionBetweenDetailAndOutputViewModel
            {
                ID = int.Parse(Request["ID"]),
                DetailName = detailService.getElement(int.Parse(Request["ID"])).DetailName,
                Count = int.Parse(Request["Count"])
            };
            output.OutputDetail.Add(detail);
            Session["Output"] = output;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreatePizzaPost()
        {
            var output = (OutputViewModel)Session["Output"];
            var outputDetails = new List<ConnectionBetweenDetailAndOutput>();
            for (int i = 0; i < output.OutputDetail.Count; ++i)
            {
                outputDetails.Add(new ConnectionBetweenDetailAndOutput
                {
                    ID = output.OutputDetail[i].ID,
                    OutputID = output.OutputDetail[i].OutputID,
                    DetailID = output.OutputDetail[i].DetailID,
                    Count = output.OutputDetail[i].Count
                });
            }
            service.addElem(new OutputBindingModel
            {
                OutputName = Request["OutputName"],
                Price = Convert.ToDecimal(Request["Price"]),
                OutputDetail = outputDetails
            });
            Session.Remove("Pizza");
            return RedirectToAction("Index", "Pizzas");
        }
    }
}