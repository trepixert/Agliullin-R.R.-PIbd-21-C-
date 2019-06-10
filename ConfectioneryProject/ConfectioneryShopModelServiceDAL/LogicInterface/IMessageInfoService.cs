using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.Attributies;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    [CustomInterface("Интерфейс для работы с сообщениями")]
    public interface IMessageInfoService {
        [CustomMethod("Метод получения списка сообщений")]
        List<MessageInfoViewModel> GetList();
        
        [CustomMethod("Метод получения сообщения по id")]
        MessageInfoViewModel GetElement(int id);
        
        [CustomMethod("Метод добавления сообщения")]
        void AddElement(MessageInfoBindingModel model);
    }
}