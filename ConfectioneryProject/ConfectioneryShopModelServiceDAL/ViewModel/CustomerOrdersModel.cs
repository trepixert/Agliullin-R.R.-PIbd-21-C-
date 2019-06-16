using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class CustomerOrdersModel {
        [DataMember] public string CustomerName { get; set; }
        [DataMember] public string DateCreate { get; set; }
        [DataMember] public string OutputName { get; set; }
        [DataMember] public int Count { get; set; }
        [DataMember] public decimal Sum { get; set; }
        [DataMember] public string Status { get; set; }
    }
}