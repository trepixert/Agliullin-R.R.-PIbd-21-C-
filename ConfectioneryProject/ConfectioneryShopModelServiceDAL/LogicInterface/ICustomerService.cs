using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface ICustomerService {
        List<CustomerViewModel> getList();
        CustomerViewModel getElement(int id);
        void addElem(CustomerBindingModel model);
        void updElem(CustomerBindingModel model);
        void delElem(int id);
    }
}