using System;
using System.Web.Http;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryRestApi.Controllers {
    public class OutputController : ApiController {
        private readonly IOutputService _service;

        public OutputController(IOutputService service) {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList() {
            var list = _service.getList();
            if ( list == null ) {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id) {
            var element = _service.getElement(id);
            if ( element == null ) {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(element);
        }

        [HttpPost]
        public void AddElement(OutputBindingModel model) {
            _service.addElem(model);
        }

        [HttpPost]
        public void UpdElement(OutputBindingModel model) {
            _service.updElem(model);
        }

        [HttpPost]
        public void DelElement(OutputBindingModel model) {
            _service.delElem(model.ID);
        }
    }
}