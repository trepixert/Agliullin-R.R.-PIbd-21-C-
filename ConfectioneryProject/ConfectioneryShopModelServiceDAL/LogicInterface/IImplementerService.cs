using System.Collections.Generic;
using ConfectioneryShopModelServiceDAL.Attributies;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    [CustomInterface("Интерфейс для работы с сотрудниками")]
    public interface IImplementerService {
        [CustomMethod("Метод получения списка сотрудников")]
        List<ImplementerViewModel> GetList();

        [CustomMethod("Метод получения сотрудника по id")]
        ImplementerViewModel GetElement(int id);

        [CustomMethod("Метод добавления сотрудника")]
        void AddElement(ImplementerBindingModel model);

        [CustomMethod("Метод изменения сотрудника")]
        void UpdElement(ImplementerBindingModel model);

        [CustomMethod("Метод удаления сотрудника")]
        void DelElement(int id);

        [CustomMethod("Метод получения свободного сотрудника")]
        ImplementerViewModel GetFreeWorker();
    }
}