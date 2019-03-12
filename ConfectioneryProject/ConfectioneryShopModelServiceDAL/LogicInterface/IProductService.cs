using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IProductService {
        List<ProductViewModel> getList();
        ProductViewModel getElement(int id);
        void addElem(ProductBindingModel model);
        void updElem(ProductBindingModel model);
        void delElem(int id);
    }
}
