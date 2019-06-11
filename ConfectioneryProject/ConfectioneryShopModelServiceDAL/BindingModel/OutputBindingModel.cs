using System.Collections.Generic;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    public class OutputBindingModel {
        public int ID { get; set; }
        public string OutputName { get; set; }
        public decimal Price { get; set; }
        public List<ConnectionBetweenDetailAndOutput> OutputDetail { get; set; }
    }
}