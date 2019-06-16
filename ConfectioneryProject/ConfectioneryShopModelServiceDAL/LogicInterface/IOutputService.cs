using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IOutputService {
        List<OutputViewModel> getList();
        OutputViewModel getElement(int id);
        void addElem(OutputBindingModel model);
        void updElem(OutputBindingModel model);
        void delElem(int id);
    }
}