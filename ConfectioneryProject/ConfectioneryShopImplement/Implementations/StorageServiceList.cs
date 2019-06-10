using System;
using System.Collections.Generic;
using System.Linq;
using ConfectioneryShopModel;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopImplement.Implementations {
    public class StorageServiceList : IStorageService {
        private DataListSingleton source;

        public StorageServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<StorageViewModel> GetList() {
            List<StorageViewModel> result = source.Storages
                .Select(rec => new StorageViewModel {
                    ID = rec.ID,
                    StorageName = rec.StorageName,
                    StorageDetails = source.StorageDetails
                        .Where(recPC => recPC.StorageID == rec.ID)
                        .Select(recPC => new StorageDetailViewModel {
                            ID = recPC.ID,
                            StorageID = recPC.StorageID,
                            DetailID = recPC.DetailID,
                            DetailName = source.Details
                                .FirstOrDefault(recC => recC.ID ==
                                                        recPC.DetailID)?.DetailName,
                            Count = recPC.Count
                        })
                        .ToList()
                })
                .ToList();
            return result;
        }

        public StorageViewModel GetElement(int id) {
            Storage element = source.Storages.FirstOrDefault(rec => rec.ID == id);
            if ( element != null ) {
                return new StorageViewModel {
                    ID = element.ID,
                    StorageName = element.StorageName,
                    StorageDetails = source.StorageDetails
                        .Where(recPC => recPC.StorageID == element.ID)
                        .Select(recPC => new StorageDetailViewModel {
                            ID = recPC.ID,
                            StorageID = recPC.StorageID,
                            DetailID = recPC.DetailID,
                            DetailName = source.Details
                                .FirstOrDefault(recC => recC.ID ==
                                                        recPC.DetailID)?.DetailName,
                            Count = recPC.Count
                        })
                        .ToList()
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElem(StorageBindingModel model) {
            Storage element = source.Storages.FirstOrDefault(rec => rec.StorageName ==
                                                                    model.StorageName);
            if ( element != null ) {
                throw new Exception("Уже есть склад с таким названием");
            }

            int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.ID) : 0;
            source.Storages.Add(new Storage {
                ID = maxId + 1,
                StorageName = model.StorageName
            });
        }

        public void UpdElem(StorageBindingModel model) {
            Storage element = source.Storages.FirstOrDefault(rec =>
                rec.StorageName == model.StorageName && rec.ID !=
                model.ID);
            if ( element != null ) {
                throw new Exception("Уже есть склад с таким названием");
            }

            element = source.Storages.FirstOrDefault(rec => rec.ID == model.ID);
            if ( element == null ) {
                throw new Exception("Элемент не найден");
            }

            element.StorageName = model.StorageName;
        }

        public void DelElem(int id) {
            Storage element = source.Storages.FirstOrDefault(rec => rec.ID == id);
            if ( element != null ) {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.StorageDetails.RemoveAll(rec => rec.StorageID == id);
                source.Storages.Remove(element);
            }
            else {
                throw new Exception("Элемент не найден");
            }
        }
    }
}