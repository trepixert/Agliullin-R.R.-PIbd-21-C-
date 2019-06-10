using System;
using System.Collections.Generic;
using System.Linq;
using ConfectioneryShopModel;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectionaryDataBase.Implementation {
    public class CustomerServiceDB : ICustomerService {
        private ConfDBContext context;

        public CustomerServiceDB(ConfDBContext context) {
            this.context = context;
        }

        public List<CustomerViewModel> GetList() {
            List<CustomerViewModel> result = context.Customers.Select(rec => new
                    CustomerViewModel {
                        ID = rec.ID,
                        CustomerFIO = rec.CustomerFIO,
                        Mail = rec.Mail
                    })
                .ToList();
            return result;
        }

        public CustomerViewModel GetElement(int id) {
            Customer element = context.Customers.FirstOrDefault(rec => rec.ID == id);
            if ( element != null ) {
                return new CustomerViewModel {
                    ID = element.ID,
                    CustomerFIO = element.CustomerFIO,
                    Mail = element.Mail,
                    Messages = context.MessageInfos
                        .Where(recM => recM.CustomerId == element.ID)
                        .Select(recM => new MessageInfoViewModel {
                            MessageId = recM.MessageId,
                            DateDelivery = recM.DateDelivery,
                            Subject = recM.Subject,
                            Body = recM.Body
                        })
                        .ToList()
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElem(CustomerBindingModel model) {
            Customer element = context.Customers.FirstOrDefault(rec => rec.CustomerFIO ==
                                                                       model.CustomerFIO);
            if ( element != null ) {
                throw new Exception("Уже есть клиент с таким ФИО");
            }

            context.Customers.Add(new Customer {
                CustomerFIO = model.CustomerFIO,
                Mail = model.Mail
            });
            context.SaveChanges();
        }

        public void UpdElem(CustomerBindingModel model) {
            Customer element = context.Customers.FirstOrDefault(rec => rec.CustomerFIO ==
                                                                       model.CustomerFIO && rec.ID != model.ID);
            if ( element != null ) {
                throw new Exception("Уже есть клиент с таким ФИО");
            }

            element = context.Customers.FirstOrDefault(rec => rec.ID == model.ID);
            if ( element == null ) {
                throw new Exception("Элемент не найден");
            }

            element.CustomerFIO = model.CustomerFIO;
            element.Mail = model.Mail;
            context.SaveChanges();
        }

        public void DelElem(int id) {
            Customer element = context.Customers.FirstOrDefault(rec => rec.ID == id);
            if ( element != null ) {
                context.Customers.Remove(element);
                context.SaveChanges();
            }
            else {
                throw new Exception("Элемент не найден");
            }
        }
    }
}