using System.Data.Entity;
using System.Data.Entity.SqlServer;
using ConfectioneryProject;
using ConfectioneryShopModel;

namespace ConfectionaryDataBase {
    public class ConfDBContext : DbContext {
        public ConfDBContext() : base("ConfDBContext") {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
                SqlProviderServices.Instance;
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Output> Outputs { get; set; }
        public virtual DbSet<ConnectionBetweenDetailAndOutput> DetailOutputs { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<StorageDetail> StorageDetails { get; set; }
        public virtual DbSet<Implementer> Implementers { get; set; }
        public virtual DbSet<MessageInfo> MessageInfos { get; set; }
    }
}