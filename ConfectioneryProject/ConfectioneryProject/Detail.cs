using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConfectioneryShopModel;

namespace ConfectioneryProject{
    public class Detail{
        public int ID { get; set; }
        [Required]
        public string DetailName { get; set; }
        [ForeignKey("DetailID")]
        public virtual List<StorageDetail> StorageDetails { get; set; }
        [ForeignKey("DetailID")]
        public virtual List<ConnectionBetweenDetailAndOutput> DetailOutput { get; set; }
    }
}
