using ConfectioneryShopModel;

namespace ConfectioneryProject {
    public class ConnectionBetweenDetailAndOutput {
        public int ID { get; set; }
        public int OutputID { get; set; }
        public int DetailID { get; set; }
        public int Count { get; set; }
        public virtual Detail Details { get; set; }
        public virtual Output Outputs { get; set; }
    }
}