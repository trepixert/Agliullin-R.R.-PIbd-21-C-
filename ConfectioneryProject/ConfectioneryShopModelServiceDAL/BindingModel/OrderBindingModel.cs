﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    public class OrderBindingModel {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
