using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseExpense
    {
        public int Serial { get; set; }
        public int ExpenseId { get; set; }
        public int Id { get; set; }
        public string ExpenseHead { get; set; }
        public string ExpenseType { get; set; }
        public string Date { get; set; }
        public decimal Payment { get; set; }
    }
}