using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]
    public class CustomerBindingModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public string CustomerFIO { get; set; }
        [DataMember] public string Mail { get; set; }
    }
}