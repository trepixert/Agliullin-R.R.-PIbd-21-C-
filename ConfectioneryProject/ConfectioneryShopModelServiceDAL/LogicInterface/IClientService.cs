using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IClientService {
        List<ClientViewModel> getList();
        ClientViewModel getElement(int id);
        void addElem(ClientBindingModel model);
        void updElem(ClientBindingModel model);
        void delElem(int id);
    }
}
