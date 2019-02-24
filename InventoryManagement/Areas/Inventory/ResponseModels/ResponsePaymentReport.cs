using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponsePaymentReport
    {
        public int Serial { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public int VendorId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}