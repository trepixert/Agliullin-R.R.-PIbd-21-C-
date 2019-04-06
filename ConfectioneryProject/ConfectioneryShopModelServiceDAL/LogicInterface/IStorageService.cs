using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IStorageService {
        List<StorageViewModel> getList();
        StorageViewModel getElement(int id);
        void addElem(StorageBindingModel model);
        void updElem(StorageBindingModel model);
        void delElem(int id);
    }
}
