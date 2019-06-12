using System;
using System.Collections.Generic;
using ConfectioneryProject;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopImplement.Implementations {
    public class DetailServiceList : IDetailService {
        private DataListSingleton source;

        public DetailServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<DetailViewModel> GetList() {
            List<DetailViewModel> result = new List<DetailViewModel>();
            for ( int i = 0; i < source.Details.Count; ++i ) {
                result.Add(new DetailViewModel {
                    ID = source.Details[i].ID,
                    DetailName = source.Details[i].DetailName
                });
            }

            return result;
        }

        public DetailViewModel GetElement(int id) {
            for ( int i = 0; i < source.Details.Count; ++i ) {
                if ( source.Details[i].ID == id )
                    return new DetailViewModel {
                        ID = source.Details[i].ID,
                        DetailName = source.Details[i].DetailName
                    };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElem(DetailBindingModel model) {
            int maxID = 0;
            for ( int i = 0; i < source.Details.Count; ++i ) {
                if ( source.Details[i].ID > maxID )
                    maxID = source.Details[i].ID;
                if ( source.Details[i].DetailName.Equals(model.DetailName) )
                    throw new Exception("Уже есть такой компонент");
            }

            source.Details.Add(new Detail {
                ID = maxID + 1,
                DetailName = model.DetailName
            });
        }

        public void UpdElem(DetailBindingModel model) {
            int index = -1;
            for ( int i = 0; i < source.Details.Count; ++i ) {
                if ( source.Details[i].ID == model.ID )
                    index = i;
                if ( source.Details[i].DetailName.Equals(model.DetailName) &&
                     source.Details[i].ID != model.ID )
                    throw new Exception("Уже есть такой компонент");
            }

            if ( index == -1 )
                throw new Exception("Элемент не найден");
            source.Details[index].DetailName = model.DetailName;
        }

        public void DelElem(int id) {
            for ( int i = 0; i < source.Customers.Count; ++i ) {
                if ( source.Details[i].ID == id ) {
                    source.Details.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }
    }
}