using ConfectioneryShopImplement.Implementations;
using ConfectioneryShopModelServiceDAL.LogicInterface;

namespace ConfWebView {
    public static class Globals {
        public static ICustomerService CustomerService { get; } = new CustomerServiceList();
        public static IDetailService DetailService { get; } = new DetailServiceList();
        public static IOutputService OutputService { get; } = new OutputServiceList();
        public static IMainService MainService { get; } = new MainServiceList();
    }
}