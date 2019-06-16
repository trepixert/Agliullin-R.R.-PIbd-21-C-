using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.Attributies;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    [CustomInterface("Интерфейс главного окна для работы с заказами")]
    public interface IMainService {
        [CustomMethod("Метод получения списка заказов")]
        List<OrderViewModel> GetList();
        
        [CustomMethod("Метод для создания заказа")]
        void CreateOrder(OrderBindingModel model);
        
        [CustomMethod("Метод для запуска заказа")]
        void TakeOrderInWork(OrderBindingModel model);
        
        [CustomMethod("Метод для заканчивания заказа")]
        void FinishOrder(OrderBindingModel model);
        
        [CustomMethod("Метод для оплаты заказа")]
        void PayOrder(OrderBindingModel model);
        
        [CustomMethod("Метод для помещения детали в склад")]
        void PutDetailOnStorage(StorageDetailBindingModel model);

        [CustomMethod("Метод для получения списка свободных заказов")]
        List<OrderViewModel> GetFreeOrders();
    }
}