using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfectioneryShopModel {
    public class Implementer {
        public int Id { get; set; }
        [Required] public string ImplementerFIO { get; set; }
        [ForeignKey("ImplementerID")] public virtual List<Order> Orders { get; set; }
    }
}