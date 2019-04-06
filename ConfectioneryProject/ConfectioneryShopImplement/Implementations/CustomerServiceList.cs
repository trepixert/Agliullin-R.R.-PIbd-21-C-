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
    public class CustomerServiceList: ICustomerService {
        private DataListSingleton source;
        
        public CustomerServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<CustomerViewModel> getList() {
            List<CustomerViewModel> result = source.Customers.Select(rec => new CustomerViewModel {
                ID = rec.ID,
                CustomerFIO = rec.CustomerFIO
            })
 .ToList();
            return result;
        }

        public CustomerViewModel getElement(int id) {
            Customer element = source.Customers.FirstOrDefault(rec => rec.ID == id);
            if (element != null) {
                return new CustomerViewModel {
                    ID = element.ID,
                    CustomerFIO = element.CustomerFIO
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void addElem(CustomerBindingModel model) {
            Customer element = source.Customers.FirstOrDefault(rec => rec.CustomerFIO == model.CustomerFIO);
            if (element != null) {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Customers.Count > 0 ? source.Customers.Max(rec => rec.ID) : 0;
            source.Customers.Add(new Customer {
                ID = maxId + 1,
                CustomerFIO = model.CustomerFIO
            });
        }

        public void updElem(CustomerBindingModel model) {
            Customer element = source.Customers.FirstOrDefault(rec => rec.CustomerFIO == model.CustomerFIO && 
            rec.ID != model.ID);
            if (element != null) {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = source.Customers.FirstOrDefault(rec => rec.ID == model.ID);
            if (element == null) {
                throw new Exception("Элемент не найден");
            }
            element.CustomerFIO = model.CustomerFIO;
        }

        public void delElem(int id) {
            Customer element = source.Customers.FirstOrDefault(rec => rec.ID == id);
            if (element != null) {
                source.Customers.Remove(element);
            } else{
                throw new Exception("Элемент не найден");
            }
        }
    }
}
