﻿using System.Web.Mvc;

namespace ConfectionaryWeb.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Customers() {
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Details() {
            return RedirectToAction("Index", "Detail");
        }

        public ActionResult Outputs() {
            return RedirectToAction("Index", "Outputs");
        }

        public ActionResult Main() {
            return RedirectToAction("Index", "OutputOrder");
        }

        public ActionResult Price() {
            return RedirectToAction("PrintPrice", "Report");
        }

        public ActionResult StorageLoad() {
            return RedirectToAction("PrintStoragesLoad", "Report");
        }
    }
}