using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class OutputViewModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public string OutputName { get; set; }
        [DataMember] public decimal Price { get; set; }
        [DataMember] public List<ConnectionBetweenDetailAndOutputViewModel> OutputDetail { get; set; }
    }
}