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
    public class ClientServiceList: IClientService {
        private DataListSingleton source;
        
        public ClientServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<ClientViewModel> getList() {
            List<ClientViewModel> result = new List<ClientViewModel>();
            for(int i = 0; i < source.Clients.Count; ++i) {
                result.Add(new ClientViewModel {
                    ID = source.Clients[i].ID,
                    ClientFIO = source.Clients[i].ClientFIO
                });
            }
            return result;
        }

        public ClientViewModel getElement(int id) {
            for(int i = 0; i < source.Clients.Count; ++i) {
                if (source.Clients[i].ID == id)
                    return new ClientViewModel {
                        ID = source.Clients[i].ID,
                        ClientFIO = source.Clients[i].ClientFIO
                    };
            }
            throw new Exception("Элемент не найден");
        }

        public void addElem(ClientBindingModel model) {
            int maxID = 0;
            for(int i = 0; i < source.Clients.Count; ++i) {
                if (source.Clients[i].ID > maxID)
                    maxID = source.Clients[i].ID;
                if (source.Clients[i].ClientFIO.Equals(model.ClientFIO))
                    throw new Exception("Уже есть клиент с таким ФИО");
            }
            source.Clients.Add(new Client {
                ID = maxID + 1,
                ClientFIO = model.ClientFIO
            });
        }

        public void updElem(ClientBindingModel model) {
            int index = -1;
            for(int i = 0; i < source.Clients.Count; ++i) {
                if (source.Clients[i].ID == model.ID)
                    index = i;
                if (source.Clients[i].ClientFIO.Equals(model.ClientFIO) &&
                    source.Clients[i].ID != model.ID)
                    throw new Exception("Уже есть клиент с таким ФИО");
            }
            if (index == -1)
                throw new Exception("Элемент не найден");
            source.Clients[index].ClientFIO = model.ClientFIO;
        }

        public void delElem(int id) {
            for(int i = 0; i < source.Clients.Count; ++i) {
                if (source.Clients[i].ID == id) {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
