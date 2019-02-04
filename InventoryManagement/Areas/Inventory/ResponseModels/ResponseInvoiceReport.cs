using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseInvoiceReport
    {
        public int Serial { get; set; }
        public string Date { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Items { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Cash { get; set; }
        public decimal Discount { get; set; }
        public decimal Dues { get; set; }
        public int SalesType { get; set; }
        public string SalesTypeName { get; set; }
    }
}