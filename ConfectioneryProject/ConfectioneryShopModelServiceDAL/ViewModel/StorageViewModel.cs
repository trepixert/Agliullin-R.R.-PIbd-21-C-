using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    public class StorageViewModel {
        public int ID { get; set; }

        [DisplayName("Название склада")]
        public string StorageName { get; set; }

        public List<StorageDetailViewModel> StorageDetails { get; set; }
    }
}
