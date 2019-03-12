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
    public class ComponentServiceList : IComponentService {
        private DataListSingleton source;

        public ComponentServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<ComponentViewModel> getList() {
            List<ComponentViewModel> result = new List<ComponentViewModel>();
            for (int i = 0; i < source.Components.Count; ++i) {
                result.Add(new ComponentViewModel {
                    ID = source.Components[i].ID,
                    ComponentName = source.Components[i].ComponentName
                });
            }
            return result;
        }

        public ComponentViewModel getElement(int id) {
            for (int i = 0; i < source.Components.Count; ++i) {
                if (source.Components[i].ID == id)
                    return new ComponentViewModel {
                        ID = source.Components[i].ID,
                        ComponentName = source.Components[i].ComponentName
                    };
            }
            throw new Exception("Элемент не найден");
        }

        public void addElem(ComponentBindingModel model) {
            int maxID = 0;
            for (int i = 0; i < source.Components.Count; ++i) {
                if (source.Components[i].ID > maxID)
                    maxID = source.Components[i].ID;
                if (source.Components[i].ComponentName.Equals(model.ComponentName))
                    throw new Exception("Уже есть такой компонент");
            }
            source.Components.Add(new Component {
                ID = maxID + 1,
                ComponentName= model.ComponentName
            });
        }

        public void updElem(ComponentBindingModel model) {
            int index = -1;
            for (int i = 0; i < source.Components.Count; ++i) {
                if (source.Components[i].ID == model.ID)
                    index = i;
                if (source.Components[i].ComponentName.Equals(model.ComponentName) &&
                    source.Components[i].ID != model.ID)
                    throw new Exception("Уже есть такой компонент");
            }
            if (index == -1)
                throw new Exception("Элемент не найден");
            source.Components[index].ComponentName = model.ComponentName;
        }

        public void delElem(int id) {
            for (int i = 0; i < source.Clients.Count; ++i) {
                if (source.Components[i].ID == id) {
                    source.Components.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
