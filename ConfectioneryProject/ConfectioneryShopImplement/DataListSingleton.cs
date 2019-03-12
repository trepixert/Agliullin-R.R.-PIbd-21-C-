using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryProject;

namespace ConfectioneryShopImplement {
    class DataListSingleton {
        private static DataListSingleton instance;
        public List<Client> Clients { get; set; }
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<ConnectionBetweenComponentAndProduct> ProductComponents { get; set; }

        private DataListSingleton(){
            Clients = new List<Client>();
            Components = new List<Component>();
            Orders = new List<Order>();
            Products = new List<Product>();
            ProductComponents = new List<ConnectionBetweenComponentAndProduct>();
        }

        public static DataListSingleton getInstance() {
            if (instance == null)
                instance = new DataListSingleton();
            return instance;
        }
    }
}
