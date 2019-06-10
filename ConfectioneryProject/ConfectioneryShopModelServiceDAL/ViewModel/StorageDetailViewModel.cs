using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class StorageDetailViewModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public int StorageID { get; set; }
        [DataMember] public int DetailID { get; set; }

        [DataMember]
        [DisplayName("Название компонента")]
        public string DetailName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}