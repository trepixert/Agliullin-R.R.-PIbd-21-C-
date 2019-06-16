using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.Attributies;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface ICustomerService {
        
        [CustomMethod("Метод получения списка клиентов")]
        List<CustomerViewModel> GetList();
        
        [CustomMethod("Метод получения клиента по id")]
        CustomerViewModel GetElement(int id);
        
        [CustomMethod("Метод добавления клиента")]
        void AddElem(CustomerBindingModel model);
        
        [CustomMethod("Метод изменения данных по клиенту")]
        void UpdElem(CustomerBindingModel model);
        
        [CustomMethod("Метод удаления клиента")]
        void DelElem(int id);
    }
}