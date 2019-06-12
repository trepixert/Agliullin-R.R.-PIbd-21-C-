using ConfectionaryDataBase;
using ConfectionaryDataBase.Implementation;
using ConfectioneryShopImplement.Implementations;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfectionaryWeb {
    public static class Globals {
        public static ConfDBContext Context { get; } = new ConfDBContext();
        public static ICustomerService CustomerService { get; } = new CustomerServiceDB(Context);
        public static IDetailService DetailService { get; } = new DetailServiceDB(Context);
        public static IOutputService OutputService { get; } = new OutputServiceDB(Context);
        public static IMainService MainService { get; } = new MainServiceDB(Context);
        public static IStorageService StorageService { get; } = new StorageServiceDB(Context);
    }
}