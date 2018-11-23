using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseDuePayment
    {
        public int Serial { get; set; }
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Name { get; set; }
        public int PayeeId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int Rows { get; set; }
    }
}