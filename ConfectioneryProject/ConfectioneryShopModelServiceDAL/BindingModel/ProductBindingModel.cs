﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    public class ProductBindingModel {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public List<ConnectionBetweenComponentAndProduct> ProductComponent { get; set; }
    }
}
