using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.Attributies;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    [CustomInterface("Интерфейс для работы с деталями")]
    public interface IDetailService {
        
        [CustomMethod("Метод получения списка деталей")]
        List<DetailViewModel> GetList();
        
        [CustomMethod("Метод получения деталя по id")]
        DetailViewModel GetElement(int id);
        
        [CustomMethod("Метод добавления детали")]
        void AddElem(DetailBindingModel model);
        
        [CustomMethod("Метод изменения детали")]
        void UpdElem(DetailBindingModel model);
        
        [CustomMethod("Метод удаления детали")]
        void DelElem(int id);
    }
}