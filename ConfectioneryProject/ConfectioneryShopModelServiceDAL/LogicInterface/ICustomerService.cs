using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface ICustomerService {
        List<CustomerViewModel> GetList();
        CustomerViewModel GetElement(int id);
        void AddElem(CustomerBindingModel model);
        void UpdElem(CustomerBindingModel model);
        void DelElem(int id);
    }
}