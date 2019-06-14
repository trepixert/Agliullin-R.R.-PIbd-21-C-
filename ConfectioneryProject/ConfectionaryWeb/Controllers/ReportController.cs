using System;
using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryWeb.Controllers {
    public class ReportController : Controller {
        private IReportService reportService = Globals.ReportService;

        public ActionResult PrintPrice() {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "filename=Price.docx");
            Response.ContentType = "application/vnd.ms-word";
            try {
                reportService.SaveOutputPrice(new ReportBindingModel {
                    FileName = "С:\\Temp\\Price.docx"
                });
                Response.WriteFile("С:\\Temp\\Price.docx");
            }
            catch ( Exception ) {
                Response.Write("Error");
            }

            Response.End();
            return View("PrintPrices/PrintPrice");
        }

        public ActionResult PrintStoragesLoad() {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment; filename=StoragesLoad.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            try {
                reportService.SaveStorageLoad(new ReportBindingModel {
                    FileName = "C:\\Temp\\SLoad.xls"
                });
                Response.WriteFile("C:\\Temp\\SLoad.xls");
            }
            catch ( Exception ) {
                Response.Write("Error");
            }

            Response.End();
            return View("StoragesLoad/Index");
        }

        public ActionResult CustomerOrders() {
            return View("CustomerOrders/Index");
        }
    }
}