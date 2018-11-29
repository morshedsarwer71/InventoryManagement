using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public int ExpenseNameId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Payment { get; set; }
        public int Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public int ConcernId { get; set; }
    }
}