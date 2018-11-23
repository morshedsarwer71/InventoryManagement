using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseSalesInvoice
    {
        public int Serial { get; set; }
        public string SalesCode { get; set; }
        public DateTime Date { get; set; }
        public int MyProperty { get; set; }
    }
}