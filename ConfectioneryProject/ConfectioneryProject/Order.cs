using System;

namespace ConfectioneryShopModel {
    public class Order {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int DetailID { get; set; }
        public int OutputID { get; set; }
        public int? ImplementerID { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Output output { get; set; }
        public virtual Implementer Implementer { get; set; }
    }
}