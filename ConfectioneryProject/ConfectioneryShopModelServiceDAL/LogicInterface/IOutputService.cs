using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IOutputService {
        List<OutputViewModel> GetList();
        OutputViewModel GetElement(int id);
        void AddElem(OutputBindingModel model);
        void UpdElem(OutputBindingModel model);
        void DelElem(int id);
    }
}