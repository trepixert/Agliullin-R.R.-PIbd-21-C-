using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using ConfectioneryShopImplement.Implementations;
using ConfectionaryDataBase;
using ConfectionaryDataBase.Implementation;
using System.Data.Entity;

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
            currentContainer.RegisterType<DbContext, ConfDBContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDetailService, DetailServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOutputService, OutputServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageService,StorageServiceDB>(new 
           HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}