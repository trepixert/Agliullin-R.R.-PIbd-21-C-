using System.IO;
using System.Web;
using System.Web.Mvc;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryWeb.Controllers {
    public class ReportController : Controller {
        private IReportService _reportService = Globals.ReportService;

        public ActionResult Index() {
            return View();
        }
        
        [HttpPost]
        public ActionResult SavePricePost() {
            HttpResponse response = System.Web.HttpContext.Current.Response;
            HttpResponse resp = System.Web.HttpContext.Current.Response;
            string filename = "thisfilename.txt";
            string destFolder =  @"D:\NET\MvcApplication2\MvcApplication2\temp";
            string filePath = Path.Combine(destFolder, filename);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write("Word ");
                writer.WriteLine("word 2");
                writer.WriteLine("Line");
                writer.Flush();
                writer.Close();
            }

            resp.ContentType = "application/text";
            resp.AppendHeader("content-disposition", "attachment; filename=" + "thisfilename.txt");
            response.WriteFile(filePath);
            response.Flush();
            response.End();
            return View();
        }
    }
}