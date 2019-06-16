using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModel;
using ConfectioneryProject;

namespace ConfectionaryDataBase.Implementation {
    public class StorageServiceDB : IStorageService {
        private ConfDBContext context;
        public StorageServiceDB(ConfDBContext context) {
            this.context = context;
        }
        public List<StorageViewModel> GetList() {
            List<StorageViewModel> result = context.Storages.Select(rec => new
           StorageViewModel {
                ID = rec.ID,
                StorageName = rec.StorageName
            })
            .ToList();
            return result;
        }
        public StorageViewModel GetElement(int id) {
            Storage element = context.Storages.FirstOrDefault(rec => rec.ID == id);
            if (element != null) {
                return new StorageViewModel {
                    ID = element.ID,
                    StorageName = element.StorageName,
                    StorageDetails = context.StorageDetails.Where(recPC => recPC.StorageID == element.ID).Select(recPC => new StorageDetailViewModel {
                        ID = recPC.ID,
                        StorageID = recPC.StorageID,
                        DetailID = recPC.DetailID,
                        DetailName = recPC.Detail.DetailName,
                        Count = recPC.Count
                    }).ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElem(StorageBindingModel model) {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName ==
           model.StorageName);
            if (element != null) {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Storages.Add(new Storage {
                StorageName = model.StorageName
            });
            context.SaveChanges();
        }

        public void UpdElem(StorageBindingModel model) {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName ==
           model.StorageName && rec.ID != model.ID);
            if (element != null) {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Storages.FirstOrDefault(rec => rec.ID == model.ID);
            if (element == null) {
                throw new Exception("Элемент не найден");
            }
            element.StorageName = model.StorageName;
            context.SaveChanges();
        }
        public void DelElem(int id) {
            Storage element = context.Storages.FirstOrDefault(rec => rec.ID == id);
            if (element != null) {
                context.Storages.Remove(element);
                context.SaveChanges();
            } else {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
