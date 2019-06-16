using System;
using System.Collections.Generic;
using System.Linq;
using ConfectioneryShopModel;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopImplement.Implementations {
    public class DetailServiceList : IDetailService {
        private DataListSingleton source;

        public DetailServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<DetailViewModel> getList() {
            List<DetailViewModel> result = source.Details.Select(rec => new DetailViewModel {
                ID = rec.ID,
                DetailName = rec.DetailName
            }).ToList();
            return result;
        }

        public DetailViewModel getElement(int id) {
            Detail element = source.Details.FirstOrDefault(rec => rec.ID == id);
            if ( element != null ) {
                return new DetailViewModel {
                    ID = element.ID,
                    DetailName = element.DetailName
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void addElem(DetailBindingModel model) {
            Detail element = source.Details.FirstOrDefault(rec => rec.DetailName == model.DetailName);
            if ( element != null ) {
                throw new Exception("Уже есть компонент с таким названием");
            }

            int maxId = source.Details.Count > 0
                ? source.Details.Max(rec =>
                    rec.ID)
                : 0;
            source.Details.Add(new Detail {
                ID = maxId + 1,
                DetailName = model.DetailName
            });
        }

        public void updElem(DetailBindingModel model) {
            Detail element = source.Details.FirstOrDefault(rec => rec.DetailName ==
                                                                  model.DetailName && rec.ID != model.ID);
            if ( element != null ) {
                throw new Exception("Уже есть компонент с таким названием");
            }

            element = source.Details.FirstOrDefault(rec => rec.ID == model.ID);
            if ( element == null ) {
                throw new Exception("Элемент не найден");
            }

            element.DetailName = model.DetailName;
        }

        public void delElem(int id) {
            Detail element = source.Details.FirstOrDefault(rec => rec.ID == id);
            if ( element != null ) {
                source.Details.Remove(element);
            }
            else {
                throw new Exception("Элемент не найден");
            }
        }
    }
}