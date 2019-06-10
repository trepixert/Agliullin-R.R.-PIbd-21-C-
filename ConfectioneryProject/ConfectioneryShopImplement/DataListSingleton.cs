using System.Collections.Generic;
using ConfectioneryProject;

namespace ConfectioneryShopImplement {
    class DataListSingleton {
        private static DataListSingleton instance;
        public List<Customer> Customers { get; set; }
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Output> Outputs { get; set; }
        public List<ConnectionBetweenDetailAndOutput> DetailOutputs { get; set; }

        private DataListSingleton() {
            Customers = new List<Customer>();
            Details = new List<Detail>();
            Orders = new List<Order>();
            Outputs = new List<Output>();
            DetailOutputs = new List<ConnectionBetweenDetailAndOutput>();
        }

        public static DataListSingleton getInstance() {
            if ( instance == null )
                instance = new DataListSingleton();
            return instance;
        }
    }
}