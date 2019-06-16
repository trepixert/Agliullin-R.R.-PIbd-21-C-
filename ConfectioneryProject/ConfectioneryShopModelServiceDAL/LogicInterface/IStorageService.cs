using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IStorageService {
        List<StorageViewModel> getList();
        StorageViewModel getElement(int id);
        void addElem(StorageBindingModel model);
        void updElem(StorageBindingModel model);
        void delElem(int id);
    }
}