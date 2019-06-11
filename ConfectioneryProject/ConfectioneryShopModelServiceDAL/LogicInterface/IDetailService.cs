using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IDetailService {
        List<DetailViewModel> GetList();
        DetailViewModel GetElement(int id);
        void AddElem(DetailBindingModel model);
        void UpdElem(DetailBindingModel model);
        void DelElem(int id);
    }
}