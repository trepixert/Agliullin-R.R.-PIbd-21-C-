using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]
    public class OrderBindingModel {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public int OutputID { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}
