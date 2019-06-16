using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class DetailViewModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public string DetailName { get; set; }
    }
}