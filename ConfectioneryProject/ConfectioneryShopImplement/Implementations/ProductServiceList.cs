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
    public class ProductServiceList {

        private DataListSingleton source;

        public ProductServiceList() {
            source = DataListSingleton.getInstance();
        }

        public List<ProductViewModel> getList() {
            List<ProductViewModel> result = new List<ProductViewModel>();
            for (int i = 0; i < source.Products.Count; ++i) {
                List<ConnectionBetweenComponentAndProductViewModel> productComponents = new List<ConnectionBetweenComponentAndProductViewModel>();
                for (int j = 0; j < source.ProductComponents.Count; ++j) {
                    if (source.ProductComponents[j].ProductID == source.Products[i].ID) {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k) {
                            if (source.ProductComponents[j].ComponentID ==
                                source.Components[k].ID) {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }
                        productComponents.Add(new ConnectionBetweenComponentAndProductViewModel {
                            ID = source.ProductComponents[j].ID,
                            ProductID = source.ProductComponents[j].ProductID,
                            ComponentID = source.ProductComponents[j].ComponentID,
                            ComponentName = componentName,
                            Count = source.ProductComponents[j].Count
                        });
                    }
                }
                result.Add(new ProductViewModel {
                    ID = source.Products[i].ID,
                    ProductName = source.Products[i].ProductName,
                    Price = source.Products[i].Price,
                    ProductComponent = productComponents
                });
            }
            return result;
        }

        public ProductViewModel getElement(int id) {
            for (int i = 0; i < source.Products.Count; ++i) {
                List<ConnectionBetweenComponentAndProductViewModel> productComponents =
                    new List<ConnectionBetweenComponentAndProductViewModel>();
                for (int j = 0; j < source.ProductComponents.Count; ++j) {
                    if (source.ProductComponents[j].ProductID == source.Products[i].ID) {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k) {
                            if (source.ProductComponents[i].ComponentID == source.Components[k].ID) {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }
                        productComponents.Add(new ConnectionBetweenComponentAndProductViewModel {
                            ID = source.ProductComponents[j].ID,
                            ProductID = source.ProductComponents[j].ProductID,
                            ComponentID = source.ProductComponents[j].ComponentID,
                            ComponentName = componentName,
                            Count = source.ProductComponents[j].Count
                        });
                    }
                }
                if (source.Products[i].ID == id) {
                    return new ProductViewModel {
                        ID = source.Products[i].ID,
                        ProductName = source.Products[i].ProductName,
                        Price = source.Products[i].Price,
                        ProductComponent = productComponents
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void addElem(ProductBindingModel model) {
            int maxId = 0;
            for (int i = 0; i < source.Products.Count; ++i) {
                if (source.Products[i].ID > maxId) {
                    maxId = source.Products[i].ID;
                }
                if (source.Products[i].ProductName == model.ProductName) {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Products.Add(new Product {
                ID = maxId + 1,
                ProductName = model.ProductName,
                Price = model.Price
            });
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i) {
                if (source.ProductComponents[i].ID > maxPCId) {
                    maxPCId = source.ProductComponents[i].ID;
                }
            }
            for (int i = 0; i < model.ProductComponent.Count; ++i) {
                for (int j = 1; j < model.ProductComponent.Count; ++j) {
                    if (model.ProductComponent[i].ComponentID ==
                    model.ProductComponent[j].ComponentID) {
                        model.ProductComponent[i].Count +=
                        model.ProductComponent[j].Count;
                        model.ProductComponent.RemoveAt(j--);
                    }
                }
            }
            for (int i = 0; i < model.ProductComponent.Count; ++i) {
                source.ProductComponents.Add(new ConfectioneryProject.ConnectionBetweenComponentAndProduct {
                    ID = ++maxPCId,
                    ProductID = maxId + 1,
                    ComponentID = model.ProductComponent[i].ComponentID,
                    Count = model.ProductComponent[i].Count
                });
            }
        }

        public void updElem(ProductBindingModel model) {
            int index = -1;
            for (int i = 0; i < source.Products.Count; ++i) {
                if (source.Products[i].ID == model.ID) {
                    index = i;
                }
                if (source.Products[i].ProductName == model.ProductName &&
                    source.Products[i].ID != model.ID) {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1) {
                throw new Exception("Элемент не найден");
            }
            source.Products[index].ProductName = model.ProductName;
            source.Products[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i) {
                if (source.ProductComponents[i].ID > maxPCId) {
                    maxPCId = source.ProductComponents[i].ID;
                }
            }
            for (int i = 0; i < source.ProductComponents.Count; ++i) {
                if (source.ProductComponents[i].ProductID == model.ID) {
                    bool flag = true;
                    for (int j = 0; j < model.ProductComponent.Count; ++j) {
                        if (source.ProductComponents[i].ID ==
                       model.ProductComponent[j].ID) {
                            source.ProductComponents[i].Count =
                           model.ProductComponent[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    if (flag) {
                        source.ProductComponents.RemoveAt(i--);
                    }
                }
            }
            for (int i = 0; i < model.ProductComponent.Count; ++i) {
                if (model.ProductComponent[i].ID == 0) {
                    for (int j = 0; j < source.ProductComponents.Count; ++j) {
                        if (source.ProductComponents[j].ProductID == model.ID &&
                        source.ProductComponents[j].ComponentID ==
                       model.ProductComponent[i].ComponentID) {
                            source.ProductComponents[j].Count +=
                           model.ProductComponent[i].Count;
                            model.ProductComponent[i].ID =
                           source.ProductComponents[j].ID;
                            break;
                        }
                    }
                }
                if (model.ProductComponent[i].ID == 0) {
                    source.ProductComponents.Add(new ConfectioneryProject.ConnectionBetweenComponentAndProduct {
                        ID = ++maxPCId,
                        ProductID = model.ID,
                        ComponentID = model.ProductComponent[i].ComponentID,
                        Count = model.ProductComponent[i].Count
                    });
                }
            }
        }

        public void delElem(int id) {
            for (int i = 0; i < source.ProductComponents.Count; ++i)
                if (source.ProductComponents[i].ProductID == id)
                    source.ProductComponents.RemoveAt(i--);
            for(int i=0;i<source.Products.Count;++i)
                if(source.Products[i].ID == id) {
                    source.Products.RemoveAt(i);
                    return;
                }
            throw new Exception("Элемент не найден");
        }
    }
}
