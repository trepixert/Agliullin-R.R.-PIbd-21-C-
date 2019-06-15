using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    public interface IReportService {
        void SaveOutputPrice(ReportBindingModel model);
        List<StorageLoadViewModel> GetStorageLoad();
        void SaveStorageLoad(ReportBindingModel model);
        List<CustomerOrdersModel> GetCustomerOrders(ReportBindingModel model);
        void SaveCustomerOrders(ReportBindingModel model);
    }
}
