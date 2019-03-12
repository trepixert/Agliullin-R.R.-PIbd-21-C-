using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    interface ILogic {
        List<ClientViewModel> GetList { get; set; }
        ClientViewModel getElement(int id);
        void addElement(ClientBindingModel model);
        void updElement(ClientBindingModel model);
        void delElement(int id);
    }
}
