using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponsePurchaseReturn
    {
        public int Serial { get; set; }
        public string PurchaseReturnCode { get; set; }
        public DateTime PurchaseReturnDate { get; set; }
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Cash { get; set; }
        public decimal Discount { get; set; }
        public decimal Due { get; set; }
        public decimal GrandTotal { get; set; }
        public int Rows { get; set; }
    }
}