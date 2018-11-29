using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseSales
    {
        public int Serial { get; set; }
        public string SalesCode { get; set; }
        public DateTime SalesDate { get; set; }
        public string BuyerName { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Cash { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Due { get; set; }
        public string Saler { get; set; }
        public int Rows { get; set; }
    }
}