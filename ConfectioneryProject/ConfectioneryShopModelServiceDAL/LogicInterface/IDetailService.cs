using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IDetailService {
        List<DetailViewModel> getList();
        DetailViewModel getElement(int id);
        void addElem(DetailBindingModel model);
        void updElem(DetailBindingModel model);
        void delElem(int id);
    }
}