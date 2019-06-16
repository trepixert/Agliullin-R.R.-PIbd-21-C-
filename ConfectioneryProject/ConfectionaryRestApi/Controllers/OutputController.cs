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
            var list = _service.GetList();
            if ( list == null ) {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id) {
            var element = _service.GetElement(id);
            if ( element == null ) {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(element);
        }

        [HttpPost]
        public void AddElement(OutputBindingModel model) {
            _service.AddElem(model);
        }

        [HttpPost]
        public void UpdElement(OutputBindingModel model) {
            _service.UpdElem(model);
        }

        [HttpPost]
        public void DelElement(OutputBindingModel model) {
            _service.DelElem(model.ID);
        }
    }
}