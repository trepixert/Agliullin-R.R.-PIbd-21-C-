using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConfectioneryProject;
using ConfectioneryShopModel;

namespace ConfectioneryDBContext {
    public class ConfDBContext : DbContext {

        ConfDBContext() { }

        //ConfDBContext() : base("ConfectioneryDataBase") {
        //    Configuration.ProxyCreationEnabled = false;
        //    Configuration.LazyLoadingEnabled = false;
        //    var ensureDLLIsCopied =
        //   System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        //}

        

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Output> Outputs { get; set; }
        public virtual DbSet<ConnectionBetweenDetailAndOutput> DetailOutputs { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<StorageDetail> StorageDetails { get; set; }
    }
}
