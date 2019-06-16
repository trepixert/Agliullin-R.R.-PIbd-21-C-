using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]
    public class OutputBindingModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public string OutputName { get; set; }
        [DataMember] public decimal Price { get; set; }
        [DataMember] public List<ConnectionBetweenDetailAndOutput> OutputDetail { get; set; }
    }
}