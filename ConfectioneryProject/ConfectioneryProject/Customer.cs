using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfectioneryShopModel {
    public class Customer {
        public int ID { get; set; }
        [Required] public string CustomerFIO { get; set; }

        public string Mail { get; set; }

        [ForeignKey("CustomerID")] public virtual List<Order> Orders { get; set; }

        [ForeignKey("CustomerId")] public virtual List<MessageInfo> MessageInfos { get; set; }
    }
}