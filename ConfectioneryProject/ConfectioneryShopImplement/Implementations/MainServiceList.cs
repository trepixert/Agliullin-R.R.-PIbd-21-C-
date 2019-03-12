using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryProject;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopImplement.Implementations {
    public class MainServiceList : IMainService {
        private DataListSingleton source;
        public MainServiceList() {
            source = DataListSingleton.getInstance();
        }
        public List<OrderViewModel> getList() {
            List<OrderViewModel> result = new List<OrderViewModel>();
            for (int i = 0; i < source.Orders.Count; ++i) {
                string clientFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j) {
                    if (source.Customers[j].ID == source.Orders[i].CustomerID) {
                        clientFIO = source.Customers[j].CustomerFIO;
                        break;
                    }
                }
                string productName = string.Empty;
                for (int j = 0; j < source.Outputs.Count; ++j) {
                    if (source.Outputs[j].ID == source.Orders[i].OutputID) {
                        productName = source.Outputs[j].OutputName;
                        break;
                    }
                }
                result.Add(new OrderViewModel {
                    ID = source.Orders[i].ID,
                    CustomerID = source.Orders[i].CustomerID,
                    CustomerFIO = clientFIO,
                    OutputID = source.Orders[i].OutputID,
                    OutputName = productName,
                    Count = source.Orders[i].Count,
                    Sum = source.Orders[i].Sum,
                    DateCreate = source.Orders[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Orders[i].DateImplement?.ToLongDateString(),
                    Status = source.Orders[i].Status.ToString()
                });
            }
            return result;
        }

        public void createOrder(OrderBindingModel model) {
            int maxId = 0;
            for (int i = 0; i < source.Orders.Count; ++i) {
                if (source.Orders[i].ID > maxId) {
                    maxId = source.Customers[i].ID;
                }
            }
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
        public void takeOrderInWork(OrderBindingModel model) {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i) {
                if (source.Orders[i].ID == model.ID) {
                    index = i;
                    break;
                }
            }
            if (index == -1) {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Принят) {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Orders[index].DateImplement = DateTime.Now;
            source.Orders[index].Status = OrderStatus.Выполняется;
        }
        public void finishOrder(OrderBindingModel model) {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i) {
                if (source.Customers[i].ID == model.ID) {
                    index = i;
                    break;
                }
            }
            if (index == -1) {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Выполняется) {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.Orders[index].Status = OrderStatus.Готов;
        }
        public void payOrder(OrderBindingModel model) {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i) {
                if (source.Customers[i].ID == model.ID) {
                    index = i;
                    break;
                }
            }
            if (index == -1) {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Готов) {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.Orders[index].Status = OrderStatus.Оплачен;
        }

    }
}
