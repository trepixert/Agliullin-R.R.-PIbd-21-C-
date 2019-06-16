using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class StorageViewModel {
        [DataMember] public int ID { get; set; }

        [DataMember]
        [DisplayName("Название склада")]
        public string StorageName { get; set; }

        [DataMember] public List<StorageDetailViewModel> StorageDetails { get; set; }
    }
}