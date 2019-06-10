using System.ComponentModel.DataAnnotations;

namespace ConfectioneryShopModel {
    public class StorageDetail {
        public int ID { get; set; }
        [Required] public int StorageID { get; set; }
        [Required] public int DetailID { get; set; }
        public int Count { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Detail Detail { get; set; }
    }
}