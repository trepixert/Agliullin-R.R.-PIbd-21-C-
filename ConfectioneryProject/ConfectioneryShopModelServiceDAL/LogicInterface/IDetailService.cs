using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IDetailService {
        List<DetailViewModel> getList();
        DetailViewModel getElement(int id);
        void addElem(DetailBindingModel model);
        void updElem(DetailBindingModel model);
        void delElem(int id);
    }
}
