using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]
    public class ConnectionBetweenDetailAndOutput {
        [DataMember] public int ID { get; set; }
        [DataMember] public int OutputID { get; set; }
        [DataMember] public int DetailID { get; set; }
        [DataMember] public int Count { get; set; }
    }
}