using System;
using System.Web.Http;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryRestApi.Controllers {
    public class StorageController : ApiController {
        private readonly IStorageService _service;

        public StorageController(IStorageService service) {
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
        public void AddElement(StorageBindingModel model) {
            _service.AddElem(model);
        }

        [HttpPost]
        public void UpdElement(StorageBindingModel model) {
            _service.UpdElem(model);
        }

        [HttpPost]
        public void DelElement(StorageBindingModel model) {
            _service.DelElem(model.ID);
        }
    }
}