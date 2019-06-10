using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.Attributies;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    [CustomInterface("Интерфейс для работы с продуктами")]
    public interface IOutputService {
        [CustomMethod("Метод получения списка продуктов")]
        List<OutputViewModel> GetList();
        
        [CustomMethod("Метод получения продукта по id")]
        OutputViewModel GetElement(int id);
        
        [CustomMethod("Метод добавления продукта")]
        void AddElem(OutputBindingModel model);
        
        [CustomMethod("Метод изменения продукта")]
        void UpdElem(OutputBindingModel model);
        
        [CustomMethod("Метод удаления продукта")]
        void DelElem(int id);
    }
}