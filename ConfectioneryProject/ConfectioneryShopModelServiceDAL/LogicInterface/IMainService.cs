using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IMainService {
        List<OrderViewModel> getList();
        void createOrder(OrderBindingModel model);
        void takeOrderInWork(OrderBindingModel model);
        void finishOrder(OrderBindingModel model);
        void payOrder(OrderBindingModel model);
    }
}