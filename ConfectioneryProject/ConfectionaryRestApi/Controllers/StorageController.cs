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
    public class StorageController : ApiController
    {
        private readonly IStorageService _service;

        public StorageController(IStorageService service)
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

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.getElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(StorageBindingModel model)
        {
            _service.addElem(model);
        }

        [HttpPost]
        public void UpdElement(StorageBindingModel model)
        {
            _service.updElem(model);
        }

        [HttpPost]
        public void DelElement(StorageBindingModel model)
        {
            _service.delElem(model.ID);
        }
    }
}
