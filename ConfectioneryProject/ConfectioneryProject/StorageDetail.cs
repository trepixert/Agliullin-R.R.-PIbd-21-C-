using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ConfectioneryProject;

namespace ConfectioneryShopModel {
    public class StorageDetail {
        public int ID { get; set; }
        [Required]
        public int StorageID { get; set; }
        [Required]
        public int DetailID { get; set; }
        public int Count { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Detail Detail { get; set; }
    }
}
