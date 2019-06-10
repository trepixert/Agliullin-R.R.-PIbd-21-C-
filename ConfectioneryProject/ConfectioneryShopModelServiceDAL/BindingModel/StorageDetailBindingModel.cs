using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]
    public class StorageDetailBindingModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public int StorageID { get; set; }
        [DataMember] public int DetailID { get; set; }
        [DataMember] public int Count { get; set; }
    }
}