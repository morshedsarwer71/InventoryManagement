using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseExpenses
    {
        public int Serial { get; set; }
        public string ExpenseName { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Payment { get; set; }
        public string PaymentType { get; set; }
        public decimal Dues { get; set; }
        public int Rows { get; set; }
    }
}