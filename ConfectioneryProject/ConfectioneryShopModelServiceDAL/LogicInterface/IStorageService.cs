using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IStorageService {
        List<StorageViewModel> GetList();
        StorageViewModel GetElement(int id);
        void AddElem(StorageBindingModel model);
        void UpdElem(StorageBindingModel model);
        void DelElem(int id);
    }
}
