using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]
    public class CustomerBindingModel {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
    }
}
