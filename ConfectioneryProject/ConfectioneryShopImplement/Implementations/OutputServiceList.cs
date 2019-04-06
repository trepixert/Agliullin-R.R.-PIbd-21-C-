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
    public class OutputServiceList : IOutputService {

        private DataListSingleton source;

        public OutputServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<OutputViewModel> getList() {
            List<OutputViewModel> result = new List<OutputViewModel>();
            for (int i = 0; i < source.Outputs.Count; ++i) {
                List<ConnectionBetweenDetailAndOutputViewModel> productComponents = new List<ConnectionBetweenDetailAndOutputViewModel>();
                for (int j = 0; j < source.DetailOutputs.Count; ++j) {
                    if (source.DetailOutputs[j].OutputID == source.Outputs[i].ID) {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Details.Count; ++k) {
                            if (source.DetailOutputs[j].DetailID ==
                                source.Details[k].ID) {
                                componentName = source.Details[k].DetailName;
                                break;
                            }
                        }
                        productComponents.Add(new ConnectionBetweenDetailAndOutputViewModel {
                            ID = source.DetailOutputs[j].ID,
                            OutputID = source.DetailOutputs[j].OutputID,
                            DetailID = source.DetailOutputs[j].DetailID,
                            DetailName = componentName,
                            Count = source.DetailOutputs[j].Count
                        });
                    }
                }
                result.Add(new OutputViewModel {
                    ID = source.Outputs[i].ID,
                    OutputName = source.Outputs[i].OutputName,
                    Price = source.Outputs[i].Price,
                    OutputDetail = productComponents
                });
            }
            return result;
        }

        public OutputViewModel getElement(int id) {
            for (int i = 0; i < source.Outputs.Count; ++i) {
                List<ConnectionBetweenDetailAndOutputViewModel> productComponents =
                    new List<ConnectionBetweenDetailAndOutputViewModel>();
                for (int j = 0; j < source.DetailOutputs.Count; ++j) {
                    if (source.DetailOutputs[j].OutputID == source.Outputs[i].ID) {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Details.Count; ++k) {
                            if (source.DetailOutputs[i].DetailID == source.Details[k].ID) {
                                componentName = source.Details[k].DetailName;
                                break;
                            }
                        }
                        productComponents.Add(new ConnectionBetweenDetailAndOutputViewModel {
                            ID = source.DetailOutputs[j].ID,
                            OutputID = source.DetailOutputs[j].OutputID,
                            DetailID = source.DetailOutputs[j].DetailID,
                            DetailName = componentName,
                            Count = source.DetailOutputs[j].Count
                        });
                    }
                }
                if (source.Outputs[i].ID == id) {
                    return new OutputViewModel {
                        ID = source.Outputs[i].ID,
                        OutputName = source.Outputs[i].OutputName,
                        Price = source.Outputs[i].Price,
                        OutputDetail = productComponents
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void addElem(OutputBindingModel model) {
            int maxId = 0;
            for (int i = 0; i < source.Outputs.Count; ++i) {
                if (source.Outputs[i].ID > maxId) {
                    maxId = source.Outputs[i].ID;
                }
                if (source.Outputs[i].OutputName == model.OutputName) {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Outputs.Add(new Output {
                ID = maxId + 1,
                OutputName = model.OutputName,
                Price = model.Price
            });
            int maxPCId = 0;
            for (int i = 0; i < source.DetailOutputs.Count; ++i) {
                if (source.DetailOutputs[i].ID > maxPCId) {
                    maxPCId = source.DetailOutputs[i].ID;
                }
            }
            for (int i = 0; i < model.OutputDetail.Count; ++i) {
                for (int j = 1; j < model.OutputDetail.Count; ++j) {
                    if (model.OutputDetail[i].DetailID ==
                    model.OutputDetail[j].DetailID) {
                        model.OutputDetail[i].Count +=
                        model.OutputDetail[j].Count;
                        model.OutputDetail.RemoveAt(j--);
                    }
                }
            }
            for (int i = 0; i < model.OutputDetail.Count; ++i) {
                source.DetailOutputs.Add(new ConfectioneryProject.ConnectionBetweenDetailAndOutput {
                    ID = ++maxPCId,
                    OutputID = maxId + 1,
                    DetailID = model.OutputDetail[i].DetailID,
                    Count = model.OutputDetail[i].Count
                });
            }
        }

        public void updElem(OutputBindingModel model) {
            int index = -1;
            for (int i = 0; i < source.Outputs.Count; ++i) {
                if (source.Outputs[i].ID == model.ID) {
                    index = i;
                }
                if (source.Outputs[i].OutputName == model.OutputName &&
                    source.Outputs[i].ID != model.ID) {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1) {
                throw new Exception("Элемент не найден");
            }
            source.Outputs[index].OutputName = model.OutputName;
            source.Outputs[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.DetailOutputs.Count; ++i) {
                if (source.DetailOutputs[i].ID > maxPCId) {
                    maxPCId = source.DetailOutputs[i].ID;
                }
            }
            for (int i = 0; i < source.DetailOutputs.Count; ++i) {
                if (source.DetailOutputs[i].OutputID == model.ID) {
                    bool flag = true;
                    for (int j = 0; j < model.OutputDetail.Count; ++j) {
                        if (source.DetailOutputs[i].ID ==
                       model.OutputDetail[j].ID) {
                            source.DetailOutputs[i].Count =
                           model.OutputDetail[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    if (flag) {
                        source.DetailOutputs.RemoveAt(i--);
                    }
                }
            }
            for (int i = 0; i < model.OutputDetail.Count; ++i) {
                if (model.OutputDetail[i].ID == 0) {
                    for (int j = 0; j < source.DetailOutputs.Count; ++j) {
                        if (source.DetailOutputs[j].OutputID == model.ID &&
                        source.DetailOutputs[j].DetailID ==
                       model.OutputDetail[i].DetailID) {
                            source.DetailOutputs[j].Count +=
                           model.OutputDetail[i].Count;
                            model.OutputDetail[i].ID =
                           source.DetailOutputs[j].ID;
                            break;
                        }
                    }
                }
                if (model.OutputDetail[i].ID == 0) {
                    source.DetailOutputs.Add(new ConfectioneryProject.ConnectionBetweenDetailAndOutput {
                        ID = ++maxPCId,
                        OutputID = model.ID,
                        DetailID = model.OutputDetail[i].DetailID,
                        Count = model.OutputDetail[i].Count
                    });
                }
            }
        }

        public void delElem(int id) {
            for (int i = 0; i < source.DetailOutputs.Count; ++i)
                if (source.DetailOutputs[i].OutputID == id)
                    source.DetailOutputs.RemoveAt(i--);
            for(int i=0;i<source.Outputs.Count;++i)
                if(source.Outputs[i].ID == id) {
                    source.Outputs.RemoveAt(i);
                    return;
                }
            throw new Exception("Элемент не найден");
        }
    }
}
