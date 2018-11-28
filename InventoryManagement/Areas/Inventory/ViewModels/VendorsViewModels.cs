using InventoryManagement.Areas.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ViewModels
{
    public class VendorsViewModels
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<Buyer> Buyers { get; set; }
        public IEnumerable<Unit> Units { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ExpenseType> ExpenseTypes { get; set; }
        public IEnumerable<ExpenseName> ExpenseNames { get; set; }
    }
}