using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryProject {
    public class Order {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int DetailID { get; set; }
        public int OutputID { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Output output { get; set; }
    }
}
