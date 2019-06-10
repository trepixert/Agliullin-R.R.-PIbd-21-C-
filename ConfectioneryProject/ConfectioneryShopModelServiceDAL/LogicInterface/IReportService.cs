using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IReportService {
        void SaveOutputPrice(ReportBindingModel model);
        List<StorageLoadViewModel> GetStorageLoad();
        void SaveStorageLoad(ReportBindingModel model);
        List<CustomerOrdersModel> GetCustomerOrders(ReportBindingModel model);
        void SaveCustomerOrders(ReportBindingModel model);
    }
}