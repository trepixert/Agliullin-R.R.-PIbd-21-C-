namespace ConfectioneryShopModelServiceDAL.ViewModel {
    public class OrderViewModel {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerFIO { get; set; }
        public int OutputID { get; set; }
        public string OutputName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
        public string DateCreate { get; set; }
        public string DateImplement { get; set; }
    }
}