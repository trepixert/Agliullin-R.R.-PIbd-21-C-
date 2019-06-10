using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfectioneryShopModel {
    public class Storage {
        public int ID { get; set; }
        [Required] public string StorageName { get; set; }

        [ForeignKey("StorageID")] public virtual List<StorageDetail> StorageDetails { get; set; }
    }
}