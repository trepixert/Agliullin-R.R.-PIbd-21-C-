using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IOutputService {
        List<OutputViewModel> getList();
        OutputViewModel getElement(int id);
        void addElem(OutputBindingModel model);
        void updElem(OutputBindingModel model);
        void delElem(int id);
    }
}
