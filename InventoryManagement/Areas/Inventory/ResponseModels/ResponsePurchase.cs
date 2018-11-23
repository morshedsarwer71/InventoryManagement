using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponsePurchase
    {
        public int Serial { get; set; }
        public string PurchaseCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SupplierName { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Cash { get; set; }
        public decimal Discount { get; set; }
        public decimal Due { get; set; }
        public decimal GrandTotal { get; set; }
        public int Rows { get; set; }
    }
}