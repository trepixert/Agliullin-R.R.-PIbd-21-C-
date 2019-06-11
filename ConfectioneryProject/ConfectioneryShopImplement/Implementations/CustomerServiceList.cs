using System;
using System.Collections.Generic;
using ConfectioneryProject;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopImplement.Implementations {
    public class CustomerServiceList : ICustomerService {
        private DataListSingleton source;

        public CustomerServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<CustomerViewModel> GetList() {
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            for ( int i = 0; i < source.Customers.Count; ++i ) {
                result.Add(new CustomerViewModel {
                    ID = source.Customers[i].ID,
                    CustomerFIO = source.Customers[i].CustomerFIO
                });
            }

            return result;
        }

        public CustomerViewModel GetElement(int id) {
            for ( int i = 0; i < source.Customers.Count; ++i ) {
                if ( source.Customers[i].ID == id )
                    return new CustomerViewModel {
                        ID = source.Customers[i].ID,
                        CustomerFIO = source.Customers[i].CustomerFIO
                    };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElem(CustomerBindingModel model) {
            int maxID = 0;
            for ( int i = 0; i < source.Customers.Count; ++i ) {
                if ( source.Customers[i].ID > maxID )
                    maxID = source.Customers[i].ID;
                if ( source.Customers[i].CustomerFIO.Equals(model.CustomerFIO) )
                    throw new Exception("Уже есть клиент с таким ФИО");
            }

            source.Customers.Add(new Customer {
                ID = maxID + 1,
                CustomerFIO = model.CustomerFIO
            });
        }

        public void UpdElem(CustomerBindingModel model) {
            int index = -1;
            for ( int i = 0; i < source.Customers.Count; ++i ) {
                if ( source.Customers[i].ID == model.ID )
                    index = i;
                if ( source.Customers[i].CustomerFIO.Equals(model.CustomerFIO) &&
                     source.Customers[i].ID != model.ID )
                    throw new Exception("Уже есть клиент с таким ФИО");
            }

            if ( index == -1 )
                throw new Exception("Элемент не найден");
            source.Customers[index].CustomerFIO = model.CustomerFIO;
        }

        public void DelElem(int id) {
            for ( int i = 0; i < source.Customers.Count; ++i ) {
                if ( source.Customers[i].ID == id ) {
                    source.Customers.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }
    }
}