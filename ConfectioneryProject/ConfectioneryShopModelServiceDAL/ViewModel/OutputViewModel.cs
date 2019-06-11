using System.Collections.Generic;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    public class OutputViewModel {
        public int ID { get; set; }
        public string OutputName { get; set; }
        public decimal Price { get; set; }
        public List<ConnectionBetweenDetailAndOutputViewModel> OutputDetail { get; set; }
    }
}