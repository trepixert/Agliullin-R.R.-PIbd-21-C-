using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryProject;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using ConfectioneryShopModel;

namespace ConfectionaryDataBase.Implementation {
    public class MainServiceDB : IMainService {
        private ConfDBContext context;

        public MainServiceDB(ConfDBContext context) {
            this.context = context;
        }

        public List<OrderViewModel> GetList() {
            List<OrderViewModel> result = context.Orders.Select(rec => new OrderViewModel {
                    ID = rec.ID,
                    CustomerID = rec.CustomerID,
                    OutputID = rec.OutputID,
                    DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                                 SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                                 SqlFunctions.DateName("yyyy", rec.DateCreate),
                    DateImplement = rec.DateImplement == null
                        ? ""
                        : SqlFunctions.DateName("dd",
                          rec.DateImplement.Value) + " " +
                          SqlFunctions.DateName("mm",
                          rec.DateImplement.Value) + " " +
                          SqlFunctions.DateName("yyyy",
                          rec.DateImplement.Value),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    CustomerFIO = rec.customer.CustomerFIO,
                    OutputName = rec.output.OutputName
                })
                .ToList();
            return result;
        }

        public void CreateOrder(OrderBindingModel model) {
            context.Orders.Add(new Order {
                CustomerID = model.CustomerID,
                OutputID = model.OutputID,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
            context.SaveChanges();
        }

        public void TakeOrderInWork(OrderBindingModel model) {
            using ( var transaction = context.Database.BeginTransaction() ) {
                try {
                    Order element = context.Orders.FirstOrDefault(rec => rec.ID ==
                                                                         model.ID);
                    if ( element == null ) {
                        throw new Exception("Элемент не найден");
                    }

                    if ( element.Status != OrderStatus.Принят ) {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }

                    var outputDetails = context.DetailOutputs.Include(rec =>
                        rec.Details).Where(rec => rec.OutputID == element.OutputID);
                    // списываем
                    foreach ( var outputDetail in outputDetails ) {
                        int countOnStorages = outputDetail.Count * element.Count;
                        var storageDetails = context.StorageDetails.Where(rec =>
                            rec.DetailID == outputDetail.DetailID);
                        foreach ( var stockComponent in storageDetails ) {
                            // компонентов на одном слкаде может не хватать
                            if ( stockComponent.Count >= countOnStorages ) {
                                stockComponent.Count -= countOnStorages;
                                countOnStorages = 0;
                                context.SaveChanges();
                                break;
                            }
                            else {
                                countOnStorages -= stockComponent.Count;
                                stockComponent.Count = 0;
                                context.SaveChanges();
                            }
                        }

                        if ( countOnStorages > 0 ) {
                            throw new Exception("Не достаточно компонента " +
                                                outputDetail.Details.DetailName + " требуется " + outputDetail.Count +
                                                ", не хватает " + countOnStorages);
                        }
                    }

                    element.DateImplement = DateTime.Now;
                    element.Status = OrderStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch ( Exception ) {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void FinishOrder(OrderBindingModel model) {
            Order element = context.Orders.FirstOrDefault(rec => rec.ID == model.ID);
            if ( element == null ) {
                throw new Exception("Элемент не найден");
            }

            if ( element.Status != OrderStatus.Выполняется ) {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }

            element.Status = OrderStatus.Готов;
            context.SaveChanges();
        }

        public void PayOrder(OrderBindingModel model) {
            Order element = context.Orders.FirstOrDefault(rec => rec.ID == model.ID);
            if ( element == null ) {
                throw new Exception("Элемент не найден");
            }

            if ( element.Status != OrderStatus.Готов ) {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }

            element.Status = OrderStatus.Оплачен;
            context.SaveChanges();
        }

        public void PutDetailOnStorage(StorageDetailBindingModel model) {
            StorageDetail element = context.StorageDetails.FirstOrDefault(rec =>
                rec.StorageID == model.StorageID && rec.DetailID == model.DetailID);
            if ( element != null ) {
                element.Count += model.Count;
            }
            else {
                context.StorageDetails.Add(new StorageDetail {
                    StorageID = model.StorageID,
                    DetailID = model.DetailID,
                    Count = model.Count
                });
            }

            context.SaveChanges();
        }
    }
}