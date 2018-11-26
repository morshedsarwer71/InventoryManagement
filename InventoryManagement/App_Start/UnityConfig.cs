using InventoryManagement.Areas.Global.Interfaces;
using InventoryManagement.Areas.Global.Services;
using InventoryManagement.Areas.Inventory.Interfaces;
using InventoryManagement.Areas.Inventory.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace InventoryManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IBuyer, BuyerService>();
            container.RegisterType<IInventorySetting, InventorySettingService>();
            container.RegisterType<ISession,SessionService>();
            container.RegisterType<ISalesInvoice,SalesInvoiceService>();
            container.RegisterType<IPurchaseInvoice,PurchaseInvoiceService>();
            container.RegisterType<IPurchaseReturn,PurchaseReturnService>();
            container.RegisterType<ISalesReturn, SalesReturnService>();
            container.RegisterType<IDuePayment, DuePaymentService>();
            container.RegisterType<ISystemUser, SystemUserService>();
            container.RegisterType<IReport, ReportService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}