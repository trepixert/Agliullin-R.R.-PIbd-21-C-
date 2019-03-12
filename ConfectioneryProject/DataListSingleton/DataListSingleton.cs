using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryProject

namespace DataListSingleton{
    public class DataListSingleton{
        private static DataListSingleton instance;
        public List<Client> Clients { get; set; }
    }
}
