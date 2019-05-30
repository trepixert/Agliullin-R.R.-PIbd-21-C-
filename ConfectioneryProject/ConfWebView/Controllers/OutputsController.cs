using ConfectioneryShopModelServiceDAL.LogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfWebView.Controllers
{
    public class OutputsController : Controller
    {
        public IOutputService service = Globals.OutputService;
        // GET: Pizzas
        public ActionResult Index()
        {
            return View(service.getList());
        }

        public ActionResult Delete(int id)
        {
            service.delElem(id);
            return RedirectToAction("Index");
        }
    }
}