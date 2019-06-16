using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class OutputViewModel {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string OutputName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<ConnectionBetweenDetailAndOutputViewModel> OutputDetail { get; set; }
    }
}
