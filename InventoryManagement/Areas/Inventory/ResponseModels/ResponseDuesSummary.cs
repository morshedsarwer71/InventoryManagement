using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseDuesSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalDues { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal GrandDues { get; set; }
    }
}