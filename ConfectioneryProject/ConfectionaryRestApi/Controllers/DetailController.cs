using System;
using System.Web.Http;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryRestApi.Controllers {
    public class DetailController : ApiController {
        private readonly IDetailService _service;

        public DetailController(IDetailService service) {
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
        public void AddElement(DetailBindingModel model) {
            _service.AddElem(model);
        }

        [HttpPost]
        public void UpdElement(DetailBindingModel model) {
            _service.UpdElem(model);
        }

        [HttpPost]
        public void DelElement(DetailBindingModel model) {
            _service.DelElem(model.ID);
        }
    }
}