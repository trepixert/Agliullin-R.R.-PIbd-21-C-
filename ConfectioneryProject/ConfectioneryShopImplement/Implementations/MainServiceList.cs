using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryProject;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModel;

namespace ConfectioneryShopImplement.Implementations {
    public class MainServiceList : IMainService {
        private DataListSingleton source;
        public MainServiceList() {
            source = DataListSingleton.getInstance();
        }
        public List<OrderViewModel> GetList() {
            List<OrderViewModel> result = source.Orders
            .Select(rec => new OrderViewModel {
                ID = rec.ID,
                CustomerID = rec.CustomerID,
                OutputID = rec.OutputID,
                DateCreate = rec.DateCreate.ToLongDateString(),
                DateImplement = rec.DateImplement?.ToLongDateString(),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = source.Customers.FirstOrDefault(recC => recC.ID ==
                rec.CustomerID)?.CustomerFIO,
                OutputName = source.Outputs.FirstOrDefault(recP => recP.ID ==
                rec.OutputID)?.OutputName,
            })
            .ToList();
            return result;
        }

        public void CreateOrder(OrderBindingModel model) {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.ID) : 0;
            source.Orders.Add(new Order {
                ID = maxId + 1,
                CustomerID = model.CustomerID,
                OutputID = model.OutputID,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });

        }
        public void TakeOrderInWork(OrderBindingModel model) {
            Order element = source.Orders.FirstOrDefault(rec => rec.ID == model.ID);
            if (element == null) {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Принят) {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            var outputDetails = source.DetailOutputs.Where(rec => rec.OutputID 
            == element.OutputID);
             foreach (var outputDetail in outputDetails) {
                int countOnStorage = source.StorageDetails
                .Where(rec => rec.DetailID ==
               outputDetail.DetailID)
               .Sum(rec => rec.Count);
                if (countOnStorage < outputDetail.Count * element.Count) {
                    var detailName = source.Details.FirstOrDefault(rec => rec.ID ==
                   outputDetail.DetailID);
                    throw new Exception("Не достаточно компонента " +
                   detailName?.DetailName + " требуется " + (outputDetail.Count * element.Count) +
                   ", в наличии " + countOnStorage);
                }
            }
            // списываем
            foreach (var outputDetail in outputDetails) {
                int countOnStorages = outputDetail.Count * element.Count;
                var storageDetails = source.StorageDetails.Where(rec => rec.DetailID
               == outputDetail.DetailID);
                foreach (var storageDetail in storageDetails) {
                    // компонентов на одном слкаде может не хватать
                    if (storageDetail.Count >= countOnStorages) {
                        storageDetail.Count -= countOnStorages;
                        break;
                    } else {
                        countOnStorages -= storageDetail.Count;
                        storageDetail.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Выполняется;

        }
        public void FinishOrder(OrderBindingModel model) {
            Order element = source.Orders.FirstOrDefault(rec => rec.ID == model.ID);
            if (element == null) {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется) {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
        }
        public void PayOrder(OrderBindingModel model) {
            Order element = source.Orders.FirstOrDefault(rec => rec.ID == model.ID);
            if (element == null) {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов) {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
        }

        public void PutDetailOnStorage(StorageDetailBindingModel model) {
            StorageDetail element = source.StorageDetails.FirstOrDefault(rec =>
           rec.StorageID == model.StorageID && rec.DetailID == model.DetailID);
            if (element != null) {
                element.Count += model.Count;
            } else {
                int maxId = source.StorageDetails.Count > 0 ?
               source.StorageDetails.Max(rec => rec.ID) : 0;
                source.StorageDetails.Add(new StorageDetail {
                    ID = ++maxId,
                    StorageID = model.StorageID,
                    DetailID = model.DetailID,
                    Count = model.Count
                });
            }
        }

    }
}
