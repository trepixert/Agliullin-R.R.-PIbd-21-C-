using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface ICustomerService {
        List<CustomerViewModel> getList();
        CustomerViewModel getElement(int id);
        void addElem(CustomerBindingModel model);
        void updElem(CustomerBindingModel model);
        void delElem(int id);
    }
}
