using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class StorageLoadViewModel {
        [DataMember] public string StorageName { get; set; }
        [DataMember] public int TotalCount { get; set; }
        [DataMember] public IEnumerable<Tuple<string, int>> Components { get; set; }
    }
}