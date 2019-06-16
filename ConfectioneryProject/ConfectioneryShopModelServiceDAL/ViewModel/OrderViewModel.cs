﻿using System.ComponentModel;
using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    [DataContract]
    public class OrderViewModel {
        [DataMember] public int ID { get; set; }
        [DataMember] public int CustomerID { get; set; }
        [DataMember] public string CustomerFIO { get; set; }
        [DataMember] public int OutputID { get; set; }
        [DataMember] public string OutputName { get; set; }
        [DataMember] public int Count { get; set; }
        [DataMember] public decimal Sum { get; set; }
        [DataMember] public string Status { get; set; }
        [DataMember] public string DateCreate { get; set; }
        [DataMember] public string DateImplement { get; set; }

        [DataMember] public int? ImplementerId { get; set; }

        [DataMember]
        [DisplayName("Имя исполнителя")]
        public string ImplementerName { get; set; }
    }
}