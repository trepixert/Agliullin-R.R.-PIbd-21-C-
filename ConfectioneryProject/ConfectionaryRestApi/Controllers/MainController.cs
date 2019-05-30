using ConfectionaryRestApi.Services;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
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

        private readonly IImplementerService _serviceImplementer;

        public MainController(IMainService service, IImplementerService serviceImplementer)
        {
            _service = service;
            _serviceImplementer = serviceImplementer;
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
        public void StartWork()
        {
            List<OrderViewModel> orders = _service.GetFreeOrders();
            foreach (var order in orders)
            {
                ImplementerViewModel impl = _serviceImplementer.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }

                new WorkImplementer(_service, _serviceImplementer, impl.Id, order.ID);
            }
        }

        [HttpPost]
        public void PayOrder(OrderBindingModel model)
        {
            _service.payOrder(model);
        }

        [HttpPost]
        public void putDetailOnStorage(StorageDetailBindingModel model)
        {
            _service.putDetailOnStorage(model);
        }
    }
}
