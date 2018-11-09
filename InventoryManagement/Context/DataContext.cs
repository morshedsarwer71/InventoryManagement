using InventoryManagement.Areas.Accounting.Models;
using InventoryManagement.Areas.Global.Models;
using InventoryManagement.Areas.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManagement.Context
{
    public class DataContext: DbContext
    {
        public DataContext():base("InventoryDBContext") { }
        //Accounting Context class
        public DbSet<AccountsHead> AccountsHeads { get; set; }
        public DbSet<ReportHead> ReportHeads { get; set; }
        public DbSet<Journal> Journals { get; set; }

        //Inventory Models class
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseDuePayment> PurchaseDuePayments { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseReturnInvoice> PurchaseReturnInvoices { get; set; }
        public DbSet<SalesDuePayment> SalesDuePayments { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesReturnInvoice> SalesReturnInvoices { get; set; }
        public DbSet<SessionInvoice> SessionInvoices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Unit> Units { get; set; }

        //Global Context class
        public DbSet<Concern> Concerns { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }

    }
}