using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.Attributies;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    [CustomInterface("Интерфейс для работы с отчётами")]
    public interface IReportService {
        [CustomMethod("Метод сохранения цены продукта")]
        void SaveOutputPrice(ReportBindingModel model);
        
        [CustomMethod("Метод получения списка загруженности склада")]
        List<StorageLoadViewModel> GetStorageLoad();
        
        [CustomMethod("Метод сохранения загруженности склада")]
        void SaveStorageLoad(ReportBindingModel model);
        
        [CustomMethod("Метод получения заказов клиента")]
        List<CustomerOrdersModel> GetCustomerOrders(ReportBindingModel model);
        
        [CustomMethod("Метод сохранения заказов клиента")]
        void SaveCustomerOrders(ReportBindingModel model);
    }
}