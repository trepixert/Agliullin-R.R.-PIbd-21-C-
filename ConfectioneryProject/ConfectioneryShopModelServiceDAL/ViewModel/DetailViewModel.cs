﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class DetailViewModel {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string DetailName { get; set; }
    }
}
