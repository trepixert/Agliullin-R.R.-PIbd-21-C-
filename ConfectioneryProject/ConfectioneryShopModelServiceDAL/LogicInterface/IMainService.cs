using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IMainService {
        List<OrderViewModel> GetList();
        void CreateOrder(OrderBindingModel model);
        void TakeOrderInWork(OrderBindingModel model);
        void FinishOrder(OrderBindingModel model);
        void PayOrder(OrderBindingModel model);
    }
}