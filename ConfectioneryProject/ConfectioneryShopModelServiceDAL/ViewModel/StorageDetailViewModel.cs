using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    public class StorageDetailViewModel {
        public int ID { get; set; }
        public int StorageID { get; set; }
        public int DetailID { get; set; }

        [DisplayName("Название компонента")]
        public string DetailName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
