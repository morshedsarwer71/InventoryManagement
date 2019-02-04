using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ViewModels
{
    public class ExpenseViewModels
    {
        public IEnumerable<ExpenseName> ExpenseNames { get; set; }
        public IEnumerable<ExpenseType> ExpenseTypes { get; set; }
        public IEnumerable<ResponseExpense> ResponseExpenses { get; set; }
    }
}