using System;
using System.Collections.Generic;
using System.Linq;
using ConfectioneryShopModel;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopModelServiceDAL.ViewModel;
using ConnectionBetweenDetailAndOutput = ConfectioneryProject.ConnectionBetweenDetailAndOutput;

namespace ConfectionaryDataBase.Implementation {
    public class OutputServiceDB : IOutputService {
        private ConfDBContext context;

        public OutputServiceDB(ConfDBContext context) {
            this.context = context;
        }

        public List<OutputViewModel> GetList() {
            List<OutputViewModel> result = context.Outputs.Select(rec => new
                    OutputViewModel {
                        ID = rec.ID,
                        OutputName = rec.OutputName,
                        Price = rec.Price,
                        OutputDetail = context.DetailOutputs
                            .Where(recPC => recPC.OutputID == rec.ID)
                            .Select(recPC => new ConnectionBetweenDetailAndOutputViewModel {
                                ID = recPC.ID,
                                OutputID = recPC.OutputID,
                                DetailID = recPC.DetailID,
                                DetailName = recPC.Details.DetailName,
                                Count = recPC.Count
                            })
                            .ToList()
                    })
                .ToList();
            return result;
        }

        public OutputViewModel GetElement(int id) {
            Output element = context.Outputs.FirstOrDefault(rec => rec.ID == id);
            if ( element != null ) {
                return new OutputViewModel {
                    ID = element.ID,
                    OutputName = element.OutputName,
                    Price = element.Price,
                    OutputDetail = context.DetailOutputs
                        .Where(recPC => recPC.OutputID == element.ID)
                        .Select(recPC => new ConnectionBetweenDetailAndOutputViewModel {
                            ID = recPC.ID,
                            OutputID = recPC.OutputID,
                            DetailID = recPC.DetailID,
                            DetailName = recPC.Details.DetailName,
                            Count = recPC.Count
                        })
                        .ToList()
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElem(OutputBindingModel model) {
            using ( var transaction = context.Database.BeginTransaction() ) {
                try {
                    Output element = context.Outputs.FirstOrDefault(rec =>
                        rec.OutputName == model.OutputName);
                    if ( element != null ) {
                        throw new Exception("Уже есть изделие с таким названием");
                    }

                    element = new Output {
                        OutputName = model.OutputName,
                        Price = model.Price
                    };
                    context.Outputs.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupComponents = model.OutputDetail
                        .GroupBy(rec => rec.DetailID)
                        .Select(rec => new {
                            DetailID = rec.Key,
                            Count = rec.Sum(r => r.Count)
                        });
                    // добавляем компоненты
                    foreach ( var groupComponent in groupComponents ) {
                        context.DetailOutputs.Add(new ConnectionBetweenDetailAndOutput {
                            OutputID = element.ID,
                            DetailID = groupComponent.DetailID,
                            Count = groupComponent.Count
                        });
                        context.SaveChanges();
                    }

                    transaction.Commit();
                }
                catch ( Exception ) {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElem(OutputBindingModel model) {
            using ( var transaction = context.Database.BeginTransaction() ) {
                try {
                    Output element = context.Outputs.FirstOrDefault(rec =>
                        rec.OutputName == model.OutputName && rec.ID != model.ID);
                    if ( element != null ) {
                        throw new Exception("Уже есть изделие с таким названием");
                    }

                    element = context.Outputs.FirstOrDefault(rec => rec.ID == model.ID);
                    if ( element == null ) {
                        throw new Exception("Элемент не найден");
                    }

                    element.OutputName = model.OutputName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.OutputDetail.Select(rec =>
                        rec.DetailID).Distinct();
                    var updateDetails = context.DetailOutputs.Where(rec =>
                        rec.OutputID == model.ID && compIds.Contains(rec.DetailID));
                    foreach ( var updateDetail in updateDetails ) {
                        updateDetail.Count =
                            model.OutputDetail.FirstOrDefault(rec => rec.ID == updateDetail.ID).Count;
                    }

                    context.SaveChanges();
                    context.DetailOutputs.RemoveRange(context.DetailOutputs.Where(rec =>
                        rec.OutputID == model.ID && !compIds.Contains(rec.OutputID)));
                    context.SaveChanges();
                    // новые записи
                    var groupDetails = model.OutputDetail
                        .Where(rec => rec.ID == 0)
                        .GroupBy(rec => rec.DetailID)
                        .Select(rec => new {
                            DetailID = rec.Key,
                            Count = rec.Sum(r => r.Count)
                        });
                    foreach ( var groupDetail in groupDetails ) {
                        ConnectionBetweenDetailAndOutput elementPC =
                            context.DetailOutputs.FirstOrDefault(rec => rec.OutputID == model.ID &&
                                                                        rec.DetailID == groupDetail.DetailID);
                        if ( elementPC != null ) {
                            elementPC.Count += groupDetail.Count;
                            context.SaveChanges();
                        }
                        else {
                            context.DetailOutputs.Add(new ConnectionBetweenDetailAndOutput {
                                OutputID = model.ID,
                                DetailID = groupDetail.DetailID,
                                Count = groupDetail.Count
                            });
                            context.SaveChanges();
                        }
                    }

                    transaction.Commit();
                }
                catch ( Exception ) {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElem(int id) {
            using ( var transaction = context.Database.BeginTransaction() ) {
                try {
                    Output element = context.Outputs.FirstOrDefault(rec => rec.ID ==
                                                                           id);
                    if ( element != null ) {
                        // удаяем записи по компонентам при удалении изделия
                        context.DetailOutputs.RemoveRange(context.DetailOutputs.Where(rec =>
                            rec.OutputID == id));
                        context.Outputs.Remove(element);
                        context.SaveChanges();
                    }
                    else {
                        throw new Exception("Элемент не найден");
                    }

                    transaction.Commit();
                }
                catch ( Exception ) {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}