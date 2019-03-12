﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.ViewModel;

namespace ConfectioneryShopModelServiceDAL.LogicInterface {
    interface ILogic {
        List<CustomerViewModel> GetList { get; set; }
        CustomerViewModel getElement(int id);
        void addElement(CustomerBindingModel model);
        void updElement(CustomerBindingModel model);
        void delElement(int id);
    }
}
