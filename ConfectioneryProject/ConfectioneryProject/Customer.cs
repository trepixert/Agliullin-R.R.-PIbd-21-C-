using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfectioneryProject {
    public class Customer {
        public int ID { get; set; }
        [Required]
        public string CustomerFIO { get; set; }

        [ForeignKey("CustomerID")]
        public virtual List<Order> Orders { get; set; }

    }
}
