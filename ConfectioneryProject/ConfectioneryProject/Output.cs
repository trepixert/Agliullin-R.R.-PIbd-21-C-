using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfectioneryProject {
    public class Output {
        public int ID { get; set; }
        [Required]
        public string OutputName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("OutputID")]
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("OutputID")]
        public virtual List<ConnectionBetweenDetailAndOutput> DetailOutput { get; set; }
    }
}
