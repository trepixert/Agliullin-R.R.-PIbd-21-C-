using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class ConnectionBetweenDetailAndOutputViewModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public int OutputID { get; set; }
        [DataMember] public int DetailID { get; set; }
        [DataMember] public string DetailName { get; set; }
        [DataMember] public int Count { get; set; }
    }
}