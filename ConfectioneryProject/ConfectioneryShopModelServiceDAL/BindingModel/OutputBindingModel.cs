using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    public class OutputBindingModel {
        public int ID { get; set; }
        public string OutputName { get; set; }
        public decimal Price { get; set; }
        public List<ConnectionBetweenDetailAndOutput> OutputDetail { get; set; }
    }
}
