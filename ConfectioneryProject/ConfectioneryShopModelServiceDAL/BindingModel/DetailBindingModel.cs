using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]

    public class DetailBindingModel {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string DetailName { get; set; }
    }
}
