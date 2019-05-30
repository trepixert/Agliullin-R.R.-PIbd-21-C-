using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConfectionaryRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;
        public MainController(IMainService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.getList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            _service.createOrder(model);
        }
        [HttpPost]
        public void TakeOrderInWork(OrderBindingModel model)
        {
            _service.takeOrderInWork(model);
        }
        [HttpPost]
        public void FinishOrder(OrderBindingModel model)
        {
            _service.finishOrder(model);
        }
        [HttpPost]
        public void PayOrder(OrderBindingModel model)
        {
            _service.payOrder(model);
        }
        [HttpPost]
        public void PutComponentOnStock(StorageDetailBindingModel model)
        {
            _service.putDetailOnStorage(model);
        }
    }

}
