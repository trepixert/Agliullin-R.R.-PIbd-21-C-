using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.Attributies;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    [CustomInterface("Интерфейс для работы со складом")]
    public interface IStorageService {
        [CustomMethod("Метод получения списка складов")]
        List<StorageViewModel> GetList();
        
        [CustomMethod("Метод получения склада по id")]
        StorageViewModel GetElement(int id);
        
        [CustomMethod("Метод добавления склада")]
        void AddElem(StorageBindingModel model);
        
        [CustomMethod("Метод изменения склада")]
        void UpdElem(StorageBindingModel model);
        
        [CustomMethod("Метод удаления склада")]
        void DelElem(int id);
    }
}