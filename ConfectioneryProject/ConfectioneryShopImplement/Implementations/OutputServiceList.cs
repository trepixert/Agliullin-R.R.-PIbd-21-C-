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
    public class OutputServiceList : IOutputService{

        private DataListSingleton source;

        public OutputServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<OutputViewModel> getList() {
            List<OutputViewModel> result = source.Outputs
            .Select(rec => new OutputViewModel {
                ID = rec.ID,
                OutputName = rec.OutputName,
                Price = rec.Price,
                OutputDetail = source.DetailOutputs
                .Where(recPC => recPC.OutputID == rec.ID)
                .Select(recPC => new ConnectionBetweenDetailAndOutputViewModel {
                    ID = recPC.ID,
                    OutputID = recPC.OutputID,
                    DetailID = recPC.DetailID,
                    DetailName = source.Details.FirstOrDefault(recC =>
                    recC.ID == recPC.DetailID)?.DetailName,
                    Count = recPC.Count
                })
                .ToList()
            })
            .ToList();
            return result;
        }

        public OutputViewModel getElement(int id) {
            Output element = source.Outputs.FirstOrDefault(rec => rec.ID == id);
            if (element != null) {
                return new OutputViewModel {
                    ID = element.ID,
                    OutputName = element.OutputName,
                    Price = element.Price,
                    OutputDetail = source.DetailOutputs
                    .Where(recPC => recPC.OutputID == element.ID)
                    .Select(recPC => new ConnectionBetweenDetailAndOutputViewModel {
                    ID = recPC.ID,
                    OutputID = recPC.OutputID,
                    DetailID = recPC.DetailID,
                    DetailName = source.Details.FirstOrDefault(recC =>
     recC.ID == recPC.DetailID)?.DetailName,
                    Count = recPC.Count
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");

        }

        public void addElem(OutputBindingModel model) {
            Output element = source.Outputs.FirstOrDefault(rec => rec.OutputName == model.OutputName);
            if (element != null) {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Outputs.Count > 0 ? source.Outputs.Max(rec => rec.ID):0;
            source.Outputs.Add(new Output {
                ID = maxId + 1,
                OutputName = model.OutputName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.DetailOutputs.Count > 0 ?
           source.DetailOutputs.Max(rec => rec.ID) : 0;
            // убираем дубли по компонентам
            var groupComponents = model.OutputDetail
            .GroupBy(rec => rec.DetailID)
           .Select(rec => new {
               DetailID = rec.Key,
               Count = rec.Sum(r => r.Count)
           });
            // добавляем компоненты
            foreach (var groupComponent in groupComponents) {
                source.DetailOutputs.Add(new ConfectioneryProject.ConnectionBetweenDetailAndOutput {
                    ID = ++maxPCId,
                    OutputID = maxId + 1,
                    DetailID = groupComponent.DetailID,
                    Count = groupComponent.Count
                });
            }

        }

        public void updElem(OutputBindingModel model) {
            Output element = source.Outputs.FirstOrDefault(rec => rec.OutputName ==
            model.OutputName && rec.ID != model.ID);
            if (element != null) {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Outputs.FirstOrDefault(rec => rec.ID == model.ID);
            if (element == null) {
                throw new Exception("Элемент не найден");
            }
            element.OutputName = model.OutputName;
            element.Price = model.Price;
            int maxPCId = source.DetailOutputs.Count > 0 ?
           source.DetailOutputs.Max(rec => rec.ID) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.OutputDetail.Select(rec =>
           rec.DetailID).Distinct();
            var updateComponents = source.DetailOutputs.Where(rec => rec.OutputID ==
           model.ID && compIds.Contains(rec.DetailID));
            foreach (var updateComponent in updateComponents) {
                updateComponent.Count = model.OutputDetail.FirstOrDefault(rec =>
               rec.ID == updateComponent.ID).Count;
            }
            source.DetailOutputs.RemoveAll(rec => rec.OutputID == model.ID &&
           !compIds.Contains(rec.DetailID));
            // новые записи
            var groupComponents = model.OutputDetail
            .Where(rec => rec.ID == 0)
           .GroupBy(rec => rec.DetailID)
           .Select(rec => new {
               ComponentId = rec.Key,
               Count = rec.Sum(r => r.Count)
           });
            foreach (var groupComponent in groupComponents) {
                ConfectioneryProject.ConnectionBetweenDetailAndOutput elementPC = source.DetailOutputs.FirstOrDefault(rec
               => rec.OutputID == model.ID && rec.DetailID == groupComponent.ComponentId);
                if (elementPC != null) {
                    elementPC.Count += groupComponent.Count;
                } else {
                    source.DetailOutputs.Add(new ConfectioneryProject.ConnectionBetweenDetailAndOutput {
                        ID = ++maxPCId,
                        OutputID = model.ID,
                        DetailID = groupComponent.ComponentId,
                        Count = groupComponent.Count
                    });
                }

            }
        }

        public void delElem(int id) {
            Output element = source.Outputs.FirstOrDefault(rec => rec.ID == id);
            if (element != null) {
                // удаяем записи по компонентам при удалении изделия
                source.DetailOutputs.RemoveAll(rec => rec.OutputID == id);
                source.Outputs.Remove(element);
            } else {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
