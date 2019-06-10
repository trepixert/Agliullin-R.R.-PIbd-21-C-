using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]
    public class StorageBindingModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public string StorageName { get; set; }
    }
}