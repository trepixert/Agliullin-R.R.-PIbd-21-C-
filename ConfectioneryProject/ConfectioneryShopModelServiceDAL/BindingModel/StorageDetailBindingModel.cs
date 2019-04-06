using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    public class StorageDetailBindingModel {
        public int ID { get; set; }
        public int StorageID { get; set; }
        public int DetailID { get; set; }
        public int Count { get; set; }
    }
}
