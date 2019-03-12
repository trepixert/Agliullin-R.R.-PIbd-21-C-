using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IComponentService {
        List<ComponentViewModel> getList();
        ComponentViewModel getElement(int id);
        void addElem(ComponentBindingModel model);
        void updElem(ComponentBindingModel model);
        void delElem(int id);
    }
}
