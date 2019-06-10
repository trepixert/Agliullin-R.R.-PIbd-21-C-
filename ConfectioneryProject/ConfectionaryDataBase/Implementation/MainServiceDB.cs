using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using ConfectioneryShopModel;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

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
                    CustomerFIO = rec.Customer.CustomerFIO,
                    OutputName = rec.output.OutputName
                })
                .ToList();
            return result;
        }

        public void CreateOrder(OrderBindingModel model) {
            var order = new Order {
                CustomerID = model.CustomerID,
                OutputID = model.OutputID,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            };
            context.Orders.Add(order);
            context.SaveChanges();
            var customer = context.Customers.FirstOrDefault(x => x.ID == model.CustomerID);
            SendEmail(customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} создан успешно",
            order.ID, order.DateCreate.ToShortDateString()));
        }

        public void TakeOrderInWork(OrderBindingModel model) {
            using ( var transaction = context.Database.BeginTransaction() ) {
                Order element = context.Orders.FirstOrDefault(rec => rec.ID == model.ID);
                try {
                    if ( element == null ) {
                        throw new Exception("Элемент не найден");
                    }

                    if ( element.Status != OrderStatus.Принят && element.Status !=
                         OrderStatus.НедостаточноРесурсов ) {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }

                    var outputDetails = context.DetailOutputs.Include(rec =>
                        rec.Details).Where(rec => rec.OutputID == element.OutputID).ToList();
                    // списываем
                    foreach ( var outputDetail in outputDetails ) {
                        int countOnStorages = outputDetail.Count * element.Count;
                        var storageDetails = context.StorageDetails.Where(rec =>
                            rec.DetailID == outputDetail.DetailID).ToList();
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
                    SendEmail(element.Customer.Mail, "Оповещение по заказам",
                    string.Format("Заказ №{0} от {1} передеан в работу", element.ID,
                    element.DateCreate.ToShortDateString()));
                    transaction.Commit();
                }
                catch ( Exception ex ) {
                    Console.WriteLine(ex.StackTrace);
                    transaction.Rollback();
                    element.Status = OrderStatus.НедостаточноРесурсов;
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
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format(
            "Заказ №{0} от {1} передан на оплату",
            element.ID, element.DateCreate.ToShortDateString()));
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
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format(
            "Заказ № {0} от {1} оплачен успешно",
            element.ID, element.DateCreate.ToShortDateString()));
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


        public List<OrderViewModel> GetFreeOrders() {
            List<OrderViewModel> result = context.Orders
                .Where(x => x.Status == OrderStatus.Принят || x.Status ==
                            OrderStatus.НедостаточноРесурсов)
                .Select(rec => new OrderViewModel {
                    ID = rec.ID
                })
                .ToList();
            return result;
        }

        private void SendEmail(string mailAddress, string subject, string text) {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;
            try {
                objMailMessage.From = new
                    MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = Encoding.UTF8;
                objMailMessage.BodyEncoding = Encoding.UTF8;
                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new
                    NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                    ConfigurationManager.AppSettings["MailPassword"]);
                objSmtpClient.Send(objMailMessage);
            }
            catch ( Exception ex ) {
                throw ex;
            }
            finally {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }
    }
}