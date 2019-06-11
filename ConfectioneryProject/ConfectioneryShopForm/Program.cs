using System;
using System.Windows.Forms;
using ConfectioneryShopImplement.Implementations;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using Unity;
using Unity.Lifetime;

namespace ConfectioneryShopForm {
    static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<ConfectioneryShopForm>());
        }

        public static IUnityContainer BuildUnityContainer() {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICustomerService, CustomerServiceList>(new
                HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDetailService, DetailServiceList>(new
                HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOutputService, OutputServiceList>(new
                HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new
                HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}