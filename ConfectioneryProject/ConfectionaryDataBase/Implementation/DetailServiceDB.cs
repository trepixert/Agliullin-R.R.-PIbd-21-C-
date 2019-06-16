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
    public class DetailServiceDB : IDetailService {
        private ConfDBContext context;
        public DetailServiceDB(ConfDBContext context) {
            this.context = context;
        }
        public List<DetailViewModel> GetList() {
            List<DetailViewModel> result = context.Details.Select(rec => new
           DetailViewModel {
                ID = rec.ID,
                DetailName = rec.DetailName
            })
            .ToList();
            return result;
        }
        public DetailViewModel GetElement(int id) {
            Detail element = context.Details.FirstOrDefault(rec => rec.ID == id);
            if (element != null) {
                return new DetailViewModel {
                    ID = element.ID,
                    DetailName = element.DetailName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElem(DetailBindingModel model) {
            Detail element = context.Details.FirstOrDefault(rec => rec.DetailName ==
           model.DetailName);
            if (element != null) {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Details.Add(new Detail {
                DetailName = model.DetailName
            });
            context.SaveChanges();
        }

        public void UpdElem(DetailBindingModel model) {
            Detail element = context.Details.FirstOrDefault(rec => rec.DetailName ==
           model.DetailName && rec.ID != model.ID);
            if (element != null) {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Details.FirstOrDefault(rec => rec.ID == model.ID);
            if (element == null) {
                throw new Exception("Элемент не найден");
            }
            element.DetailName = model.DetailName;
            context.SaveChanges();
        }
        public void DelElem(int id) {
            Detail element = context.Details.FirstOrDefault(rec => rec.ID == id);
            if (element != null) {
                context.Details.Remove(element);
                context.SaveChanges();
            } else {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
