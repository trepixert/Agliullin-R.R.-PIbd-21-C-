using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    public class OutputViewModel {
        public int ID { get; set; }
        public string OutputName { get; set; }
        public decimal Price { get; set; }
        public List<ConnectionBetweenDetailAndOutputViewModel> OutputDetail { get; set; }
    }
}
