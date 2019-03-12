using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    public class ConnectionBetweenDetailAndOutputViewModel {
        public int ID { get; set; }
        public int OutputID { get; set; }
        public int DetailID { get; set; }
        public string DetailName { get; set; }
        public int Count { get; set; }
    }
}
