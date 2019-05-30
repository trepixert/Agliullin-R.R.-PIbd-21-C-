using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfWebView.Controllers
{
    public class DetailController : Controller
    {
        private IDetailService service = Globals.DetailService;
        // GET: Ingredients
        public ActionResult Index()
        {
            return View(service.getList());
        }


        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePost()
        {
            service.addElem(new DetailBindingModel
            {
                DetailName = Request["DetailName"]
            });
            return RedirectToAction("Index");
        }


        // GET: Ingredients/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = service.getElement(id);
            var bindingModel = new DetailBindingModel
            {
                ID = id,
                DetailName = viewModel.DetailName
            };
            return View(bindingModel);
        }


        [HttpPost]
        public ActionResult EditPost()
        {
            service.updElem(new DetailBindingModel
            {
                ID = int.Parse(Request["ID"]),
                DetailName = Request["DetailName"]
            });
            return RedirectToAction("Index");
        }


        // GET: Ingredients/Delete/5
        public ActionResult Delete(int id)
        {
            service.delElem(id);
            return RedirectToAction("Index");
        }
    }
}