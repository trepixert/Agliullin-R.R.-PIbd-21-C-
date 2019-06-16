using System;
using System.Collections.Generic;
using System.Web.Http;
using ConfectionaryRestApi.Services;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectionaryRestApi.Controllers {
    public class MainController : ApiController {
        private readonly IMainService _service;
        private readonly IImplementerService _serviceImplementer;

        public MainController(IMainService service, IImplementerService serviceImplementer) {
            _service = service;
            _serviceImplementer = serviceImplementer;
        }
        public MainController(IMainService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IHttpActionResult GetList() {
            var list = _service.GetList();
            if ( list == null ) {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(list);
        }
        
        [HttpPost]
        public void CreateOrder(OrderBindingModel model) {
            _service.CreateOrder(model);
        }

        [HttpPost]
        public void StartWork() {
            List<OrderViewModel> orders = _service.GetFreeOrders();
            foreach ( var order in orders ) {
                ImplementerViewModel impl = _serviceImplementer.GetFreeWorker();
                if ( impl == null ) {
                    throw new Exception("Нет сотрудников");
                }

                new WorkImplementer(_service, _serviceImplementer, impl.Id, order.ID);
            }
        }

        [HttpPost]
        public void PayOrder(OrderBindingModel model) {
            _service.PayOrder(model);
        }

        [HttpPost]
        public void putDetailOnStorage(StorageDetailBindingModel model) {
            _service.PutDetailOnStorage(model);
        }

        [HttpGet]
        public IHttpActionResult GetInfo() {
            ReflectionService service = new ReflectionService();
            var list = service.GetInfoByAssembly();
            if ( list == null ) {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
    }
}