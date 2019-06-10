using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]
    public class DetailBindingModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public string DetailName { get; set; }
    }
}