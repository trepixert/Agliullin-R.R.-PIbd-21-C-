using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfWebView.Controllers {
    public class OutputController : Controller {
        private IOutputService service = Globals.OutputService;
        private IDetailService detailService = Globals.DetailService;

        public ActionResult Index() {
            if ( Session["Output"] == null ) {
                var output = new OutputViewModel();
                output.OutputDetail = new List<ConnectionBetweenDetailAndOutputViewModel>();
                Session["Output"] = output;
            }
            return View((OutputViewModel) Session["Output"]);
        }

        public ActionResult AddDetail() {
            var details = new SelectList(detailService.GetList(), "ID", "DetailName");
            ViewBag.Ingredients = details;
            return View();
        }

        [HttpPost]
        public ActionResult AddDetailPost() {
            var output = (OutputViewModel) Session["Output"];
            var detail = new ConnectionBetweenDetailAndOutputViewModel {
                ID = int.Parse(Request["ID"]),
                DetailName = detailService.GetElement(int.Parse(Request["ID"])).DetailName,
                Count = int.Parse(Request["Count"])
            };
            output.OutputDetail.Add(detail);
            Session["Output"] = output;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreatePizzaPost() {
            var output = (OutputViewModel) Session["Output"];
            var outputDetails = new List<ConnectionBetweenDetailAndOutput>();
            for ( int i = 0; i < output.OutputDetail.Count; ++i ) {
                outputDetails.Add(new ConnectionBetweenDetailAndOutput {
                    ID = output.OutputDetail[i].ID,
                    OutputID = output.OutputDetail[i].OutputID,
                    DetailID = output.OutputDetail[i].DetailID,
                    Count = output.OutputDetail[i].Count
                });
            }

            service.AddElem(new OutputBindingModel {
                OutputName = Request["OutputName"],
                Price = Convert.ToDecimal(Request["Price"]),
                OutputDetail = outputDetails
            });
            Session.Remove("Output");
            return RedirectToAction("Index", "Output");
        }
    }
}