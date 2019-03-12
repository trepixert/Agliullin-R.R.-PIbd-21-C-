using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    public class ConnectionBetweenComponentAndProductViewModel {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int ComponentID { get; set; }
        public string ComponentName { get; set; }
        public int Count { get; set; }
    }
}
