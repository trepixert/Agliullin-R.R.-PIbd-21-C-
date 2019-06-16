using System;
using System.Web.Http;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryRestApi.Controllers {
    public class ReportController : ApiController {
        private readonly IReportService _service;

        public ReportController(IReportService service) {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetStorageLoad() {
            var list = _service.GetStorageLoad();
            if ( list == null ) {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult GetClientOrders(ReportBindingModel model) {
            var list = _service.GetCustomerOrders(model);
            if ( list == null ) {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(list);
        }

        [HttpPost]
        public void SaveOutputPrice(ReportBindingModel model) {
            _service.SaveOutputPrice(model);
        }

        [HttpPost]
        public void SaveStorageLoad(ReportBindingModel model) {
            _service.SaveStorageLoad(model);
        }

        [HttpPost]
        public void SaveCustomerOrders(ReportBindingModel model) {
            _service.SaveCustomerOrders(model);
        }
    }
}